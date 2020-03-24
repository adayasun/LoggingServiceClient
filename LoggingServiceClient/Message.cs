using System;
using System.Collections.Generic;
using System.Text;

namespace LoggingServiceClient
{
    public class Message
    {
        public string userName { get; set; }
        public string message { get; set; }
        public string level { get; set; }
        public string date { get; set; }
        public string timezone { get; set; }

        public static string CreateMessageString(Message createToString)
        {
            string message = null;

            message = "{\"message\": \"" + createToString.message +
                "\", \"level\": \"" + createToString.level +
                "\", \"date\" : \"" + createToString.date +
                "\",\"timezone\": \""+ createToString.timezone +"\"}";

           return message;
        }
    }

   
}
