/*
	FILE			: Client.cs
    PROJECT         : SENG2040 - Assign-03 (A-04)
	PROGRAMMER		: Amy Dayasundara, Paul Smith
    FIRST VERSION	: 2020-03-17
	DESCRIPTION		:
		Working within the client to setup and send info
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;

namespace LoggingServiceClient
{
    class Client
    {
        // The TcpClient class provides simple methods for connecting, sending, and receiving stream data over a network
        TcpClient clientSocket;
        // The NetworkStream class provides methods for sending and receiving data over Stream sockets
        NetworkStream stream;
        bool connected;
        // Constructor takes ip adress and port
        public Client(string IP, int port)
        {
            connected = true;
            int choice = 0;
            // Creates new instance of TcpClient as read only and destroy it after not in use

            while (connected)
            {
                using (clientSocket = new TcpClient())
                {
                

                    Console.WriteLine("Please enter 1 for Manual, 2 for Automatic or 3 to quit");
                    choice = int.Parse(UI.GetInput());

                    Message user = new Message();
                    Console.WriteLine("Connecting.....");
                    Thread.Sleep(10);
                    try
                    {
                        clientSocket.Connect(IPAddress.Parse(IP), port);
                        Console.WriteLine("Connected");
                        user.connected = "0";

                        stream = clientSocket.GetStream();

                    }
                    catch
                    {
                        Console.WriteLine("Issue Connecting");
                        break;
                    }

                    if (choice == 1) //Manual
                    {
                        try
                        {
                            user = AskForUserName(); //Received username
                            user = ComposeMessage(user);
                            serializeAndEncode(user);
                        }
                        catch
                        {
                            Console.WriteLine("Something went wrong.");
                        }
                    }
                    else if (choice == 2) //Automatic
                    {
                        try
                        {
                            Send(user);
                        }
                        catch
                        {
                            Console.WriteLine("Something went wrong.");
                        }
                    }
                    else if (choice == 3) // Quit
                    {
                        try
                        {
                            user.connected = "1";
                            serializeAndEncode(user);
                            clientSocket.Close();
                            Console.WriteLine("Disconnected.");
                            connected = false;
                        }
                        catch
                        {
                            Console.WriteLine("Something went wrong.");
                        }
                    }
                }
            }
        }

        //
        //METHOD        : Send
        //DESCRIPTION   : Automatically send info to the server
        //PARAMETERS    : Message user - user set up in client constructor
        //RETURN        : NONE
        //
        public void Send(Message user)
        {
                try
                {
                    user.userName = "Momo";
                    user.message = "I'm an issue";
                    user.level = "CRITICAL";
                    user.date = DateTime.UtcNow.ToString("dddd, dd MMMM yyyy HH:mm:ss");
                    user.timezone = "America/Sao_Paulo";                   

                    connected = serializeAndEncode(user);

                    user.userName = "Santa Maria";
                    user.message = "Let's get busy";
                    user.level = "INFO";
                    user.date = DateTime.UtcNow.ToString("dddd, dd MMMM yyyy HH:mm:ss");
                    user.timezone = "Toronto";

                     connected = serializeAndEncode(user);
            }
            catch (Exception e)
                {
                    Console.WriteLine(e);
                }
        }

        //
        //METHOD        : CommposeMessage
        //DESCRIPTION   : Manual message to be sent to the server
        //PARAMETERS    : Message user - user set up in client constructor
        //RETURN        : Message - to be serialized
        //

        public Message ComposeMessage(Message user)
        {
            Message newMessage = new Message();
            int levelBuff = 0;
            int loopCon = 0;
            Console.WriteLine("Please enter your message:");
            newMessage.message = UI.GetInput();
            Console.WriteLine("Please select your message level:\n\t1: DEBUG\n\t2: INFO\n\t3: WARNING\n\t4: ERROR\n\t5: CRITIAL");
            while (loopCon == 0)
            {
                //Which type of message to be sent
                levelBuff = int.Parse(UI.GetInput());
                switch(levelBuff)
                {
                    case 1:
                        newMessage.level = "DEBUG";
                        loopCon = 1;
                        break;
                    case 2:
                        newMessage.level = "INFO";
                        loopCon = 1;
                        break;
                    case 3:
                        newMessage.level = "WARNING";
                        loopCon = 1;
                        break;
                    case 4:
                        newMessage.level = "ERROR";
                        loopCon = 1;
                        break;
                    case 5:
                        newMessage.level = "CRITICAL";
                        loopCon = 1;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid selection:");
                        break;
                }
            }
            newMessage.date = DateTime.UtcNow.ToString("dddd, dd MMMM yyyy HH:mm:ss");

            return newMessage;
        }

        //
        //METHOD        : SerualizeAndEncode
        //DESCRIPTION   : Convert the object into bytes to be sent
        //PARAMETERS    : Message messageToBeConverted - Converts message into bytes to be sent
        //RETURN        : NONE
        //
        private bool serializeAndEncode(Message messageToBeConverted)
        {
            try
            {
                string str = Message.CreateMessageString(messageToBeConverted);
                byte[] message = Encoding.UTF8.GetBytes(str);
                stream.Write(message, 0, message.Count());
            }
            catch
            {
                Console.WriteLine("");
            }
            return connected = true;
        }

        //
        //METHOD        : AskForUserName
        //DESCRIPTION   : Get user name
        //PARAMETERS    : NONE
        //RETURN        : NONE
        //
        private Message AskForUserName()
        {
            Message username = new Message();
            Console.WriteLine("Please enter your chat room username.");
            username.userName= UI.GetInput();
            return username;
        }
    }
}

