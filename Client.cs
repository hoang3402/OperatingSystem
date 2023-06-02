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
            while (true)
            {
                input = Console.ReadLine()!;
                streamWriter.WriteLine(input);
                streamWriter.Flush();
                if (input.ToUpper().Equals("THOAT")) break;
                s = streamReader.ReadLine()!;
                Console.WriteLine("Server gui:{0}", s);
            }
            client.Disconnect(true);
            client.Close();
        }
    }
}
