using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreApplication.Library
{
    public class Location
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// State
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// Location Id
        /// </summary>
        public int LocationId { get; set; }

        /// <summary>
        /// Orders List at location
        /// </summary>
        public IList<Order> Orders { get; set; } = new List<Order>();

        /// <summary>
        /// Customers at location
        /// </summary>
        public IList<Customer> Customers { get; set; } = new List<Customer>();
        /// <summary>
        /// Inventory of location
        /// </summary>
        public IList<Inventories> Inventory { get; set; } = new List<Inventories>();


    }
}
