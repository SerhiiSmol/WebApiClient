using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Collections.Generic;
using WebApiClient.Repositories;
using Newtonsoft.Json;
using System.Linq;

namespace WebApiClient
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Client client = new Client("https://tester.consimple.pro");
            (List<Products> products,List<Categories> categories) = await client.GetProductsAndCategories();
            client.PrintProductsAndCategories(products, categories);
        }
        
    }
}
