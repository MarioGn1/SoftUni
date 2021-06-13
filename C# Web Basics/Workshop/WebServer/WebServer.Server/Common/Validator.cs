using System;

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
