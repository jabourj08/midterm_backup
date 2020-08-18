using System;
using System.Collections.Generic;

namespace Space_JALS_Gyms
{
    class Program
    {
        public static int CurrentClub;
        public static int clubLocationIndex;
        static void Main(string[] args)
        {            
            ClubController cc = new ClubController();

            cc.ReadFromFile();
            cc.WriteClubInfoToList();
            CurrentClub = cc.InitializeClubLocation(out clubLocationIndex);
            while (cc.lContinue)
            {
                cc.WelcomeToGym();
            }
            cc.WriteToFile();

        }
    }
}
