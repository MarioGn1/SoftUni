using System.Runtime.CompilerServices;
using WebServer.Server.Http;
using WebServer.Server.Results;

namespace WebServer.Server.Controllers
{
    public abstract class Controller
    {
        protected Controller(HttpRequest request)
        {
            this.Request = request;
            this.Response = new HttpResponse(HttpStatusCode.OK);
        }

        protected HttpRequest Request { get; private init; }
        protected HttpResponse Response { get; private init; }

        protected ActionResult Text(string text)
            => new TextResult(this.Response, text);

        protected ActionResult Html(string html)
            => new HtmlResult(this.Response, html);

        protected ActionResult Redirect(string location)
            => new RedirectResult(this.Response, location);

        protected ActionResult View([CallerMemberName] string viewName = "")
            => new ViewResult(this.Response, viewName, GetControlerName(), null);

        protected ActionResult View(string viewName, object model)
            => new ViewResult(this.Response, viewName, GetControlerName(), model);

        protected ActionResult View(object model, [CallerMemberName] string viewName = "")
            => new ViewResult(this.Response, viewName, GetControlerName(), model);

        private string GetControlerName()
            => this.GetType().Name.Replace(nameof(Controller), string.Empty);
    }
}
