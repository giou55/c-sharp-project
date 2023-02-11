using static App.Helper; // if we want to use the static members of a class 
using Namespace1; // if we want to use the classes in a namespace

namespace Application
{
    class Program
    {
        static void Main(string[] args)
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