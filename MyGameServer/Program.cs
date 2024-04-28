using ConnectFourServer;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace ConnectFourServer
{
    class Program
    {
        const int portNo = 5000;
        private const string ipAddress = "127.0.0.1";

        static void Main(string[] args)
        {
            System.Net.IPAddress localAdd = System.Net.IPAddress.Parse(ipAddress);

            TcpListener listener = new TcpListener(localAdd, portNo);

            Console.WriteLine("Simple TCP Server");
            Console.WriteLine("Listening to ip {0} port: {1}", ipAddress, portNo);
            Console.WriteLine("Server is ready.");

            // Start listen to incoming connection requests
            listener.Start();

            // infinit loop.
            while (true)
            {
                // AcceptTcpClient - Blocking call
                // Execute will not continue until a connection is established

                // create an instance of ChatClient so the server will be able to 
                // serve multiple client at the same time.
                //AcceptTcpClient open new socket for the new client
                TcpClient tcpClient = listener.AcceptTcpClient();
                Console.WriteLine("new socket: " + tcpClient.Client.RemoteEndPoint.ToString());
                //ChatClient user = new ChatClient(listener.AcceptTcpClient());
                Server user = new Server(tcpClient);
            }
        }
    }
}
