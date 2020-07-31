//using ExtendedDatabaseJob;
using NUnit.Framework;
using System;


namespace Tests
{
    public class ExtendedDatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor_Check_ZeroCountValidity()
        {
            ExtendedDatabase database = new ExtendedDatabase();

            int actual = database.Count;
            int expected = 0;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Constructor_Check_CountValidity_UsingActualArray()
        {
            Person personone = new Person(12, "Pesho");
            Person persontwo = new Person(13, "Gosho");
            ExtendedDatabase database = new ExtendedDatabase(personone, persontwo);

            int actual = database.Count;
            int expected = 2;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Constructor_Check_ExceptionThrown_UsingArrayWithMoreThan16numbers()
        {
            Person[] persons = new Person[17];            

            Assert.That(() => new ExtendedDatabase(persons), Throws.ArgumentException.With.Message.EqualTo("Provided data length should be in range [0..16]!"));
        }

        [Test]
        public void Constructor_CheckForRepeatedUsername()
        {
            Person personone = new Person(12, "Pesho");
            Person persontwo = new Person(13, "Pesho");            

            Assert.That(() => new ExtendedDatabase(personone, persontwo), Throws.InvalidOperationException.With.Message.EqualTo("There is already user with this username!"));
        }

        [Test]
        public void Constructor_CheckForRepeatedID()
        {
            Person personone = new Person(12, "Pesho");
            Person persontwo = new Person(12, "Gosho");

            Assert.That(() => new ExtendedDatabase(personone, persontwo), Throws.InvalidOperationException.With.Message.EqualTo("There is already user with this Id!"));
        }

        [Test]
        public void AddMethod_ExceptionThrown_TryingToAddMoreThan16Persons()
        {
            Person[] persons = new Person[16];
            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i, "Name" + i);
            }
            ExtendedDatabase database = new ExtendedDatabase(persons);
            Person person = new Person(12, "Gosho");

            Assert.That(() => database.Add(person), Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void AddMethod_Check_ExceptionThrown_TryingToAddExistingPerson()
        {
            Person[] persons = new Person[2];
            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i, "Name" + i);
            }
            ExtendedDatabase database = new ExtendedDatabase(persons);
            Person person = new Person(3, "Name0");

            Assert.That(() => database.Add(person), Throws.InvalidOperationException.With.Message.EqualTo("There is already user with this username!"));
        }

        [Test]
        public void AddMethod_Check_ExceptionThrown_TryingToAddExistingID()
        {
            Person[] persons = new Person[2];
            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i, "Name" + i);
            }
            ExtendedDatabase database = new ExtendedDatabase(persons);
            Person person = new Person(0, "Name3");

            Assert.That(() => database.Add(person), Throws.InvalidOperationException.With.Message.EqualTo("There is already user with this Id!"));
        }

        [Test]
        public void AddMethod_Check_CountRising()
        {
            Person[] persons = new Person[2];
            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i, "Name" + i);
            }
            ExtendedDatabase database = new ExtendedDatabase(persons);
            database.Add(new Person(2, "Name2"));

            int actual = database.Count;
            int expected = 3;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void RemoveMethod_Check_CountDecrease()
        {
            Person[] persons = new Person[2];
            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i, "Name" + i);
            }
            ExtendedDatabase database = new ExtendedDatabase(persons);
            database.Remove();

            int actual = database.Count;
            int expected = 1;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void RemoveMethod_Check_ExceptionThrown_TryToRemoveWhenEmptyArray()
        {
            ExtendedDatabase database = new ExtendedDatabase();

            Assert.That(() => database.Remove(), Throws.InvalidOperationException);
        }

        [TestCase(null)]
        [TestCase("")]
        public void FindByUsername_Check_ExceptionThrown_TryToFindUsernameWithNullParameter(string username)
        {
            ExtendedDatabase database = new ExtendedDatabase();

            Assert.That(() => database.FindByUsername(username), Throws.ArgumentNullException);                     
        }

        [Test]
        public void FindByUsername_Check_ExceptionThrown_TryToFindNotExistingUsername()
        {
            string nameOne = "Name3";            
            
            ExtendedDatabase database = new ExtendedDatabase();

            Assert.That(() => database.FindByUsername(nameOne), Throws.InvalidOperationException.With.Message.EqualTo("No user is present by this username!"));
        }

        [Test]
        public void FindByUsername_Check_IfReturnIsCorectUsingUsername()
        {
            Person person = new Person( 1 , "Gosho");
            string nameSearch = "Gosho";

            ExtendedDatabase database = new ExtendedDatabase(person);

            Person actual = database.FindByUsername(nameSearch);
            Person expected = person;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void FndByID_Check_ExceptionThrown_TryToFindWithNegativeIdParameter()
        {
            ExtendedDatabase database = new ExtendedDatabase();


            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-1));
        }

        [Test]
        public void FndByID_Check_ExceptionThrown_TryToFindNonExistingId()
        {
            ExtendedDatabase database = new ExtendedDatabase();

            Assert.That(() => database.FindById(1), Throws.InvalidOperationException.With.Message.EqualTo("No user is present by this ID!"));
        }

        [Test]
        public void FindByUsername_Check_IfReturnIsCorectUsingId()
        {
            Person person = new Person(1, "Gosho");
            int idSearch = 1;

            ExtendedDatabase database = new ExtendedDatabase(person);

            Person actual = database.FindById(idSearch);
            Person expected = person;

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}