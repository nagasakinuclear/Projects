using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ShopApi
{
    public class RequireHttpsAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.RequestUri.Scheme != Uri.UriSchemeHttps)
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Found);
                actionContext.Response.Content = new StringContent("<h2>Use HTTPS instead of HTTP </h2>", Encoding.UTF8, "text/html");
                UriBuilder uri = new UriBuilder(actionContext.Request.RequestUri);
                uri.Scheme = Uri.UriSchemeHttps;
                uri.Port = 44356;

                actionContext.Response.Headers.Location = uri.Uri;
            }
            else
            {
                base.OnAuthorization(actionContext);
            }
        }
    }
}