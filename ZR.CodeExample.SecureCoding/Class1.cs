using System;
using System.Security.Cryptography;

namespace ZR.CodeExample.SecureCoding
{
    class PasswordHashingExample
    {
        public static void Main()
        {
            string password = "myPassword123";

            // Generate a random salt
            byte[] salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            // Create the password hash
            byte[] hashedPassword = HashPassword(password, salt);

            // Store the hashed password and salt securely
            // ...

            Console.WriteLine("Password hashed successfully.");
        }

        private static byte[] HashPassword(string password, byte[] salt)
        {
            // Use a secure hashing algorithm like bcrypt or Argon2
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256))
            {
                return pbkdf2.GetBytes(32); // 32 bytes for a 256-bit hash
            }
        }
    }
}