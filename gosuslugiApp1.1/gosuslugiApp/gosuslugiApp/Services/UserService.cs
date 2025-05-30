using System.Collections.Generic;
using System.Linq;

public class UserService
{
    private readonly IUserRepository userRepository;
    private readonly ICharacteristicRepository characteristicRepository;
    private readonly ICharacteristicTypeRepository characteristicTypeRepository;

    public UserService(IUserRepository userRepository, ICharacteristicRepository characteristicRepository, ICharacteristicTypeRepository characteristicTypeRepository)
    {
        this.userRepository = userRepository;
        this.characteristicRepository = characteristicRepository;
        this.characteristicTypeRepository = characteristicTypeRepository;   
    }

    public List<CharacteristicType> GetCharacteristicTypes()
    {
        return characteristicTypeRepository.GetAll();
    }
    public List<User> GetGovernmentEmployees()
    {
        return userRepository.GetAll().Where(u => u.Role == UserRole.госслужащий).ToList();
    }
    public User FindById(int ID)
    {
        return userRepository.FindById(ID);
    }
    public void UpdateProfile(int userId, string fullName, string email)
    {
        var user = userRepository.FindById(userId);
        if (user != null)
        {
            user.FullName = fullName;
            user.Email = email;
            userRepository.UpdateUser(user);
        }
    }
    public void UpdateCharacteristic(Characteristic characteristic)
    {
        var existingChar = characteristicRepository.FindByUserId(characteristic.UserId)
            .FirstOrDefault(c => c.TypeId == characteristic.TypeId);

        if (existingChar != null)
        {
            existingChar.Value = characteristic.Value;
            characteristicRepository.Update(existingChar);
        }
        else
        {
            characteristicRepository.Create(characteristic);
        }
    }
    public List<Characteristic> GetCharacteristics(int userId)
    {
        return characteristicRepository.FindByUserId(userId);
    }


    public void AddCharacteristic(Characteristic characteristic)
    {
        characteristicRepository.Create(characteristic);
    }
}