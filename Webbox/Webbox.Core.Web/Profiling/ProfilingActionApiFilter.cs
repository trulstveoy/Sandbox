using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using StackExchange.Profiling;

namespace Webbox.Core.Web.Profiling
{
    public class ProfilingActionApiFilter : ActionFilterAttribute
    {
        const string StackKey = "ProfilingActionApiFilterStack";

        /// <summary>
        /// Happens before the action starts running
        /// </summary>
        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            var mp = MiniProfiler.Current;
            if (mp != null)
            {
                var stack = HttpContext.Current.Items[StackKey] as Stack<IDisposable>;
                if (stack == null)
                {
                    stack = new Stack<IDisposable>();
                    HttpContext.Current.Items[StackKey] = stack;
                }

                var profiler = MiniProfiler.Current;
                if (profiler != null)
                {

                    var tokens = filterContext.Request.GetRouteData().Route.DataTokens;
                    string area = tokens != null && tokens.ContainsKey("area") && !string.IsNullOrEmpty(tokens["area"].ToString()) ?
                        tokens["area"] + "." : "";
                    string controller = filterContext.ControllerContext.Controller.ToString().Split('.').Last() + ".";
                    string action = filterContext.ActionDescriptor.ActionName;

                    stack.Push(profiler.Step("Controller: " + area + controller + action));
                }


            }
            base.OnActionExecuting(filterContext);
        }

        /// <summary>
        /// Happens after the action executes
        /// </summary>
        public override void OnActionExecuted(HttpActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            var stack = HttpContext.Current.Items[StackKey] as Stack<IDisposable>;
            if (stack != null && stack.Count > 0)
            {
                stack.Pop().Dispose();
            }
        }
    }
}
