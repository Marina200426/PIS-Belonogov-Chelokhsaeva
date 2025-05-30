using System.Collections.Generic;

public interface ICharacteristicRepository
{
    List<Characteristic> FindByUserId(int userId);
    void Create(Characteristic characteristic);
    void Delete(int id);
    void Update(Characteristic characteristic);
}