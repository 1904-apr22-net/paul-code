using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.Library
{
    public class ProductCat
    {
        /// <summary>
        /// Id of Product
        /// </summary>
        public int ProductCategoryId { get; set; }
        /// <summary>
        /// Category Name
        /// </summary>
        public string CategoryName { get; set; }
        /// <summary>
        /// Products that reference this
        /// </summary>
        public List<Product> Products { get; set; }

    }
}
