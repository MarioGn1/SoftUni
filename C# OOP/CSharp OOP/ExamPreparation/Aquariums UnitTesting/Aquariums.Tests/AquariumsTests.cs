namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

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

        [Test]
        public void AquariumRemoveMethod_Chek_ThrownInvalidOperationException()
        {
            string name = "N";
            Fish fish = new Fish("M");
            Aquarium aquarium = new Aquarium("A", 2);
            aquarium.Add(fish);                       

            Assert.That(() => aquarium.RemoveFish(name), Throws.InvalidOperationException.With.Message.EqualTo($"Fish with the name {name} doesn't exist!"));
        }

        [Test]
        public void AquariumRemoveMethod_Chek_CorectRemove()
        {
            string name = "M";
            Fish fish = new Fish("M");
            Aquarium aquarium = new Aquarium("A", 2);
            aquarium.Add(fish);
            aquarium.RemoveFish(name);

            int actualAquariumCount = aquarium.Count;
            int expectedAquariumCount = 0;

            Assert.That(actualAquariumCount, Is.EqualTo(expectedAquariumCount));
        }

        [Test]
        public void AquariumRemoveMethod_Chek_CorectRemoveWithMoreThanOneFish()
        {
            string name = "M";
            Fish fish = new Fish("M");
            Fish fishTwo = new Fish("N");
            Aquarium aquarium = new Aquarium("A", 2);
            aquarium.Add(fish);
            aquarium.Add(fishTwo);
            aquarium.RemoveFish(name);

            int actualAquariumCount = aquarium.Count;
            int expectedAquariumCount = 1;

            Assert.That(actualAquariumCount, Is.EqualTo(expectedAquariumCount));
        }

        [Test]
        public void AquariumSellFishMethod_Chek_TrownInvalidOperationException()
        {
            string name = "N";
            Fish fish = new Fish("M");
            
            Aquarium aquarium = new Aquarium("A", 2);
            aquarium.Add(fish);            

            Assert.That(() => aquarium.SellFish(name), Throws.InvalidOperationException.With.Message.EqualTo($"Fish with the name {name} doesn't exist!"));
        }

        [Test]
        public void AquariumSellFishMethod_Chek_CorrectSell()
        {
            string name = "M";
            Fish fish = new Fish("M");

            Aquarium aquarium = new Aquarium("A", 2);
            aquarium.Add(fish);
            aquarium.SellFish(name);

            bool expectedFishStatus = false;
            bool actualFishStatus = fish.Available;

            Assert.That(actualFishStatus, Is.EqualTo(expectedFishStatus));
        }

        [Test]
        public void AquariumSellFishMethod_Chek_CorrectReturn()
        {
            string name = "M";
            Fish fish = new Fish("M");

            Aquarium aquarium = new Aquarium("A", 2);
            aquarium.Add(fish);
            Fish requestedFish = aquarium.SellFish(name);

            Fish expectedFishStatus = fish;
            Fish actualFishStatus = requestedFish;

            Assert.That(actualFishStatus, Is.EqualTo(expectedFishStatus));
        }

        [Test]
        public void AquariumReportMethod_Chek_CorrectReturn()
        {
            string name = "M";
            Fish fish = new Fish("M");
            Fish fishTwo = new Fish("N");

            Aquarium aquarium = new Aquarium("A", 2);
            aquarium.Add(fish);
            aquarium.Add(fishTwo);
            

            string expectedReturn = $"Fish available at A: M, N"; ;
            string actualReturn = aquarium.Report();

            Assert.That(actualReturn, Is.EqualTo(expectedReturn));
        }
    }
}
