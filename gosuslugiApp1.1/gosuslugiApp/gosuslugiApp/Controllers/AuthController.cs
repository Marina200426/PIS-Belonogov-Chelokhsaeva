public class AuthController
{
    private readonly AuthService authService;

    public AuthController(AuthService authService)
    {
        this.authService = authService;
    }

    public bool Login(string email, string password, out User user)
    {
        return authService.Login(email, password, out user);
    }

    public bool Register(User user)
    {
        return authService.Register(user);
    }

    public bool RegisterAdmin(User user, UserRole role)
    {
        return authService.RegisterAdmin(user, role);
    }
}