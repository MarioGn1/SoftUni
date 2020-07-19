using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.IO
{
    public interface IWriter
    {
        void WriteLine(string text);

        void Write(string text);
    }
}
