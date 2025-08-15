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

    }
}
