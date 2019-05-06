using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.Library
{
    public class Product
    {
        //public Product(int ProductCost, string ProductName, int ProductId, int ProductCount, bool HasComponents = false)
        //{
        //    this.ProductCost = ProductCost;
        //    this.ProductName = ProductName;
        //    this.ProductId = ProductId;
        //    this.ProductCount = ProductCount;
        //    this.HasComponents = HasComponents;
        //}


        public decimal ProductCost { get; set; }
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public int ProductCount { get; set; }
        

        public string Category { get; set; }
        public int CategoryId { get; set; }

        public bool HasComponents { get; set; }
        public IList<ComponentInventory> Components { get; set; } = new List<Product>();
    }
}
