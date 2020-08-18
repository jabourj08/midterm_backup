using System;
using System.Collections.Generic;
using System.Text;

namespace Space_JALS_Gyms
{
    abstract class Member
    {
        #region Properties
        public int MemberID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int MemberFees { get; set; }
        public bool PaidBill { get; set; }
        public int MemberPoints { get; set; }
        #endregion

        #region Constructors
        public Member() { }

        public Member(int ID, string firstName, string lastName)
        {
            MemberID = ID;
            FirstName = firstName;
            LastName = lastName;
        }
        public Member(int ID, string firstName, string lastName, int memberFees, bool paidBill)
        {
            MemberID = ID;
            FirstName = firstName;
            LastName = lastName;
            MemberFees = memberFees;
            PaidBill = paidBill;
        }
        public Member(int ID, string firstName, string lastName, int memberFees, bool paidBill,  int memberPoints)
        {
            MemberID = ID;
            FirstName = firstName;
            LastName = lastName;
            MemberPoints = memberPoints;
            MemberFees = memberFees;
            PaidBill = paidBill;
        }
        #endregion

        #region Methods
        public abstract void CheckIn(Club club, int MemberID);
        public virtual void PrintInfo()
        {
            Console.WriteLine($"Member ID: {MemberID} \nFirst Name: {FirstName} \nLast Name: {LastName}");
        }

        #endregion
    }
}