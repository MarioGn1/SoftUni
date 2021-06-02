using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responses.Contracts;
using SIS.WebServer.Result;

namespace Demo.App.Controllers
{
    public class HomeController : BaseController
    {
        public IHttpResponse Home(IHttpRequest httpRequest)
        {
            string content = "<h1>Hello, World!</h1>";
            return new HtmlResult(content, SIS.HTTP.Enums.HttpResponseStatusCode.Ok);
        }
    }
}
