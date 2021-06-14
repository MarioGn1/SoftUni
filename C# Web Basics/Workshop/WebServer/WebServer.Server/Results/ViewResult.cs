using System.IO;
using System.Linq;
using WebServer.Server.Http;

namespace WebServer.Server.Results
{
    public class ViewResult : ActionResult
    {
        private const char PathSeparator = '/';

        public ViewResult(HttpResponse response, string viewName, string controllerName, object model)
            : base(response)
        {
            this.GetHtml(viewName, controllerName, model);
        }

        private void GetHtml(string viewName, string controllerName, object model)
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

            if (model != null)
            {
                viewContent = this.PopulateModel(viewContent, model);
            }

            this.PrepareContent(viewContent, HttpContentType.Html);
        }

        private void PrepareMissinViewError(string viewPath)
        {
            this.StatusCode = HttpStatusCode.NotFound;

            var errorMessage = $"View '{viewPath}' was not found.";

            this.PrepareContent(errorMessage, HttpContentType.PlainText);
        }

        private string PopulateModel(string viewContent, object model)
        {
            var data = model
                .GetType()
                .GetProperties()
                .Select(pr => new 
                { 
                    Name = pr.Name,
                    Value = pr.GetValue(model) 
                });

            foreach (var entry in data)
            {
                const string openingBrakets = "{{";
                const string closingBrakets = "}}";
                viewContent = viewContent.Replace($"{openingBrakets}{entry.Name}{closingBrakets}", entry.Value.ToString());
            }

            return viewContent;
        }
    }
}
