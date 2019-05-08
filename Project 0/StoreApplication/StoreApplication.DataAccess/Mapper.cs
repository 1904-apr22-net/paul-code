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
            DefaultLocation = Map(consumer.Store),
            Orders = Map(consumer.Orders).ToList(),    
            StoreId = consumer.StoreId,
        };
        public static Consumer Map(Customer customer) => new Consumer
        {
            ConsumerId = customer.CustomerId,
            Fname = customer.FName,
            Lname = customer.LName,
            Store = Map(customer.DefaultLocation),
            Orders = Map(customer.Orders).ToList(),
            State = customer.State,
            StoreId = customer.DefaultLocation.LocationId,
        };
        public static Location Map(Store store) => new Location
        {
            LocationId = store.StoreId,
            Name = store.Name,
            State = store.State,
            //Customers = Map(store.Consumer).ToList(),
            Inventory = Map(store.Inventory).ToList(),
           //Orders = Map(store.Orders).ToList(),
        };
        public static Store Map(Location location) => new Store
        {
            StoreId = location.LocationId,
            Name = location.Name,
            State = location.State,
            Consumer = Map(location.Customers).ToList(),
            Inventory = Map(location.Inventory).ToList(),
            Orders = Map(location.Orders).ToList(),
        };

        public static Products Map(Product product) => new Products
        {
                Price = product.ProductCost,
                ProductName = product.ProductName,
                ProductId = product.ProductId,
                ProductCategoryId = product.CategoryId,
                ComponentBit = product.HasComponents,    
                ProductCategory = Map(product.CategoryRef),
                ComponentsBaseProduct = Map(product.BaseComponents).ToList(),
                ComponentsComponentProduct = Map(product.Components).ToList(),
                ProductDesc = product.ProductDesc,
                Inventory = Map(product.Inventory).ToList(),
                OrderItem = Map(product.OrderDetails).ToList(),
        };
        public static Product Map(Products products) => new Product
        {
            ProductCost = products.Price,
            ProductName = products.ProductName,
            ProductId = products.ProductId,
            Category = products.ProductCategory.CategoryName,
            CategoryId = products.ProductCategory.ProductCategoryId,
            HasComponents = products.ComponentBit,
            Components = Map(products.ComponentsComponentProduct).ToList(),
            quantitySale = 0,
            CategoryRef = Map(products.ProductCategory),
            BaseComponents = Map(products.ComponentsBaseProduct).ToList(),
            Inventory = Map(products.Inventory).ToList(),
            OrderDetails = Map(products.OrderItem).ToList(),
            ProductCat = Map(products.ProductCategory),
            ProductDesc = products.ProductDesc,
        };

        public static Order Map(Orders orders) => new Order
        {
            TotalAmount = orders.TotalAmount,
          //Customer = Map(orders.Consumer),
            Location = Map(orders.Store),
            OrderId = orders.OrderId,
            TimeStamp = orders.Time,
            OrderDetails = Map(orders.OrderItem).ToList(),
            CustomerId = orders.ConsumerId,
            StoreId = orders.StoreId,
        };
        public static Orders Map(Order order) => new Orders
        {
            TotalAmount = order.TotalAmount,
          //  Consumer = Map(order.Customer),
            Store = Map(order.Location),
            OrderId = order.OrderId,
            Time = order.TimeStamp,
            ConsumerId = order.CustomerId,
            StoreId = order.StoreId,
            OrderItem = Map(order.OrderDetails).ToList(),
        };
        public static OrderDetails Map(OrderItem orderItem) => new OrderDetails
        {
            OrderId = orderItem.OrderId,
            OrderItemId = orderItem.OrderItemId,
            ProductId = orderItem.ProductId,
            Quantity = orderItem.Quantity,
        };
        public static OrderItem Map(OrderDetails orderDetails) => new OrderItem
        {
            OrderId = orderDetails.OrderId,
            OrderItemId = orderDetails.OrderItemId,
            ProductId = orderDetails.ProductId,
            Quantity = orderDetails.Quantity,
        };
        public static ComponentInventory Map(Components components) => new ComponentInventory
        {
            BaseProductId = components.BaseProductId,
            ComponentProductId = components.ComponentProductId,
            ComponentId = components.ComponentId,
        };
        public static Components Map(ComponentInventory componentInventory) => new Components
        {
            BaseProductId = componentInventory.BaseProductId,
            ComponentProductId = componentInventory.ComponentProductId,
            ComponentId = componentInventory.ComponentId
        };
        public static Inventory Map(Inventories inventories) => new Inventory
        {
            InventoryId = inventories.InventoryId,
            ProductId = inventories.ProductId,
            StoreId = inventories.StoreId,
            Quantity = inventories.Quantity,
        };

        public static Inventories Map(Inventory inventory) => new Inventories
        {
            InventoryId = inventory.InventoryId,
            ProductId = inventory.ProductId,
            StoreId = inventory.StoreId,
            Quantity = inventory.Quantity,
        };
        public static ProductCat Map(ProductCategory productCategory) => new ProductCat
        {
            CategoryName = productCategory.CategoryName,
            ProductCategoryId = productCategory.ProductCategoryId,
        };
        public static ProductCategory Map(ProductCat productCat) => new ProductCategory
        {
            CategoryName = productCat.CategoryName,
            ProductCategoryId = productCat.ProductCategoryId,
        };
 
        public static IEnumerable<Order> Map(IEnumerable<Orders> orders) => orders.Select(Map);
        public static IEnumerable<Orders> Map(IEnumerable<Order> order) => order.Select(Map);
        public static IEnumerable<ProductCategory> Map(IEnumerable<ProductCat> productCats) => productCats.Select(Map);
        public static IEnumerable<ProductCat> Map(IEnumerable<ProductCategory> productCategories) => productCategories.Select(Map);
        public static IEnumerable<OrderDetails> Map(IEnumerable<OrderItem> orderItem) => orderItem.Select(Map);
        public static IEnumerable<OrderItem> Map(IEnumerable<OrderDetails> orderDetails) => orderDetails.Select(Map);
        public static IEnumerable<Product> Map(IEnumerable<Products> products) => products.Select(Map);
        public static IEnumerable<Products> Map(IEnumerable<Product> product) => product.Select(Map);
        public static IEnumerable<ComponentInventory> Map(IEnumerable<Components> components) => components.Select(Map);
        public static IEnumerable<Components> Map(IEnumerable<ComponentInventory> componentInventories) => componentInventories.Select(Map);
        public static IEnumerable<Inventory> Map(IEnumerable<Inventories> inventories) => inventories.Select(Map);
        public static IEnumerable<Inventories> Map(IEnumerable<Inventory> inventory) => inventory.Select(Map);

        public static IEnumerable<Customer> Map(IEnumerable<Consumer> consumer) => consumer.Select(Map);
        public static IEnumerable<Consumer> Map(IEnumerable<Customer> customer) => customer.Select(Map);

        public static IEnumerable<Location> Map(IEnumerable<Store> store) => store.Select(Map);
        public static IEnumerable<Store> Map(IEnumerable<Location> location) => location.Select(Map);


    }
}
