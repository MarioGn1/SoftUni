using System.Threading.Tasks;
using WebServer.Controllers;
using WebServer.Server;
using WebServer.Server.Controllers;

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
                    .MapGet<AnimalsController>("/Cats", c => c.Cats())
                    .MapGet<AnimalsController>("/Bunnies", c => c.Bunnies())
                    .MapGet<AnimalsController>("/Turtles", c => c.Turtles())
                    .MapGet<AccountController>("/Cookie", c => c.ActionWithCookies())
                    .MapGet<CatsController>("/Cats/Create", c => c.Create())
                    .MapPost<CatsController>("/Cats/Save", c => c.Save()))
                .Start();
        }
    }
}
