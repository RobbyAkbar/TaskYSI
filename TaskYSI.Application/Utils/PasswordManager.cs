namespace TaskYSI.Application.Utils;

public static class PasswordManager
{
    public static string HashPassword(string password)
    {
        // Generate a salt and hash the password with it
        var salt = BCrypt.Net.BCrypt.GenerateSalt(12);
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);
        return hashedPassword;
    }

    public static bool VerifyPassword(string password, string hashedPassword)
    {
        // Verify the password against the stored hash
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}