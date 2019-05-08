using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreApplication.Library
{
    public class Order
    {
        /// <summary>
        /// Order Id
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// Customer Id
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// Store Id
        /// </summary>
        public int StoreId { get; set; }
        /// <summary>
        /// Location
        /// </summary>
        public Location Location { get; set; }
        /// <summary>
        /// Customer
        /// </summary>
        public Customer Customer { get; set; }
        /// <summary>
        /// TimeStamp
        /// </summary>
        public DateTime TimeStamp { get; set; }
        /// <summary>
        /// Total Amount
        /// </summary>
        public Decimal TotalAmount { get; set; }
        /// <summary>
        /// Order details connectd to order
        /// </summary>
        public IList<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();























        public static List<Order> SortList(List<Order> orders, Sort sort)
        {
            if (sort == Sort.Early)
            {
                return orders.OrderBy((x) => x.TimeStamp).ToList();
               // var orders2 = orders.OrderBy((x) => x.TimeStamp).Select((y)=>y.TimeStamp).ToList();
            }
            
            else if (sort == Sort.Late)
            {
                var orders2 = orders.OrderByDescending((x) => x.TimeStamp).ToList();
                return orders2;
            }
            else if (sort == Sort.Cheap)
            {
                var orders2 = orders.OrderBy((x) => x.TotalAmount).ToList();
                return orders2;
            }
            else if (sort == Sort.Expensive)
            {
                var orders2 = orders.OrderByDescending((x) => x.TotalAmount).ToList();
                return orders2;
            }
            return orders;
        }


        public static string GetProductName(List<Product> products, int ProductId)
        {
            var i = products.Where((x) => x.ProductId == ProductId).Select((a) => a.ProductName).FirstOrDefault();
            int b = ProductId;
            return i;
        }
        public static bool CheckCart(Product product, List<Inventories> inventories)
        {
            var quant = inventories.Where((t) => t.ProductId == product.ProductId).Select((x) => x.Quantity).FirstOrDefault();

            if(quant - 1 < 0)
            {
                return false;
            }
            else
            {
                int count = 0;
               foreach(var x in inventories)
                {
                    if(x.ProductId == product.ProductId)
                    {
                        x.Quantity -= 1;      
                        return true;
                    }
                    count++;
                }
            }

            return false;

        }

        public static int getInventory(List<Inventories> inventories, int ProductId)
        {
           return inventories.Where(x => x.ProductId == ProductId).Select(y => y.Quantity).FirstOrDefault();
        }
    }
}
