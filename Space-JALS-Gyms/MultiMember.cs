using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Space_JALS_Gyms
{
//    Override Checkin(Club club)
//Check if member is allowed to check in to specific club.Spoiler they will.
//Void PointCheck()
//Check how many points the member has.Add points on check in.
//Override PrintInfo()
//Print member info
//fName
//lName

    class MultiMember : Member
    {
        #region Properties
        public int ClubID { get; set; }
        public int MemberPoints { get; set; }
        #endregion

        #region Constructors
        public MultiMember() { }
        public MultiMember(int memberID, string fName, string lName, int memberFees, bool paidBill, int clubID, int memberPoints) //: base (memberID, fName, lName, memberFees, paidBill)
        {
            ClubID = clubID;
            MemberPoints = memberPoints;
        }
        #endregion

        #region Methods
        public void CheckIn(Club club)
        {
            if (club.ClubID == ClubID)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Access Granted!");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine($"Welcome to Space JALS: Sector - {club.Name}!");
            }

        }
        public override void PrintInfo()
        {
            Console.WriteLine($"Member ID: {MemberID}");
            Console.WriteLine($"Name: {fName} {lName}");
            if (paidBill == false)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Balance: {MemberFees}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("No current balance.");
                Console.ResetColor();
            }
            Console.WriteLine();
            CheckPoints();
        }


        public void CheckPoints()
        {
            MemberPoints++;
            Console.WriteLine($"Current Points: {MemberPoints}");
        }
        #endregion
    }
}
