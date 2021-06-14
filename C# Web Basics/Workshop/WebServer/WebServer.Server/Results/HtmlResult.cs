using WebServer.Server.Http;

namespace WebServer.Server.Results
{
    public class HtmlResult : ContentResult
    {
        public HtmlResult(HttpResponse response, string html) 
            : base(response, html, HttpContentType.Html)
        {
        }
    }
}
