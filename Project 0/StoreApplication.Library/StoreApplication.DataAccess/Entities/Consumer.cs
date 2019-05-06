using System;
using System.Collections.Generic;

namespace StoreApplication.DataAccess.Entities
{
    public partial class Consumer
    {
        public Consumer()
        {
            Orders = new HashSet<Orders>();
        }

        public int ConsumerId { get; set; }
        public int StoreId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string State { get; set; }

        public virtual Store Store { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
