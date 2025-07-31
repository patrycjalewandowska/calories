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
        public void AddNewRecipe() 
        {

        
        }

        public void DeleteRecipe()
        {


        }

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

        public void UpdateRecipe()
        {


        }
    }
}
