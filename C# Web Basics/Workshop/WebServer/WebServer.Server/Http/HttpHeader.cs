using WebServer.Server.Common;

namespace WebServer.Server.Http
{
    public class HttpHeader
    {
        public HttpHeader(string name, string value)
        {
            Validator.AgainstNull(name, nameof(name));
            Validator.AgainstNull(value, nameof(value));

            this.Name = name;
            this.Value = value;
        }
        public string Name { get; init; }
        public string Value { get; init; }

        public override string ToString()
        {
            return $"{this.Name}: {this.Value}";
        }
    }
}
