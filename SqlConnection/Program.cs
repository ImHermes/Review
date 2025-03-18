// See https://aka.ms/new-console-template for more information
using Microsoft.Data.SqlClient;
Console.WriteLine("Hello, World!");

string connectionStringValue = "Server=tcp:org32c700d6.crm.dynamics.com;Authentication=Active Directory Default; Database=org32c700d6";

try
{
    using (SqlConnection connection = new SqlConnection(connectionStringValue))
    {
        Console.WriteLine("\nQuery data example:"); 
        Console.WriteLine("=========================================\n");

        String sql = "SELECT TOP 5 FROM dbo.ccount";

        using (SqlCommand command = new SqlCommand(sql, connection))
        {
            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                }
            }
        }

    }

}
catch (SqlException e)
{

    Console.WriteLine(e.ToString());
}

