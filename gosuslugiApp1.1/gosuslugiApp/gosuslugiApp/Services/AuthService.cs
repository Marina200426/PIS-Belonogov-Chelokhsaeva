public class AuthService
{
    private readonly IUserRepository _userRepository;

    public AuthService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public bool Login(string email, string password, out User user)
    {
        user = _userRepository.FindByEmail(email);
        if (user != null && VerifyPassword(password, user.Password))
        {
            Session.UserId = user.Id;
            Session.FullName = user.FullName;
            Session.Email = user.Email;
            Session.Role = user.Role.ToString();
            return true;
        }
        return false;
    }

    public bool Register(User user)
    {
        if (!ValidateUserData(user))
            return false;

        if (_userRepository.FindByEmail(user.Email) != null)
            return false;

        _userRepository.CreateUser(user);
        return true;
    }

    public bool RegisterAdmin(User user, UserRole role)
    {
        if (!ValidateRole(role) || !ValidateUserData(user))
            return false;

        user.Role = role;
        return Register(user);
    }

    private bool VerifyPassword(string inputPassword, string storedPassword)
    {
        return inputPassword == storedPassword;
    }

    private bool ValidateUserData(User user)
    {
        return !string.IsNullOrEmpty(user.Email) &&
               !string.IsNullOrEmpty(user.Password) &&
               !string.IsNullOrEmpty(user.FullName);
    }

    private bool ValidateRole(UserRole role)
    {
        return role == UserRole.администратор ||
               role == UserRole.госслужащий || role == UserRole.гражданин;
    }
}