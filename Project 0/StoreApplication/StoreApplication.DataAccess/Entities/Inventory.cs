using System;
using System.Collections.Generic;

namespace StoreApplication.DataAccess.Entities
{
    public partial class Inventory
    {
        public int InventoryId { get; set; }
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Products Product { get; set; }
        public virtual Store Store { get; set; }
    }
}
