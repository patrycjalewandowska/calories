using apkakalorie.Models;
using apkakalorie.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apkakalorie.ConsoleUI
{
    public class RecipeConsoleUI
    {
        public static void CreateRecipe(ServiceRecipe recipeService, ServiceProduct productService)
        {
            Recipe recipe = new Recipe();
            
            List<RecipeItem> listIdProductToRecipe = new List<RecipeItem>();

            Console.WriteLine("Podaj nazwe przepisu");
            recipe.Name = Console.ReadLine();

            Console.WriteLine("Wybierz dostepne produkty do przepisu. Jesli chcesz zakonczyc dodawanie produktow wcisnij - 0");
            ProductConsoleUI.ShowAllProducts(productService);

            while (true)
            {
                RecipeItem recipeItem = new RecipeItem();
                Console.WriteLine("Podaj ID produktu");
                recipeItem.ProductId = ReadIntFromUser();
                if (recipeItem.ProductId == 0) break;
                Console.WriteLine("Podaj wage w gramach produktu do przepisu");
                recipeItem.Quantity = ReadDoubleFromUser();
                listIdProductToRecipe.Add(recipeItem);

            }

            Console.WriteLine("Podaj opis przygotowania");
            recipe.Description = Console.ReadLine();

            Console.WriteLine("Ilosc porcji");
            recipe.NumberOfServings = ReadIntFromUser();

            recipeService.AddNewRecipe(recipe, listIdProductToRecipe);
        }

        public static void GetAllRecipe(ServiceRecipe recipeService)
        {
            List<Recipe> allRecipes = new List<Recipe>();
            allRecipes = recipeService.GetAllRecipe();  

            foreach (Recipe recipe in allRecipes)
            {
                Console.WriteLine($"Nazwa: {recipe.Name}");
                Console.WriteLine($"Kalorie: {recipe.CaloricContent}");
                Console.WriteLine($"Przygotowanie: {recipe.Description}");
            }
        }

        public static void DeleteRecipeWithIdFromUser(ServiceRecipe recipeService)
        {
            Console.WriteLine("Podaj id przepiu ktorego chcesz usunac");
            string input = Console.ReadLine();
            Int32.TryParse( input, out int id);
            recipeService.DeleteRecipe(id);
        }

        public static void UpdateRecipeFromUser(ServiceRecipe recipeService, ServiceMenu serviceMenu, ServiceProduct productService)
        { 
            Recipe recipe = new Recipe();
            GetAllRecipe(recipeService);
            int recipeId = GetIdFromUser();
            recipe = recipeService.GetRecipeById(recipeId)
            ShowRecipe(recipe, productService);

            serviceMenu.ShowMenu();
            int input = ReadIntFromUser(); // zmiana nazwy na int jedna metoda

            switch (input)
            {
                case 1: UpdateRecipeFromUser(recipeId, recipeService); break;
                case 2: Console.WriteLine("Dodanie produktow"); break;
                case 3: DeleteIdProductFromRecipe(recipeId, recipe.listIdProductToRecipe, productService,  recipeService); break;
                case 4: Console.WriteLine("Aktualizacja produktu?????"); break;
            }

            //menu change produkt -> edit produkt -> dodac metode w prdukt service
              
        }

        public static void UpdateRecipeFromUser(int id, ServiceRecipe recipeService)
        {
            Recipe recipeNew = new Recipe();
            Console.WriteLine("Zmiana nazwy przepisu");
            recipeNew.Name = Console.ReadLine();
            Console.WriteLine("Zmiana Opisu");
            recipeNew.Description = Console.ReadLine();

            recipeService.UpdateRecipe(id, recipeNew);
        }

        public static void DeleteIdProductFromRecipe(int idRecipe,List<RecipeItem> listProducts, ServiceProduct productService, ServiceRecipe recipeService)
        {
            Console.WriteLine("Produkty w przepisie:");

            foreach (var p in listProducts)
            {
                var product = productService.GetProductById(p.ProductId);

                if (product != null)
                {
                    ProductConsoleUI.ShowProductShort(product);
                }
            }
            
            Console.WriteLine("Jaki produkt chcesz usunac z listy?");
            int idProduct = ReadIntFromUser();

            recipeService.DeleteProductFromRecipe(idProduct, idRecipe);
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

        private static int ReadIntFromUser()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (Int32.TryParse(input, out int value))
                    return value;
                Console.WriteLine("Nieprawidłowa wartość. Spróbuj ponownie:");
            }

        }

        private static int GetIdFromUser()
        {
            string productIdInput = Console.ReadLine();
            Int32.TryParse(productIdInput, out int productId);
            return productId;
        }

        private static void ShowRecipe(Recipe recipeFromDb, ServiceProduct productService)
        {
               Console.WriteLine($"Id: {recipeFromDb.Id}," +
                $"Nazwa: {recipeFromDb.Name}," +
                $"Przygotowanie: {recipeFromDb.Description}+" +
                $"Kalorie: {recipeFromDb.CaloricContent}+" +
                $"Liczba procji: {recipeFromDb.NumberOfServings}+" +
                $"Białko: {recipeFromDb.Protein} +" +
                $"Tłuszcze: {recipeFromDb.Fat}+" +
                $"Węglowodany: {recipeFromDb.Carbs}");

            foreach (var product in recipeFromDb.listIdProductToRecipe)
            {
               Product p = productService.GetProduct(product.ProductId);
               ProductConsoleUI.ShowProductShort(p);
            }
        }

    }
}
