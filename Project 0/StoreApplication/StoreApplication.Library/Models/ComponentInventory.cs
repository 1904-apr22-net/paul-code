using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.Library
{
    public class ComponentInventory
    {
        /// <summary>
        /// ID of Component
        /// </summary>
        public int ComponentId { get; set; }
        /// <summary>
        /// Base Product ID
        /// </summary>
        public int BaseProductId { get; set; }
        /// <summary>
        /// Component Id -- Combine to make Base Product
        /// </summary>
        public int ComponentProductId { get; set; }

        public Product BaseProduct { get; set; }
        public Product ComponentProduct { get; set; }

    }
}
