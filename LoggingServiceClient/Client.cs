using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

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
        public Client(string IP, int port, int choice)
        {
            connected = true;
            // Creates new instance of TcpClient as read only and destroy it after not in use
            using (clientSocket = new TcpClient())
            {
                Message user = new Message();
                Console.WriteLine("Connecting.....");
                clientSocket.Connect(IPAddress.Parse(IP), port);
                Console.WriteLine("Connected");
                user = AskForUserName(); //Received username
                stream = clientSocket.GetStream();
                if (choice == 1)
                {
                    try
                    {
                        user = ComposeMessage(user);
                        serializeAndEncode(user);
                    }
                    catch
                    {
                        Console.WriteLine("Something went wrong.");
                    }
                }
                else if(choice == 2)
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

                clientSocket.Close();
                Console.WriteLine("Disconnected.");

                connected = false;
            }
        }

        public void Send(Message user)
        {
            while (connected == true)
            {
                try
                {
                    Message obj = new Message
                    {
                        userName = user.userName,
                        message = "I'm an issue",
                        level = "CRITICAL",
                        date = DateTime.UtcNow.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                        timezone = "America/Sao_Paulo"
                    };

                    connected = serializeAndEncode(obj);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

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

        private bool serializeAndEncode(Message messageToBeConverted)
        {
            string str = Message.CreateMessageString(messageToBeConverted);
            byte[] message = Encoding.UTF8.GetBytes(str);
            stream.Write(message, 0, message.Count());

            return connected = false;
        }

        private Message AskForUserName()
        {
            Message username = new Message();
            Console.WriteLine("Please enter your chat room username.");
            username.userName= UI.GetInput();
            return username;
        }
    }
}

