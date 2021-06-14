using System;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System.Threading.Tasks;
using WebServer.Server.Http;
using WebServer.Server.Routing;

namespace WebServer.Server
{
    public class HttpServer
    {
        private readonly int port;
        private readonly IPAddress iPAddress;
        private readonly TcpListener listener;
        private readonly RoutingTable routingTable;

        public HttpServer(string ipAddress, int port, Action<IRoutingTable> routingTableConfiguration)
        {
            this.iPAddress = IPAddress.Parse(ipAddress);
            this.port = port;

            listener = new TcpListener(this.iPAddress, this.port);

            routingTableConfiguration(this.routingTable = new RoutingTable());
        }

        public HttpServer(int port, Action<IRoutingTable> routingTable) : this("127.0.0.1", port, routingTable)
        {
        }

        public HttpServer(Action<IRoutingTable> routingTable) : this(8080, routingTable)
        {
        }

        public async Task Start()
        { 
            this.listener.Start();

            Console.WriteLine($"Server started on port {port}");
            Console.WriteLine("Listening for request...");

            while (true)
            {
                TcpClient connection = await listener.AcceptTcpClientAsync();

                var networkStream = connection.GetStream();

                var requestText = await ReadRequest(networkStream);

                try
                {
                    var request = HttpRequest.Parse(requestText);

                    var response = this.routingTable.ExecuteRequest(request);

                    this.PrepareSession(request, response);

                    this.LogPipeline(request, response);

                    await WriteResponce(networkStream, response);
                }
                catch (Exception exception)
                {
                    await HandleError(networkStream, exception);
                }


                connection.Close();
            }
        }

        private void LogPipeline(HttpRequest request, HttpResponse response)
        {
            var separator = new string('-', 50);
            var sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine(separator);

            sb.AppendLine("REQUEST:");
            sb.AppendLine(request.ToString());

            sb.AppendLine();

            sb.AppendLine("RESPONSE:");
            sb.AppendLine(response.ToString());

            sb.AppendLine();

            Console.WriteLine(sb.ToString());
        }

        private void PrepareSession(HttpRequest request, HttpResponse response)
        {
            response.AddCookie(HttpSession.SessionCookieName, request.Session.Id);
        }

        private async Task<string> ReadRequest(NetworkStream networkStream)
        {
            var bufferLength = 1024;
            var buffer = new byte[bufferLength];

            var requestBuilder = new StringBuilder();

            do
            {
                var bytesCount = await networkStream.ReadAsync(buffer, 0, bufferLength);
                requestBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesCount));

            } while (networkStream.DataAvailable);

            return requestBuilder.ToString();
        }

        private async Task HandleError(NetworkStream networkStream, Exception exception)
        {
            var errorMessage = $"{exception.Message}{Environment.NewLine}{exception.StackTrace}";
            var errorResponse = HttpResponse.ForError(errorMessage);
            await WriteResponce(networkStream, errorResponse);
        }

        private async Task WriteResponce(NetworkStream networkStream, HttpResponse response)
        {
            var responseBytes = Encoding.UTF8.GetBytes(response.ToString());

            await networkStream.WriteAsync(responseBytes);
        }
    }
}
