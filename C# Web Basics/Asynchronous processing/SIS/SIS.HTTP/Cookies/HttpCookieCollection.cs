using SIS.HTTP.Cookies.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIS.HTTP.Cookies
{
    public class HttpCookieCollection : IHttpCookieCollection
    {
        private const string HttpCookieStringSeparator = "\r\n";
        private readonly Dictionary<string, HttpCookie> cookies;

        public HttpCookieCollection()
        {
            this.cookies = new Dictionary<string, HttpCookie>();
        }

        public void AddCookie(HttpCookie cookie)
        {
            this.cookies.Add(cookie.Key, cookie);
        }

        public bool ContainsCookie(string key)
        => this.cookies.Any(c => c.Key == key);
        

        public HttpCookie GetCookie(string key)
        => this.cookies[key];
        

        public bool HasCookie()
        => this.cookies.Any();        

        public IEnumerator<HttpCookie> GetEnumerator()
        => this.cookies.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        => this.GetEnumerator();

        public override string ToString()
        {
            return string.Join(HttpCookieStringSeparator, this.cookies.Values);
        }
    }
}
