namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AquariumsTests
    {


        [Test]
        public void FishConstructor_Chek_ValidInitialization()
        {
            string name = "A";
            Fish fish = new Fish(name);

            string actualName = fish.Name;
            string expectedName = name;
            bool actualAvailableProperty = fish.Available;
            bool expectedAvailableProperty = true;

            Assert.That(actualName, Is.EqualTo(expectedName));
            Assert.That(actualAvailableProperty, Is.EqualTo(expectedAvailableProperty));
        }

        [Test]
        public void PropertyName_Check_GetterAndSetter()
        {
            string name = "A";
            Fish fish = new Fish(name);

            fish.Name = "B";
            fish.Available = false;

            string actualName = fish.Name;
            string expectedName = "B";
            bool actualAvailableProperty = fish.Available;
            bool expectedAvailableProperty = false;

            Assert.That(actualName, Is.EqualTo(expectedName));
            Assert.That(actualAvailableProperty, Is.EqualTo(expectedAvailableProperty));
        }

        [Test]
        public void AquariumConstructor_Chek_FishCount()
        {
            string name = "A";
            int capacity = 10;
            Aquarium aquarium = new Aquarium(name, capacity);

            int actualCount = aquarium.Count;
            int expectedCount = 0;

            Assert.That(actualCount, Is.EqualTo(expectedCount));
            
        }

        [Test]
        public void AquariumConstructor_Chek_NameAndCapacityGettersAndSetters()
        {
            string name = "A";
            int capacity = 10;
            Aquarium aquarium = new Aquarium(name, capacity);

            string actualName = aquarium.Name;
            string expectedName = name;
            int actualCapacity = aquarium.Capacity;
            int expectedCapacity = capacity;

            Assert.That(actualCapacity, Is.EqualTo(expectedCapacity));
            Assert.That(actualName, Is.EqualTo(expectedName));

        }

        [TestCase ("")]
        [TestCase (null)]
        public void AquariumConstructor_Chek_NameThrowArgumentNullExeption(string name)
        {
            int capacity = 0;
            Assert.That(() => new Aquarium(name, capacity), Throws.ArgumentNullException.With.Message.EqualTo("Invalid aquarium name! (Parameter 'value')"));           

        }

        [Test]
        public void AquariumConstructor_Chek_CapacityThrowArgumentNullExeption()
        {
            int capacity = -1;
            Assert.That(() => new Aquarium("A", capacity), Throws.ArgumentException.With.Message.EqualTo("Invalid aquarium capacity!"));

        }

        [Test]
        public void AquariumAddMethod_Chek_InvalidOperationExceptionWhenCapacityIsFull()
        {
            Fish fish = new Fish("M");
            Aquarium aquarium = new Aquarium("A", 0);
            Assert.That(() => aquarium.Add(fish), Throws.InvalidOperationException.With.Message.EqualTo("Aquarium is full!"));
        }

        [Test]
        public void AquariumAddMethod_Chek_CorrectAdding()
        {
            Fish fish = new Fish("M");
            Aquarium aquarium = new Aquarium("A", 2);
            aquarium.Add(fish);
            aquarium.Add(fish);

            int expectedCount = 2;
            int actualCount = aquarium.Count;

            Assert.That(actualCount, Is.EqualTo(expectedCount));            
        }
    }
}
