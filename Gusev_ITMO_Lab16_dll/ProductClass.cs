using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Unicode;
using System.Text.Encodings.Web;
using System.Text.Json.Serialization;

namespace Gusev_ITMO_Lab16_dll
{
    public class Product
    {
        [JsonPropertyName("Код товара")]
        public int ProductCode { get; set; }
        [JsonPropertyName("Название товара")]
        public string ProductName { get; set; }
        [JsonPropertyName("Цена товара")]
        public double ProductPrice { get; set; }
    }
}