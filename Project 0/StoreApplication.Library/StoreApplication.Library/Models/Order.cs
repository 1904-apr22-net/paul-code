using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.Library
{
    public class Order
    {
        //public Order(int OrderId, Location Location, Customer Customer, DateTime TimeStamp, List<Product> Products)
        //{
        //    this.OrderId = OrderId;
        //    this.Location = Location;
        //    this.Customer = Customer;
        //    this.TimeStamp = TimeStamp;
        //    this.Products = Products;
        //}


        public int OrderId { get; set; }
        public Location Location { get; set; }
        public Customer Customer { get; set; }
        public DateTime TimeStamp { get; set; }
        public Decimal TotalAmount { get; set; }
        public IList<Product> Products { get; set; } = new List<Product>();
    }
}
