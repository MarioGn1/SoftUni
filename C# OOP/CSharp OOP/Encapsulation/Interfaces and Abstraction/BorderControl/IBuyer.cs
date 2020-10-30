using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    interface IBuyer : IInhabitable
    {
        public void BuyFood();
        public int Food { get; }
    }
}
