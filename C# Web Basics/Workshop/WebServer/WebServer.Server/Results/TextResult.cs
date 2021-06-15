using WebServer.Server.Http;

namespace WebServer.Server.Results
{
    public class TextResult : ContentResult
    {
        public TextResult(HttpResponse response, string text)
            : base(response, text, HttpContentType.PlainText)
        {
        }
    }
}

