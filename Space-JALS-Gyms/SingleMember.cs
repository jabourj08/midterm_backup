using System;
using System.Collections.Generic;
using System.Text;

namespace Space_JALS_Gyms
{
    class SingleMember : Member
    {
        //Constructor
        public SingleMember()
        {

        }
        public SingleMember(int ID, string firstName, string lastName) : base(ID, firstName, lastName)
        {
        }
        public SingleMember(int ID, string firstName, string lastName, int fees, bool paidBill) : base(ID, firstName, lastName, fees, paidBill)
        {
        }
        public override void PrintInfo()
        {
            Console.WriteLine($"ID: {MemberID}");
            Console.WriteLine($"First Name: {FirstName}");
            Console.WriteLine($"Last Name: {LastName}");

            if (PaidBill == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"You do not have an outstanding balance.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"You have a balance of {MemberFees} Star Specks");
            }
        }
        public override void CheckIn(Club club, int MemberID)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            if (club.ClubID == 100 && MemberID >= 1 && MemberID < 100)
            {
                Console.WriteLine($"Welcome to your club. {club.Name} sector.");
            }
            else if (club.ClubID == 200 && MemberID >= 100 && MemberID < 200)
            {
                Console.WriteLine($"Welcome to your club. {club.Name} sector.");
            }
            else if (club.ClubID == 300 && MemberID >= 200 && MemberID < 300)
            {
                Console.WriteLine($"Welcome to your club. {club.Name} sector.");
            }
            else if (club.ClubID == 400 && MemberID >= 300 && MemberID < 400)
            {
                Console.WriteLine($"Welcome to your club. {club.Name} sector.");
            }
            else if (club.ClubID == 500 && MemberID >= 400 && MemberID < 500)
            {
                Console.WriteLine($"Welcome to your club. {club.Name} sector.");
            }
            else if (club.ClubID == 600 && MemberID >= 500 && MemberID < 600)
            {
                Console.WriteLine($"Welcome to your club. {club.Name} sector.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("This doesn't appear to be your club. Please try again.");
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
        }
    }
}
