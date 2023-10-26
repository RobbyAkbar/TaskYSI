namespace TaskYSI.Application.Utils;

public class PasswordManager
{
    public static string HashPassword(string password)
    {
        // Generate a salt and hash the password with it
        string salt = BCrypt.Net.BCrypt.GenerateSalt(12);
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);
        return hashedPassword;
    }

    public static bool VerifyPassword(string password, string hashedPassword)
    {
        // Verify the password against the stored hash
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}