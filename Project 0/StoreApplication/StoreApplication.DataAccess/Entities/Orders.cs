using System;
using System.Collections.Generic;

namespace StoreApplication.DataAccess.Entities
{
    public partial class Orders
    {
        public Orders()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        public int OrderId { get; set; }
        public int ConsumerId { get; set; }
        public int StoreId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime Time { get; set; }

        public virtual Consumer Consumer { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}
