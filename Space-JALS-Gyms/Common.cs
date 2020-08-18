using System;
using System.Collections.Generic;
using System.Text;

namespace Space_JALS_Gyms
{

    public static class Common
    {
        #region Console Methods

        public static string GetUserInput(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }
        #endregion
        
        public static string YesNoChecker()
        {
            string input1 = Console.ReadLine().ToLower();
            while (input1 != "y" && input1 != "n")
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("Invalid input. Please enter either \"y\" or \"n\": ");
                input1 = Console.ReadLine();
            }
            return input1;
        }

        public static int CheckNumber(string input, bool rangeCheck, int num)
        {
            int validNumber = 0;
            bool invalid = true;
            while (invalid)
            {
                try
                {
                    validNumber = int.Parse(input);
                    if (rangeCheck)
                    {
                        if (validNumber > 0 && validNumber <= num)
                        {
                            invalid = false;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("You have angered the Chickens of Space! I said enter a number from 1-" + num + ".");
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.Write("Please try again: ");
                            input = Console.ReadLine();
                        }
                    }
                    else
                    {
                        invalid = false;
                    }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("You have angered the Chickens of Space! I said enter a number.");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write("Please try again: ");
                    input = Console.ReadLine();
                }
            }
            return validNumber;
        }
        public static string CheckMemberStatus(int ID, out bool validID)
        {
            string status = "";
            validID = true;

            if (ID > 0 && ID < 600)
            {
                status = "Single";
            }
            else if (ID > 5000)
            {
                status = "Multi";
            }
            else
            {
                Console.WriteLine("It doesn't appear that you are a member.");
                Console.WriteLine("We are accepting new members, please join us!");
                Console.WriteLine("Or else...");
                validID = false;
            }

            return status;

        }
    }
}
