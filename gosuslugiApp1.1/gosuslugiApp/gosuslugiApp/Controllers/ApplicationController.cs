using System.Collections.Generic;
using System.Linq;
using System;

public class ApplicationController
{
    private readonly ApplicationService applicationService;

    public ApplicationController(ApplicationService applicationService)
    {
        this.applicationService = applicationService;
    }
    public DateTime? GetPlannedDateForLastApplication(int userId)
    {
        var apps = applicationService.GetUserApplications(userId);


        return apps.OrderByDescending(a => a.DateSubmitted).FirstOrDefault()?.PlannedDate;
    }

    public bool SubmitApplication(int userId, int serviceId, out string failReason, out DateTime? plannedDate)
    {
        return applicationService.SubmitApplication(userId, serviceId, out failReason, out plannedDate);
    }


    public List<Applications> GetUserApplications(int userId)
    {
        return applicationService.GetUserApplications(userId);
    }

    public List<Applications> GetApplicationsForResponsible(int responsibleId)
    {
        return applicationService.GetApplicationsForResponsible(responsibleId);
    }

    public bool CancelApplication(int applicationId)
    {
        return applicationService.CancelApplication(applicationId);
    }

    public bool UpdateRequestStatusAndResult(int appId, ApplicationStatus status, string result, int userId)
    {
        return applicationService.UpdateRequestStatusAndResult(appId, status, result, userId);
    }
}