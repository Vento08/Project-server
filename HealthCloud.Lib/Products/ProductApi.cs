using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

using System.Net;


namespace HealthCloud.Lib.Products
{
    /// <summary>
    /// Wrapper over Products API of HealthCloud
    /// </summary>
    public sealed class ProductApi
    {

        public ProductApi()
        {
        }

        /// <summary>
        /// Gets List of all products
        /// </summary>
        /// <returns></returns>
        public IList<Product> GetAllProducts()
        {
            HttpWebRequest request = WebRequest.CreateHttp("http://healthapp-kurswork.herokuapp.com/api/products/list");
            request.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            IList<Product> result = null;

            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string json = reader.ReadToEnd();
                result = JsonConvert.DeserializeObject<Product[]>(json).ToList();
            }

            return result;
        }

        /// <summary>
        /// Selects only some products
        /// </summary>
        /// <param name="startIndex">How much products to skip</param>
        /// <param name="count">How much products to select</param>
        /// <returns></returns>
        public IList<Product> SelectProducts(int startIndex, int count)
        {
            HttpWebRequest request = WebRequest.CreateHttp(string.Format("http://healthapp-kurswork.herokuapp.com/api/products/select?start={0}&count={1}", startIndex, count));
            request.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            IList<Product> result = null;

            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string json = reader.ReadToEnd();
                result = JsonConvert.DeserializeObject<Product[]>(json).ToList();
            }

            return result;
        }

        /// <summary>
        /// Adds Product to Database
        /// </summary>
        /// <param name="product">Product that will be added</param>
        /// <param name="password">Password, required to do changes to database</param>
        /// <returns><see cref="true"/> if <paramref name="product"/> was added, otherwise <see cref="false"/></returns>
        public bool AddProduct(Product product, string password)
        {
            HttpWebRequest request = WebRequest.CreateHttp("http://healthapp-kurswork.herokuapp.com/api/products/add?password=" + password);
            request.Method = "POST";
            request.ContentType = "application/json";

            string json = JsonConvert.SerializeObject(product);

            using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
            {
                writer.Write(json);
                writer.Flush();
            }

            HttpWebResponse response = (HttpWebResponse) request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                Console.WriteLine(response.StatusDescription);
                return false;
            }
        }

        /// <summary>
        /// Removes Product from Database by Name
        /// </summary>
        /// <param name="productName">Name of <see cref="Product"/> that will be removed</param>
        /// <param name="password">Password, required to do changes to database</param>
        /// <returns><see cref="true"/> if <paramref name="product"/> was removed succesfully, otherwise <see cref="false"/></returns>
        public bool RemoveProduct(string productName, string password)
        {
            HttpWebRequest request = WebRequest.CreateHttp("http://healthapp-kurswork.herokuapp.com/api/products/add?password=" + password + "&name=" + productName);
            request.Method = "POST";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                Console.WriteLine(response.StatusDescription);
                return false;
            }
        }
    }
}
