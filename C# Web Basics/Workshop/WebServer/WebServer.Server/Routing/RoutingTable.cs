using System;
using System.Collections.Generic;
using WebServer.Server.Common;
using WebServer.Server.Http;
using WebServer.Server.Results;

namespace WebServer.Server.Routing
{
    public class RoutingTable : IRoutingTable
    {
        private readonly Dictionary<HttpMethod, Dictionary<string, HttpResponse>> routes;

        public RoutingTable()
        {
            this.routes = new()
            {
                [HttpMethod.GET] = new(),
                [HttpMethod.POST] = new(),
                [HttpMethod.PUT] = new(),
                [HttpMethod.DELETE] = new(),
            };
        }

        public IRoutingTable Map(HttpMethod method, string path, HttpResponse response)
        {
            Validator.AgainstNull(path, nameof(path));
            Validator.AgainstNull(response, nameof(response));

            this.routes[HttpMethod.GET][path] = response;

            return this;
        }

        public IRoutingTable MapGet(string path, HttpResponse response)
        {
            return Map(HttpMethod.GET, path, response);
        }

        public IRoutingTable MapPost(string path, HttpResponse response)
        {
            return Map(HttpMethod.POST, path, response);
        }

        public HttpResponse MatchRequest(HttpRequest request)
        {
            var requestMethod = request.Method;
            var requestPath = request.Path;

            if (!this.routes.ContainsKey(requestMethod) || !this.routes[requestMethod].ContainsKey(requestPath))
            {
                return new NotFoundResponse();
            }

            return this.routes[requestMethod][requestPath];
        }
    }
}
