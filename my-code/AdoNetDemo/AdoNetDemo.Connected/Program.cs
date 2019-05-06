using System;
using System.Data.SqlClient;

namespace AdoNetDemo.Connected
{
    class Program
    {
        static void Main(string[] args)
        {
            // first we need some way to connect/authenticate to the database.
            // we need the connection string.

            // connection strings are considered secret credentials
            // so we make a .gitignore for this solution that
            // ignores SecretConfiguration.cs.

            // make file SecretConfiguration.cs looking like this:

            //namespace AdoNetDemo.Connected
            //{
            //    internal static class SecretConfiguration
            //    {
            //        internal static readonly string ConnectionString = "(insert connection string)";
            //    }
            //}

            // copy the connection string from Azure.

            var connectionString = SecretConfiguration.ConnectionString;

            // to get SqlConnection from System.Data namespace, we need
            // NuGet package System.Data.SqlClient.
            // in bash, we can say: dotnet add package System.Data.SqlClient


            using (var connection = new SqlConnection(connectionString))
            {
                // step 1: open the connection.
                connection.Open();

                Console.WriteLine("Enter a condition: ");
                var condition = Console.ReadLine();

                if (condition != "")
                {
                    condition = " WHERE " + condition;
                }

                // this allows serious security vulnerability called
                // "SQL injection", where a user can trick your application
                // into doing harmful things to the database
                
                // solutions: careful validation of all user input,
                // or, use some framework that manages the SQL command creation
                // (like Entity Framework).

                var commString = $"SELECT * FROM SalesLT.Customer{condition};";
                // step 2: execute your query.
                using (var command = new SqlCommand(commString, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // for INSERT, UPDATE, anything except SELECT...
                    // instead of .ExecuteReader(), you do .ExecuteNonQuery()

                    // step 3: process the results.
                    if (reader.HasRows)
                    {
                        // the DataReader is a sort of cursor that advances
                        // through the returned rows.
                        while (reader.Read())
                        {
                            // process one row.
                            var id = (int)reader["customerid"];
                            var title = (string)reader["firstname"];

                            Console.WriteLine($"{id}: {title}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows returned.");
                    }
                }

                // 4. close the connection.
                connection.Close();
            }
        }
    }
}
