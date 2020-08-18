using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace Space_JALS_Gyms
{

    class MultiMember : Member
    {

        #region Constructors
        public MultiMember() { }
        public MultiMember(int memberID, string fName, string lName, int memberFees, bool paidBill, int memberPoints) : base (memberID, fName, lName, memberFees, paidBill, memberPoints)
        {
        }
        #endregion

        #region Methods
        public override void CheckIn(Club club, int memberID)
        {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("Access Granted!");
            Console.WriteLine($"Welcome to {club.Name} sector!");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            IncreaseMemberPoints(memberID);
            Console.WriteLine();
            Console.WriteLine($"Your current points are: {MemberPoints}");

        }
        public override void PrintInfo()
        {
            Console.WriteLine($"Member ID: {MemberID}");
            Console.WriteLine($"Name: {FirstName} {LastName}");
            if (PaidBill == false)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Balance: {MemberFees} Star Specks");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("No current balance.");
                Console.ResetColor();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Your Gorgal balance is: {MemberPoints}");
            Console.WriteLine();
        }


        public void IncreaseMemberPoints(int memberID)
        {
            int points = 0;

            points = CheckPoints(memberID);
            points++;

            MemberPoints = points;

            foreach (Member member in ClubController.MemberInfo)
            {
                if (member.MemberID == memberID)
                {
                    member.MemberPoints = points ;
                    break;
                }
            }

        }
        public int CheckPoints(int memberID)
        {
            int points = 0;

            foreach (Member member in ClubController.MemberInfo)
            {
                if (member.MemberID == memberID)
                {
                    points = member.MemberPoints;
                    break;
                }
            }
           

            return points;
        }
        #endregion
    }
}
