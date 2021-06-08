using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Server.Common
{
    public static class Validator
    {
        public static void AgainstNull(object value, string name= null)
        {
            if (value == null)
            {
                name ??= "Value";
                throw new ArgumentException($"{name} can not be null.")!;
            }
        }
    }
}
