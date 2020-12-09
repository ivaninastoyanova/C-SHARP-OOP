using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Computers.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ComputerConstructorShouldWork()
        {
            Computer computer = new Computer("lenovo", "ideapad", 2000m);
            Assert.AreEqual(computer.Manufacturer, "lenovo");
            Assert.AreEqual(computer.Model, "ideapad");
            Assert.AreEqual(computer.Price, 2000m);
        }
        [Test]
        public void ComputerManagerConstructorShouldWork()
        {
            ComputerManager computerManager = new ComputerManager();
            Assert.AreEqual(0, computerManager.Count);
            //ili da e po dr nachin kaunta
        }
        [Test]
        public void AddComputerMethodShoulThrowExpWhenSameComputer()
        {
            ComputerManager computerManager = new ComputerManager();
            Computer computer = new Computer("lenovo", "ideapad", 2000m);
            computerManager.AddComputer(computer);
            Assert.Throws<ArgumentException>(() =>
            {
                computerManager.AddComputer(computer);
            });
        }
        [Test]
        public void AddComputerMethodShoulThrowExpWhenNullValue()
        {
            ComputerManager computerManager = new ComputerManager();
            Computer computer = new Computer("lenovo", "ideapad", 2000m);
            computerManager.AddComputer(computer);
            Assert.Throws<ArgumentNullException>(() =>
            {
                computerManager.AddComputer(null);
            });
        }

        [Test]
        public void AddComputerMethodShoulWork() //moje da iska da ima samo razlika v edno- marka ili model
        {
            ComputerManager computerManager = new ComputerManager();
            Computer computer = new Computer("lenovo", "ideapad", 2000m);
            Computer computer2 = new Computer("hp", "model", 2000m);
            computerManager.AddComputer(computer);
            computerManager.AddComputer(computer2);
            Assert.AreEqual(computerManager.Count, 2);
        }
        [Test]
        public void GetComputerMethodShoulThrowExpWhenNotFound()
        {
            ComputerManager computerManager = new ComputerManager();
            Computer computer = new Computer("lenovo", "ideapad", 2000m);
            
            computerManager.AddComputer(computer);
            Assert.Throws<ArgumentException>(() =>
            {
                computerManager.GetComputer(computer.Manufacturer, "razlichen");
            });
        }
        [Test]
        public void GetComputerMethodShoulThrowExpWhenNullManufacturer()
        {
            ComputerManager computerManager = new ComputerManager();
            Computer computer = new Computer("lenovo", "ideapad", 2000m);

            computerManager.AddComputer(computer);
            Assert.Throws<ArgumentNullException>(() =>
            {
                computerManager.GetComputer(null, "razlichen");
            });
        }
        [Test]
        public void GetComputerMethodShoulThrowExpWhenNullModel()
        {
            ComputerManager computerManager = new ComputerManager();
            Computer computer = new Computer("lenovo", "ideapad", 2000m);

            computerManager.AddComputer(computer);
            Assert.Throws<ArgumentNullException>(() =>
            {
                computerManager.GetComputer("hp", null);
            });
        }
        [Test]
        public void GetComputerMethodShoulWork() 
        {
            ComputerManager computerManager = new ComputerManager();
            Computer computer = new Computer("lenovo", "ideapad", 2000m);
            computerManager.AddComputer(computer);
            Computer newComp= computerManager.GetComputer(computer.Manufacturer, computer.Model);
            //Assert.AreEqual(computer, newComp);
            Assert.AreEqual(computer.Manufacturer, newComp.Manufacturer);
            Assert.AreEqual(computer.Model, newComp.Model);
        }
      
        [Test]
        public void GetComputersByManufacturerMethodShoulWork()
        {
            ComputerManager computerManager = new ComputerManager();
            Computer computer1 = new Computer("lenovo", "ideapad", 2000m);
            Computer computer2 = new Computer("hp", "komp", 1500m);
            Computer computer3 = new Computer("lenovo", "drmodel", 2200m);
            computerManager.AddComputer(computer1);
            computerManager.AddComputer(computer2);
            computerManager.AddComputer(computer3);
            ICollection<Computer> computers = computerManager.GetComputersByManufacturer("lenovo");
            Assert.AreEqual(2, computers.Count);

        }
        [Test]
        public void GetComputerByManufacturerMethodShoulThrowExpWhenNullManufacturer()
        {
            ComputerManager computerManager = new ComputerManager();
            Computer computer = new Computer("lenovo", "ideapad", 2000m);
            computerManager.AddComputer(computer);
            Assert.Throws<ArgumentNullException>(() =>
            {
                computerManager.GetComputersByManufacturer(null);
            });
        }
        [Test]
        public void GetComputersByManufacturerMethodShoulReturnEmptyCollection()
        {
            ComputerManager computerManager = new ComputerManager();
            Computer computer1 = new Computer("lenovo", "ideapad", 2000m);
            Computer computer2 = new Computer("hp", "komp", 1500m);
            Computer computer3 = new Computer("lenovo", "drmodel", 2200m);
            computerManager.AddComputer(computer1);
            computerManager.AddComputer(computer2);
            computerManager.AddComputer(computer3);
            var collection = computerManager.GetComputersByManufacturer("Asus").ToList();

            CollectionAssert.IsEmpty(collection);
        }
        [Test]
        public void RemoveComputerMethodShoulWork()
        {
            ComputerManager computerManager = new ComputerManager();
            Computer computer = new Computer("lenovo", "ideapad", 2000m);
            computerManager.AddComputer(computer);
            computerManager.RemoveComputer(computer.Manufacturer, computer.Model);
            Assert.AreEqual(computerManager.Count, 0);
        }
        [Test]
        public void RemoveComputerMethodShoulThrowExpWhenNullManufact()
        {
            ComputerManager computerManager = new ComputerManager();
            Computer computer = new Computer("lenovo", "ideapad", 2000m);
            computerManager.AddComputer(computer);

            Assert.Throws<ArgumentNullException>(() =>
            {
                var computer = computerManager.RemoveComputer(null, "Model");
            });
        }
        [Test]
        public void RemoveComputerMethodShoulThrowExpWhenNullModel()
        {
            ComputerManager computerManager = new ComputerManager();
            Computer computer = new Computer("lenovo", "ideapad", 2000m);
            computerManager.AddComputer(computer);

            Assert.Throws<ArgumentNullException>(() =>
            {
                var computer = computerManager.RemoveComputer("lenovo", null);
            });
        }
    }
}