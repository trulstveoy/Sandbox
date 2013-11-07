﻿using System;
using System.Web;
using NLog;
using LogFactory = Webbox.Core.Logging.LogFactory;

namespace Webbox.Core.Web.Filters
{
    public class LoggingHttpModule : IHttpModule
    {
        private static readonly Logger Log = LogFactory.Instance;
        public void Init(HttpApplication application)
        {
            application.EndRequest += OnApplicationEndRequest;
        }

        private void OnApplicationEndRequest(object sender, EventArgs e)
        {
            //var application = (HttpApplication)sender;
            //var request = application.Request;

            //string httpInfo = request.HttpMethod + " " + request.RawUrl + " " + request.ServerVariables["SERVER_PROTOCOL"];
            //Log.Debug(httpInfo);


        }

        public void Dispose()
        {
            
        }
    }
}