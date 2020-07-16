using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Exeptions
{
    public class MyExeption : Exception
    {
        private const string MSG = "Incorect parameter!";
        public MyExeption()
            : base (MSG)
        {
        }

        public MyExeption(string message) : base(message)
        {
        }
    }
}
