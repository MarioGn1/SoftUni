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

        public IRoutingTable Map(string url, HttpMethod method, HttpResponse response)
        {
            return method switch
            {
                HttpMethod.GET => this.MapGet(url, response),
                _ => throw new InvalidOperationException("Request is not Valid."),
            };
        }

        public IRoutingTable MapGet(string url, HttpResponse response)
        {
            Validator.AgainstNull(url, nameof(url));
            Validator.AgainstNull(response, nameof(response));

            this.routes[HttpMethod.GET][url] = response;

            return this;
        }

        public HttpResponse MatchRequest(HttpRequest request)
        {
            var requestMethod = request.Method;
            var requestUrl = request.Url;

            if (!this.routes.ContainsKey(requestMethod) || !this.routes[requestMethod].ContainsKey(requestUrl))
            {
                return new NotFoundResponse();
            }

            return this.routes[requestMethod][requestUrl];
        }
    }
}
