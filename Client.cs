using System.Net;
using System.Net.Sockets;

namespace OperatingSystem
{
    internal class Client
    {
        static public void Main()
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2023);
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
            ProtocolType.Tcp);
            client.Connect(iep);

            NetworkStream networkStream = new NetworkStream(client);
            StreamReader streamReader = new StreamReader(networkStream);
            StreamWriter streamWriter = new StreamWriter(networkStream);
            string s = streamReader.ReadLine()!;
            Console.WriteLine("Server gui:{0}", s);
            string input;
            Thread send = new Thread(() =>
            {
                while (true)
                {
                    input = Console.ReadLine()!;
                    streamWriter.WriteLine(input);
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
                        Console.WriteLine("Server gui:{0}", s);
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
            send.Join();
            client.Disconnect(true);
            client.Close();
        }
    }
}
