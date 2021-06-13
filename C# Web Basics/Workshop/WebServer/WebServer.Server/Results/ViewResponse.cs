using System.IO;
using WebServer.Server.Http;

namespace WebServer.Server.Results
{
    public class ViewResponse : HttpResponse
    {
        private const char PathSeparator = '/';

        public ViewResponse(string viewName, string controllerName)
            : base(HttpStatusCode.OK)
        {
            this.GetHtml(viewName, controllerName);
        }

        private void GetHtml(string viewName, string controllerName)
        {
            if (!viewName.Contains(PathSeparator))
            {
                viewName = controllerName + PathSeparator + viewName;
            }

            var viewPath = Path.GetFullPath(Directory.GetCurrentDirectory() + "/Views/" + viewName.TrimStart(PathSeparator) + ".cshtml");

            if (!File.Exists(viewPath))
            {
                this.PrepareMissinViewError(viewPath);

                return;
            }

            var viewContent = File.ReadAllText(viewPath);

            this.PrepareContent(viewContent, HttpContentType.Html);
        }

        private void PrepareMissinViewError(string viewPath)
        {
            this.StatusCode = HttpStatusCode.NotFound;

            var errorMessage = $"View '{viewPath}' was not found.";

            this.PrepareContent(errorMessage, HttpContentType.PlainText);
        }
    }
}
