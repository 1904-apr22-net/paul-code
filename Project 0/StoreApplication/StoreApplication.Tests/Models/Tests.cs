using StoreApplication.DataAccess;
using StoreApplication.DataAccess.Entities;
using StoreApplication.Library;
using StoreApplication.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StoreApplication.Tests.Models
{
     public class Tests
    {
        private Order order { get; set; } = new Order();

        [Fact]
        public void InitializeOrder()
        {
            Assert.NotNull(order);
        }
        [Fact]
        public void InitializeOrderDetails()
        {
            OrderDetails x = new OrderDetails();
            order.OrderDetails.Add(x);
            Assert.NotNull(order.OrderDetails[0]);
        }



        private Customer customer { get; set; } = new Customer();
        [Fact]
        public void InitializeCustomer()
        {
            Assert.NotNull(customer);
        }
        [Fact]
        public void GetFullCustName()
        {
            customer.FName = "Paul";
            customer.LName = "Grimes";
            Assert.Equal(customer.FName + ' ' + customer.LName , customer.GetFullName());
        }


        private Location location { get; set; } = new Location();
        [Fact]
        public void InitializeLocation()
        {
            Assert.NotNull(location);
        }
        [Fact]
        public void InitializeCustomerLocation()
        {
            location.Customers.Add(customer);
            Assert.NotNull(location.Customers[0]);
        }
        private Product product { get; set; } = new Product();

        [Fact]
        public void InitializeProduct()
        {
            Assert.NotNull(product);
        }
           

    }
}
