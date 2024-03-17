using Microsoft.Data.SqlClient;
 
namespace ZR.CodingExamples.SecureCodeing.Functions
{
    public class SQL
    {
        public void ExecuteQuery(string username, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Users WHERE Username = @Username";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    // Execute the query
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    // Process the results
                    while (reader.Read())
                    {
                        // Process the user data
                    }

                    reader.Close();
                }
            }
        }

    }
}
