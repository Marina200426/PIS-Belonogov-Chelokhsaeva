using System.Collections.Generic;

public interface IServiceRepository
{
    List<Service> GetActiveServices();
    Service FindById(int id);
    void Create(Service service);
    void Update(Service service);

}
