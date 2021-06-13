using WebServer.Server.Http;

namespace WebServer.Server.Results
{
    public class TextResponse : ContentResponse
    {
        public TextResponse(string text)
            : base(text, HttpContentType.PlainText)
        {
        }
    }
}
