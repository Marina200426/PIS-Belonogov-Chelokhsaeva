using System.Collections.Generic;
using System.Linq;
using System;

public class ApplicationService
{
    private readonly IApplicationRepository applicationRepository;
    private readonly IServiceRepository serviceRepository;
    private readonly IRuleRepository ruleRepository;
    private readonly ICharacteristicRepository characteristicRepository;
    

    public ApplicationService(
        IApplicationRepository applicationRepository,
        IServiceRepository serviceRepository,
        IRuleRepository ruleRepository,
        ICharacteristicRepository characteristicRepository)
    {
        this.applicationRepository = applicationRepository;
        this.serviceRepository = serviceRepository;
        this.ruleRepository = ruleRepository;
        this.characteristicRepository = characteristicRepository;
        
    }

    public DateTime? GetPlannedDateForLastApplication(int userId)
    {
        var apps = this.applicationRepository.FindByUserId(userId);

        return apps.OrderByDescending(a => a.DateSubmitted).FirstOrDefault()?.PlannedDate;
    }
    public bool SubmitApplication(int userId, int serviceId, out string failReason, out DateTime? plannedDate)
    {
        var rules = ruleRepository.FindByServiceId(serviceId);
        var characteristics = characteristicRepository.FindByUserId(userId);
        var groupedRules = rules.GroupBy(r => r.CharacteristicTypeId);

        List<string> errors = new List<string>();
        DateTime? baseDate = null;
        int maxDeadline = 0;

        foreach (var group in groupedRules)
        {
            var userChar = characteristics.FirstOrDefault(c => c.TypeId == group.Key);
            string ruleName = group.First().Name;

            if (userChar == null)
            {
                errors.Add("Отсутствует характеристика: " + ruleName);
                continue;
            }

            string op = group.First().Operator.ToUpper();
            bool match = false;

            if (op == "AND")
                match = group.All(r => string.IsNullOrEmpty(r.Value) || r.Value == userChar.Value);
            else if (op == "OR")
                match = group.Any(r => string.IsNullOrEmpty(r.Value) || r.Value == userChar.Value);

            if (!match)
            {
                errors.Add("Не соответствует характеристике: " + ruleName + " (значение: " + userChar.Value + ")");
            }

            foreach (var rule in group)
            {
                if (rule.Name.Contains("въезда") && DateTime.TryParse(userChar.Value, out var entryDate))
                    baseDate = entryDate;

                if ((rule.Name.Contains("патент") || rule.Name.Contains("6.5") || rule.Name.Contains("6.6")) &&
                    DateTime.TryParse(userChar.Value, out var patentDate))
                    baseDate = patentDate;

                maxDeadline = Math.Max(maxDeadline, rule.Deadline);
            }
        }

        if (errors.Count > 0)
        {
            failReason = string.Join("\n", errors);
            plannedDate = null;
            return false;
        }

        if (!baseDate.HasValue)
        {
            failReason = "Не удалось определить дату для определения сроков (укажи в профиле дату въезда или дату получения патента, если он есть)";
            plannedDate = null;
            return false;
        }

        plannedDate = baseDate.Value.AddDays(maxDeadline);
        
        if (plannedDate < DateTime.Today)
        {
            failReason = $"Вы не можете получить услугу, так как срок истек {plannedDate.Value.ToShortDateString()}";
            plannedDate = null;
            return false;
        }

        var app = new Applications
        {
            UserId = userId,
            ServiceId = serviceId,
            DateSubmitted = DateTime.Now,
            PlannedDate = plannedDate.Value,
            Status = ApplicationStatus.рассматривается,
            Result = ""
        };

        applicationRepository.Create(app);

        failReason = "";
        return true;
    }

    public List<Applications> GetApplicationsForResponsible(int responsibleId)
    {
        return applicationRepository.FindByResponsibleId(responsibleId);
    }



    public List<Applications> GetUserApplications(int userId)
    {
        return applicationRepository.FindByUserId(userId);
    }

    public bool CancelApplication(int applicationId)
    {
        var application = applicationRepository.GetApplication(applicationId);
        if (application != null && application.Status == ApplicationStatus.рассматривается)
        {
            application.Status = ApplicationStatus.отменено;
            applicationRepository.Update(application);
            return true;
        }
        return false;
    }

    public bool UpdateRequestStatusAndResult(int applicationId, ApplicationStatus status, string result, int currentUserId)
    {
        var application = applicationRepository.GetApplication(applicationId);
        if (application == null) return false;

        var service = serviceRepository.FindById(application.ServiceId);
        if (service == null || service.ResponsibleId != currentUserId)
        {
            return false;
        }

        application.Status = status;
        application.Result = result;
        applicationRepository.Update(application);
        return true;
    }

}