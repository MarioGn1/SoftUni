using NUnit.Framework;

namespace BankAccount.UnitTests
{
    [TestFixture]
    public class BankAccountTest
    {
        private UnitTesting.BankAccount account;

        [SetUp]
        public void Initializer()
        {
            account = new UnitTesting.BankAccount(5000m);
        }

        [Test]
        public void AccountInitializeWithPositiveValue()
        {           
            Assert.That(account.Amount, Is.EqualTo(5000m));
        }

        [Test]
        public void DepositShouldAddMoney()
        {
            account.Deposit(1000m);

            Assert.That(account.Amount, Is.EqualTo(6000m));
        }
    }
}
