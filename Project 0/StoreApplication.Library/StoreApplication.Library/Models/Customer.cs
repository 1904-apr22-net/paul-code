using System;

namespace StoreApplication.Library
{
    public class Customer
    {

        //public Customer(string FName, string LName, string State, int CustomerId)
        //{
        //    this.FName = FName;
        //    this.LName = LName;
        //    this.State = State;
        //    this.CustomerId = CustomerId;
        //}
        public string FName { get; set; }
        public string LName { get; set; }

        public string State { get; set; }
        public int CustomerId { get; set; }

        public Location DefaultLocation { get; set; }



        public string GetFullName()
        {
            return FName + " " + LName;
        }

        // private Location _lastLocation;
        //private DateTime _lastTime;
    }
}
