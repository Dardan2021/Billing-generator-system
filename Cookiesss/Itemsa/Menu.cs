using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Diagnostics;
using System.Xml.Linq;

namespace Cookiesss.Itemsa
{
    public class Menu
    {
        public List<Items> BuildMenu()
        {
            var weatherForecast1 = new Items
            {
                Id = "1",
                Definition = "Wheat",
                Price = 10
            };
            var weatherForecast2 = new Items
            {
                Id = "2",
                Definition = "Milk",
                Price = 20
            };
            var weatherForecast3 = new Items
            {
                Id = "3",
                Definition = "Flour",
                Price = 25
            };
            var weatherForecast4 = new Items
            {
                Id = "4",
                Definition = "Sugar",
                Price = 23
            };
            var weatherForecast5 = new Items
            {
                Id = "5",
                Definition = "Onion",
                Price = 2330
            };
            List<Items> list = new List<Items>();
            list.Add(weatherForecast1);
            list.Add(weatherForecast2);
            list.Add(weatherForecast3);
            list.Add(weatherForecast4);
            list.Add(weatherForecast5);


            return list;

        }
        public void ShowMenu()
        {
            Menu m1 = new Menu();
            var list = m1.BuildMenu();
            Console.WriteLine("containerjj" + list);
            string fileName = "WeatherForecast.json";
            string jsonString = JsonSerializer.Serialize(list);
            File.WriteAllText(fileName, jsonString);
            foreach (var l in list)
            {
                Console.WriteLine(l.Id + ". " + l.Definition + " - $" + l.Price);
            }
        }

    }
}