using P01_StudentSystem.Data;
using System;

namespace P01_StudentSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new StudentSystemContext();

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
    }
}
