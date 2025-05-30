using System.Collections.Generic;
using System;

public class ServiceService
{
    private readonly IRuleRepository ruleRepository;
    private readonly IServiceRepository serviceRepository;

    public ServiceService(IRuleRepository ruleRepository, IServiceRepository serviceRepository)
    {
        this.ruleRepository = ruleRepository;
        this.serviceRepository = serviceRepository;
    }

    public List<Rule> GetRulesForService(int serviceId)
    {
        return ruleRepository.FindByServiceId(serviceId);
    }

    public void AddService(Service service, List<Rule> rules)
    {
        serviceRepository.Create(service);
        foreach (var rule in rules)
        {
            rule.ServiceId = service.Id;
            ruleRepository.Create(rule);
        }
    }

    public void ReplaceService(int oldServiceId, Service newService)
    {
        DeleteService(oldServiceId);
        AddService(newService, new List<Rule>());
    }

    public void DeleteService(int serviceId)
    {
        var service = serviceRepository.FindById(serviceId);
        if (service != null)
        {
            service.DateDeactivated = DateTime.Now;
            serviceRepository.Update(service);
        }
    }
}