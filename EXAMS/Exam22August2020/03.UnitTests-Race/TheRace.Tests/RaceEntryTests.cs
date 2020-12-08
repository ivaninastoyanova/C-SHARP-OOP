using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void UnitCarConstructorShoulWorkCorrect()
        {
            UnitCar unitCar = new UnitCar("audi", 200, 2.2);
            Assert.AreEqual(unitCar.Model, "audi");
            Assert.AreEqual(unitCar.HorsePower, 200);
            Assert.AreEqual(unitCar.CubicCentimeters, 2.2);
        }
        [Test]
        public void UnitDriverConstructorShoulWorkCorrect()
        {
            UnitCar unitCar = new UnitCar("audi", 200, 2.2);
            UnitDriver unitDriver = new UnitDriver("ivan", unitCar);
            Assert.AreEqual(unitDriver.Name, "ivan");
            Assert.AreEqual(unitDriver.Car , unitCar);
        }
        [Test]
        public void UnitDriverConstructorShoulThrowExpIfDriverNameIsNull()
        {
            UnitCar unitCar = new UnitCar("audi", 200, 2.2);
            Assert.Throws<ArgumentNullException>(() =>
            {
                UnitDriver unitDriver = new UnitDriver(null, unitCar);
            });
        }
        [Test]
        public void RaceEntryConstructorShoulWorkCorrect()
        {
            RaceEntry raceEntry = new RaceEntry();
            Assert.AreEqual(0, raceEntry.Counter);
        }
        [Test]
        public void AddDriverMethodShoulThrowExpIfDriverIsNull()
        {
            RaceEntry raceEntry = new RaceEntry();
            Assert.Throws<InvalidOperationException>(() =>
            {
                raceEntry.AddDriver(null);
            });
        }
        [Test]
        public void AddDriverMethodShoulThrowExpIfDriverWithSameName()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitCar unitCar = new UnitCar("audi", 200, 2.2);
            UnitDriver unitDriver = new UnitDriver("gosho", unitCar);
            raceEntry.AddDriver(unitDriver);
            Assert.Throws<InvalidOperationException>(() =>
            {
                raceEntry.AddDriver(unitDriver);
            });
        }
        [Test]
        public void AddDriverMethodShoulWorkCorrect()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitCar unitCar = new UnitCar("audi", 200, 2.2);
            UnitDriver unitDriver1 = new UnitDriver("gosho", unitCar);
            UnitDriver unitDriver2 = new UnitDriver("pesho", unitCar);
            raceEntry.AddDriver(unitDriver1);
            raceEntry.AddDriver(unitDriver2);
            Assert.AreEqual(raceEntry.Counter, 2);
        }
        [Test]
        public void CalculateAverageHorsePowerShoulThrowExpIfNotEnoughParticipants()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitCar unitCar = new UnitCar("audi", 200, 2.2);
            UnitDriver unitDriver = new UnitDriver("gosho", unitCar);
            raceEntry.AddDriver(unitDriver);
            Assert.Throws<InvalidOperationException>(() =>
            {
                raceEntry.CalculateAverageHorsePower();
            });
        }
        [Test]
        public void CalculateAverageHorsePowerMethodShoulWorkCorrect()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitCar unitCar1 = new UnitCar("audi", 200, 2.2);
            UnitCar unitCar2 = new UnitCar("bmw", 300, 2.2);
            UnitDriver unitDriver1 = new UnitDriver("gosho", unitCar1);
            UnitDriver unitDriver2 = new UnitDriver("pesho", unitCar2);
            raceEntry.AddDriver(unitDriver1);
            raceEntry.AddDriver(unitDriver2);
            double result= raceEntry.CalculateAverageHorsePower();
            double expectedResult = 250.0;
            Assert.AreEqual(expectedResult, result);
        }
    }
}