using apkakalorie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apkakalorie.Database
{
    public class Context
    {
        public List<Recipe> recipes = new List<Recipe>();
        public List<Product> products = new List<Product>();
    }
}
