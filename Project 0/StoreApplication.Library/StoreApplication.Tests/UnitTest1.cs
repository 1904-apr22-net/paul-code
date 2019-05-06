using StoreApplication.Library;
using System;
using Xunit;

namespace StoreApplication.Tests
{
    public class LocationTest
    {
        [Fact]
        public void CheckProductId()
        {
            Location Location = new Location();
            Product Product = new Product(5, "Pineapple", 2, 4);
            Location.Products.Add(Product);

            Assert.True(Location.CheckProductId(2));
            Assert.False(Location.CheckProductId(1));
        }

        [Fact]
        public void CountProduct()
        {
            Location Location = new Location();
            Product Product = new Product(5, "Pineapple", 2, 4);
            Location.Products.Add(Product);

            Assert.True(Location.CountProduct(2) == 4);
            Assert.True(Location.CountProduct(10) == 0);
        }
        [Fact]
        public void DecreaseProduct()
        {
            Location Location = new Location();
            Product Product = new Product(5, "Pineapple", 2, 4);
            Location.Products.Add(Product);
            Location.DecreaseProduct(2,2);

            Assert.True(Location.CountProduct(2) == 2);
            Assert.False(Location.CountProduct(10) == 2);
        }

        [Fact]
        public void DecreaseProductReturn()
        {
            Location Location = new Location();
            Product Product = new Product(5, "Pineapple", 2, 4);
            Location.Products.Add(Product);

            Assert.True(Location.DecreaseProduct(2, 2));
            Assert.False(Location.DecreaseProduct(2, 3));

        }
    }
}
