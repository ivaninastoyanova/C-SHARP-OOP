using NUnit.Framework;
using System;

namespace Store.Tests
{
    public class StoreManagerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ProductConstructorShouldWorkCorrectly()
        {
            Product product = new Product("product", 5, 1.25m);
            Assert.AreEqual(product.Name , "product");
            Assert.AreEqual(product.Quantity, 5);
            Assert.AreEqual(product.Price ,  1.25m);
        }
        [Test]
        public void StoreManagerConstructorShouldWorkCorrectly()
        {
            StoreManager storeManager = new StoreManager();
            Assert.AreEqual(storeManager.Products.Count, 0);
        }
        [Test]
        public void StoreManagerAddMethodShouldWorkCorrectly()
        {
            StoreManager storeManager = new StoreManager();
            Product product = new Product("meso", 2, 5.25m);
            storeManager.AddProduct(product);
            Assert.AreEqual(storeManager.Count, 1);
        }
        [Test]
        public void StoreManagerAddMethodShouldThrowArgExpIfQuantity0()
        {
            StoreManager storeManager = new StoreManager();
            Product product = new Product("qicaaa", 0, 5.25m);
            Assert.Throws<ArgumentException>(() =>
           {
               storeManager.AddProduct(product);
           });
        }
        [Test]
        public void StoreManagerAddMethodShouldThrowArgExpIfQuantityBelow0()
        {
            StoreManager storeManager = new StoreManager();
            Product product = new Product("qica", -1, 5.25m);
            Assert.Throws<ArgumentException>(() =>
            {
                storeManager.AddProduct(product);
            });
        }
        [Test]
        public void StoreManagerAddMethodShouldThrowArgNullExpIfNull()
        {
            StoreManager storeManager = new StoreManager();
            Assert.Throws<ArgumentNullException>(() =>
            {
                storeManager.AddProduct(null);
            });
        }
        [Test]
        public void StoreManagerBuyProductMethodShouldThrowArgNullExpIfNull()
        {
            StoreManager storeManager = new StoreManager();
            Product product = new Product("qicaaa", 2, 5.25m);
            storeManager.AddProduct(product);
            Assert.Throws<ArgumentNullException>(() =>
            {
                storeManager.BuyProduct(null, 1);
            });
        }
        [Test]
        public void StoreManagerBuyProductMethodShouldThrowArgExpIfNotEnoughQuantity()
        {
            StoreManager storeManager = new StoreManager();
            Product product = new Product("qica", 2, 5.25m);
            storeManager.AddProduct(product);
            Assert.Throws<ArgumentException>(() =>
            {
                storeManager.BuyProduct(product.Name, 3);
            });
        }
        [Test]
        public void StoreManagerBuyProductMethodShouldWorkCorrectly()
        {
            StoreManager storeManager = new StoreManager();
            Product product = new Product("meso", 2, 5.25m);
            storeManager.AddProduct(product);
            decimal expectedPrice = product.Price * product.Quantity;
            storeManager.BuyProduct(product.Name, 2);
            decimal finalPrice = product.Price * 2;
            Assert.AreEqual(expectedPrice , finalPrice);
            Assert.AreEqual(product.Quantity, 0);
        }
        [Test]
        public void GetMostExpensiveProductShouldWorkCorrect()
        {
            StoreManager storeManager = new StoreManager();
            Product product1 = new Product("meso", 2, 5.50m);
            Product product2 = new Product("banan", 2, 1.00m);
            Product product3 = new Product("qica", 2, 3.50m);
            storeManager.AddProduct(product1);
            storeManager.AddProduct(product2);
            storeManager.AddProduct(product3);
            Product mostExpensveProduct = storeManager.GetTheMostExpensiveProduct();
            Assert.AreEqual(mostExpensveProduct.Price , product1.Price);
        }
        [Test]
        public void GetMostExpensiveProductShouldReturnDefaultValueIfNoProducts()
        {
            StoreManager storeManager = new StoreManager();
            Product mostExpensveProduct = storeManager.GetTheMostExpensiveProduct();
            Assert.AreEqual(mostExpensveProduct, null);
        }
    }
}