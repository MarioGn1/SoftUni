using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public interface IInhabitable
    {
        public string Id { get; }
        public string Name { get; }
        public string Birthday { get; }
        public int Age { get; }
    }
}
