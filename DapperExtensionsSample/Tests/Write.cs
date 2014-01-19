using System;
using Newtonsoft.Json;

namespace Tests
{
    public static class Write
    {
        public static void Out(object obj)
        {
            string text = JsonConvert.SerializeObject(obj, Formatting.Indented);
            Console.WriteLine(text);
        }
    }
}