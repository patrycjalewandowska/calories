using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apkakalorie.Models
{
    public class MealsDay
    {
        public int Id { get; set; }
        public int BreakfastId { get; set; }
        public int BreakfastSecondId { get; set; }
        public int LunchId { get; set; }
        public int TeaId { get; set; }
        public int DinnerId { get; set; }

        public int Day; // enum?


    }
}
