/*
	FILE			: Program.cs
    PROJECT         : SENG2040 - Assign-03 (A-04)
	PROGRAMMER		: Amy Dayasundara, Paul Smith
    FIRST VERSION	: 2020-03-17
	DESCRIPTION		:
		Working within the client to setup and send info
*/
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
