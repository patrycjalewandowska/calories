using apkakalorie.Database;
using apkakalorie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apkakalorie.Service
{
    internal class ServiceRecipe
    {
        private readonly Context _context;
        public ServiceRecipe(Context context)
        {
            _context = context;
        }
        public void AddNewRecipe(Recipe recipe)
        {
            _context.recipes.Add(recipe);

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