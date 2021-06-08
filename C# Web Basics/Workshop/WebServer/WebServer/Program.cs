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
                    .MapGet("/Dogs", new TextResponse("<h1>Hello from the dogs!</h1>", "text/html"))
                    .MapGet("/Cats", new TextResponse("<h1>Hello from the cats!</h1>", "text/html")))
                .Start();            
        }
    }
}
