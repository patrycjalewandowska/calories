using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apkakalorie.Models
{
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double CaloriesPer100g { get; set; }
    public double ProteinPer100g { get; set; }
    public double FatPer100g { get; set; }
    public double CarbsPer100g { get; set; }
}
}
