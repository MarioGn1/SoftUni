using NUnit.Framework;
using System.Collections.Generic;


namespace Computers.Tests
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ComputerConstructor()
        {
            Computer comp = new Computer("DC", "A", (decimal)5.5);

            Assert.That(comp.Manufacturer, Is.EqualTo("DC"));
            Assert.That(comp.Model, Is.EqualTo("A"));
            Assert.That(comp.Price, Is.EqualTo(5.5));
        }
        [Test]
        public void ComputerProperties()
        {
            Computer comp = new Computer("DC", "A", (decimal)5.5);
            comp.Manufacturer = "AC";
            comp.Model = "B";
            comp.Price = (decimal)6.5;

            Assert.That(comp.Manufacturer, Is.EqualTo("AC"));
            Assert.That(comp.Model, Is.EqualTo("B"));
            Assert.That(comp.Price, Is.EqualTo(6.5));
        }

        [Test]
        public void ComputerManagerConstructor()
        {
            ComputerManager comp = new ComputerManager();

            Assert.That(comp.Count, Is.EqualTo(0));
           
        }

        [Test]
        public void ComputerManagerColection()
        {
            ComputerManager compMan = new ComputerManager();
            Computer comp = new Computer("DC", "A", (decimal)5.5);
            compMan.AddComputer(comp);
            List<Computer> comps = new List<Computer>();
            comps.Add(comp);

            Assert.That(compMan.Computers, Is.EqualTo(comps));

        }

        [Test]
        public void ComputerManagerAddMethodException()
        {
            ComputerManager compMan = new ComputerManager();
            Computer comp = new Computer("DC", "A", (decimal)5.5);
            compMan.AddComputer(comp);            

            Assert.That(() => compMan.AddComputer(comp), Throws.ArgumentException.With.Message.EqualTo("This computer already exists."));
        }

        [Test]
        public void ComputerManagerRemoveMethod()
        {
            ComputerManager compMan = new ComputerManager();
            Computer comp = new Computer("DC", "A", (decimal)5.5);
            compMan.AddComputer(comp);
            Computer compRemoved = compMan.RemoveComputer("DC", "A");

            Assert.That(compRemoved, Is.EqualTo(compRemoved));
        }

        [Test]
        public void ComputerManagerGetMethodEception()
        {
            ComputerManager compMan = new ComputerManager();
            Computer comp = new Computer("DC", "A", (decimal)5.5);
            compMan.AddComputer(comp);
            

            Assert.That(() => compMan.RemoveComputer("DC", "B"), Throws.ArgumentException.With.Message.EqualTo("There is no computer with this manufacturer and model."));
        }

        [Test]
        public void ComputerManagerGetMethodReturn()
        {
            ComputerManager compMan = new ComputerManager();
            Computer comp = new Computer("DC", "A", (decimal)5.5);
            compMan.AddComputer(comp);
            Computer compRemoved = compMan.GetComputer("DC", "A");
            Assert.That(compRemoved, Is.EqualTo(compRemoved));
        }

        [Test]
        public void ComputerManagerGetCollectionMethodReturn()
        {
            ComputerManager compMan = new ComputerManager();
            Computer comp = new Computer("DC", "A", (decimal)5.5);
            Computer compTwo = new Computer("DC", "B", (decimal)5.5);
            compMan.AddComputer(comp);
            compMan.AddComputer(compTwo);
            List<Computer> comps = new List<Computer>();
            comps.Add(comp);
            comps.Add(compTwo);
            ICollection<Computer> compsReturned = compMan.GetComputersByManufacturer("DC");
            Assert.That(compsReturned, Is.EqualTo(comps));
        }

        [Test]
        public void ComputerManagerGetCollectionException()
        {
            ComputerManager compMan = new ComputerManager();
            
            Assert.That(() => compMan.GetComputersByManufacturer(null), Throws.ArgumentNullException);
        }

        [Test]
        public void ComputerManagerGetMethodExceptionWhenProducerNull()
        {
            ComputerManager compMan = new ComputerManager();
            
            Assert.That(() => compMan.GetComputer(null, "A"), Throws.ArgumentNullException);
        }

        [Test]
        public void ComputerManagerGetMethodExceptionWhenModelNull()
        {
            ComputerManager compMan = new ComputerManager();

            Assert.That(() => compMan.GetComputer("AC", null), Throws.ArgumentNullException);
        }

        [Test]
        public void ComputerManagerAddMethodExceptionWhenNullComp()
        {
            ComputerManager compMan = new ComputerManager();            

            Assert.That(() => compMan.AddComputer(null), Throws.ArgumentNullException);
        }

        [Test]
        public void ComputerManagerCount()
        {
           
            ComputerManager compMan = new ComputerManager();
            Computer comp = new Computer("DC", "A", (decimal)5.5);
            Computer comptwo = new Computer("DC", "B", (decimal)5.5);
            compMan.AddComputer(comp);
            compMan.AddComputer(comptwo);           
            

            Assert.That(compMan.Count, Is.EqualTo(2));
        }

        [Test]
        public void ComputerManagerRemoveMethodExceptionWhenProducerIsNull()
        {
            ComputerManager compMan = new ComputerManager();

            Assert.That(() => compMan.RemoveComputer(null, "A"), Throws.ArgumentNullException);
        }
        [Test]
        public void ComputerManagerRemoveMethodExceptionWhenModelIsNull()
        {
            ComputerManager compMan = new ComputerManager();

            Assert.That(() => compMan.RemoveComputer("AC", null), Throws.ArgumentNullException);
        }
    }
}