using Newtonsoft.Json;

namespace App
{
    public class Helper
    {
        public static void Dump(object o)
        {
            string json = JsonConvert.SerializeObject(o, Formatting.Indented);
            Console.WriteLine(json);
        }
    }
}