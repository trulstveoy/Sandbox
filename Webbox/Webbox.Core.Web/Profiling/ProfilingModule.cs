using System;
using System.Web;
using StackExchange.Profiling;

namespace Webbox.Core.Web.Profiling
{
    public class ProfilingModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += OnBeginRequest;
            context.EndRequest += OnEndRequest;
        }

        private void OnBeginRequest(object sender, EventArgs e)
        {
            MiniProfiler.Start();
        }

        private void OnEndRequest(object sender, EventArgs e)
        {
            MiniProfiler.Stop();
        }

        public void Dispose()
        {}
    }
}
