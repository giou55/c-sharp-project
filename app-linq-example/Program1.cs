using MyNamespace; // if we want to use the classes in a namespace
using static App.Helper; // if we want to use the static members of a class 

namespace Application1
{
    class Program1
    {
        static void Main1(string[] args)
        {
            var hero = new Hero()
            {
                Name = "Tarodev",
                Damage = 420
            };

            Dump(hero);
            // {
            //   "Name": "Tarodev",
            //   "Damage": 420,
            //   "Message": ""
            // }
            Dump("hello world".Split(" "));
            // [
            //   "hello",
            //   "world"
            // ]

            var h = new MyClass();
            h.SayHello();

            Dump(typeof(Program1).Assembly.GetTypes()
                .Where(x => x.Name.EndsWith("ero")));
            // [
            //     "Application.Hero, app, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"
            // ]
        }
    }

    public class Hero
    {
        public Hero()
        {
            Console.WriteLine("Constructor is called");
        }

        public string? Name;
        public int? Damage;
        public string? Message { get; set; } = string.Empty;

        public void Attack()
        {
            Console.WriteLine($"{Name} did {Damage} damage");
        }
    }


}