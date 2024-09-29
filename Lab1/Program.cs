using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    namespace Lab1
    {
        internal class Program
        {
            // Assuming ProductModel class has a collection of Categories and Products
            static ProductModel model = new ProductModel();

            static void Main(string[] args)
            {
                // Uncomment these to test the respective methods
                // AllCategories();
                // AllProducts();
                // ProductsQuantityLessThan100();
                // ProductsQuantityGreaterThan120();
                //ProductsTotalValue();
                ProductsInHardwareCategory();
                SuppliersAndTheirParts();
            }

            static void AllCategories()
            {
                Console.WriteLine("Categories:");
                foreach (var category in model.Categories)
                {
                    Console.WriteLine(category); // Assuming category has a proper ToString() override
                }
                Console.WriteLine("-------------------------------");
            }

            static void AllProducts()
            {
                Console.WriteLine("Products:");
                foreach (var product in model.Products)
                {
                    Console.WriteLine(product); // Assuming product has a proper ToString() override
                }
                Console.WriteLine("-------------------------------");
            }

            static void ProductsQuantityLessThan100()
            {
                Console.WriteLine("Products with a Quantity <= 100:");
                var filteredProducts = model.Products.Where(p => p.QuantityStock <= 100);

                foreach (var product in filteredProducts)
                {
                    Console.WriteLine(product); // Assuming product has a proper ToString() override
                }
                Console.WriteLine("-------------------------------");
            }

            static void ProductsQuantityGreaterThan120()
            {
                Console.WriteLine("Products with a Quantity > 120:");
                var filteredProducts = model.Products.Where(p => p.QuantityStock > 120);

                foreach (var product in filteredProducts)
                {
                    Console.WriteLine(product); // Assuming product has a proper ToString() override
                }
                Console.WriteLine("-------------------------------");
            }

            static void ProductsTotalValue()
            {
                // Select each product and calculate its total value
                var productsTotalValue = model.Products.Select(p => new
                {
                    p.ProductID,
                    p.Description,
                    TotalValue = p.QuantityStock * p.UnitPrice
                });

                Console.WriteLine("Products and their total value:");
                foreach (var product in productsTotalValue)
                {
                    Console.WriteLine($"Product ID: {product.ProductID}, Total Value: {product.TotalValue:C}");
                }
                
            }

            static void ProductsInHardwareCategory()
            {
                Console.WriteLine("Products in the Hardware Category:");

               
                var hardwareProducts = from product in model.Products
                                       join category in model.Categories on product.CategoryID equals category.Id
                                       where category.Description == "Hardware"
                                       select new
                                       {
                                           product.ProductID,
                                           product.Description,
                                           product.QuantityStock,
                                           product.UnitPrice,
                                           TotalValue = product.QuantityStock * product.UnitPrice
                                       };

                foreach (var product in hardwareProducts)
                {
                    Console.WriteLine($"Product ID: {product.ProductID}, Description: {product.Description} ");
                                      
                }

            }
            static void SuppliersAndTheirParts()
            {
                Console.WriteLine("Suppliers and their Parts:");

                var supplierParts = from supplier in model.Suppliers
                                    join supplierProduct in model.SupplierProducts on supplier.SupplierID equals supplierProduct.SupplierID
                                    join product in model.Products on supplierProduct.ProductID equals product.ProductID
                                    orderby supplier.SupplierName
                                    select new
                                    {
                                        supplier.SupplierName,
                                        supplierProduct.DateFirstSupplied,
                                        product.ProductID,
                                        product.Description,
                                    };

                foreach (var item in supplierParts)
                {
                    Console.WriteLine($"Supplier: {item.SupplierName}, Product: {item.Description}, Product ID: {item.ProductID}, Date: {item.DateFirstSupplied}");
                                      
                }


            }


        }
    }
}

    
