using WebServer.Server.Http;

namespace WebServer.Server.Results
{
    public class RedirectResult : ActionResult
    {
        public RedirectResult(HttpResponse response, string location) 
            : base(response)
        {
            this.StatusCode = HttpStatusCode.Found;
            this.AddHeader(HttpHeader.Location, location);
        }
    }
}
