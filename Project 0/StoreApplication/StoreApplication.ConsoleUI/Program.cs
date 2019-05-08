using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using NLog;
using StoreApplication.DataAccess;
using StoreApplication.DataAccess.Entities;
using StoreApplication.Library;
using StoreApplication.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ILogger = NLog.ILogger;

namespace StoreApplication.ConsoleUI
{
    public class Program
    {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            using (StoreApplicationContext dbContext = CreateDbContext())
            using (IStoreRepository storeRepository = new StoreRepository(dbContext))
            {

                while (true)
                {
                    try
                    {
                        _logger.Info($"Saving");
                        storeRepository.Save();
                    }
                    catch (DbUpdateException ex)
                    {
                        _logger.Error($"Failed to Save");
                        Console.WriteLine(ex.Message);
                    }
                    
                    Console.WriteLine();
                    Console.WriteLine("1:\tDisplay All Names");
                    Console.WriteLine("2:\tSearch By Last Name");
                    Console.WriteLine("3:\tDisplay Order History of each location");
                    Console.WriteLine("4:\tQuit");
                    Console.WriteLine();

                    int input = IntValidation(1, 4);
                    string input2;
                    var count = 0;
                    Customer customer;
                    Product ProductValue;
                    var products = storeRepository.DisplayProducts();
                    var products2 = products.ToList();
                    List<OrderDetails> orderDetails;
                    IEnumerable<Order> OrderValue;
                    IEnumerable<Customer> AllNames;
                    IEnumerable<Inventories> LocationInventory;
                    IEnumerable<ProductCat> prodCategories;
                    IEnumerable<Product> getRecoProduct;
                    IEnumerable<ComponentInventory> componentInventories;
                    List<Product> Cart;
                    List<Product> ComponentCart;
                    decimal Total = 0;
                    int tempOrderId;
                    Dictionary<string, int> HashProducts;
                    HashSet<Product> HashLoop;
                    int inventoryId;
                    switch (input)
                    {
                        case 1:
                            AllNames = storeRepository.GetNames();
                            Console.WriteLine();
                            count = 0;
                            _logger.Info($"Choosing Customer to Order for");
                            foreach (var x in AllNames)
                            {
                                Console.WriteLine($"\t{count}: {x.GetFullName()}");
                                count++;
                            }

                            if (count == 0)
                            {
                                Console.WriteLine("There are 0 Customers");
                                break;
                            }
                            var AllNamesList = AllNames.ToList();

                            Console.WriteLine($"Choose Customer to interact with or Press {AllNames.Count()} to go back");

                            input = IntValidation(0, AllNames.Count());
                            if (input != AllNames.Count())
                            {
   
                                customer = AllNames.ElementAt(input);
                                OrderValue = storeRepository.GetOrders(customer);
  
                                _logger.Info($"Displaying orders for {customer.FName} {customer.LName} {customer.CustomerId}");
                                List<OrderDetails> temp2 = new List<OrderDetails>();
                                while (true)
                                {

                                    Console.WriteLine();
                                    Console.WriteLine("Do you want to view and sort Customer Order History?");
                                    Console.WriteLine("1:\tYes");
                                    Console.WriteLine("2:\tNo");
                                    Console.WriteLine();
                                    input = IntValidation(1, 2);
                                    if (input == 2)
                                    {
                                        break;
                                    }

                                    Console.WriteLine();
                                    Console.WriteLine("What do you want to sort by?");
                                    Console.WriteLine("1:\tEarliest");
                                    Console.WriteLine("2:\tLatest");
                                    Console.WriteLine("3:\tCheapest");
                                    Console.WriteLine("4:\tExpensive");
                                    Console.WriteLine();
                                    input = IntValidation(1, 4);
                                    List<Order> orderList = OrderValue.ToList();
                                    if (input == 1)
                                    {
                                        orderList = Order.SortList(orderList, Sort.Early);
                                    }
                                    else if (input == 2)
                                    {
                                        orderList = Order.SortList(orderList, Sort.Late);
                                    }
                                    else if (input == 3)
                                    {
                                        orderList = Order.SortList(orderList, Sort.Cheap);
                                    }
                                    else if (input == 4)
                                    {
                                        orderList = Order.SortList(orderList, Sort.Expensive);
                                    }
                                    count = 0;
                                    foreach (var x in orderList)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine($"Order {count}:\tTime:{x.TimeStamp}  \nStore: {x.Location.Name}\tCost: ${x.TotalAmount}");
                                        orderDetails = storeRepository.GetOrderDetails(x).ToList();
                                        temp2.AddRange(orderDetails);
                                        var y = orderDetails;
                                        foreach (var z in y)
                                        {
                                            var i = Order.GetProductName(products.ToList(), z.ProductId);
                                            Console.WriteLine($"\t{i}\tAmount:{z.Quantity} ");
                                        }
                                        count++;
                                    }
                                }
                                Cart = new List<Product>();

                                LocationInventory = storeRepository.GetInventories(customer);
                                List<Inventories> LocationInventoryList = LocationInventory.ToList();
                                Total = 0;
                                while (true)
                                {
                                    count = 4;
                                    products = storeRepository.DisplayProducts();
                                    Console.WriteLine();
                                    foreach (var x in products)
                                    {
                                        if (count % 3 == 0)
                                        {
                                            Console.WriteLine($"\t{count - 4}: {x.ProductCost}  {x.ProductName}\t\t ");
                                        }
                                        else
                                        {
                                            Console.Write($"\t{count - 4}: {x.ProductCost}  {x.ProductName}\t\t ");
                                        }
                                        count++;
                                    }
                                    _logger.Info($"Get Recommended Items");
                                    Product product = new Product();

                                    List<Product> tempP = new List<Product>();
                                    List<Order> orderList = OrderValue.ToList();
                                    foreach (var x in orderList)
                                    {
                                        var y = storeRepository.GetOrderDetails(x).ToList();
                                        foreach (var z in y)
                                        {
                                            foreach (var t in products)
                                            {
                                                if (t.ProductId == z.ProductId)
                                                {
                                                    tempP.Add(t);
                                                }
                                            }
                                        }
                                        count++;
                                    }

                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.WriteLine("Recommended Items:\n");
                                    var getStuff = dbContext.Products.Where(x => x.ProductCategoryId == tempP[tempP.Count - 1].CategoryId).ToList();
                                    count = 0;
                                    foreach (var x in getStuff)
                                    {
                                        if (count > 2)
                                        {
                                            break;
                                        }
                                        Console.Write($"   {x.ProductName}");
                                        count++;
                                    }
                                    
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.WriteLine($"Add Product to cart or Enter {products.Count()} to purchase it\n");
                                    Console.WriteLine($"Purchasing from Default Location: {customer.DefaultLocation.Name}");
                                    Console.WriteLine($"There are {Cart.Count} Items in cart for a total of ${Total}");
                                    input = IntValidation(0, products.Count());
                                    _logger.Info($"Choose item to add to cart");
                                    if (input != products.Count())
                                    {
                                        ProductValue = products.ElementAt(input);
                                        _logger.Info($"Item chosen = {ProductValue.ProductName}");
                                        if (ProductValue.HasComponents)
                                        {
                                            componentInventories = storeRepository.GetComponents(ProductValue);
                                            ComponentCart = new List<Product>();
                                            foreach (var x in componentInventories)
                                            {
                                                foreach (var y in products2)
                                                {
                                                    if (x.ComponentProductId == y.ProductId)
                                                    {
                                                        ComponentCart.Add(y);
                                                    }
                                                }
                                            }
                                            List<Inventories> tempInv = new List<Inventories>();
                                            tempInv.AddRange(LocationInventoryList);
                                            Decimal tempTotal = Total;
                                            List<Product> tempCart = new List<Product>();
                                            tempCart.AddRange(Cart);

                                            foreach (var x in ComponentCart)
                                            {
                                                if (Order.CheckCart(x, LocationInventoryList))
                                                {
                                                    Console.WriteLine($"\t{x.ProductName} has been added to cart");
                                                    Total += x.ProductCost;
                                                    Cart.Add(x);
                                                }
                                                else
                                                {
                                                    LocationInventoryList.Clear();
                                                    LocationInventoryList.AddRange(tempInv);
                                                    Cart.Clear();
                                                    Cart.AddRange(tempCart);
                                                    Total = tempTotal;

                                                    Console.WriteLine();
                                                    Console.WriteLine("Inventory is out");

                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (Order.CheckCart(ProductValue, LocationInventoryList))
                                            {
                                                Console.WriteLine($"\t{ProductValue.ProductName} has been added to cart");
                                                Total += ProductValue.ProductCost;
                                                Cart.Add(ProductValue);
                                            }
                                            else
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine("Inventory is out");
                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (Cart.Count == 0)
                                        {

                                            Console.WriteLine();
                                            Console.WriteLine("The cart is empty, so nothing was purchased!");
                                            Console.WriteLine();
                                            break;
                                        }
                                        else
                                        {
                                            //SA.Orders(ConsumerId,StoreId,TotalAmount)
                                            Order newOrder = new Order
                                            {
                                                CustomerId = customer.CustomerId,
                                                StoreId = customer.DefaultLocation.LocationId,
                                                TotalAmount = Total,
                                                Location = customer.DefaultLocation,
                                                Customer = customer,
                                                TimeStamp = DateTime.Now,

                                            };
                                            storeRepository.AddOrder(newOrder, customer.DefaultLocation, customer);
                                            try
                                            {
                                                _logger.Info($"Saving");
                                                storeRepository.Save();
                                            }
                                            catch (DbUpdateException ex)
                                            {
                                                _logger.Error($"Failed to Save");
                                                Console.WriteLine(ex.Message);
                                            }
                                            Thread.Sleep(50);
                                            tempOrderId = dbContext.Orders.OrderByDescending(y => y.OrderId).Select(a => a.OrderId).FirstOrDefault();
                                            HashProducts = new Dictionary<string, int>();
                                            HashLoop = new HashSet<Product>();
                                            foreach (var x in Cart)
                                            {
                                                if (HashProducts.ContainsKey(x.ProductName))
                                                {
                                                    HashProducts[x.ProductName] += 1;
                                                }
                                                else
                                                {
                                                    HashProducts.Add(x.ProductName, 1);
                                                }
                                                HashLoop.Add(x);
                                            }
                                            count = 0;
                                            foreach (var x in HashLoop)
                                            {
                                                count++;
                                                Console.WriteLine(count);
                                                OrderDetails newOrderDetails = new OrderDetails
                                                {
                                                    OrderId = tempOrderId,
                                                    ProductId = x.ProductId,
                                                    Quantity = HashProducts[x.ProductName],
                                                };

                                                storeRepository.AddOrderDetails(newOrderDetails, newOrder, x);
                                                try
                                                {
                                                    _logger.Info($"Saving");
                                                    storeRepository.Save();
                                                }
                                                catch (DbUpdateException ex)
                                                {
                                                    _logger.Error($"Failed to Save");
                                                    Console.WriteLine(ex.Message);
                                                }
                                                inventoryId = dbContext.Inventory.Where(y => y.ProductId == x.ProductId && y.StoreId == customer.DefaultLocation.LocationId).Select(a => a.InventoryId).First();
                                                Thread.Sleep(50);
                                                Inventories inventories = new Inventories
                                                {
                                                    Quantity = Order.getInventory(LocationInventoryList, x.ProductId),
                                                    StoreId = customer.DefaultLocation.LocationId,
                                                    ProductId = x.ProductId,
                                                    InventoryId = inventoryId,
                                                };
                                                storeRepository.UpdateInventory(inventories);
                                                try
                                                {
                                                    _logger.Info($"Saving");
                                                    storeRepository.Save();
                                                }
                                                catch (DbUpdateException ex)
                                                {
                                                    _logger.Error($"Failed to Save");
                                                    Console.WriteLine(ex.Message);
                                                }
                                            }


                                        }
                                        break;
                                    }
                                }
                            }
                            break;
                        case 2:
                            _logger.Info($"Search for name name");
                            do
                            {
                                Console.WriteLine("Please enter Full/Parital Last Name to search by");
                                input2 = Console.ReadLine();
                                if (input2.Length < 200 && input2.Length > 0)
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Please enter word with 1 - 199 characters, ");
                                }
                            } while (true);

                            AllNames = storeRepository.GetNames(input2);
                            Console.WriteLine();
                            count = 0;

                            foreach (var x in AllNames)
                            {
                                Console.WriteLine($"\t{count}: {x.GetFullName()}");
                                count++;
                            }
                            if (count == 0)
                            {
                                Console.WriteLine("Your search had 0 results");
                            }
                            break;
                        case 3:
                            _logger.Info($"Display All orders by each location");
                            var n = storeRepository.GetOrders().ToList();
                            var p = n.OrderByDescending(k => k.Location.LocationId);


                            foreach (var a in p)
                            {
                                var b = dbContext.Consumer.ToList();
                                var z = dbContext.Store.ToList();
                                string name = "John Albert";
                                foreach (var m in z)
                                {
                                    if(m.Consumer.Where(c => c.ConsumerId == a.CustomerId).Select(x=>x.ConsumerId).FirstOrDefault() == a.CustomerId)
                                    {
                                        name = m.Consumer.Where(c => c.ConsumerId == a.CustomerId).Select(x => x.Fname).FirstOrDefault() + " " + m.Consumer.Where(c => c.ConsumerId == a.CustomerId).Select(x => x.Lname).FirstOrDefault();
                                    }
                           }
                                Console.WriteLine($"{ a.Location.Name}");
                                Console.WriteLine($"\t{name}\t{a.TimeStamp}\t{a.TotalAmount}");
                                Console.WriteLine();
                            }
                            break;
                        case 4:
                            _logger.Info($"Exiting Application");
                            return;
                    }
                }


            }

        }
        public static StoreApplicationContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<StoreApplicationContext>();
            optionsBuilder
              //  .UseLoggerFactory(AppLoggerFactory)
                .UseSqlServer(SecretConfiguration.ConnectionString); 

            return new StoreApplicationContext(optionsBuilder.Options);
        }



        static int IntValidation(int min, int max, string error = "Please enter a valid input")
        {
            bool CheckInt;
            int CheckedInt;
            while (true)
            {
                string input = Console.ReadLine();
                CheckInt = Int32.TryParse(input, out CheckedInt);
                if (CheckInt && CheckedInt >= min && CheckedInt <= max)
                {
                    return CheckedInt;
                }
                else
                {
                   Console.WriteLine(error);
                }
            }
        }

    }
}
