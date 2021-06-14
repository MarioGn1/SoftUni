using WebServer.Server.Http;

namespace WebServer.Server.Results
{
    public class NotFoundResult : ActionResult
    {
        public NotFoundResult(HttpResponse response) 
            : base(response)
        {
            this.StatusCode = HttpStatusCode.NotFound;
        }
    }
}
