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
        private static readonly HttpClient client = new HttpClient();
        public static async Task Main(string[] args)
        {
            await ProcessRepositories();
        }
        private static async Task ProcessRepositories()
        {
            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");


            var stringTask = await client.GetStringAsync("https://tester.consimple.pro");

            var prods = JsonConvert.DeserializeObject<Dictionary<string, List<Products>>>(stringTask).Where(x => x.Key == "Products").SelectMany(x=>x.Value).ToList();
            var cats = JsonConvert.DeserializeObject<Dictionary<string, List<Categories>>>(stringTask).Where(x => x.Key == "Categories").SelectMany(x=>x.Value).ToList();

            foreach (var item in prods)
            {
                Console.WriteLine($"{item.name} {(from c in cats where c.id == item.categoryId select c.name).First()}");
            }

         
        }
    }
}
