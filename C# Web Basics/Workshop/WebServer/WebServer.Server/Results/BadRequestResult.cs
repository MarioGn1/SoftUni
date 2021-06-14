using WebServer.Server.Http;

namespace WebServer.Server.Results
{
    public class BadRequestResult : HttpResponse
    {
        public BadRequestResult() 
            : base(HttpStatusCode.BadRequest)
        {
        }
    }
}
