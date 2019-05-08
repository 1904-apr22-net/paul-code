using Microsoft.EntityFrameworkCore;
using NLog;
using StoreApplication.DataAccess.Entities;
using StoreApplication.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreApplication.DataAccess
{
   public class StoreRepository : Library.Interfaces.IStoreRepository
    {
        private readonly StoreApplicationContext _dbContext;


        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        public StoreRepository(StoreApplicationContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

            /// <summary>
            /// Return list of customers (if name is not null filter customers by last name);
            /// </summary>
            /// <param name="search"></param>
            /// <returns></returns>
        public IEnumerable<Customer> GetNames(string search = null)
        {
            _logger.Info($"Retrieving Names");

            IQueryable<Consumer> items = _dbContext.Consumer
                .Include(r => r.Store).AsNoTracking();
            if (search != null)
            {
                items = items.Where(r => r.Lname.Contains(search));
            }
            return Mapper.Map(items);
        }
        /// <summary>
        /// Get all orders (if customer isn't null filter by ID)
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public IEnumerable<Order> GetOrders(Customer customer = null)
        {
            _logger.Info($"Retrieving Orders");

            IQueryable<Orders> items = _dbContext.Orders
                .Include((x) => x.Store)
                .Include(x => x.Consumer)
                .Include(x => x.OrderItem);

                
                
            if (customer != null)
            {
                items = items.Where(r => r.ConsumerId == customer.CustomerId);
            }
            return Mapper.Map(items);
        }
        /// <summary>
        /// Get all inventories if Customer is not null filter by their location
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public IEnumerable<Inventories> GetInventories(Customer customer = null)
        {
            _logger.Info($"Retrieving Inventory");

            IQueryable<Inventory> items = _dbContext.Inventory
                .Include((x) => x.Store).AsNoTracking();

            if (customer != null)
            {
                items = items.Where(r => r.StoreId == customer.DefaultLocation.LocationId);
            }
            return Mapper.Map(items);
        }
        /// <summary>
        /// Get components (if product is not null filter by product)
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public IEnumerable<ComponentInventory> GetComponents(Product product = null)
        {
            _logger.Info($"Retrieving Components");

            IQueryable<Components> items = _dbContext.Components
                .AsNoTracking();

            if (product != null)
            {
                items = items.Where(r => r.BaseProductId == product.ProductId);
            }
            return Mapper.Map(items);
        }
        /// <summary>
        /// Get categories if product is not null filter by category id
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public IEnumerable<ProductCat> GetCategory(Product product = null)
        {
            _logger.Info($"Retrieving Categories");

            IQueryable<ProductCategory> items = _dbContext.ProductCategory.Include(x=>x.Products)
                .AsNoTracking();

            if (product != null)
            {
                items = items.Where(r => r.ProductCategoryId == product.CategoryId);
            }
            return Mapper.Map(items);
        }
        /// <summary>
        /// Get recommend list of products if Category is not null
        /// </summary>
        /// <param name="productCat"></param>
        /// <returns></returns>
        public IEnumerable<Product> GetRecommended(ProductCat productCat = null)
        {
            _logger.Info($"Getting Recommended Products");


            IQueryable<Products> items = _dbContext.Products.Include(x=>x.ProductCategory)
                .AsNoTracking();

            if (productCat != null)
            {
                items = items.Where(r => r.ProductCategoryId == productCat.ProductCategoryId);
            }
            return Mapper.Map(items);
        }
        /// <summary>
        /// Returns details of orders, filters by Order Id if not null
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public IEnumerable<OrderDetails> GetOrderDetails(Order order = null)
        {
            _logger.Info($"Retrieving Order Details");
            IQueryable<OrderItem> items = _dbContext.OrderItem.Include(x=>x.Order).Include(y=>y.Product)
                .AsNoTracking();
            if (order != null)
            {
                items = items.Where(r => r.OrderId == order.OrderId);
            }
            return Mapper.Map(items);
        }

        /// <summary>
        /// Returns products
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> DisplayProducts()
        {
            _logger.Info($"Retrieving Products");

            IQueryable<Products> items = _dbContext.Products
                .Include(r=>r.ProductCategory).AsNoTracking();
 
            return Mapper.Map(items);
        }

        /// <summary>
        /// Add Order -- Update location and Customer (M-M)
        /// </summary>
        /// <param name="order"></param>
        /// <param name="location"></param>
        /// <param name="customer"></param>
        public void AddOrder(Order order, Location location, Customer customer)
        {
            _logger.Info($"Adding Order {order.OrderId}");
            Store storeEntity = _dbContext.Store.Include(o => o.Orders).First(o => o.StoreId == location.LocationId);
            Consumer consumerEntity = _dbContext.Consumer.Include(c => c.Orders).First(c => c.ConsumerId == customer.CustomerId);

            
            Orders newEntity = Mapper.Map(order);
            storeEntity.Orders.Add(newEntity);
            consumerEntity.Orders.Add(newEntity);

            location.Orders.Add(order);
            customer.Orders.Add(order);
        }
        /// <summary>
        /// Add order details -- Update product and order (M-M)
        /// </summary>
        /// <param name="orderDetails"></param>
        /// <param name="order"></param>
        /// <param name="product"></param>
        public void AddOrderDetails(OrderDetails orderDetails, Order order, Product product)
        {
            _logger.Info($"Adding order details : {orderDetails.OrderId}");
            Products products = _dbContext.Products.Include(x => x.OrderItem).First(x => x.ProductId == product.ProductId);

            OrderItem orderItem = Mapper.Map(orderDetails);

            products.OrderItem.Add(orderItem);

            order.OrderDetails.Add(orderDetails);

        }
        /// <summary>
        /// Update order details
        /// </summary>
        /// <param name="orderDetails"></param>
        public void UpdateOrderDetails(OrderDetails orderDetails)
        {
            _logger.Info($"Updating Order Details {orderDetails.OrderId}");
            OrderItem currentOrder = _dbContext.OrderItem.Find(orderDetails.OrderId);
            OrderItem newEntity = Mapper.Map(orderDetails);

            _dbContext.Entry(currentOrder).CurrentValues.SetValues(newEntity);
        }

        /// <summary>
        /// Update inventory
        /// </summary>
        /// <param name="inventories"></param>
        public void UpdateInventory(Inventories inventories)
        {
            _logger.Info($"Updating inventory {inventories.InventoryId}");
            var x = inventories.InventoryId;
            var y = inventories;
            Inventory currentInv = _dbContext.Inventory.Find(inventories.InventoryId);
            Inventory newEntity = Mapper.Map(inventories);
            

            _dbContext.Entry(currentInv).CurrentValues.SetValues(newEntity);
        }
 
        /// <summary>
        /// Save Tracked items to Database
        /// </summary>
        public void Save()
        {
            _dbContext.SaveChanges();
        }
        private bool disposedValue = false; // To detect redundant calls

        /// <summary>
        /// Dispose of dbContext after use.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
        }
    }
}
