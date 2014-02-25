using HtmlAgilityPack;

namespace HtmlGenerator
{
    public static class HtmlAgilityPackExtensions
    {
        public static HtmlNode CreateElementWithHtml(this HtmlDocument htmlDocument, string name, string html)
        {
            HtmlNode htmlNode = htmlDocument.CreateElement(name);
            htmlNode.InnerHtml = html;
            return htmlNode;
        }

        public static HtmlNode CreateElement(this HtmlNode htmlNode, string name)
        {
            HtmlNode element = htmlNode.OwnerDocument.CreateElement(name);
            htmlNode.AppendChild(element);
            return element;
        }

        public static HtmlNode CreateElementWithHtml(this HtmlNode htmlNode, string name, string html)
        {
            HtmlNode element = htmlNode.OwnerDocument.CreateElement(name);
            element.InnerHtml = html;
            htmlNode.AppendChild(element);
            return element;
        }

        public static HtmlNode CreateAttributeWithValue(this HtmlNode htmlNode, string name, string value)
        {
            HtmlAttribute htmlAttribute = htmlNode.OwnerDocument.CreateAttribute(name);
            htmlAttribute.Value = value;
            htmlNode.Attributes.Add(htmlAttribute);
            return htmlNode;
        }
    }
}