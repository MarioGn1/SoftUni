using System;
using WebServer.Server.Controllers;
using WebServer.Server.Http;

namespace WebServer.Controllers
{
    public class AccountController : Controller
    {
        public AccountController(HttpRequest request) 
            : base(request)
        {
        }

        public HttpResponse ActionWithCookies()
        {
            const string cookieName = "My-Cookie";

            if (this.Request.Cookies.ContainsKey(cookieName))
            {
                var cookie = this.Request.Cookies[cookieName];

                return Text($"Cookie already exist - {cookie}");
            }
            this.Response.AddCookie(cookieName, "My-Value");
            this.Response.AddCookie("My-Second-Cookie", "My-Second-Value");

            return Text("Cookies set!");
        }

        public HttpResponse ActionWithSession()
        {
            const string currDateKey = "CurrentDate";

            if (this.Request.Session.ContainsKey(currDateKey))
            {
                var currDate = this.Request.Session[currDateKey];

                return Text($"Stored date: {currDate}");
            }

            this.Request.Session[currDateKey] = DateTime.UtcNow.ToString();

            return Text("Current date stored!");
        }
    }
}
