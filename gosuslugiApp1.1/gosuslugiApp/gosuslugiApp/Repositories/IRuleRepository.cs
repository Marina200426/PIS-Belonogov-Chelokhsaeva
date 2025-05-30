using System.Collections.Generic;

public interface IRuleRepository
{
    List<Rule> FindByServiceId(int serviceId);
    void Create(Rule rule);
}
