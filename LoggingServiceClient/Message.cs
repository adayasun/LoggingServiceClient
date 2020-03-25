/*
	FILE			: Message.cs
    PROJECT         : SENG2040 - Assign-03 (A-04)
	PROGRAMMER		: Amy Dayasundara, Paul Smith
    FIRST VERSION	: 2020-03-17
	DESCRIPTION		:
		Setting up the message info to be sent
*/
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

        //
        //METHOD        : CreateMessageStrin
        //DESCRIPTION   : Create it to string
        //PARAMETERS    : Message createToString - Take the Message object to be converted
        //RETURN        : string - final created string message
        //

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
