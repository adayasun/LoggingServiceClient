using System;
using System.Collections.Generic;
using System.Text;

namespace LoggingServiceClient
{
    public static class UI
    {
        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
        public static string GetInput()
        {
            return Console.ReadLine();
        }
    }
}
