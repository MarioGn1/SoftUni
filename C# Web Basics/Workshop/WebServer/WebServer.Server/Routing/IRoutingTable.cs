using WebServer.Server.Http;

namespace WebServer.Server.Routing
{
    public interface IRoutingTable
    {
        IRoutingTable Map(string url,HttpMethod method, HttpResponse response);
        IRoutingTable MapGet(string url, HttpResponse response);
    }
}
