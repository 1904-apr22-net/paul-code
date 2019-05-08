using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.Library.Interfaces
{
   public interface IStoreRepository : IDisposable
    {
        IEnumerable<Customer> GetNames(string search = null);
        IEnumerable<Order> GetOrders(Customer customer = null);
        IEnumerable<Inventories> GetInventories(Customer customer = null);
        IEnumerable<ComponentInventory> GetComponents(Product product = null);

        IEnumerable<ProductCat> GetCategory(Product product = null);

        IEnumerable<Product> GetRecommended(ProductCat productCat = null);

        IEnumerable<OrderDetails> GetOrderDetails(Order order = null);

        IEnumerable<Product> DisplayProducts();
        void AddOrder(Order order, Location location, Customer customer);
        void AddOrderDetails(OrderDetails orderDetails, Order order, Product product);
        void UpdateOrderDetails(OrderDetails orderDetails);
        void UpdateInventory(Inventories inventories);
        void Save();

    }
}
