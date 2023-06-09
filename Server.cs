using System.Net;
using System.Net.Sockets;

namespace OperatingSystem
{
    internal class Server
    {
        static public void Main()
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2023);
            Socket _server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _server.Bind(iep);
            _server.Listen(10);
            Console.WriteLine($"Server is running... on port: {iep.Port}");
            Socket client = _server.Accept();

            NetworkStream networkStream = new NetworkStream(client);
            StreamReader streamReader = new StreamReader(networkStream);
            StreamWriter streamWriter = new StreamWriter(networkStream);

            Console.WriteLine($"Client connected! Client is {client?.RemoteEndPoint?.ToString()}");

            string s = "Chao ban den voi Server";
            streamWriter.WriteLine(s);
            streamWriter.Flush();
            Thread send = new Thread(() =>
            {
                while (true)
                {
                    s = Console.ReadLine()!;
                    streamWriter.WriteLine(s);
                    streamWriter.Flush();
                    if (s.ToUpper().Equals("THOAT")) break;
                }
            });
            Thread receive = new Thread(() =>
            {
                try
                {
                    while (true)
                    {
                        s = streamReader.ReadLine()!;
                        Console.WriteLine("Client gui:{0}", s);
                        if (s.ToUpper().Equals("THOAT")) break;
                    }
                }
                catch (IOException)
                {
                    // Catch the IOException to handle the case when the client disconnects
                    Console.WriteLine("Client disconnected.");
                }
            });

            send.Start();
            receive.Start();
            send.Join(); // Wait for the send thread to finish
            client?.Shutdown(SocketShutdown.Both);
            client?.Close();
            _server.Close();
        }
    }
}
