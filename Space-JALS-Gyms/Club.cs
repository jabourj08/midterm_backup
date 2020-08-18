using System;
using System.Collections.Generic;
using System.Text;

namespace Space_JALS_Gyms
{

    class Club
    {
        #region Properties
        public int ClubID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        #endregion

        #region Constructors
        public Club()
        {

        }
        public Club(int clubID, string name, string address)
        {
            this.ClubID = clubID;
            Name = name;
            Address = address;
        }
        #endregion

        #region Methods
        public void ClubInfo()
        {
            Console.WriteLine("Club Information:");
            Console.WriteLine();
            Console.WriteLine($"\tClub ID: {ClubID}");
            Console.WriteLine($"\tClub Name: {Name}");
            Console.WriteLine($"\tClub Address: {Address}");
        }
        #endregion
    }
}
