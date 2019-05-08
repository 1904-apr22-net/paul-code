using System;
using System.Collections.Generic;

namespace StoreApplication.DataAccess.Entities
{
    public partial class Store
    {
        public Store()
        {
            Consumer = new HashSet<Consumer>();
            Inventory = new HashSet<Inventory>();
            Orders = new HashSet<Orders>();
        }

        public int StoreId { get; set; }
        public string Name { get; set; }
        public string State { get; set; }

        public virtual ICollection<Consumer> Consumer { get; set; }
        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
