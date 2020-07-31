//using CarManager;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class CarTests
    {
        private string make;
        private string model;
        private double fuelConsumption;
        private double fuelCapacity;
        private Car car;

        [SetUp]
        public void Setup()
        {
            make = "VW";
            model = "Passat";
            fuelConsumption = 6.5;
            fuelCapacity = 69.5;

            car = new Car(make, model, fuelConsumption, fuelCapacity);
        }

        [Test]
        public void EmtyConstructor_CheckFuelAmount_CorectInitialize()
        {                       
            double actualFuelAmount = car.FuelAmount;
            double expectedFuelAmount = 0;

            Assert.That(actualFuelAmount, Is.EqualTo(expectedFuelAmount));
        }

        [Test]
        public void CheckMake_PropertyCorectGetter()
        {           
            string actualMake = car.Make;
            string expectedMake = make;

            Assert.That(actualMake, Is.EqualTo(expectedMake));
        }

        [TestCase(null)]
        [TestCase("")]
        public void Constructor_CheckMake_TrowArgumentException_IfPropertyIsNullOrEmpty(string makeCases)
        {           
            Assert.That(() => new Car(makeCases, model, fuelConsumption, fuelCapacity), Throws.ArgumentException.With.Message.EqualTo("Make cannot be null or empty!"));
        }

        [Test]
        public void CheckModel_PropertyCorectGetter()
        {
            string actualMake = car.Model;
            string expectedMake = model;

            Assert.That(actualMake, Is.EqualTo(expectedMake));
        }

        [TestCase(null)]
        [TestCase("")]
        public void Constructor_CheckModel_TrowArgumentException_IfPropertyIsNullOrEmpty(string modelCases)
        {
            Assert.That(() => new Car(make, modelCases, fuelConsumption, fuelCapacity), Throws.ArgumentException.With.Message.EqualTo("Model cannot be null or empty!"));
        }

        [Test]
        public void CheckFuelConsumption_PropertyCorectGetter()
        {
            double actualFuelConsumption = car.FuelConsumption;
            double expectedFuelConsumption = fuelConsumption;

            Assert.That(actualFuelConsumption, Is.EqualTo(expectedFuelConsumption));
        }

        [TestCase(-0.9)]
        [TestCase(0)]
        public void Constructor_CheckFuelConsumption_TrowArgumentException_IfArgumentIsEqualOrLessThanZeor(double fuelConsumption)
        {
            Assert.That(() => new Car(make, model, fuelConsumption, fuelCapacity), Throws.ArgumentException.With.Message.EqualTo("Fuel consumption cannot be zero or negative!"));
        }

        [Test]
        public void CheckFuelCapacity_PropertyCorectGetter()
        {
            double actualFuelCapacity = car.FuelCapacity;
            double expectedFuelCapacity = fuelCapacity;

            Assert.That(actualFuelCapacity, Is.EqualTo(expectedFuelCapacity));
        }

        [TestCase(-0.9)]
        [TestCase(0)]
        public void Constructor_CheckFuelCapacity_TrowArgumentException_IfArgumentIsEqualOrLessThanZeor(double fuelCapacity)
        {
            Assert.That(() => new Car(make, model, fuelConsumption, fuelCapacity), Throws.ArgumentException.With.Message.EqualTo("Fuel capacity cannot be zero or negative!"));
        }

        [TestCase(-0.9)]
        [TestCase(0)]
        public void Refuel_Check_TrowArgumentException_IfArgumentIsEqualOrLessThanZeo(double refuelAmount)
        {
            Assert.That(() => car.Refuel(refuelAmount), Throws.ArgumentException.With.Message.EqualTo("Fuel amount cannot be zero or negative!"));
        }

        [Test]
        public void Refuel_Check_CorectLoad()
        {
            double refuelAmount = 10;
            double currFuel = car.FuelAmount;
            car.Refuel(refuelAmount);

            double actualFuel = car.FuelAmount;
            double expectedFuel = currFuel + refuelAmount;

            Assert.That(actualFuel, Is.EqualTo(expectedFuel));
        }

        [Test]
        public void Refuel_Check_ResizeFuelAmountDependOnFuelCapacity()
        {
            double refuelAmount = 100;
            double currFuel = car.FuelAmount;
            car.Refuel(refuelAmount);

            double actualFuel = car.FuelAmount;
            double expectedFuel = car.FuelCapacity;

            Assert.That(actualFuel, Is.EqualTo(expectedFuel));
        }

        //[Test]
        //public void Refuel_Check_TrowArgumentExceptionUsingTheSetter_IfArgumentIsEqualOrLessThanZeo()
        //{
        //    Assert.That(() => car.Refuel(-1), Throws.ArgumentException.With.Message.EqualTo("Fuel amount cannot be negative!"));
        //}

        [Test]
        public void DriveMethod_Check_TrowInvalidOperationException_WhitZeroFuel()
        {
            Assert.That(() => car.Drive(1000), Throws.InvalidOperationException.With.Message.EqualTo("You don't have enough fuel to drive!"));
        }

        [Test]
        public void DriveMethod_Check_TrowInvalidOperationException_WhitExistingFuel()
        {
            car.Refuel(10);
            Assert.That(() => car.Drive(1000), Throws.InvalidOperationException.With.Message.EqualTo("You don't have enough fuel to drive!"));
        }

        [Test]
        public void DriveMethod_Check_SuccessDrive()
        {
            car.Refuel(70);
            car.Drive(1000);

            double actualFuelLeft = car.FuelAmount;
            double expectedFuelLeft = 4.5;
            Assert.That(actualFuelLeft, Is.EqualTo(expectedFuelLeft));
        }
    }
}