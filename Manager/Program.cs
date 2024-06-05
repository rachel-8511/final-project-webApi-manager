
using System;

namespace Manager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataAccess dataAccess = new DataAccess();
            string connectionString = "  Data Source = SRV2\\PUPILS; Initial Catalog =  My_Shop_214189656; Integrated Security = True;";
            string type = "";
            string flag="y";
            while(flag!="n")
            {
                Console.WriteLine("insert type you need add");
                type = Console.ReadLine();
                if(type=="category")
                {
                    dataAccess.AddCategory(connectionString);
                }
                else
                {
                    dataAccess.AddProduct(connectionString);
                }
                Console.WriteLine("you want to continue");
                flag = Console.ReadLine();
            }
            dataAccess.GetProducts(connectionString);
            Console.WriteLine("--------------------------------------------------------------------");
            dataAccess.GetCategories(connectionString);
            Console.ReadLine();
        }
    }
}
 