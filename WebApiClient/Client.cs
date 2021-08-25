using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApiClient.Repositories;

namespace WebApiClient
{
    public class Client
    {
        private static HttpClient _client;
        private static string _url;

        public Client(string url)
        {
            _url = url;
            _client = new HttpClient();
        }

        public async Task<(List<Products> prods, List<Categories> cats)> GetProductsAndCategories()
        {
            _client.DefaultRequestHeaders.Accept.Clear();

            var stringTask = await _client.GetStringAsync(_url);

            var prods = JsonConvert.DeserializeObject<Dictionary<string, List<Products>>>(stringTask).Where(x => x.Key == "Products").SelectMany(x => x.Value).ToList();
            var cats = JsonConvert.DeserializeObject<Dictionary<string, List<Categories>>>(stringTask).Where(x => x.Key == "Categories").SelectMany(x => x.Value).ToList();
            return (prods, cats);
        }
        public void PrintProductsAndCategories(List<Products> products,List<Categories> categories)
        {
            foreach (var item in products)
            {
                Console.WriteLine($"{item.name} {(from c in categories where c.id == item.categoryId select c.name).First()}");
            }
        }
    }
}
