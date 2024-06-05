using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Manager
{
    class DataAccess
    {
        internal int AddProduct(string connectionString)
        {
            string  product_name, price, category_id,description,image_url;

            Console.WriteLine("insert product name");
            product_name = Console.ReadLine();

            Console.WriteLine("insert price");
            price = Console.ReadLine();

            Console.WriteLine("insert category");
            category_id = Console.ReadLine();

            Console.WriteLine("insert description");
            description = Console.ReadLine();

            Console.WriteLine("insert image_url");
            image_url = Console.ReadLine();

            string query = "INSERT INTO PRODUCTS(PRODUCT_NAME, PRICE, CATEGORY_ID, DESCRIPTION,IMAGE_URL)" +
                           "VALUES(@PRODUCT_NAME, @PRICE, @CATEGORY_ID, @DESCRIPTION,@IMAGE_URL)";
            using(SqlConnection cn =new SqlConnection(connectionString))
            using(SqlCommand cmd=new SqlCommand(query,cn))
            {
                cmd.Parameters.Add("@PRODUCT_NAME", SqlDbType.NChar, 30).Value = product_name;
                cmd.Parameters.Add("@PRICE", SqlDbType.Float).Value = price;
                cmd.Parameters.Add("@CATEGORY_ID", SqlDbType.Int).Value = category_id;
                cmd.Parameters.Add("@DESCRIPTION", SqlDbType.NChar, 100).Value = description;
                cmd.Parameters.Add("@IMAGE_URL", SqlDbType.NChar, 50).Value = image_url;

                cn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                cn.Close();

                return rowsAffected;
            }
        }

        internal int AddCategory(string connectionString)
        {
            string category_name;

            Console.WriteLine("insert category name");
            category_name = Console.ReadLine();

          
            string query = "INSERT INTO CATEGORIES(CATEGORY_NAME)" +
                           "VALUES(@CATEGORY_NAME)";
            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@CATEGORY_NAME", SqlDbType.NChar, 30).Value = category_name;
                
                cn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                cn.Close();

                return rowsAffected;
            }
        }

        internal void GetProducts(string connectionString)
        {
            string queryString = "select * from PRODUCTS";
            using (SqlConnection connection=new SqlConnection(connectionString))
            {
                SqlCommand command= new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Console.WriteLine();
                    Console.WriteLine("\tId\tPRODUCT_NAME\t\t\tPRICE\t\tCATEGORY_ID\t\tIMAGE_URL\tDESCRIPTION");
                    Console.WriteLine();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}\t\t{3}\t\t\t{5}{4}",
                            reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
                    }
                    reader.Close();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
               
            }
        }

       internal void GetCategories(string connectionString)
        {
            string queryString = "select * from CATEGORIES";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Console.WriteLine();
                    Console.WriteLine("\tId\tCATEGORY_NAME");
                    Console.WriteLine();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}",
                            reader[0], reader[1]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
           
            }
        }
    }
}
