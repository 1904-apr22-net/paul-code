using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreApplication.Library
{
    public class Location
    {
        //public Location(string State, string Name, int LocationId)
        //{
        //    Products = new List<Product>();
        //    Orders = new List<Order>();
        //    this.State = State;
        //    this.Name = Name;
        //    this.LocationId = LocationId;
        //}


        public string Name { get; set; }
        public string State { get; set; }

        public int LocationId { get; set; }

        public IList<Product> Products { get; set; } = new List<Product>();
        public IList<Order> Orders { get; set; } = new List<Order>();
        public IList<Customer> Customers { get; set; } = new List<Customer>();




        public bool LowerMultipleIngredients()
        {
            return true;
        }
        public bool CheckCustomerOrder2hrs(string Email)
        {
            var HistoryCheck = Orders.Where(x => x.Customer.Email == Email && x.Address.Address == this.Address)
                .OrderBy(x => x.TimeStamp)
                .Select((x) => x.TimeStamp).FirstOrDefault();
            DateTime Local = DateTime.Now;

            if((HistoryCheck - Local).TotalMinutes > 120)
            {
                return false;
            }

            return true; 
        }
        public bool DecreaseProduct(int ProductId, int Amount)
        { 
            if(!CheckProductId(ProductId) || !(CountProduct(ProductId) - Amount >= 0)){
                return false;
            }

            foreach (var Product in Products)
            {
                if(ProductId == Product.ProductId)
                {
                    Product.ProductCount -= Amount;
                    return true;
                }
            }
            return false;
        }

        public int CountProduct(int ProductId)
        {
            /* return (from p in Products
                     where p.ProductId == ProductId
                     select p.ProductCount).FirstOrDefault();*/
            return  (Products.Where((p) => p.ProductId == ProductId)
                    .Select((c) => c.ProductCount)).FirstOrDefault();
        }

        public bool CheckProductId(int ProductId)
        {
            if (Products.Any(x => x.ProductId == ProductId)){
                return true;
            }
            return false;
        }
    }
}
