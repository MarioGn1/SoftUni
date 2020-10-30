//using DatabaseProblem;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class DatabaseTests
    {               
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Constructor_Check_ZeroCountValidity()
        {
            Database database = new Database();

            int actual = database.Count;
            int expected = 0;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Constructor_Check_CountValidity_UsingActualArray()
        {
            Database database = new Database(1, 2);

            int actual = database.Count;
            int expected = 2;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Constructor_Check_CorectInsertion_Sequence()
        {
            Database database = new Database(1, 2);

            int[] actual = database.Fetch();
            int[] expected = { 1, 2 };

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Constructor_Check_ExceptionThrown_UsingArrayWithMoreThan16numbers()
        {
            int[] arr = new int[17];          

            Assert.That(() => new Database(arr), Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void Add_Check_ExceptionThrown_UsingActualArray()
        {
            int[] arr = new int[16];
            Database database = new Database(arr);

            Assert.That(() => database.Add(0), Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void Add_CheckCount_AddingActualNumbers()
        {            
            Database database = new Database();
            database.Add(1);

            int actual = database.Count;
            int expected = 1;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Add_Check_CorectInsertion_Sequence()
        {
            Database database = new Database();
            database.Add(1);
            database.Add(2);

            int[] actual = database.Fetch();
            int[] expected = { 1, 2 };

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Remove_Check_ExceptionThrown_UsingActualArray()
        {
            
            Database database = new Database();
            

            Assert.That(() => database.Remove(), Throws.InvalidOperationException.With.Message.EqualTo("The collection is empty!"));
        }

        [Test]
        public void Remove_CheckCount_RemovingNumbers()
        {
            int[] arr = new int[16];
            Database database = new Database(arr);
            database.Remove();

            int actual = database.Count;
            int expected = 15;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Remove_Check_RemovingSequence()
        {            
            Database database = new Database(1, 2, 3);
            database.Remove();

            int[] actual = database.Fetch();
            int[] expected = {1, 2};

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Fetch_CheckCount()
        {            
            Database database = new Database();
            int[] fetchedArray = database.Fetch();

            int actual = fetchedArray.Length;
            int expected = database.Count;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Fetch_Check_FetchingSequence()
        {
            Database database = new Database(1,2);
            int[] fetchedArray = database.Fetch();

            int[] actual = fetchedArray;
            int[] expected = { 1, 2};

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}