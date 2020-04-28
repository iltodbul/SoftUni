namespace Robots.Tests
{
    using System;
    using NUnit.Framework;

    public class RobotsTests
    {
        private Robot robot1;
        private Robot robot2;

        private RobotManager manager;

        [SetUp]
        public void Setup()
        {
            robot1 = new Robot("Pesho", 100);
            robot2 = new Robot("Gosho", 200);

            manager = new RobotManager(2);
        }

        [Test]
        public void TestRobotConstructor()
        {
            Assert.That(this.robot1.Name, Is.EqualTo("Pesho"));
            Assert.That(this.robot1.MaximumBattery, Is.EqualTo(100));
            Assert.That(this.robot1.Battery, Is.EqualTo(100));
        }

        [Test]
        public void TestRobotManagerConstructor()
        {
            this.manager.Add(robot1);

            Assert.That(this.manager.Count, Is.EqualTo(1));
            Assert.That(this.manager.Capacity, Is.EqualTo(2));
        }

        [Test]
        public void ShuldThrowExceptionWhenValueCapacityIsNegativ()
        {
            Assert.Throws<ArgumentException>(() => this.manager = new RobotManager(-1));
        }

        [Test]
        public void ShouldThrowExceptionWhenRobotToAddAlreadyExist()
        {
            this.robot2 = new Robot(this.robot1.Name, this.robot1.MaximumBattery);

            this.manager.Add(robot1);

            Assert.Throws<InvalidOperationException>(() => this.manager.Add(robot2));
        }

        [Test]
        public void ThrowExceptionWhenNotEnoughCapacityAddingRobot()
        {
            var robot3 = new Robot("Test", 300);

            this.manager.Add(robot1);
            this.manager.Add(robot2);

            Assert.Throws<InvalidOperationException>(() => this.manager.Add(robot3));
        }

        [Test]
        public void ThrowExceptionWhenRobotToRemoveNotExist()
        {
            this.manager.Add(robot1);

            Assert.Throws<InvalidOperationException>(() => this.manager.Remove("Gosho"));
        }

        [Test]
        public void RemoveRobotshouldWorkProperly()
        {
            this.manager.Add(robot1);
            this.manager.Add(robot2);
            this.manager.Remove("Pesho");

            Assert.That(this.manager.Count, Is.EqualTo(1));
        }

        [Test]
        public void ThrowExceptionWhenRobotToWorkNotExist()
        {
            this.manager.Add(robot1);

            Assert.Throws<InvalidOperationException>(() => this.manager.Work("Gosho", "Work", 10));
        }

        [Test]
        public void ThrowExceptionWhenRobotToWorkDoesntHaveEenoughBbattery()
        {
            this.manager.Add(robot1);

            Assert.Throws<InvalidOperationException>(() => this.manager.Work("Pesho", "Work", 101));
        }

        [Test]
        public void WhenRobotWorkBatteryCapacityShouldReduce()
        {
            this.manager.Add(robot1);

            this.manager.Work("Pesho", "Work", 10);

            Assert.That(this.robot1.Battery, Is.EqualTo(90));
            
        }

        [Test]
        public void ThrowExceptionWhenRobotToChargeNotExist()
        {
            this.manager.Add(robot1);

            Assert.Throws<InvalidOperationException>(() => this.manager.Charge("Gosho"));
        }

        [Test]
        public void WhenRobotChargeBatteryCapacityShouldBeToMaximum()
        {
            this.manager.Add(robot1);
            this.manager.Work("Pesho", "Work", 10);
            this.manager.Charge("Pesho");

            Assert.That(this.robot1.Battery, Is.EqualTo(100));

        }
    }
}
