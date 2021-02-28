using ADO.NET.Utils;
using System;
using System.Data.SqlClient;
using System.Threading;

namespace ADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            var _menu = new Menu();

            bool running = true;

            while (running)
            {
                running = _menu.MainMenu();
            }
        }
    }
}
