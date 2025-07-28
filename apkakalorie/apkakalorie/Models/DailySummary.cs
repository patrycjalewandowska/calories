using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apkakalorie.Models
{
    public class DailySummary
    {
        public DateTime Date { get; set; }
       
        public double TotalCalories { get; set; }
        public double TotalProtein { get; set; }
        public double TotalFat { get; set; }
        public double TotalCarbs { get; set; }
    }

}
