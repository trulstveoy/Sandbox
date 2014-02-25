using System.IO;
using System.Web.Mvc;

namespace InlineBootstrap.Tools
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString InlineScriptBlock<TModel>(this HtmlHelper<TModel> htmlHelper, string path)
        {
            var builder = new TagBuilder("script");
            builder.Attributes.Add("type", "text/javascript");

            var physicalPath = htmlHelper.ViewContext.RequestContext.HttpContext.Server.MapPath(path);
            builder.InnerHtml = File.ReadAllText(physicalPath);

            return MvcHtmlString.Create(builder.ToString());
        }

        public static MvcHtmlString InlineStylesheet<TModel>(this HtmlHelper<TModel> htmlHelper, string path)
        {
            var builder = new TagBuilder("style");

            var physicalPath = htmlHelper.ViewContext.RequestContext.HttpContext.Server.MapPath(path);
            builder.InnerHtml = File.ReadAllText(physicalPath);

            return MvcHtmlString.Create(builder.ToString());
        }
    }

}