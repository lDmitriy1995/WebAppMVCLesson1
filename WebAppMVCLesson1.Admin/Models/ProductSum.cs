﻿using Microsoft.AspNetCore.DataProtection.Repositories;

namespace WebAppMVCLesson1.Admin.Models
{
    public class ProductSum
    {
        public IRepository Repository { get; set; }
        public ProductSum(IRepository repo)
            
        {
            Repository = repo;
        }

        public decimal Total => Repository.Products.Sum(s => s.Price);
    }
    public class Product
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }

    public interface IRepository
    {
        IEnumerable<Product> Products { get; }

        Product this[string name] { get; }

        void AddProduct(Product product);

        void DeleteProduct(Product product);

    }

    public class Repository : IRepository
    {
        private Dictionary<string, Product> _products;

        private IStorage _storage;


        public Repository(IStorage storage)
        {
            _storage = storage;

            _products = new Dictionary<string, Product>();
            new List<Product>
            {
                new Product {Name = "Women Shoes", Price=99m},
                new Product {Name = "Skirts", Price=29.99m},
            }.ForEach(p => AddProduct(p));
           
        }

        private string guid = System.Guid.NewGuid().ToString();

        public override string ToString()
        {
            return guid;
        }

        public IEnumerable<Product> Products => _products.Values;
        public Product this[string name] => _products[name];

        public void AddProduct(Product product)
        {
            _products[product.Name] = product;
        }

        public void DeleteProduct(Product product) 
        {
            _products.Remove(product.Name);
        }
    }
}
