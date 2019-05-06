using System;
using System.Collections.Generic;

namespace StoreApplication.DataAccess.Entities
{
    public partial class Products
    {
        public Products()
        {
            ComponentsBaseProduct = new HashSet<Components>();
            ComponentsComponentProduct = new HashSet<Components>();
            Inventory = new HashSet<Inventory>();
            OrderItem = new HashSet<OrderItem>();
        }

        public int ProductId { get; set; }
        public int ProductCategoryId { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public decimal Price { get; set; }
        public bool ComponentBit { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ICollection<Components> ComponentsBaseProduct { get; set; }
        public virtual ICollection<Components> ComponentsComponentProduct { get; set; }
        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}
