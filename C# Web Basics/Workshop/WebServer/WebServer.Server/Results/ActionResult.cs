using WebServer.Server.Http;
using System.Collections.Generic;

namespace WebServer.Server.Results
{
    public abstract class ActionResult : HttpResponse
    {
        public ActionResult(HttpResponse response) 
            : base(response.StatusCode)
        {
            this.Content = response.Content;
            PrepareHeaders(response.Headers);
            PrepareCookies(response.Cookies);
        }

        protected HttpResponse Response { get; private init; }

        private void PrepareHeaders(IDictionary<string, HttpHeader> headers)
        {
            foreach (var header in headers.Values)
            {
                this.AddHeader(header.Name, header.Value);
            }
        }

        private void PrepareCookies(IDictionary<string, HttpCookie> cookies)
        {
            foreach (var cookie in cookies.Values)
            {
                this.AddCookie(cookie.Name, cookie.Value);
            }
        }
    }
}
