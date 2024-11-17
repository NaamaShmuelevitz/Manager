using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string connectionString = "Data Source=SRV2\\PUPILS;Initial Catalog=Shop;Integrated Security=True;Trust Server Certificate=True";
            string connectionString = "data source=srv2\\pupils;initial catalog=Shop;Integrated Security=SSPI;Persist Security Info=False;TrustServerCertificate=true";
            Categoty categoty = new Categoty();
            //Console.WriteLine(categoty.InsertCategoty(connectionString)+" row insert sucssefully");
            //categoty.ReadCategoty(connectionString);

            Product product = new Product();
            //Console.WriteLine(product.InsertProduct(connectionString) + " row insert sucssefully");
            product.ReadProduct(connectionString);
        }
    }
}
