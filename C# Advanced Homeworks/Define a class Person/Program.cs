using System;

namespace DefiningClasses1
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person(10);
            

            Person persontwo = new Person();
            persontwo.Name = "Ivan";
            persontwo.Age = 15;

        }
    }
}
