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
        public string connected { get; set; }

        public static string CreateMessageString(Message createToString)
        {
            string message = null;

            message =
                "{\"header\" : \"" + createToString.userName +
                "\", \"message\": \"" + createToString.message +
                "\", \"level\" : \"" + createToString.level +
                "\", \"date\" : \"" + createToString.date +
                "\", \"timezone\" : \""+ createToString.timezone +"\", " +
                "\"connected\" : \"" + createToString.connected + "\"}";

           return message;
        }
    }

   
}
