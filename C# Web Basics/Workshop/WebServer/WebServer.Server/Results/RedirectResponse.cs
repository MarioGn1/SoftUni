using WebServer.Server.Http;

namespace WebServer.Server.Results
{
    public class RedirectResponse : HttpResponse
    {
        public RedirectResponse(string location) 
            : base(HttpStatusCode.Found)
        {
            this.Headers.Add(HttpHeader.Location, new HttpHeader(HttpHeader.Location, location));
        }
    }
}
