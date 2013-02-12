using System;
using System.IO;
using System.Reflection;

namespace EmbeddedResourceWorksLikeThis.LastName
{
    public class Program
    {
        static void Main(string[] args)
        {
            foreach (var manifestResourceName in Assembly.GetExecutingAssembly().GetManifestResourceNames())
            {
                Console.WriteLine(manifestResourceName);
            }

            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("EmbeddedResourceWorksLikeThis.LastName.Foo.Bar.Text.txt");
            var reader = new StreamReader(stream);
            string text = reader.ReadToEnd();

            Console.WriteLine(text);
        }
    }
}
