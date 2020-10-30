using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    class StationaryPhone : ICallable
    {       
        public void Call(string number)
        {
            bool containsDigits = number.All(el => char.IsDigit(el));
            if (!containsDigits)
            {
                throw new ArgumentException("Invalid number!");
            }

            Console.WriteLine($"Dialing... {number}");
        }
    }
}
