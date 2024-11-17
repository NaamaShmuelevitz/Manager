using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Manager
{
    internal class Categoty
    {
        int rowsAdd = 0;
        public int InsertCategoty(string connectionString)
        {
            string name;
            Console.WriteLine("Insert category name:");
            name = Console.ReadLine();

            string query = "INSERT INTO Category(name)" + "VALUES (@Name)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = name;
                connection.Open();
                rowsAdd += command.ExecuteNonQuery();
                connection.Close();

                Console.WriteLine("Would tou like to insert new category? y/n");
                string res = Console.ReadLine();
                if (res == "y")
                {
                    InsertCategoty(connectionString);
                }
                return rowsAdd;
            }
        }

        public void ReadCategoty(string connectionString)
        {
            string query = "select * from Category";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}", reader[0], reader[1]);
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }
        }
    }
}
