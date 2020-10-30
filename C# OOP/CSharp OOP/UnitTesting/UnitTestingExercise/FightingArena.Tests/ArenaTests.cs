//using FightingArena;
using NUnit.Framework;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        [Test]
        public void Constuctor_Check_CountEqualToZeroGetter()
        {
            

            int actualWarriorsCount = arena.Warriors.Count;
            int expectedWarriorsCount = 0;

            Assert.That(actualWarriorsCount, Is.EqualTo(expectedWarriorsCount));
        }

        [Test]
        public void WarriorsProperty_Check_Getter()
        {
            
            Warrior wariorOne = new Warrior("Paladin", 40, 40);
            arena.Enroll(wariorOne);

            Warrior actualWarrior = arena.Warriors.FirstOrDefault(w => w.Name == wariorOne.Name);
            Warrior expectedWarrior = wariorOne;

            Assert.That(actualWarrior, Is.EqualTo(expectedWarrior));
        }

        [Test]
        public void CountProperty_Check_Getter()
        {
            
            Warrior wariorOne = new Warrior("Paladin", 40, 40);
            arena.Enroll(wariorOne);

            int actualCount = arena.Count;
            int expectedCount = 1;

            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Enroll_Check_TrownInvalidOperationException_WhenAddHeroWithAlreadyExistingName()
        {
            
            Warrior wariorOne = new Warrior("Pesho", 40, 40);
            Warrior wariorTwo = new Warrior("Pesho", 35, 35);
            arena.Enroll(wariorOne);

            Assert.That(() => arena.Enroll(wariorTwo), Throws.InvalidOperationException.With.Message.EqualTo("Warrior is already enrolled for the fights!"));
        }

        [Test]
        public void Enroll_Check_CorrectAddingOfNewHeroes()
        {
           
            Warrior wariorOne = new Warrior("Pesho", 40, 40);
            Warrior wariorTwo = new Warrior("Gosho", 35, 35);
            arena.Enroll(wariorOne);
            arena.Enroll(wariorTwo);

            Warrior actualWarriorOne = arena.Warriors.First(w => w.Name == wariorOne.Name);
            Warrior expectetWarriorOne = wariorOne;

            int actualCount = arena.Warriors.Count;
            int expectedCount = 2;

            Assert.That(actualWarriorOne, Is.EqualTo(expectetWarriorOne));
            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }

        [Test]
        public void FightMethod_Check_TrownInvalidOperationException_WhenOneOfTheDuelistsIsNullReference()
        {
            
            Warrior wariorOne = new Warrior("Pesho", 40, 40);
            Warrior wariorTwo = new Warrior("Gosho", 35, 35);
            arena.Enroll(wariorOne);
            arena.Enroll(wariorTwo);

            string nonExistingName = "Mario";
            string nonExistingNameTwo = "Ivo";

            Assert.That(() => arena.Fight(nonExistingName, nonExistingNameTwo), Throws.InvalidOperationException.With.Message.EqualTo($"There is no fighter with name {nonExistingNameTwo} enrolled for the fights!"));
            Assert.That(() => arena.Fight(nonExistingName, "Gosho"), Throws.InvalidOperationException.With.Message.EqualTo($"There is no fighter with name {nonExistingName} enrolled for the fights!"));
            Assert.That(() => arena.Fight("Pesho", nonExistingName), Throws.InvalidOperationException.With.Message.EqualTo($"There is no fighter with name {nonExistingName} enrolled for the fights!"));
        }

        [Test]
        public void TestFightMethodWithAttackerAndDefender()
        {
            Warrior attacker = new Warrior("Pesho", 40, 40);
            Warrior defender = new Warrior("Gosho", 40, 40);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            int expectedAttackerHP = attacker.HP - defender.Damage;
            int expectedDefenderHP = defender.HP - attacker.Damage;

            this.arena.Fight(attacker.Name, defender.Name);

            int actualAttackerHP = attacker.HP;            
            int actualDefenrHP = defender.HP;           

            Assert.AreEqual(expectedAttackerHP, actualAttackerHP);

            Assert.AreEqual(expectedDefenderHP, actualDefenrHP);

        }
    }
}
