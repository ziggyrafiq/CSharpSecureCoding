using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace ZR.CodingExample.SecureCoding.Functions;

public static class User
{
    public static bool ValidateRegistrationForm(string username, string password, string email)
    {
        bool isValid = true;

        // Perform input validation for username
        if (string.IsNullOrWhiteSpace(username))
        {
            isValid = false;
        }

        // Perform input validation for password
        if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
        {
            isValid = false;
        }

        // Perform input validation for email
        if (string.IsNullOrWhiteSpace(email) || !IsValidEmail(email))
        {
            isValid = false;
        }

        return isValid;
    }

    public static bool IsValidEmail(string email)
    {
        // Regular expression pattern for email validation
        string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

        // Create a Regex object with the email pattern
        Regex regex = new Regex(emailPattern);

        // Perform the email validation
        bool isValid = regex.IsMatch(email);

        return isValid;
    }

 

    public static void PerformOperation()
    {
        try
        {
            // Perform the operation

            // Example: Division by zero
            int numerator = 10;
            int denominator = 0;
            int result = numerator / denominator;

            Console.WriteLine("Result: " + result);
        }
        catch (Exception ex)
        {
            // Handle the exception
            Console.WriteLine("An error occurred: " + ex.Message);
            // Log the error or take appropriate action
        }
    }


}
