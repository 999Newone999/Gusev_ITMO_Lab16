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
    class WriteProgram
    {
        static void Main(string[] args)
        {
            const int numberOfProducts = 5;
            int codeOfProduct;
            string nameOfProduct;
            double priceOfProduct;
            Product[] productArray = new Product[numberOfProducts];

            string jsonString;

            string fileName = "Products.json";
            
            Console.WriteLine("Это программа по вводу информации о товарах");
            for (int i = 0; i < numberOfProducts; i++)
            {
                //Product productExemplar = new Product();
                productArray[i] = new Product();
                Console.WriteLine("Введите информацию о товаре №{0}", i+1);
                InputProductPropertyFromConsole(i+1, "Код", out codeOfProduct);
                productArray[i].ProductCode = codeOfProduct;
                InputProductPropertyFromConsole(i + 1, "Название", out nameOfProduct);
                productArray[i].ProductName = nameOfProduct;
                InputProductPropertyFromConsole(i + 1, "Цена", out priceOfProduct);
                productArray[i].ProductPrice = priceOfProduct;
            }

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            jsonString = JsonSerializer.Serialize(productArray, options);
            Console.WriteLine(jsonString);

            if (!File.Exists(fileName))
            {
                File.Create(fileName);
            }

            using (StreamWriter sw = new StreamWriter(fileName, false))
            {
                sw.WriteLine(jsonString);
            }

            Console.ReadKey();
        }

        static void InputProductPropertyFromConsole(int numberOfProduct, string nameOfProperty, out int answer)
        {
            bool inputOk;
            answer = 0;
            do 
            {
                try
                {
                    inputOk = true;
                    Console.WriteLine(nameOfProperty + " товара №{0}", numberOfProduct);
                    answer = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    inputOk = false;
                }
            } while (!inputOk);
        }

        static void InputProductPropertyFromConsole(int numberOfProduct, string nameOfProperty, out double answer)
        {
            bool inputOk;
            answer = 0;
            do
            {
                try
                {
                    inputOk = true;
                    Console.WriteLine(nameOfProperty + " товара №{0}", numberOfProduct);
                    answer = Convert.ToDouble(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    inputOk = false;
                }
            } while (!inputOk);
        }

        static void InputProductPropertyFromConsole(int numberOfProduct, string nameOfProperty, out string answer)
        {
            bool inputOk;
            answer = "";
            do
            {
                try
                {
                    inputOk = true;
                    Console.WriteLine(nameOfProperty + " товара №{0}", numberOfProduct);
                    answer = Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    inputOk = false;
                }
            } while (!inputOk);
        }
    }


}