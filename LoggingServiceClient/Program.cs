using System;
using System.Net.Sockets;

namespace LoggingServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = null;
            //Ask user if manual input 
            Console.WriteLine("Please enter 1 for Manual or 2 for Automatic:");
            message = UI.GetInput();
            if(message == "1") //Manual
            {
                Client client = new Client("127.0.0.1", 10000, int.Parse(message));
            }
            else if(message == "2") //Automatic
            {
                Client client = new Client("127.0.0.1", 10000, int.Parse(message));
            }   
        }
    }
}
