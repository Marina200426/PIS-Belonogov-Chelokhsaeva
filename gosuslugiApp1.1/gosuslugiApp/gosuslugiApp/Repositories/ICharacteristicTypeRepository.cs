using System.Collections.Generic;

public interface ICharacteristicTypeRepository
{
    List<CharacteristicType> GetAll();
    void Create(CharacteristicType type);
    void Delete(int id);
}