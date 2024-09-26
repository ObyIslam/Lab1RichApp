using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class ProductModel
    {
        //supplier {PK - SupplierID}
        //Product {PK - ProductID}   
        //Category {PK - Id}
        //SupplierProduct {PK - SupplierID, ProductID}


        public List<Supplier> Suppliers { get;} = new List<Supplier>();
        public List<Product> Products { get;} = new List<Product>();
        public List<Category> Categories { get;} = new List<Category>();
        public List <SupplierProduct> SupplierProducts { get;} = new List<SupplierProduct>();




        public ProductModel()
        {
            //Suppliers
            Suppliers.Add(new Supplier(1,"ACME","Collooney","Sligo"));
            Suppliers.Add(new Supplier(2, "Swift Electric", "Finglas", "Dublin"));

            //Products
            Products.Add(new Product(1,"9 Inch Nails",200,0.1,1));
            Products.Add(new Product(2, "9 Inch Botls", 120, 0.2, 1));
            Products.Add(new Product(3, "Chimney Hoover", 10, 100.30, 2));
            Products.Add(new Product(4, "Washing Machine", 7, 399.50, 2));

            //Categories
            Categories.Add(new Category(2, "Hardware"));
            Categories.Add(new Category(2, "Electrical Appliances"));

            //SupplierProducts
            SupplierProducts.Add(new SupplierProduct(1, 1, DateTime.Parse("2012-12-12")));
            SupplierProducts.Add(new SupplierProduct(2, 1, DateTime.Parse("2017-08-13")));
            SupplierProducts.Add(new SupplierProduct(3, 2, DateTime.Parse("2022-09-09")));
            SupplierProducts.Add(new SupplierProduct(4, 2, DateTime.Parse("2024-04-11")));

        }   

        

    }

    public class Supplier
    {
        public int SupplierID; 
        public string SupplierName { get; set; }
        public string SupplierAddressLine1 { get; set; }
        public string SupplierAddressLine2 { get; set; }

        public Supplier(int supplierID, string supplierName, string supplierAddressLine1, string supplierAddressLine2)
        {
            SupplierID = supplierID;
            SupplierName = supplierName;
            SupplierAddressLine1 = supplierAddressLine1;
            SupplierAddressLine2 = supplierAddressLine2;
        }

        public override string ToString()
        {
            return SupplierID.ToString() + " " + SupplierName.ToString() + " " + SupplierAddressLine1.ToString() + " " + SupplierAddressLine2.ToString();
        }
    }

    public class Product
    {
        public int ProductID; 
        public string Description { get; set; }
        public int QuantityStock { get; set; }
        public double UnitPrice { get; set; }
        public int CategoryID { get; set; }

        public Product(int productID, string description, int quantityStock, double unitPrice, int categoryID)
        {
            ProductID = productID;
            Description = description;
            QuantityStock = quantityStock;
            UnitPrice = unitPrice;
            CategoryID = categoryID;
        }

        public override string ToString()
        {
            return $"ProductID:{ProductID} - Description:{Description} -  Quantity:{QuantityStock} - UnitPrice:{UnitPrice} -  CategoryID:{CategoryID}";
        }



    }

    public class Category
    {
        public int Id;
        public string Description { get; set; }

        public Category(int id, string description)
        {
            Id = id;
            Description = description;
        }

        public override string ToString()
        {
            return $"ID:{Id} - Description:{Description}";
        }
    }

    public class SupplierProduct
    {
        public int ProductID;
        public int SupplierID;
        public DateTime DateFirstSupplied { get; set; }

        public SupplierProduct(int productID, int supplierID, DateTime dateFirstSupplied)
        {
            ProductID = productID;
            SupplierID = supplierID;
            DateFirstSupplied = dateFirstSupplied;
        }

        public override string ToString()
        {
            return $"{ProductID} {SupplierID} {DateFirstSupplied}";
        }
    }
}
