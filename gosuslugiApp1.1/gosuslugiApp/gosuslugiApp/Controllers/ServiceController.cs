using System.Collections.Generic;

public class ServiceController
{
    private readonly IServiceRepository serviceRepository;
    private readonly ServiceService serviceService;
    private readonly ICharacteristicTypeRepository characteristicTypeRepository;
    private readonly IRuleRepository ruleRepository;
    private readonly UserService userService;

    public ServiceController(
        IServiceRepository serviceRepository,
        ServiceService serviceService,
        ICharacteristicTypeRepository characteristicTypeRepository,
        IRuleRepository ruleRepository,
        UserService userService)
    {
        this.serviceRepository = serviceRepository;
        this.serviceService = serviceService;
        this.characteristicTypeRepository = characteristicTypeRepository;
        this.ruleRepository = ruleRepository;
        this.userService = userService;
    }

    public List<User> GetGovernmentEmployees()
    {
        return userService.GetGovernmentEmployees();
    }

    public List<CharacteristicType> GetCharacteristicTypes()
    {
        return characteristicTypeRepository.GetAll();
    }

    public List<Rule> GetRulesByServiceId(int serviceId)
    {
        return ruleRepository.FindByServiceId(serviceId);
    }

    public void AddRule(Rule rule)
    {
        ruleRepository.Create(rule);
    }

    public void CreateCharacteristicType(CharacteristicType characteristicType)
    {
        characteristicTypeRepository.Create(characteristicType);
    }

    public List<Service> GetActiveServices()
    {
        return serviceRepository.GetActiveServices();
    }

    public void AddService(Service service, List<Rule> rules)
    {
        serviceService.AddService(service, rules);
    }

    public void ReplaceService(int serviceId, Service updatedService)
    {
        serviceService.ReplaceService(serviceId, updatedService);
    }

    public void DeleteService(int serviceId)
    {
        serviceService.DeleteService(serviceId);
    }

    public Service GetServiceById(int serviceId)
    {
        return serviceRepository.FindById(serviceId);
    }
}

