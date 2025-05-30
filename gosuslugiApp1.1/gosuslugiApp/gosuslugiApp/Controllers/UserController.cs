using System.Collections.Generic;

public class UserController
{
    private readonly UserService userService;
    

    public UserController(UserService userService)
    {
        this.userService = userService;
    }

    public User GetUserProfile(int userId)
    {
        return userService.FindById(userId); 
    }

    public List<CharacteristicType> GetCharacteristicTypes()
    {
        return userService.GetCharacteristicTypes();
    }

    public List<Characteristic> GetUserCharacteristics(int userId)
    {
        return userService.GetCharacteristics(userId);
    }

    public void AddOrUpdateCharacteristic(int userId, int typeId, string value)
    {
        var characteristic = new Characteristic
        {
            UserId = userId,
            TypeId = typeId,
            Value = value
        };
        userService.UpdateCharacteristic(characteristic);
    }

    public void UpdateProfile(int userId, string fullName, string email)
    {
        userService.UpdateProfile(userId, fullName, email);
    }
}