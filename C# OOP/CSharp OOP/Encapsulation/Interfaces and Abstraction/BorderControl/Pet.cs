using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    class Pet : IInhabitable
    {
        public Pet(string name, string birthday)
        {
            this.Birthday = birthday;
            this.Name = name;
        }
        public string Birthday { get; private set; }

        public string Name { get; private set; }

        public string Id => null;

        public int Age => throw new NotImplementedException();
    }
}
