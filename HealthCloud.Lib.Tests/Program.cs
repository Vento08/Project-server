using System;
using HealthCloud.Lib.Products;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Http;

namespace HealthCloud.Tests
{
    public class Program
    {
        public static async Task Main(string[] args)
        {

            var api = new ProductApi();

            var full = api.GetAllProducts();

            Console.WriteLine("Full Count: " + full.Count);

            foreach(var prod in full)
            {
                Console.WriteLine(prod.ToString());
            }

            var part = api.SelectProducts(0, 5);

            Console.WriteLine("");
            Console.WriteLine("Part Count: " + part.Count);

            foreach (var prod in part)
            {
                Console.WriteLine(prod.ToString());
            }

            Console.ReadLine();
        }
    }
}
