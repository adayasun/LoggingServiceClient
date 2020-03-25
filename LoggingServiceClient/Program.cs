using System;
using System.Net.Sockets;

namespace LoggingServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // Run client on localhost at 9999 port
            Client client = new Client("127.0.0.1", 10000);
        }
    }
}
