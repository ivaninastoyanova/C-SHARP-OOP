namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    public class RobotsTests
    {
        [Test]
        public void RobotConstructorWorkProperly()
        {
            Robot robot = new Robot("ime", 20);
            Assert.AreEqual(robot.Name, "ime");
            Assert.AreEqual(robot.Battery, 20);
            Assert.AreEqual(robot.MaximumBattery, 20);
        }
        [Test]
        public void WhenRobotManagerIsCreatedCapacityIsSet()
        {
            RobotManager robotManager = new RobotManager(10);
            Assert.AreEqual(robotManager.Capacity, 10);
           
        }
        [Test]
        public void WhenRobotManagerIsCreatedWithNegativeCapacityThrowException()
        {
           
            Assert.Throws<ArgumentException>(() => 
            { 
                RobotManager robotManager = new RobotManager(-1);
            });

        }
        [Test]
        public void WhenRobotManagerIsCreatedCountIsZero()
        {
            RobotManager robotManager = new RobotManager(10);
            Assert.AreEqual(robotManager.Count, 0);

        }
        [Test]
        public void AddWorkFine()
        {
            RobotManager robotManager = new RobotManager(10);
            robotManager.Add(new Robot("ime", 10));
            Assert.AreEqual(robotManager.Count, 1);
            robotManager.Add(new Robot("ime2", 11));
            Assert.AreEqual(robotManager.Count, 2);
        }
        [Test]
        public void AddThrowsInvExpWhenSameName()
        {
            RobotManager robotManager = new RobotManager(10);
            Robot robot1 = new Robot("ivan", 20);
            robotManager.Add(robot1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(robot1);
            });
        }
        [Test]
        public void AddThrowsInvExpWhenNoMoreCapacity()
        {
            RobotManager robotManager = new RobotManager(1);
            Robot robot1 = new Robot("ivan", 20);
            robotManager.Add(robot1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(new Robot("pesho", 10));
            });
        }
        [Test]
        public void AddThrowsInvExpWhenNoMoreCapacity0()
        {
            RobotManager robotManager = new RobotManager(0);
            Robot robot1 = new Robot("ivan", 20);
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(robot1);
            });
        }
        [Test]
        public void RemoveThrowsInvExpWhenNoSuchRobotExist()
        {
            RobotManager robotManager = new RobotManager(10);
            Robot robot1 = new Robot("ivan", 20);
            robotManager.Add(robot1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Remove("gosho");
            });
        }
        [Test]
        public void RemoveWorksFine()
        {
            RobotManager robotManager = new RobotManager(10);
            Robot robot1 = new Robot("ivan", 20);
            robotManager.Add(robot1);
            robotManager.Remove("ivan");
            Assert.AreEqual(robotManager.Count, 0);
        }
        [Test]
        public void WorkMethodWorksFineAndReduceBattery()
        {
            RobotManager robotManager = new RobotManager(10);
            Robot robot1 = new Robot("ivan", 20);
            robotManager.Add(robot1);
            robotManager.Work(robot1.Name, "rabota", 15);
            Assert.AreEqual(robot1.Battery, 5);
        }
        [Test]
        public void WorkMethodThrowExpWhenNoSuchRobot()
        {
            RobotManager robotManager = new RobotManager(10);
            Robot robot1 = new Robot("ivan", 20);
            robotManager.Add(robot1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work("pesho", "rabota", 15);
            });
        }
        [Test]
        public void WorkMethodThrowExpWhenNoBattery()
        {
            RobotManager robotManager = new RobotManager(10);
            Robot robot1 = new Robot("ivan", 20);
            robotManager.Add(robot1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work(robot1.Name, "rabota", robot1.Battery+1);
            });
        }
        [Test]
        public void ChargeMethodThrowExpWhenNoSuchRobot()
        {
            RobotManager robotManager = new RobotManager(10);
            Robot robot1 = new Robot("ivan", 20);
            robotManager.Add(robot1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Charge("pesho");
            });
        }
        [Test]
        public void ChargeMethodWorksFine()
        {
            RobotManager robotManager = new RobotManager(10);
            Robot robot1 = new Robot("ivan", 20);
            robotManager.Add(robot1);
            robotManager.Work("ivan", "rabota", 15);
            robotManager.Charge(robot1.Name);
            Assert.AreEqual(20, robot1.Battery);
        }
    }
}
