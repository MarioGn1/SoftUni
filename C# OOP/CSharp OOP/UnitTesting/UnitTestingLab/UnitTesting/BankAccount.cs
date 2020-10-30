using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTesting
{
    public class BankAccount
    {
        private decimal ammount;

        public decimal Amount
        {
            get { return ammount; }
            private set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Value must be positive");
                }
                ammount = value; 
            }
        }

        

        public BankAccount(decimal initialAmount)
        {            
            this.Amount = initialAmount;
        }

        public void Deposit(decimal amount)
        {
            Amount += amount;
        }
    }
}
