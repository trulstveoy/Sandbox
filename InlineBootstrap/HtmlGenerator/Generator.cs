using System.IO;
using System.Text;
using HtmlAgilityPack;

namespace HtmlGenerator
{
    public class Generator
    {
        public string Generate(string baseHtml)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(baseHtml);

            WriteContent(doc);
            
            var sb = new StringBuilder();
            var writer = new StringWriter(sb);
            doc.Save(writer);
            return sb.ToString();
        }

        public string Append(string baseHtml)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(baseHtml);

            AppendContent(doc);

            var sb = new StringBuilder();
            var writer = new StringWriter(sb);
            doc.Save(writer);
            return sb.ToString();
        }

        private void WriteContent(HtmlDocument doc)
        {
            HtmlNode bodyContent = doc.GetElementbyId("bodyContent");

            var heading = doc.CreateElement("h1");
            heading.InnerHtml = "Heading";
            bodyContent.AppendChild(heading);

            HtmlNode table = bodyContent.CreateElement("table");
            table.CreateAttributeWithValue("class", "table table-striped table-bordered");
            var tableHead = table.CreateElement("thead");
            var headerRow = tableHead.CreateElement("tr");
            headerRow.CreateElementWithHtml("td", "First");
            headerRow.CreateElementWithHtml("td", "Second");
            headerRow.CreateElementWithHtml("td", "Third");
            headerRow.CreateElementWithHtml("td", "Fourth");
            headerRow.CreateElementWithHtml("td", "Fifth");

            HtmlNode tableBody = table.CreateElement("tbody");
            const string text = "Fi fa fo fum fi fa fo fum fi fa fo fum fi fa fo fum";
            for (int i = 0; i < 10; i++)
            {
                HtmlNode bodyRow = tableBody.CreateElement("tr");
                bodyRow.CreateElementWithHtml("td", i + " first " + text);
                bodyRow.CreateElementWithHtml("td", i + " second " + text);
                bodyRow.CreateElementWithHtml("td", i + " third " + text);
                bodyRow.CreateElementWithHtml("td", i + " fourth " + text);
                bodyRow.CreateElementWithHtml("td", i + " fifth " + text);
            }
        }

        private void AppendContent(HtmlDocument doc)
        {
            HtmlNode bodyContent = doc.GetElementbyId("bodyContent");

            var heading = doc.CreateElement("h1");
            heading.InnerHtml = "Appended Heading";
            bodyContent.AppendChild(heading);

            HtmlNode table = bodyContent.CreateElement("table");
            table.CreateAttributeWithValue("class", "table table-striped table-bordered");
            var tableHead = table.CreateElement("thead");
            var headerRow = tableHead.CreateElement("tr");
            headerRow.CreateElementWithHtml("td", "First");
            headerRow.CreateElementWithHtml("td", "Second");
            headerRow.CreateElementWithHtml("td", "Third");
            headerRow.CreateElementWithHtml("td", "Fourth");
            headerRow.CreateElementWithHtml("td", "Fifth");

            HtmlNode tableBody = table.CreateElement("tbody");
            const string text = "Fi fa fo fum fi fa fo fum fi fa fo fum fi fa fo fum";
            for (int i = 0; i < 10; i++)
            {
                HtmlNode bodyRow = tableBody.CreateElement("tr");
                bodyRow.CreateElementWithHtml("td", i + " first " + text);
                bodyRow.CreateElementWithHtml("td", i + " second " + text);
                bodyRow.CreateElementWithHtml("td", i + " third " + text);
                bodyRow.CreateElementWithHtml("td", i + " fourth " + text);
                bodyRow.CreateElementWithHtml("td", i + " fifth " + text);
            }
        }
    }
}