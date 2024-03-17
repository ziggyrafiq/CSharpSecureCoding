using System.Security.Cryptography;
using System.Text;

namespace ZR.CodingExamples.SecureCodeing.Functions;
public static class Passwords
{
    public static string HashPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            // Convert the password to bytes
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Compute the hash
            byte[] hashBytes = sha256.ComputeHash(passwordBytes);

            // Convert the hash to a hexadecimal string
            string hashedPassword = BitConverter.ToString(hashBytes).Replace("-", "");

            return hashedPassword;
        }
    }

}
