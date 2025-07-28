using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apkakalorie.Models
{
    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public float Quantity { get; set; }
        public string unit { get; set; }
    }
}
