using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApiClient.Repositories
{
    public class Products
    {
        [JsonPropertyName("Name")]
        public string name { get; set; }
        [JsonPropertyName("Id")]
        public int id { get; set; }
        [JsonPropertyName("CategoryId")]
        public int categoryId { get; set; }
    }
}
