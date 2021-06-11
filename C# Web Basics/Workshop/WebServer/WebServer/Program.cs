using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WebServer.Controllers;
using WebServer.Server;
using WebServer.Server.Controllers;
using WebServer.Server.Results;

namespace WebServer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await new HttpServer("127.0.0.1", 8080,
                routes => routes
                    .MapGet<HomeController>("/", c => c.Index())
                    .MapGet<HomeController>("/ToCats", c => c.LocalRedirect())
                    .MapGet<HomeController>("/softuni", c => c.ToSoftUni())
                    .MapGet<AnimalsController>("/Dogs", c => c.Dogs())
                    .MapGet<AnimalsController>("/Cats", c => c.Cats()))
                .Start();
        }
    }
}
