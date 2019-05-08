using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.Library
{
    public class OrderDetails
    {
        /// <summary>
        /// Order Item Id
        /// </summary>
        public int OrderItemId { get; set; }
        /// <summary>
        /// Reference to product
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// reference to order
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// Amount of this item in order
        /// </summary>
        public int Quantity { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }

    }
}
