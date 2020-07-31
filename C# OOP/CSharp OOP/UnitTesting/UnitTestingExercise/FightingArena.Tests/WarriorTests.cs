using NUnit.Framework;
//using FightingArena;

namespace Tests
{
    [TestFixture]
    public class WarriorTests
    {
        private string name;
        private int damage;
        private int hp;
        Warrior warrior;

        [SetUp]
        public void Setup()
        {
            name = "Mario";
            damage = 10;
            hp = 10;
            warrior = new Warrior(name, damage, hp);
        }

        [Test]
        public void CheckName_PropertyCorectGetter()
        {
            string actualName = warrior.Name;
            string expectedName = name;

            Assert.That(actualName, Is.EqualTo(expectedName));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Constructor_CheckName_TrowArgumentException_IfPropertyIsNullOrEmptyOrWhiteSpaces(string name)
        {
            Assert.That(() => new Warrior(name, damage, hp), Throws.ArgumentException.With.Message.EqualTo("Name should not be empty or whitespace!"));
        }

        [Test]
        public void CheckDamagen_PropertyCorectGetter()
        {
            int actualDamage = warrior.Damage;
            int expectedDamage = damage;

            Assert.That(actualDamage, Is.EqualTo(expectedDamage));
        }

        [TestCase(-1)]
        [TestCase(0)]
        public void Constructor_CheckDamage_TrowArgumentException_IfArgumentIsEqualOrLessThanZeor(int damage)
        {
            Assert.That(() => new Warrior(name, damage, hp), Throws.ArgumentException.With.Message.EqualTo("Damage value should be positive!"));
        }

        [Test]
        public void CheckHP_PropertyCorectGetter()
        {
            double actualFuelCapacity = warrior.HP;
            double expectedFuelCapacity = hp;

            Assert.That(actualFuelCapacity, Is.EqualTo(expectedFuelCapacity));
        }

        [Test]
        public void Constructor_CheckHp_TrowArgumentException_IfArgumentIsEqualOrLessThanZeor()
        {
            int zeroHp = -1;
            Assert.That(() => new Warrior(name, damage, zeroHp), Throws.ArgumentException.With.Message.EqualTo("HP should not be negative!"));
        }

        [Test]
        public void Attack_CheckHp_InvalidOperationException_WhenHpLessThan_MIN_ATTACK_HP()
        {
            Warrior enemy = new Warrior("DarkElf", 20, 20);

            Assert.That(() => warrior.Attack(enemy), Throws.InvalidOperationException.With.Message.EqualTo("Your HP is too low in order to attack other warriors!"));
        }

        [Test]
        public void Attack_CheckHp_InvalidOperationException_WhenEnemyHpLessThan_MIN_ATTACK_HP()
        {
            warrior = new Warrior("Mario", 10, 40);
            Warrior enemy = new Warrior("DarkElf", 20, 20);

            Assert.That(() => warrior.Attack(enemy), Throws.InvalidOperationException);
        }

        [Test]
        public void Attack_CheckHp_InvalidOperationException_WhenEnemyHpMoreThan_HeroHp()
        {
            warrior = new Warrior("Mario", 10, 40);
            Warrior enemy = new Warrior("DarkElf", 50, 35);

            Assert.That(() => warrior.Attack(enemy), Throws.InvalidOperationException.With.Message.EqualTo($"You are trying to attack too strong enemy"));
        }

        [Test]
        public void Attack_Check_DecreaseHeroHPValue()
        {
            warrior = new Warrior("Mario", 10, 40);
            Warrior enemy = new Warrior("DarkElf", 35, 35);
            warrior.Attack(enemy);

            int actualHerroHp = warrior.HP;
            int expectedHerroHp = 5;

            Assert.That(actualHerroHp, Is.EqualTo(expectedHerroHp));
        }

        [Test]
        public void Attack_Check_EnemyHpDecreaseToZero()
        {
            warrior = new Warrior("Mario", 40, 40);
            Warrior enemy = new Warrior("DarkElf", 35, 35);
            warrior.Attack(enemy);

            int actualEnemyHp = enemy.HP;
            int expectedEnemyoHp = 0;

            Assert.That(actualEnemyHp, Is.EqualTo(expectedEnemyoHp));
        }

        [Test]
        public void Attack_Check_EnemyHpDecrease()
        {
            warrior = new Warrior("Mario", 40, 40);
            Warrior enemy = new Warrior("DarkElf", 35, 50);
            warrior.Attack(enemy);

            int actualEnemyHp = enemy.HP;
            int expectedEnemyoHp = 10;

            Assert.That(actualEnemyHp, Is.EqualTo(expectedEnemyoHp));
        }
    }
}