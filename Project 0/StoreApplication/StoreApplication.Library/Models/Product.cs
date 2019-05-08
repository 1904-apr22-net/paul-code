using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.Library
{
    public class Product
    {
        /// <summary>
        /// Cost of Product
        /// </summary>
        public decimal ProductCost { get; set; }
        /// <summary>
        /// Product Name
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// Product Id
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// Quantity of product available
        /// </summary>
        public int quantitySale { get; set; }
        public string ProductDesc { get; set; }
        /// <summary>
        /// Category Reference
        /// </summary>
        public ProductCat CategoryRef { get; set; }
        /// <summary>
        /// Category
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// Category ID
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// check if this products is made of other products
        /// </summary>
        public bool HasComponents { get; set; }

        public ProductCat ProductCat { get; set; }
        /// <summary>
        /// List of components
        /// </summary>
        public IList<ComponentInventory> BaseComponents { get; set; } = new List<ComponentInventory>();
        //public IList<Inventories> Inventory { get; set; } = new List<Inventories>();

        public IList<ComponentInventory> Components { get; set; } = new List<ComponentInventory>();
        public IList<Inventories> Inventory { get; set; } = new List<Inventories>();
        public IList<OrderDetails>OrderDetails { get; set; }
    }
}
