using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.Library
{
    public class HeadQuarters
    {
        public HeadQuarters()
        {
            Locations = new List<Location>();
        }
        public IList<Location> Locations;

        public IList<Customer> SearchByName(string FName = null, string LName = null)
        {
            throw new NotImplementedException();
        }

        public IList<Order> AllOrdersByStore()
        {
            throw new NotImplementedException();
        }
    }
}
