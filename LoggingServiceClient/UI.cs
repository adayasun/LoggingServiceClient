/*
	FILE			: UI.cs
    PROJECT         : SENG2040 - Assign-03 (A-04)
	PROGRAMMER		: Amy Dayasundara, Paul Smith
    FIRST VERSION	: 2020-03-17
	DESCRIPTION		:
		ReadLine UI info
*/
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggingServiceClient
{
    public static class UI
    {
        //
        //METHOD        : DisplayMessafe
        //DESCRIPTION   : Print message to screen
        //PARAMETERS    : string message - message to be displayed
        //RETURN        : NONE
        //
        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        //
        //METHOD        : GetInput
        //DESCRIPTION   : From the user
        //PARAMETERS    : NONE
        //RETURN        : string - the user input
        //
        public static string GetInput()
        {
            return Console.ReadLine();
        }
    }
}
