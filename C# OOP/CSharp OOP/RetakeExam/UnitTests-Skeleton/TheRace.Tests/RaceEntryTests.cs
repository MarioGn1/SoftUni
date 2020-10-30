using NUnit.Framework;
using TheRace;

namespace TheRace.Tests
{
    [TestFixture]
    public class RaceEntryTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DriverConstructorTest()
        {
            UnitCar car = new UnitCar("CZ", 100, 5.5);
            UnitDriver driver = new UnitDriver("A", car);
            Assert.That(driver.Name, Is.EqualTo("A"));
            Assert.That(driver.Car, Is.EqualTo(car));
        }

        [Test]
        public void DriverConstructorThrowException()
        {
            UnitCar car = new UnitCar("CZ", 100, 5.5);
           
            Assert.That(() => new UnitDriver(null, car), Throws.ArgumentNullException);
            
        }

        [Test]
        public void CarConstructorTest()
        {
            UnitCar car = new UnitCar("CZ", 100, 5.5);
            
            Assert.That(car.Model, Is.EqualTo("CZ"));
            Assert.That(car.HorsePower, Is.EqualTo(100));
            Assert.That(car.CubicCentimeters, Is.EqualTo(5.5));
        }

        [Test]
        public void RaceConstructorTest()
        {
            RaceEntry race = new RaceEntry();
            Assert.That(race.Counter, Is.EqualTo(0));
        }

        [Test]
        public void RaceAddDriverExceptionWhenNullDriver()
        {
            
            RaceEntry race = new RaceEntry();
            
            Assert.That(() => race.AddDriver(null), Throws.InvalidOperationException.With.Message.EqualTo("Driver cannot be null."));
        }

        [Test]
        public void RaceAddDriverException()
        {
            UnitCar car = new UnitCar("CZ", 100, 5.5);
            UnitDriver driver = new UnitDriver("A", car);
            RaceEntry race = new RaceEntry();
            race.AddDriver(driver);

            Assert.That(() => race.AddDriver(driver), Throws.InvalidOperationException.With.Message
                .EqualTo(string.Format("Driver {0} is already added.",driver.Name)));
        }

        [Test]
        public void RaceAddDriver()
        {
            UnitCar car = new UnitCar("CZ", 100, 5.5);
            UnitDriver driver = new UnitDriver("A", car);
            RaceEntry race = new RaceEntry();
            race.AddDriver(driver);

            Assert.That(race.Counter, Is.EqualTo(1));
            UnitDriver driverTwo = new UnitDriver("B", car);
            race.AddDriver(driverTwo);
            Assert.That(race.Counter, Is.EqualTo(2));

        }

        [Test]
        public void RaceAddDriverReturn()
        {
            UnitCar car = new UnitCar("CZ", 100, 5.5);
            UnitDriver driver = new UnitDriver("A", car);
            RaceEntry race = new RaceEntry();
            string returnedString = race.AddDriver(driver);

            Assert.That(returnedString, Is.EqualTo(string.Format("Driver {0} added in race.", driver.Name)));
        }
        [Test]
        public void RaceCalcMethotException()
        {
            UnitCar car = new UnitCar("CZ", 100, 5.5);
            UnitDriver driver = new UnitDriver("A", car);
            RaceEntry race = new RaceEntry();
            race.AddDriver(driver);

            Assert.That(() => race.CalculateAverageHorsePower(), Throws.InvalidOperationException);
        }

        [Test]
        public void RaceCalcMethotTest()
        {
            UnitCar car = new UnitCar("CZ", 100, 5.5);
            UnitDriver driver = new UnitDriver("A", car);
            UnitDriver driverTwo = new UnitDriver("B", car);
            RaceEntry race = new RaceEntry();
            race.AddDriver(driver);
            race.AddDriver(driverTwo);
            double avrgPower = race.CalculateAverageHorsePower();

            Assert.That(avrgPower, Is.EqualTo(100));
        }

        [Test]
        public void RaceCalcMethotTestTwo()
        {
            UnitCar car = new UnitCar("CZ", 100, 5.5);
            UnitCar cartwo = new UnitCar("CZ", 3, 5.5);
            UnitDriver driver = new UnitDriver("A", car);
            UnitDriver driverTwo = new UnitDriver("B", cartwo);
            RaceEntry race = new RaceEntry();
            race.AddDriver(driver);
            race.AddDriver(driverTwo);
            double avrgPower = race.CalculateAverageHorsePower();

            Assert.That(avrgPower, Is.EqualTo(51.5));
        }
    }
}