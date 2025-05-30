using System.Collections.Generic;
using System;

public class ServiceService
{
    private readonly IRuleRepository ruleRepository;
    private readonly IServiceRepository serviceRepository;
    private readonly ICharacteristicTypeRepository characteristicTypeRepository;

    public ServiceService(IRuleRepository ruleRepository, IServiceRepository serviceRepository, ICharacteristicTypeRepository characteristicTypeRepository)
    {
        this.ruleRepository = ruleRepository;
        this.serviceRepository = serviceRepository;
        this.characteristicTypeRepository = characteristicTypeRepository;
    }

    public Service GetServiceById(int serviceId)
    {
        return serviceRepository.FindById(serviceId);
    }
    public List<Service> GetActiveServices()
    {
        return serviceRepository.GetActiveServices();
    }

    public List<Rule> GetRulesByServiceId(int serviceId)
    {
        return ruleRepository.FindByServiceId(serviceId);
    }


    public List<CharacteristicType> GetCharacteristicTypes()
    {
        return characteristicTypeRepository.GetAll();
    }

    public void CreateCharacteristicType(CharacteristicType characteristicType)
    {
        characteristicTypeRepository.Create(characteristicType);
    }
    public void AddRule(Rule rule)
    {
        ruleRepository.Create(rule);
    }
    public List<Rule> GetRulesForService(int serviceId)
    {
        return ruleRepository.FindByServiceId(serviceId);
    }

    public void AddService(Service service)
    {
        serviceRepository.Create(service);
        
    }

    public void ReplaceService(int oldServiceId, Service newService)
    {
        DeleteService(oldServiceId);
        AddService(newService);
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