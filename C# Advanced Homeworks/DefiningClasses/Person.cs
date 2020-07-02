namespace DefiningClasses
{
    public class Person
    {
        private string name;
        private int age;


        public Person()
        {
            this.Name = "No name";
            this.Age = 1;
        }

        public Person(int age) : this()
        {
            this.Age = age;
        }

        public Person(string name, int age)
        {
            this.Age = age;
            this.Name = name;
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
//namespace DefiningClasses
//{
//    public class Person
//    {
//        private string name;
//        private int age;

//        public string Name
//        {
//            get
//            {
//                return name;
//            }
//            set
//            {
//                name = value;
//            }
//        }

//        public int Age
//        {
//            get
//            {
//                return age;
//            }
//            set
//            {
//                age = value;
//            }
//        }

//        public Person(string name, int age)
//        {
//            Name = name;
//            Age = age;
//        }

//        public Person(int age) : this("No name", age)
//        {
//        }

//        public Person() : this("No name", 1)
//        {
//        }
//    }
//}
