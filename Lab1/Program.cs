using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductModel model = new ProductModel();

            Console.WriteLine("Categories");
            foreach (var categories in model.Categories)
            {
                Console.WriteLine(categories);
            }
            Console.WriteLine("-------------------------------");

            Console.WriteLine("Products");
            foreach (var products in model.Products)
            {
                Console.WriteLine(products);
            }

        }
    }
}
