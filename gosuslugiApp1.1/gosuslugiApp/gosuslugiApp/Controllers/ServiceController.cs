using System.Collections.Generic;

public class ServiceController
{
    
    private readonly ServiceService serviceService;
    private readonly UserService userService;

    public ServiceController(
        ServiceService serviceService,
        UserService userService)
    {
        this.serviceService = serviceService;
       
        this.userService = userService;
    }

    public List<User> GetGovernmentEmployees()
    {
        return userService.GetGovernmentEmployees();
    }

    public List<CharacteristicType> GetCharacteristicTypes()
    {
        return serviceService.GetCharacteristicTypes();
    }

    public List<Rule> GetRulesByServiceId(int serviceId)
    {
        return serviceService.GetRulesByServiceId(serviceId);
    }

    public void AddRule(Rule rule)
    {
        serviceService.AddRule(rule);
    }

    public void CreateCharacteristicType(CharacteristicType characteristicType)
    {
        serviceService.CreateCharacteristicType(characteristicType);
    }

    public List<Service> GetActiveServices()
    {
        return serviceService.GetActiveServices();
    }

    public void AddService(Service service, List<Rule> rules)
    {
        serviceService.AddService(service);
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
        return serviceService.GetServiceById(serviceId);
    }
}

