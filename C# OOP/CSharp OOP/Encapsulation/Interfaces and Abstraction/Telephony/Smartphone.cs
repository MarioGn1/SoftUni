using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    class Smartphone : ICallable, IBrowseable
    {       
        public void Browse(string url)
        {
            bool containsDigits = url.Any(el => char.IsDigit(el));
            if (containsDigits)
            {
                throw new ArgumentException("Invalid URL!");
            }

            Console.WriteLine($"Browsing: {url}!");
        }

        public void Call(string number)
        {
            bool containsDigits = number.All(el => char.IsDigit(el));
            if (!containsDigits)
            {
                throw new ArgumentException("Invalid number!");
            }

            Console.WriteLine($"Calling... {number}");
        }
    }
}
