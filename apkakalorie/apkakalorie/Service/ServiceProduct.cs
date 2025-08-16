using apkakalorie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using apkakalorie.Database;

namespace apkakalorie.Service
{
    public class ServiceProduct
    {
        private int id = 0;

        private  Context _context;

        //private readonly Context _context;

        public ServiceProduct(Context context)
           {
               _context = context;
           }
        public void AddNewProduct(Product product) 
        {
            Product newProduct = new Product();
            newProduct.Id = GenereteNewProductId();
            newProduct.Name = product.Name;
            newProduct.CaloriesPer100g = product.CaloriesPer100g;
            newProduct.ProteinPer100g = product.ProteinPer100g;
            newProduct.FatPer100g = product.FatPer100g;
            newProduct.CarbsPer100g = product.CarbsPer100g;

            _context.products.Add(newProduct);

            Console.WriteLine("DODANO NOWY PRODUKT");

        }

        public int GenereteNewProductId()
        {
            id++;
            return id;
        }
        public void DeleteProduct(int id)
        {
            var product = _context.products.FirstOrDefault(p => p.Id == id);
          
            if (product != null)
            {
                _context.products.Remove(product);
                Console.WriteLine($"Produkt o ID {id} został usunięty.");
            }
            else
            {
                Console.WriteLine($"Produkt o ID {id} nie istnieje.");
            }
        }
        public Product GetProduct(int id)
        {

            return _context.products.FirstOrDefault(p=> p.Id == id);
        }
        public List<Product> GetAllProducts()
        {
            if (_context.products == null)
            {
                Console.WriteLine("LISTA PRODUKTOW JEST PUSTA");
            }
            return _context.products;
        }
        public Product GetProductById(int id) {

            Product product = _context.products.FirstOrDefault(p => p.Id == id);

            return product;
        }
        public void UpdateProduct(int id, Product updateProduct)
        {
            Product product = GetProduct(id);
            updateProduct.Id = id;
            updateProduct.Name = product.Name;
            updateProduct.CaloriesPer100g = product.CaloriesPer100g;
            updateProduct.ProteinPer100g = product.ProteinPer100g;
            updateProduct.FatPer100g = product.FatPer100g;
            updateProduct.CarbsPer100g = product.CarbsPer100g;

            Console.WriteLine("Zapisowano produkt");

        }

    }
}
