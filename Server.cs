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
            while (true)
            {
                s = streamReader.ReadLine()!;
                Console.WriteLine("Client gui len:{0}", s);
                //Neu chuoi nhan duoc la Thoat thi thoat
                if (s.ToUpper().Equals("THOAT")) break;
                //Gui tra lai cho client chuoi s
                s = s.ToUpper();
                streamWriter.WriteLine(s);
                streamWriter.Flush();

            }
            client?.Shutdown(SocketShutdown.Both);
            client?.Close();
            _server.Close();
        }
    }
}
