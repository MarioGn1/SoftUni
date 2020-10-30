namespace Robots.Tests
{
    using NUnit.Framework;
    using System;
    [TestFixture]
    public class RobotsTests
    {
        [Test]
        public void ConstructorRobot_Check_ValidInitialization()
        {
            string name = "A";            
            int maxBatery = 10;

            Robot robot = new Robot(name, maxBatery);

            string actualName = robot.Name;
            int actualMaxBatery = robot.MaximumBattery;
            int actualBatery = robot.Battery;

            string expecetedlName = name;
            int expecetedMaxBatery = maxBatery;
            int expecetedBatery = maxBatery;

            Assert.That(actualName, Is.EqualTo(expecetedlName));
            Assert.That(actualBatery, Is.EqualTo(expecetedBatery));
            Assert.That(actualMaxBatery, Is.EqualTo(expecetedMaxBatery));
        }

        [Test]
        public void PropertiesRobot_Check_SettersProperWork()
        {
            string name = "A";
            int maxBatery = 10;

            Robot robot = new Robot(name, maxBatery);
            robot.Name = "B";
            robot.Battery = 5;

            string actualName = robot.Name;            
            int actualBatery = robot.Battery;

            string expecetedlName = "B";            
            int expecetedBatery = 5;

            Assert.That(actualName, Is.EqualTo(expecetedlName));
            Assert.That(actualBatery, Is.EqualTo(expecetedBatery));            
        }

        [Test]
        public void ConstructorRobotManager_Check_CorrectInitialization()
        {
            int capacity = 5;
            RobotManager robotManager = new RobotManager(capacity);

            int actualCount = robotManager.Count;
            int expectedCount = 0;

            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }

        [Test]
        public void ConstructorRobotManager_Check_ThrownArgumentExceptionWhenCapacityIsLessThanZero()
        {
            int capacity = -1;                      

            Assert.That(() => new RobotManager(capacity), Throws.ArgumentException.With.Message.EqualTo("Invalid capacity!"));
        }

        [Test]
        public void ConstructorRobotManager_Check_CorrectCapacityInitialization()
        {
            int capacity = 5;
            RobotManager robotManager = new RobotManager(capacity);

            int actualCapacity = robotManager.Capacity;
            int expectedCapacity = 5;

            Assert.That(actualCapacity, Is.EqualTo(expectedCapacity));
        }

        [Test]
        public void PropertieCount_RobotManager_Check_CorrectIncrementWhenAddElements()
        {
            int capacity = 5;
            RobotManager robotManager = new RobotManager(capacity);

            string name = "A";
            int maxBatery = 10;

            Robot robot = new Robot(name, maxBatery);

            robotManager.Add(robot);

            int actualCount = robotManager.Count;
            int expectedCount = 1;

            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }

        [Test]
        public void AddMethod_RobotManager_Check_ThrownInvalidOperationException()
        {
            int capacity = 5;
            RobotManager robotManager = new RobotManager(capacity);

            string name = "A";
            int maxBatery = 10;

            Robot robot = new Robot(name, maxBatery);
            robotManager.Add(robot);

            Assert.That(() => robotManager.Add(robot), Throws.InvalidOperationException.With.Message.EqualTo($"There is already a robot with name {robot.Name}!"));
        }

        [Test]
        public void AddMethod_RobotManager_Check_ThrownInvalidOperationExceptionWhenCapacityIsFull()
        {
            int capacity = 1;
            RobotManager robotManager = new RobotManager(capacity);

            string name = "A";
            int maxBatery = 10;

            Robot robot = new Robot(name, maxBatery);
            robotManager.Add(robot);

            Assert.That(() => robotManager.Add(new Robot("B", 5)), Throws.InvalidOperationException.With.Message.EqualTo("Not enough capacity!"));
        }

        [Test]
        public void RemoveMethod_RobotManager_Check_ThrownInvalidOperationException()
        {
            int capacity = 1;
            RobotManager robotManager = new RobotManager(capacity);

            string nameToRemove = "A";

            Assert.That(() => robotManager.Remove(nameToRemove), Throws.InvalidOperationException.With.Message.EqualTo($"Robot with the name {nameToRemove} doesn't exist!"));
        }

        [Test]
        public void RemoveMethod_RobotManager_Check_CorectRemove()
        {
            int capacity = 1;
            RobotManager robotManager = new RobotManager(capacity);

            string name = "A";
            int maxBatery = 10;

            Robot robot = new Robot(name, maxBatery);
            robotManager.Add(robot);

            robotManager.Remove(name);

            int actualCount = robotManager.Count;
            int expectedCount = 0;

            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }

        [Test]
        public void WorkMethod_RobotManager_Check_ThrownInvalidOperationExceptionIfRobbotNotExist()
        {
            int capacity = 1;
            RobotManager robotManager = new RobotManager(capacity);

            string robotName = "A";
            int bateryUsage = 5;
            string job = "clean";
            

            Assert.That(() => robotManager.Work(robotName,job,bateryUsage), Throws.InvalidOperationException.With.Message.EqualTo($"Robot with the name {robotName} doesn't exist!"));
        }

        [Test]
        public void WorkMethod_RobotManager_Check_ThrownInvalidOperationExceptionIfLowBattery()
        {
            int capacity = 1;
            RobotManager robotManager = new RobotManager(capacity);

            string name = "A";
            int maxBatery = 4;

            Robot robot = new Robot(name, maxBatery);
            robotManager.Add(robot);

            string robotName = "A";
            int bateryUsage = 5;
            string job = "clean";


            Assert.That(() => robotManager.Work(robotName, job, bateryUsage), Throws.InvalidOperationException.With.Message.EqualTo($"{robot.Name} doesn't have enough battery!"));
        }

        [Test]
        public void WorkMethod_RobotManager_Check_DoTheJobAndDrainBatteryCorrectly()
        {
            int capacity = 1;
            RobotManager robotManager = new RobotManager(capacity);

            string name = "A";
            int maxBatery = 6;

            Robot robot = new Robot(name, maxBatery);
            robotManager.Add(robot);

            string robotName = "A";
            int bateryUsage = 5;
            string job = "clean";
            robotManager.Work(robotName, job, bateryUsage);

            int expectedBatery = maxBatery - bateryUsage;
            int actualBatery = robot.Battery;

            Assert.That(actualBatery, Is.EqualTo(expectedBatery));
        }

        [Test]
        public void ChargeMethod_RobotManager_Check_ThrownInvalidOperationExceptionIfLowBattery()
        {
            int capacity = 1;
            RobotManager robotManager = new RobotManager(capacity);

            string name = "A";
            
            Assert.That(() => robotManager.Charge(name), Throws.InvalidOperationException.With.Message.EqualTo($"Robot with the name {name} doesn't exist!"));
        }

        [Test]
        public void ChargeMethod_RobotManager_Check_CorrectCharge()
        {
            int capacity = 1;
            RobotManager robotManager = new RobotManager(capacity);

            string name = "A";
            int maxBatery = 6;

            Robot robot = new Robot(name, maxBatery);
            robotManager.Add(robot);

            string robotName = "A";
            int bateryUsage = 5;
            string job = "clean";
            robotManager.Work(robotName, job, bateryUsage);
            robotManager.Charge(name);

            int actualBatery = robot.Battery;
            int expectedBatery = maxBatery;

            Assert.That(actualBatery, Is.EqualTo(expectedBatery));
        }
    }
}
