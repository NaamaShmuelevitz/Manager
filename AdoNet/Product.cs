using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace Manager
{
    internal class Product
    {
        int rowsAdd=0;
        public int InsertProduct(string connectionString)
        {
            Console.WriteLine("Would tou like to insert new product? y/n");
            string res = Console.ReadLine();
            if (res == "n") 
            {
                return -1;
            }
            string categoryId,name,description,price,image;
            Console.WriteLine("Insert product categoryId:");
            categoryId = Console.ReadLine();
            Console.WriteLine("Insert product name:");
            name = Console.ReadLine();
            Console.WriteLine("Insert product description:");
            description = Console.ReadLine();
            Console.WriteLine("Insert product price:");
            price = Console.ReadLine();
            Console.WriteLine("Insert product image:");
            image = Console.ReadLine();

            string query = "INSERT INTO Product(Category_Id,Name,Description,Price,Image)" + "VALUES (@Category_Id,@Name,@Description,@Price,@Image)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@Category_Id", SqlDbType.VarChar, 50).Value = categoryId;
                command.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = name;
                command.Parameters.Add("@Description", SqlDbType.VarChar, 50).Value = description;
                command.Parameters.Add("@Price", SqlDbType.Float).Value = price;
                command.Parameters.Add("@Image", SqlDbType.VarChar, 50).Value = image;

                connection.Open();
                rowsAdd += command.ExecuteNonQuery();
                connection.Close();

                Console.WriteLine("Would tou like to insert new product? y/n");
                string result = Console.ReadLine();
                if (result == "y")
                {
                    InsertProduct(connectionString);
                }
                return rowsAdd;
            }
        }

        public void ReadProduct(string connectionString)
        {
            string query = "select * from Product";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}", reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
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
