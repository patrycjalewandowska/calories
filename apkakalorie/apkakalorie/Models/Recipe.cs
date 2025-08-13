using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using apkakalorie.Models;

namespace apkakalorie.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //  public CategoryRecipe CategoryRecipeId { get; set; }
        // public int CategoryRecipeId { get; set; }
        public List<RecipeItem> listIdProductToRecipe { get; set; } 

        public double CaloricContent { get; set; }

        public double Protein{ get; set; }
        public double Fat { get; set; }
        public double Carbs { get; set; }

        public int NumberOfServings { get; set; }

    }
}
