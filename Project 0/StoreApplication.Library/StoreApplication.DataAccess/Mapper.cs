using StoreApplication.DataAccess.Entities;
using StoreApplication.Library;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreApplication.DataAccess
{
    public static class Mapper
    {
        public static Customer Map(Consumer consumer) => new Customer
        {
            CustomerId = consumer.ConsumerId,
            FName = consumer.Fname,
            LName = consumer.Lname,
            State = consumer.State,
            DefaultLocation = Map(consumer.Store)

        };
        public static Consumer Map(Customer customer) => new Consumer
        {
            ConsumerId = customer.CustomerId,
            Fname = customer.FName,
            Lname = customer.LName,
            Store = Map(customer.DefaultLocation)
        };
        public static Location Map(Store store) => new Location
        {
            LocationId = store.StoreId,
            Name = store.Name,
            State = store.State,
            Customers = Map(store.Consumer).ToList(),
            Products = Map(store.Inventory).ToList(),
        };
        public static Store Map(Location location) => new Store
        {
            StoreId = location.LocationId,
            Name = location.Name,
            State = location.State,
            Consumer = Map(location.Customers).ToList(),
            Inventory = location.Customers.Select(()=)
        };
        public static Product Map(Inventory inventory) => new Product
        {
            ProductCost = inventory.Product.Price,
            ProductName = inventory.Product.ProductName,
            ProductId = inventory.Product.ProductId,
            ProductCount = inventory.Quantity,
            Category = inventory.Product.ProductCategory.CategoryName,
            CategoryId = inventory.Product.ProductCategory.ProductCategoryId,
            HasComponents = inventory.Product.ComponentBit,
            Components = Map(inventory.Product.ComponentsComponentProduct).ToList()
        };

        public static Product Map(Products products) => new Product
        {
            ProductCost = products.Price,
            ProductName = products.ProductName,
            ProductId = products.ProductId,
            ProductCount = products.Inventory.Where((x)=> x.ProductId)
            Category = inventory.products.ProductCategory.CategoryName,
            CategoryId = inventory.products.ProductCategory.ProductCategoryId,
            HasComponents = inventory.products.ComponentBit,
            Components = Map(inventory.products.ComponentsComponentProduct).ToList()
        }
        public static ComponentInventory Map(Components components) => new ComponentInventory
        {
            BaseProductId = components.BaseProductId,
            ComponentProductId = components.ComponentProductId,
            ComponentId = components.ComponentId
        };
        public static Products Map(Product product) => new Products
        {
            v
        };
        //public static Product Map(Products products) => new Product
        //{
        //    ProductId = products.ProductId,
        //    ProductCost = products.Price,
        //    ProductName = products.ProductName,
        //    //Components = Map(products.Inventory).ToList(),
        //    //ProductCount = 
        //};

        //public static Products Map(Product product) => new Products
        //{
        //    ProductId = product.ProductId,
        //    Price = product.ProductCost,
        //    ProductName = product.ProductName,
        //    //Inventory = Map2(product.Components).,
        //};
        //public static Product Map(Inventory inventory) => new Product
        //{

        //};
        //public static Inventory Map2(Product inventory) => new Inventory
        //{

        //};
        public static IEnumerable<ComponentInventory> Map(IEnumerable<Components> components) => inventory.Select(Map);
        public static IEnumerable<Product> Map(IEnumerable<Inventory> inventory) => inventory.Select(Map);
        //public static IEnumerable<Inventory> Map(IEnumerable<Product> product) => product.Select(Map);


        public static IEnumerable<Customer> Map(IEnumerable<Consumer> consumer) => consumer.Select(Map);
        public static IEnumerable<Consumer> Map(IEnumerable<Customer> customer) => customer.Select(Map);

        public static IEnumerable<Location> Map(IEnumerable<Store> store) => store.Select(Map);
        public static IEnumerable<Store> Map(IEnumerable<Location> location) => location.Select(Map);


    }
}
