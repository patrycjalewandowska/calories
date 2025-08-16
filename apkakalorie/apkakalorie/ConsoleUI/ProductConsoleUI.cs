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

            Console.WriteLine("Dostępne produkty");

            foreach (var p in products)
            {
                ShowProductShort(p);             
            }
        }

        public static void DeleteProductById(ServiceProduct productService)
        {
            Product p = new Product();

            Console.WriteLine("Ktory produkt chcesz usunac?");

            int productId = GetIdFromUser();

            productService.DeleteProduct(productId);
        }

        public static void UpdateProductFromUserInput(ServiceProduct productService)
        {

            Product p = new Product();

            Console.WriteLine("Ktory produkt chcesz aktualizowac?");
            ShowAllProducts(productService);

            int productId = GetIdFromUser();

            Product productFromDb = new Product();

            productFromDb = productService.GetProduct(productId);

            ShowProduct(productFromDb);


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

            productService.UpdateProduct(productId, p);
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

        public static void ShowProductShort(Product product)
        {
                Console.WriteLine($"{product.Id}: {product.Name} - {product.CaloriesPer100g} kcal");
        }

        private static int GetIdFromUser()
        {
            string productIdInput = Console.ReadLine();
            Int32.TryParse(productIdInput, out int productId);
            return productId;
        }


        private static void ShowProduct(Product productFromDb)
        {
            Console.WriteLine($"Id: {productFromDb.Id}," +
                $"Name: {productFromDb.Name}," +
                $"kalorie na 100g: {productFromDb.CaloriesPer100g}," +
                $"białko na 100g: {productFromDb.ProteinPer100g}," +
                $"węglowodany na 100g: {productFromDb.CarbsPer100g}," +
                $"tłuszcz na 100g: {productFromDb.FatPer100g}");
        }
    }   
}
