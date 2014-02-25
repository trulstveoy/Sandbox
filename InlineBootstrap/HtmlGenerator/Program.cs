using System;
using System.Diagnostics;
using System.IO;

namespace HtmlGenerator
{
    class Program
    {
        static void Main()
        {
            var retriever = new HtmlRetriever();
            var baseHtml = retriever.Go();

            var generator = new Generator();
            string html = generator.Generate(baseHtml);

            string filepath = string.Format(@"C:\temp\{0}.html", Guid.NewGuid());
            File.WriteAllText(filepath, html);
            Process.Start(filepath);

            string htmlForAppend = File.ReadAllText(filepath);
            string appendedHtml = generator.Append(htmlForAppend);

            string filepath2 = string.Format(@"C:\temp\{0}.html", Guid.NewGuid());
            File.WriteAllText(filepath2, appendedHtml);
            Process.Start(filepath2);
        }
    }
}
