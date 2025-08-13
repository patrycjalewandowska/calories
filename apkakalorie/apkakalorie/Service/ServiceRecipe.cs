using apkakalorie.Database;
using apkakalorie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apkakalorie.Service
{
    public class ServiceRecipe
    {
        private  Context _context;
        private int id = 0;
         public ServiceRecipe(Context context)
        {
            _context = context;
        }

        public int GenereteNewRecipeId()
        {
            id++;
            return id;
        }

        public void AddNewRecipe(Recipe recipe, List<RecipeItem> listIdProductToRecipe)
        {
            ServiceProduct serviceProduct = new ServiceProduct(_context);
            Recipe r = new Recipe();
            List<Product> allProducts = serviceProduct.GetAllProducts();

            for (int i = 0; i < allProducts.Count; i++)
            {
                foreach (var item in listIdProductToRecipe)
                {
                    if (item.ProductId == allProducts[i].Id)
                    {
                        r.CaloricContent += allProducts[i].CaloriesPer100g * item.Quantity / 100;
                        r.Protein += allProducts[i].ProteinPer100g * item.Quantity / 100; ;
                        r.Fat += allProducts[i].FatPer100g * item.Quantity / 100; ;
                        r.Carbs += allProducts[i].CarbsPer100g * item.Quantity / 100; ;
                    }
                }
            }

            r.Id = GenereteNewRecipeId();
            r.listIdProductToRecipe = listIdProductToRecipe;
            r.Description = recipe.Description;
            r.Name = recipe.Name;
            r.NumberOfServings = recipe.NumberOfServings;

            _context.recipes.Add(r);

            Console.WriteLine("Dodano przepis");
        }

        public void DeleteRecipe(int id)
        {
            Recipe recipe = new Recipe();
            recipe = GetRecipeById(id);

            if (recipe != null)
            {

                _context.recipes.RemoveAt(id);
            }
            else {
                Console.WriteLine("Taki przepis nie istneje");

            }
        }

    //    public List<Recipe> GetRecipeByName(string name){   }
        public Recipe GetRecipeById(int id)
            {
                Recipe recipe = new Recipe();
                foreach (var item in _context.recipes)
                {
                    if (item.Id == id)
                    {
                        recipe = item;
                        return recipe;
                    }
                }
                return null;
            }

            public List<Recipe> GetAllRecipe()
            {
                return _context.recipes;

            }

            public void UpdateRecipe(Recipe recipeNew)
            {
                Recipe recipe = new Recipe();
                recipe = GetRecipeById(recipeNew.Id);
                recipe.Name = recipeNew.Name; //składniki 


            }
        
    }
}