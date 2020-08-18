using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Enumeration;
using System.Text;


namespace Space_JALS_Gyms
{    
    class ClubController
    {
        //all methods are set inititally set to void to avoid errors while writing code. That will change as logic is added.
        public static List<Club> ClubLocations;
        public static List<Member> MemberInfo = new List<Member>();
        public bool lContinue = true;

        public void WelcomeToGym()
        {
            while(lContinue)
            { 
                SingleMember sMember = new SingleMember();
                MultiMember mMember = new MultiMember();
                Club club = new Club();
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine($"Welcome to {ClubLocations[Program.clubLocationIndex].Name} {ClubLocations[Program.clubLocationIndex].ClubID}!");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("1. Check-in");
                Console.WriteLine("2. Add Member");
                Console.WriteLine("3. Remove Member");
                Console.WriteLine("4. Check Points");
                Console.WriteLine("5. Create Bill");
                Console.WriteLine("6. Show Member Info");
                Console.WriteLine("7. Quit");
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                string selection = Common.GetUserInput("Please enter a number 1 - 7: ");
                int option = Common.CheckNumber(selection, true, 7);

                bool validID = true;


                if (option == 1)
                {
                    Console.Clear();
                    string tempMemberID = Common.GetUserInput("Please enter your Member ID to check-in: ");
                    int memberID = Common.CheckNumber(tempMemberID, false, 0);

                    Common.CheckMemberStatus(memberID, out validID);

                    if (validID)
                    {
                        bool bFound = CheckIfMemberExists(memberID);
                        if (bFound)
                        {
                            CheckMembership(sMember, mMember, memberID);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Invalid Member ID! Try again!");
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("This doesn't appear to be your club. Back to your spaceship!");
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    }

                }
                else if (option == 2)
                {
                    AddMember();
                }
                else if (option == 3)
                {
                    RemoveMember();
                }
                else if (option == 4)
                {

                    string tempMemberID = Common.GetUserInput("Please enter your Member ID: ");
                    int memberID = Common.CheckNumber(tempMemberID, false, 0);
                    Common.CheckMemberStatus(memberID, out validID);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine();
                    if (memberID >= 5000)
                    {
                        Console.WriteLine($"Current Point Balance: {mMember.CheckPoints(memberID)} Gorgals");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, you are not a multi-club member.");
                    }
                    
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                }
                else if (option == 5)
                {
                    Console.Clear();
                    string tempMemberID = Common.GetUserInput("Please enter your Member ID: ");
                    int memberID = Common.CheckNumber(tempMemberID, false, 0);
                    Common.CheckMemberStatus(memberID, out validID);

                    CreateBill(memberID);
                }
                else if (option == 6)
                {
                    string tempMemberID = Common.GetUserInput("Please enter your Member ID: ");
                    int memberID = Common.CheckNumber(tempMemberID, false, 0);

                    Common.CheckMemberStatus(memberID, out validID);

                    int index = 0;

                    if (validID)
                    {
                        bool bFound = CheckIfMemberExists(memberID);
                        
                        if (bFound)
                        {
                            for (int i = 0; i < MemberInfo.Count; i++)
                            {
                                if (memberID == MemberInfo[i].MemberID)
                                {
                                    index = i;
                                    break;
                                }
                            }

                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;                            

                            if (memberID < 5000)
                            {
                                SingleMember singleMember = new SingleMember(MemberInfo[index].MemberID, MemberInfo[index].FirstName, MemberInfo[index].LastName, MemberInfo[index].MemberFees, MemberInfo[index].PaidBill);

                                singleMember.PrintInfo();
                            }
                            
                            if (memberID >= 5000)
                            {
                                MultiMember multiMember = new MultiMember(MemberInfo[index].MemberID, MemberInfo[index].FirstName, MemberInfo[index].LastName, MemberInfo[index].MemberFees, MemberInfo[index].PaidBill, MemberInfo[index].MemberPoints);                                
                                multiMember.PrintInfo();
                            }
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Invalid Member ID! Try again!");
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        }
                    }


                }
                else if (option == 7)
                {
                    Console.Clear();
                    Console.WriteLine("Thanks for visiting Space JALS!");
                    Console.WriteLine("Enjoy your day!");
                    Console.WriteLine();
                    lContinue = false;
                }
                Console.WriteLine("Press any \'space\' key to continue!");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public bool CheckIfMemberExists(int memIDToCheck)
        {
            foreach (Member m in MemberInfo)
            {
                if (m.MemberID == memIDToCheck)
                {
                    return true;
                }
            }
            return false;
        }
        public void AddMember()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("To Add a new Member, please fill in the following: ");
            Console.WriteLine();
            string strFName = Common.GetUserInput("First Name: ");
            string strLName = Common.GetUserInput("Last Name: ");
            Console.WriteLine();

            int count = 1;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            foreach (Club clubSector in ClubLocations)
            {
                Console.WriteLine($"{count}. {clubSector.Name}");
                count++;
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            string sectorSelection = Common.GetUserInput("Please select the sector you would like to join,\nor press 7 to blast off as a multi-club member! (Enter 1 - 7): ");
            int ID = Common.CheckNumber(sectorSelection, true, 7);

            if (int.Parse(sectorSelection) == 1)
            {
                int minID = 0;
                int maxID = 99;
                int newID = NewMemberID(minID, maxID, minID);

                SingleMember newMember = new SingleMember(newID, strFName, strLName, 10, true);
                Console.WriteLine();
                Console.Write($"Are you sure you want to add {strFName} {strLName}? Enter y/n: ");
                string confirmation = Common.YesNoChecker();
                if (confirmation == "y")
                {
                    MemberInfo.Add(newMember);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{strFName} {strLName} has been added to the list!");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"{strFName} {strLName} has not been added.");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                }

            }
            else if (int.Parse(sectorSelection) == 2)
            {
                int minID = 100;
                int maxID = 199;
                int newID = NewMemberID(minID, maxID, minID);

                SingleMember newMember = new SingleMember(newID, strFName, strLName, 10, true);
                Console.WriteLine();
                Console.Write($"Are you sure you want to add {strFName} {strLName}? Enter y/n: ");
                string confirmation = Common.YesNoChecker();
                if (confirmation == "y")
                {
                    MemberInfo.Add(newMember);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{strFName} {strLName} has been added to the list!");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"{strFName} {strLName} has not been added.");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                }
            }
            else if (int.Parse(sectorSelection) == 3)
            {
                int minID = 200;
                int maxID = 299;
                int newID = NewMemberID(minID, maxID, minID);

                SingleMember newMember = new SingleMember(newID, strFName, strLName, 10, true);
                Console.WriteLine();
                Console.Write($"Are you sure you want to add {strFName} {strLName}? Enter y/n: ");
                string confirmation = Common.YesNoChecker();
                if (confirmation == "y")
                {
                    MemberInfo.Add(newMember);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{strFName} {strLName} has been added to the list!");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"{strFName} {strLName} has not been added.");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                }
            }
            else if (int.Parse(sectorSelection) == 4)
            {
                int minID = 300;
                int maxID = 399;
                int newID = NewMemberID(minID, maxID, minID);

                SingleMember newMember = new SingleMember(newID, strFName, strLName, 10, true);
                Console.WriteLine();
                Console.Write($"Are you sure you want to add {strFName} {strLName}? Enter y/n: ");
                string confirmation = Common.YesNoChecker();
                if (confirmation == "y")
                {
                    MemberInfo.Add(newMember);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{strFName} {strLName} has been added to the list!");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"{strFName} {strLName} has not been added.");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                }
            }
            else if (int.Parse(sectorSelection) == 5)
            {
                int minID = 400;
                int maxID = 499;
                int newID = NewMemberID(minID, maxID, minID);

                SingleMember newMember = new SingleMember(newID, strFName, strLName, 10, true);
                Console.WriteLine();
                Console.Write($"Are you sure you want to add {strFName} {strLName}? Enter y/n: ");
                string confirmation = Common.YesNoChecker();
                if (confirmation == "y")
                {
                    MemberInfo.Add(newMember);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{strFName} {strLName} has been added to the list!");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"{strFName} {strLName} has not been added.");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                }
            }
            else if (int.Parse(sectorSelection) == 6)
            {
                int minID = 500;
                int maxID = 599;
                int newID = NewMemberID(minID, maxID, minID);

                SingleMember newMember = new SingleMember(newID, strFName, strLName, 10, true);
                Console.WriteLine();
                Console.Write($"Are you sure you want to add {strFName} {strLName}? Enter y/n: ");
                string confirmation = Common.YesNoChecker();
                if (confirmation == "y")
                {
                    MemberInfo.Add(newMember);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{strFName} {strLName} has been added to the list!");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"{strFName} {strLName} has not been added.");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                }
            }
            else if (int.Parse(sectorSelection) == 7)
            {
                int minID = 5000;
                int maxID = 50000;
                int newID = NewMemberID(minID, maxID, minID);

                MultiMember newMember = new MultiMember(newID, strFName, strLName, 25, true, 0);
                Console.WriteLine();
                Console.Write($"Are you sure you want to add {strFName} {strLName}? Enter y/n: ");
                string confirmation = Common.YesNoChecker();
                if (confirmation == "y")
                {
                    MemberInfo.Add(newMember);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{strFName} {strLName} has been added to the list!");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"{strFName} {strLName} has not been added.");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                }
            }


        }
        public int NewMemberID(int min, int max, int highestMemberID)
        {
            try
            {
                foreach (Member memID in MemberInfo)
                {
                    if (memID.MemberID > min && memID.MemberID < max)
                    {
                        if (memID.MemberID > highestMemberID)
                        {
                            highestMemberID = memID.MemberID;
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("hire new programmers");
            }

            return (highestMemberID + 1);
        }
        public void RemoveMember()
        {
            Console.Clear();
            bool foundMember = false;
            string input = Common.GetUserInput("Which unlucky Chicken is getting fried today? Enter a member ID: ");
            int tempInput = Common.CheckNumber(input, false, 0);
            
            foreach (Member removedMember in MemberInfo)
            {
                if (removedMember.MemberID == tempInput)
                {
                    foundMember = true;
                    Console.Write($"Are you sure you want to remove {removedMember.FirstName}? Enter y/n: ");
                    string confirmation = Common.YesNoChecker();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    if (confirmation == "y")
                    {
                        MemberInfo.Remove(removedMember);
                        Console.WriteLine(removedMember.FirstName + " has been fried and removed from the member List.");
                    }
                    else
                    {
                        Console.WriteLine($"{removedMember.FirstName} has not been fried or removed from the member list.");
                    }
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    break;
                }
            }
            if (foundMember == false)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("This isn't the ID you're looking for.");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            }
        }
        public void CheckMembership(SingleMember sMember, MultiMember mMember, int memberID)
        {
            bool validID = true;
            string memberStatus = Common.CheckMemberStatus(memberID, out validID);

            if (memberStatus == "Single")
            {
                if (ClubLocations[Program.clubLocationIndex].ClubID == Program.CurrentClub)
                {
                    sMember.CheckIn(ClubLocations[Program.clubLocationIndex], memberID);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine();
                    Console.WriteLine("You are not permitted to use this Space.");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                }
            }
            else if (memberStatus == "Multi")
            {
                mMember.CheckIn(ClubLocations[Program.clubLocationIndex], memberID);
            }
        }
        public void CreateBill(int memberID)
        {
            foreach (Member memBill in MemberInfo)
            {
                if (memberID == memBill.MemberID)
                {
                    if (memBill.PaidBill == true)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Your bill has been paid! Thank you!");
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    }
                    else
                    {
                        if (memBill.MemberID < 5000)
                        {
                            GenerateBill(memBill, 10);
                            Console.WriteLine($"Would you like to pay your bill?");
                            string payBill = Common.YesNoChecker();
                            if (payBill == "y")
                            {
                                PayBill(memBill);
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("I'm sorry, members with an outstanding balance are not permitted into the club.");
                            }
                        }
                        else
                        {
                            GenerateBill(memBill, 25);
                            Console.Write($"Would you like to pay your bill? Enter y/n: ");
                            string payBill = Common.YesNoChecker();
                            if (payBill == "y")
                            {
                                PayBill(memBill);
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("I'm sorry, members with an outstanding balance are not permitted into the club.");
                            }
                        }
                    }
                }
            }
        }
        public void PayBill(Member paidMember)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Thank you for paying your bill on time!");
            Console.WriteLine("Have a great day!");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;


            paidMember.PaidBill = true;

        }
        public void GenerateBill(Member memBill, int fee)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("SPACE JALS GYMS BILL");
            Console.WriteLine("-*--*--*--*--*--*--*--*--*-");
            Console.WriteLine($"Hello, {memBill.FirstName} {memBill.LastName}!");
            Console.WriteLine($"You owe {fee} star specks.");

            if (memBill.MemberID > 5000)
            {
                Console.WriteLine($"You have {memBill.MemberPoints} Gorgals!");
            }
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine();
        }
        public void WriteToFile()
        {
            string fileName = "../../../Memberinfo.txt";
            StreamWriter writer = new StreamWriter(fileName, false); //need to pass (x,true) in order to write to the end of file and not overwrite text file data

            foreach (Member memData in MemberInfo)
            {
                writer.WriteLine($"{memData.MemberID}|{memData.FirstName}|{memData.LastName}|{memData.MemberFees}|{memData.PaidBill}|{memData.MemberPoints}");
            }

            writer.Close();


        }
        public void ReadFromFile() //string fileName
        {
            //may need logic in the future that dictates which file to read from (memberinfo or Clubinfo)
            //string fileName = "../../../ClubInfo.txt"; can uncomment for future use if needed
            string fileName = "../../../Memberinfo.txt";

            StreamReader reader = new StreamReader(fileName);
            List<string> readInfo = new List<string>();

            //currently set to read the entire file, once logic for info has been put in place, we will set up the reader to read specific lines.
            string line = reader.ReadLine();

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("In which sector is your gym located?");
            Console.WriteLine();
            
            while (line != null)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                string[] memberInfo = line.Split('|');
                if (int.Parse(memberInfo[5]) == 0)
                {
                    SingleMember newMember = new SingleMember(int.Parse(memberInfo[0]), memberInfo[1], memberInfo[2], int.Parse(memberInfo[3]), bool.Parse(memberInfo[4]));
                    MemberInfo.Add(newMember);
                }
                else
                {
                    MultiMember newMember = new MultiMember(int.Parse(memberInfo[0]), memberInfo[1], memberInfo[2], int.Parse(memberInfo[3]), bool.Parse(memberInfo[4]), int.Parse(memberInfo[5]));
                    MemberInfo.Add(newMember);
                }
                line = reader.ReadLine();
            }

            reader.Close();
        
        }
        public void WriteClubInfoToList()
        {
            List<Club> cl = new List<Club>() { };

            string fileName = "../../../ClubInfo.txt";

            StreamReader reader = new StreamReader(fileName, true);

            string line = reader.ReadLine();
            int i = 0;

            while (line != null && i <= 5 )
            {

                string[] clubInfo = line.Split('|');
                Club newClub = new Club(int.Parse(clubInfo[0]), clubInfo[1], clubInfo[2]);
                cl.Add(newClub);
                line = reader.ReadLine();
                i++;

            }

            reader.Close();

            ClubLocations = cl;

        }
        public int InitializeClubLocation(out int clubIndex)
        {
            List<int> clubID = new List<int>() { };
            int count = 1;
            foreach (Club clubSector in ClubLocations)
            {
                Console.WriteLine($"{count}. {clubSector.Name}");
                clubID.Add(clubSector.ClubID);
                count++;
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            string sectorSelection = Common.GetUserInput("Enter 1 - 6 to choose your sector: ");

            int ID = Common.CheckNumber(sectorSelection, true, 6);

            int currentClubID = 0;
            clubIndex = 0;

            for (int i = 0; i < clubID.Count; i++)
            {

                if (ID-1 == i)
                {
                    currentClubID = clubID[i];
                    clubIndex = i;
                    break;
                }
            }
            Console.Clear();
            return currentClubID;
        }

    }

}
