using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Data;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace ShopifyTest
{
    class Program
    {
        private static readonly string apiKey = System.Configuration.ConfigurationManager.AppSettings["apiKey"].ToString();
        private static readonly string password = System.Configuration.ConfigurationManager.AppSettings["password"].ToString();
        private static readonly string apiHostString = System.Configuration.ConfigurationManager.AppSettings["apiHostString"].ToString();
        private static readonly string apiVersion = System.Configuration.ConfigurationManager.AppSettings["apiVersion"].ToString();

        static void Main()
        {
            // Required for API call due to SSL error
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var apiCountCall = CallApi("products/count", "");
            var jsonCountResults = apiCountCall.Result;
            string deserializedCount = GetDeserializedItem(jsonCountResults, "count");
            Console.WriteLine("Product Count: " + deserializedCount);

            var apiProductListCall = CallApi("products", "?fields=id,title");
            var jsonProductResults = apiProductListCall.Result;

            List<Product> productList = GetDeserializedList(jsonProductResults, "products");
            PrintProductList(productList);

            // For viewing console logs
            Console.ReadLine();
        }

        // Make call to API and return json string
        public static async Task<string> CallApi(string resource, string filters)
        {
            // Request URL Format: https://{API_KEY}:{PASSWORD}@loversonline.myshopify.com/admin/api/{VERSION}/{RESOURCE}.json{FILTERS}
            RestClient client = new RestClient(apiHostString);
            client.Authenticator = new HttpBasicAuthenticator($"{apiKey}", $"{password}");
            RestRequest request = new RestRequest($"{apiVersion}/{resource}.json{filters}");

            var response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }

        // Deserialize json string and target a single endpoint to return as a string
        private static string GetDeserializedItem (string jsonResults, string jsonEndpoint)
        {
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(jsonResults);
            string itemString = jsonResponse[jsonEndpoint].ToString();
            return itemString;
        }

        private static List<Product> GetDeserializedList (string jsonResults, string jsonEndpoint)
        {
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(jsonResults);
            List<Product> list = JsonConvert.DeserializeObject<List<Product>>(jsonResponse[jsonEndpoint].ToString());
            
            return list;
        }

        private static void PrintProductList (List<Product> list)
        {
            foreach (Product item in list)
            {
                Console.WriteLine("ID: " + item.id.ToString() + ", Title: " + item.title);
            }
        }
    }
}
