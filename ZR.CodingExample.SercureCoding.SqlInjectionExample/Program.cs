using System;
using System.Data.SqlClient;

namespace ZR.CodingExample.SercureCoding;
class SqlInjectionExample
{
    public static void Main()
    {
        string username = "admin'; DROP TABLE Users; --";
        string password = "password";

        // Validate and sanitize input
        if (!IsValidInput(username) || !IsValidInput(password))
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        // Perform parameterized query
        using (var connection = new SqlConnection("connectionString"))
        {
            connection.Open();

            string sql = "SELECT * FROM Users WHERE username = @username AND password = @password";
            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                // Execute the query
                // ...
            }
        }

        Console.WriteLine("Query executed successfully.");
    }

    private static bool IsValidInput(string input)
    {
        // Implement validation logic here (e.g., check for special characters)
        // Return true if the input is considered valid, false otherwise
        return true;
    }
}