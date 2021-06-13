using WebServer.Server.Http;

namespace WebServer.Server.Results
{
    public class HtmlResponse : ContentResponse
    {
        public HtmlResponse(string html) 
            : base(html, HttpContentType.Html)
        {
        }
    }
}
