using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apkakalorie.Models
{
    public class RecipeProduct
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public double QuantityInGrams { get; set; }
    }

}
