using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WebServer.Server;
using WebServer.Server.Results;

namespace WebServer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await new HttpServer("127.0.0.1", 8080,
                routes => routes
                    .MapGet("/", new TextResponse("Hello from Mario!"))
                    .MapGet("/Dogs", new HtmlResponse("<h1>Hello from the dogs!</h1>"))
                    .MapGet("/Cats", request =>
                    {
                        const string nameKey = "Name";
                        
                        var query = request.Query;

                        var catName = query.ContainsKey(nameKey) ? query[nameKey] : "the cats";

                        var result = $"<h1>Hello from {catName}!</h1>";

                        return new HtmlResponse(result);
                    }))
                .Start();
        }
    }
}
