using System;
using Newtonsoft.Json;

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
        }

        private static void Dump(object o)
        {
            string json = JsonConvert.SerializeObject(o, Formatting.Indented);
            Console.WriteLine(json);
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