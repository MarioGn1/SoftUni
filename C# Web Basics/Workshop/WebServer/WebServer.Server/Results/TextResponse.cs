using System.Text;
using WebServer.Server.Common;
using WebServer.Server.Http;

namespace WebServer.Server.Results
{
    public class TextResponse : ContentResponse
    {
        public TextResponse(string text)
            : base(text, "text/plain; charset=UTF-8")
        {
        }
    }
}
