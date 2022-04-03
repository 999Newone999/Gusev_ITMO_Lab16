using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Unicode;
using System.Text.Encodings.Web;
using System.Text.Json.Serialization;
using System.IO;
using Gusev_ITMO_Lab16_dll;

namespace Gusev_ITMO_Lesson16
{
    class ReadProgram
    {
        static void Main(string[] args)
        {
            const int numberOfProducts = 5;
            double MaxPriceOfProduct;
            int countOfProductWithMaxPrice=0;
            int numberOfProductWithMaxPrice=0;
            int count;
            Product[] productArray = new Product[numberOfProducts];
            for (int i = 0; i < numberOfProducts; i++)
            {
                productArray[i] = new Product();
            }

            string jsonString;
            string bufferString;

            string fileName = "Products.json";

            Console.WriteLine("Это программа по выводу информации о товарах");
            if (!File.Exists(fileName))
            {
                Console.WriteLine("Файла \"Products.json\" не существует или он находится не в корневом каталоге программы.");
            }
            else
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    jsonString = sr.ReadToEnd();
                    productArray = JsonSerializer.Deserialize<Product[]>(jsonString);
                }

                MaxPriceOfProduct= productArray[0].ProductPrice;
                for (int i = 1; i < numberOfProducts; i++)
                {
                    if (MaxPriceOfProduct < productArray[i].ProductPrice)
                    {
                        MaxPriceOfProduct = productArray[i].ProductPrice;
                        numberOfProductWithMaxPrice = i;
                    }
                }

                for (int i = 0; i < numberOfProducts; i++)
                {
                    if (MaxPriceOfProduct == productArray[i].ProductPrice)
                        countOfProductWithMaxPrice++;
                }
                if (countOfProductWithMaxPrice <= 1)
                {
                    Console.Write("Товар с максимальной ценой: ");
                    Console.Write(productArray[numberOfProductWithMaxPrice].ProductName);
                    Console.WriteLine(".");
                }
                else 
                {
                    Console.WriteLine("Товары с максимальной ценой: ");
                    count = 0;
                    for (int i = 1; i < numberOfProducts; i++)
                    {
                        if(MaxPriceOfProduct == productArray[i].ProductPrice)
                        {
                            Console.Write(productArray[i].ProductName);
                            count++;
                        }
                        if (count< countOfProductWithMaxPrice)
                            Console.Write(", ");
                    }
                }
                Console.ReadKey();
            }
        }
    }
}