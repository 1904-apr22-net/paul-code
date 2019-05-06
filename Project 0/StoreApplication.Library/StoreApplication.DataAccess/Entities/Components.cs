using System;
using System.Collections.Generic;

namespace StoreApplication.DataAccess.Entities
{
    public partial class Components
    {
        public int ComponentId { get; set; }
        public int BaseProductId { get; set; }
        public int ComponentProductId { get; set; }

        public virtual Products BaseProduct { get; set; }
        public virtual Products ComponentProduct { get; set; }
    }
}
