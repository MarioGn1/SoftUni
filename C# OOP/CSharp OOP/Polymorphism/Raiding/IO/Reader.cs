using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.IO
{
    class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
