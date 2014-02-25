using System;
using System.IO;
using System.Net;

namespace HtmlGenerator
{
    public class HtmlRetriever
    {
        public string Go()
        {
            WebRequest webRequest = WebRequest.Create("http://localhost:49569/");
            Stream responseStream = webRequest.GetResponse().GetResponseStream();
            if (responseStream == null)
            {
                throw new InvalidOperationException("Should never be null");
            }
            
            var reader = new StreamReader(responseStream);
            string html = reader.ReadToEnd();

            return html;
        }
    }
}