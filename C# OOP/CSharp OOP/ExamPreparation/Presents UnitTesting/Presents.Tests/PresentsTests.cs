namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class PresentsTests
    {
        [Test]
        public void PresentConstructor_Check_CorectInitialization()
        {
            string name = "A";
            double magic = 5.5;

            Present present = new Present(name, magic);

            Assert.That(present.Name, Is.EqualTo(name));
            Assert.That(present.Magic, Is.EqualTo(magic));
        }

        [Test]
        public void PresentProperties_Check_CorectSetters()
        {
            string name = "A";
            double magic = 5.5;
            string nameTwo = "B";
            double magicTwo = 0;

            Present present = new Present(name, magic);
            present.Name = nameTwo;
            present.Magic = magicTwo;

            Assert.That(present.Name, Is.EqualTo(nameTwo));
            Assert.That(present.Magic, Is.EqualTo(magicTwo));
        }

        [Test]
        public void BagConstructor_Check_CorectInitialization()
        {
            Bag bag = new Bag();

            int expectedCount = 0;
            int actualCount = bag.GetPresents().Count;

            Assert.That(actualCount, Is.EqualTo(expectedCount));            
        }

        [Test]
        public void BagCreateMethod_Check_ThrownArgumentNullExceptionWhenPresentIsNull()
        {
            Bag bag = new Bag();
            Present present = null;
            Assert.That(() => bag.Create(present), Throws.ArgumentNullException);
        }

        [Test]
        public void BagCreateMethod_Check_ThrownInvalidOperationExceptionPresentAlreadyExist()
        {
            Bag bag = new Bag();
            string name = "A";
            double magic = 5.5;
            Present present = new Present(name, magic);
            bag.Create(present);
            Assert.That(() => bag.Create(present), Throws.InvalidOperationException.With.Message.EqualTo("This present already exists!"));
        }

        [Test]
        public void BagCreateMethod_Check_AddingCorrectlyPresents()
        {
            Bag bag = new Bag();
            string name = "A";
            double magic = 5.5;
            Present present = new Present(name, magic);
            
            string actualPresentName = bag.Create(present);
            string expectedPresentName = present.Name;

            int actualCount = bag.GetPresents().Count;
            int expectedCount = 1;

            Assert.That(actualCount, Is.EqualTo(expectedCount));
            Assert.That(actualPresentName, Is.EqualTo(actualPresentName));
        }

        [Test]
        public void BagRemoveMethod_Check_RemoveCorectlyPresents()
        {
            Bag bag = new Bag();

            string name = "A";
            double magic = 5.5;
            Present present = new Present(name, magic);

            string nameTwo = "B";
            double magicTwo = 4.5;
            Present presentTwo = new Present(nameTwo, magicTwo);

            bag.Create(present);
            bag.Create(presentTwo);

            bag.Remove(present);

            bool actualyContains = bag.GetPresents().Contains(present);
            bool expectedContains = false;

            Assert.That(actualyContains, Is.EqualTo(expectedContains));
        }

        [Test]
        public void BagRemoveMethod_Check_RemoveCorectlyReturn()
        {
            Bag bag = new Bag();

            string name = "A";
            double magic = 5.5;
            Present present = new Present(name, magic);

            bag.Create(present);           

            bool actualRemove = bag.Remove(present);
            bool expectedRemove = true;                       

            Assert.That(actualRemove, Is.EqualTo(expectedRemove));
        }

        [Test]
        public void BagGetPresentWithLeastMagicMethod_Check_CorectGetPresentWithLeastMagic()
        {
            Bag bag = new Bag();

            string name = "A";
            double magic = 5.5;
            Present present = new Present(name, magic);

            string nameTwo = "B";
            double magicTwo = 4.5;
            Present presentTwo = new Present(nameTwo, magicTwo);

            bag.Create(present);
            bag.Create(presentTwo);

            Present actual = bag.GetPresentWithLeastMagic();
            Present expected = presentTwo;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void BagGetPresentMethod_Check_CorectGetPresent()
        {
            Bag bag = new Bag();

            string name = "A";
            double magic = 5.5;
            Present present = new Present(name, magic);

            string nameTwo = "B";
            double magicTwo = 4.5;
            Present presentTwo = new Present(nameTwo, magicTwo);

            bag.Create(present);
            bag.Create(presentTwo);

            Present actual = bag.GetPresent(present.Name);
            Present expected = present;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void BagGetPresentMethod_Check_GetPresentReturnNull()
        {
            Bag bag = new Bag();

            string name = "A";                                

            Present actual = bag.GetPresent(name);
            Present expected = null;

            Assert.That(actual, Is.EqualTo(expected));
        }

    }
}
