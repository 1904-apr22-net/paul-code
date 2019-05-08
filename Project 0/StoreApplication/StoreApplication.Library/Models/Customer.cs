using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreApplication.Library
{
    public class Customer
    {
         public int StoreId { get; set; }

        /// <summary>
        /// First Name
        /// </summary>
        public string FName { get; set; }
        /// <summary>
        /// Last Name
        /// </summary>
        public string LName { get; set; }
        /// <summary>
        /// State (USA)
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// Customer ID
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// Location Class -- 1 per customer
        /// </summary>
        public Location DefaultLocation { get; set; }

        /// <summary>
        /// List Of customers personal orders
        /// </summary>

        public IList<Order> Orders { get; set; } = new List<Order>();
        /// <summary>
        /// Combine First Name + Last Name
        /// </summary>
        /// <returns> Full Name </returns>
        public string GetFullName()
        {
            return FName + " " + LName;
        }

        
        // private Location _lastLocation;
        //private DateTime _lastTime;
    }
    public enum Sort
    {
        Early = 0,
        Late = 1,
        Cheap = 2,
        Expensive = 3
    }
}
