using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product> {
                new Product{ProductId = 1, CategoryId=1,ProductName="Bardak",
                UnitPrice=15,UnitsInStock = 15},
            new Product { ProductId = 2, CategoryId = 1, ProductName = "Kupa",
                UnitPrice = 500, UnitsInStock = 3 },
            new Product { ProductId = 3, CategoryId = 2, ProductName = "Telefon",
                UnitPrice = 1500, UnitsInStock = 2 },
            new Product { ProductId = 4, CategoryId = 2, ProductName = "Klavye",
                UnitPrice = 150, UnitsInStock = 65 },
            new Product { ProductId = 5, CategoryId = 2, ProductName = "Fare",
                UnitPrice = 85, UnitsInStock = 1},
            new Product{CategoryId=1,ProductId=6,ProductName="Masa",UnitPrice=2500,UnitsInStock=5}
            };
        }


        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ - Language Integrated Query
            //Lambda




            //bu foreach uslubu ile yazilmis koddu 
            //Product productToDelete = null;
            //foreach (var p in _products)
            //{
            //    if (product.ProductId==p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //}
            //
            // bu LINQ ile yazilan kod bundan sonra linq yazicam
          Product  productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);

            _products.Remove(productToDelete);

        }


        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
           return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
         //Gonderdigim urun id'sine sahip olan listedeki urunu bul
           Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.ProductId = product.ProductId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
