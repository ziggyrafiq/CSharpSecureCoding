 

namespace ZR.CodingExample.SecureCoding.Services;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }=string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
public interface IEncryptionService
{
    string Encrypt(string data);
    string Decrypt(string encryptedData);
}

public interface IUserRepository
{
    void CreateUser(string username, string password, string email);
    User GetUserById(int userId);
     
}


public class UserRegistrationService
{
    private readonly IUserRepository userRepository;
    private readonly IEncryptionService encryptionService;

    public UserRegistrationService(IUserRepository userRepository, IEncryptionService encryptionService)
    {
        this.userRepository = userRepository;
        this.encryptionService = encryptionService;
    }

    public void RegisterUser(string username, string password, string email)
    {
        // Perform input validation and sanitization

        // Encrypt the password before storing it
        string encryptedPassword = encryptionService.Encrypt(password);

        // Store the user information securely
        userRepository.CreateUser(username, encryptedPassword, email);

        // Send a confirmation email to the user
        EmailService.SendConfirmationEmail(email);
    }
}