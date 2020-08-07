using System;

namespace Space_JALS_Gyms
{
    class Program
    {
        static void Main(string[] args)
        {
            Club myClub = new Club(500, "club Name","12345 planet drive");
            myClub.ClubInfo();
        }
    }
}
