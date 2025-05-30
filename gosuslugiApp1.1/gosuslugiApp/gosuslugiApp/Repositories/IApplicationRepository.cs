using System.Collections.Generic;

public interface IApplicationRepository
{
    List<Applications> FindByUserId(int userId);
    List<Applications> FindByResponsibleId(int responsibleId);
    void Create(Applications application);
    void Update(Applications application);
    Applications GetApplication(int applicationId);
}

