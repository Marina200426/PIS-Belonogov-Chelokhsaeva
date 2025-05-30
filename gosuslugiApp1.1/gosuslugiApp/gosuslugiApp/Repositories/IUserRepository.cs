using System.Collections.Generic;

public interface IUserRepository
{
    User FindById(int id);
    User FindByEmail(string email);
    List<User> GetAll();
    void CreateUser(User user);
    void UpdateUser(User user);
}