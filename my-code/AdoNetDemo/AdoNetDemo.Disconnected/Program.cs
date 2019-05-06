using AdoNetDemo.Connected;
using System;
using System.Data;
using System.Data.SqlClient;

namespace AdoNetDemo.Disconnected
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = SecretConfiguration.ConnectionString;

            Console.WriteLine("Enter a condition: ");
            var condition = Console.ReadLine();

            if (condition != "")
            {
                condition = " WHERE " + condition;
            }

            var commString = $"SELECT * FROM SalesLT.Customer{condition};";
            var dataSet = new DataSet();

            // minimize the time the connection is open.
            // read all results into a DataSet, and process them later.

            using (var connection = new SqlConnection(connectionString))
            {
                // step 1: open the connection.
                connection.Open();

                using (var command = new SqlCommand(commString, connection))
                using (var adapter = new SqlDataAdapter(command))
                {
                    // step 2: execute the query, filling the dataset.
                    adapter.Fill(dataSet);
                }

                // step 3: close the connection.
                connection.Close();
            }

            // step 4: process the results.

            // inside DataSet....
            // there are DataTables...
            // inside each DataTable are DataColumns and DataRows.
            // inside each DataRow is an object[] (non-generic)

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                DataColumn idColumn = dataSet.Tables[0].Columns["FirstName"];

                Console.WriteLine($"Genre #{row[idColumn]}: {row["FirstName"]}");
            }
        }
    }
}
