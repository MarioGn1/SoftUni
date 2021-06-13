using System.Runtime.CompilerServices;
using WebServer.Server.Http;
using WebServer.Server.Results;

namespace WebServer.Server.Controllers
{
    public abstract class Controller
    {
        protected Controller(HttpRequest request)
            => this.Request = request;

        protected HttpRequest Request { get; private init; }

        protected HttpResponse Text(string text)
            => new TextResponse(text);

        protected HttpResponse Html(string html)
            => new HtmlResponse(html);

        protected HttpResponse Redirect(string location)
            => new RedirectResponse(location);

        protected HttpResponse View([CallerMemberName] string viewName = "")
            => new ViewResponse(viewName, GetControlerName(), null);

        protected HttpResponse View(string viewName, object model)
            => new ViewResponse(viewName, GetControlerName(), model);

        protected HttpResponse View(object model, [CallerMemberName] string viewName = "")
            => new ViewResponse(viewName, GetControlerName(), model);

        private string GetControlerName()
            => this.GetType().Name.Replace(nameof(Controller), string.Empty);
    }
}
