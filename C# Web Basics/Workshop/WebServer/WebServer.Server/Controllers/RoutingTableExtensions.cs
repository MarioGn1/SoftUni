using System;
using WebServer.Server.Http;
using WebServer.Server.Routing;

namespace WebServer.Server.Controllers
{
    public static class RoutingTableExtensions
    {
        public static IRoutingTable MapGet<TController>(this IRoutingTable routingTable, string path, Func<TController, HttpResponse> controllerFunction)
            where TController : Controller
                => routingTable.MapGet(path, request =>
                {
                    var controller = CreateController<TController>(request);

                    return controllerFunction(controller);
                });


        public static IRoutingTable MapPost<TController>(this IRoutingTable routingTable, string path, Func<TController, HttpResponse> controllerFunction)
            where TController : Controller
                => routingTable.MapPost(path, request =>
                {
                    var controller = CreateController<TController>(request);

                    return controllerFunction(controller);
                });

        private static TController CreateController<TController>(HttpRequest request)
        => (TController)Activator.CreateInstance(typeof(TController), new[] { request });
    }
}
