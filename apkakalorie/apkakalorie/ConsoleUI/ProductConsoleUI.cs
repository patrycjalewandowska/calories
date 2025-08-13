using apkakalorie.Models;
using apkakalorie.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apkakalorie.ConsoleUI
{
    public class ProductConsoleUI
    {
        public static void CreateProductFromUserInput(ServiceProduct productService)
        {
            Product p = new Product();

            Console.WriteLine("Podaj nazwę produktu:");
            p.Name = Console.ReadLine();

            Console.WriteLine("Podaj kalorie na 100g:");
            p.CaloriesPer100g = ReadDoubleFromUser();

            Console.WriteLine("Podaj białko na 100g:");
            p.ProteinPer100g = ReadDoubleFromUser();

            Console.WriteLine("Podaj tłuszcz na 100g:");
            p.FatPer100g = ReadDoubleFromUser();

            Console.WriteLine("Podaj węglowodany na 100g:");
            p.CarbsPer100g = ReadDoubleFromUser();

            productService.AddNewProduct(p);
        }

        public static void ShowAllProducts(ServiceProduct productService)
        {
            var products = productService.GetAllProducts();

            if (products.Count == 0)
            {
                Console.WriteLine("Brak produktów.");
                return;
            }

            foreach (var p in products)
            {
                Console.WriteLine($"{p.Id}: {p.Name} - {p.CaloriesPer100g} kcal");
            }
        }

        private static double ReadDoubleFromUser()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (double.TryParse(input, out double value))
                    return value;
                Console.WriteLine("Nieprawidłowa wartość. Spróbuj ponownie:");
            }
        }
    }   
}
