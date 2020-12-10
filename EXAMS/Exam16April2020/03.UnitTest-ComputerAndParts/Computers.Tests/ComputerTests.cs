namespace Computers.Tests
{
    using NUnit.Framework;
    using System;

    public class ComputerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RartConstructorShouldWork()
        {
            Part part = new Part("platka", 500m);
            Assert.AreEqual(part.Name, "platka");
            Assert.AreEqual(part.Price, 500m);
        }
        [Test]
        public void ComputerConstructorShouldWork()
        {
            Computer computer = new Computer("kompa");
            Assert.AreEqual(computer.Name, "kompa");
            Assert.AreEqual(computer.Parts.Count, 0);
        }
        [Test]
        public void ComputerConstructorShouldThrowExpWhenNullName()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Computer computer = new Computer(null);
            });
        }
        [Test]
        public void ComputerConstructorShouldThrowExpWhenEmptyName()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Computer computer = new Computer(" ");
            });
        }
        [Test]
        public void TotalPriceShouldWork()
        {
            Computer computer = new Computer("kompa");
            Part part1 = new Part("ekran", 200m);
            Part part2 = new Part("klaviatura", 100m);
            computer.AddPart(part1);
            computer.AddPart(part2);
            var price = computer.TotalPrice;
            Assert.AreEqual(price, 300m);
        }
        [Test]
        public void AddPartShouldWork()
        {
            Computer computer = new Computer("kompa");
            Part part1 = new Part("ekran", 200m);
            Part part2 = new Part("klaviatura", 100m);
            computer.AddPart(part1);
            computer.AddPart(part2);
            Assert.AreEqual(2, computer.Parts.Count);
        }
        [Test]
        public void AddPartShouldThrowExpWhenNullPart()
        {
            Computer computer = new Computer("kompa");
            Assert.Throws<InvalidOperationException>(() =>
            {
                computer.AddPart(null);
            });
        }
        [Test]
        public void RemovePartShouldWork()
        {
            Computer computer = new Computer("kompa");
            Part part1 = new Part("ekran", 200m);
            Part part2 = new Part("klaviatura", 100m);
            computer.AddPart(part1);
            computer.AddPart(part2);
            computer.RemovePart(part1);
            Assert.AreEqual(1, computer.Parts.Count);
        }
        [Test]
        public void GetPartShouldWork()
        {
            Computer computer = new Computer("kompa");
            Part part1 = new Part("ekran", 200m);
            Part part2 = new Part("klaviatura", 100m);
            computer.AddPart(part1);
            computer.AddPart(part2);
            var newPart = computer.GetPart(part1.Name);
            Assert.AreEqual(part1, newPart);
        }
    }
}