using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.Library
{
   public class Inventories
    {
        /// <summary>
        /// Inventory ID
        /// </summary>
        public int InventoryId { get; set; }
        /// <summary>
        /// Store ID -- Reference
        /// </summary>
        public int StoreId { get; set; }
        /// <summary>
        /// Product ID -- Referecne
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// Quantity -- Of product at location
        /// </summary>
        public int Quantity { get; set; }

        public Product Product { get; set; }
        public Location Store { get; set; }

    }
}
