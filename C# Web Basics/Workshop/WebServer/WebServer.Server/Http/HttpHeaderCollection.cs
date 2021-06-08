using System.Collections;
using System.Collections.Generic;

namespace WebServer.Server.Http
{
    public class HttpHeaderCollection : IEnumerable<HttpHeader>
    {
        private readonly Dictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
        {
            headers = new();
        }

        public int Count => this.headers.Count;

        public void Add(string name, string vallue)
        {
            var header = new HttpHeader(name, vallue);
            this.headers.Add(header.Name, header);
        }

        public IEnumerator<HttpHeader> GetEnumerator()
        {
           return this.headers.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
