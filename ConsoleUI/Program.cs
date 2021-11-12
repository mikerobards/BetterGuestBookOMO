using System;
using GuesBookLibrary.Models;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        private static List<GuestModel> guests = new List<GuestModel>();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Better Guest Book OMO!");

            RequestGuestInfo();

            DisplayGuests();

        }

        private static string GetGuestInfo(string message)
        {
            Console.Write(message);

            string output = Console.ReadLine();

            return output;
        }

        private static void DisplayGuests()
        {
            foreach (GuestModel guest in guests)
            {
                Console.WriteLine(guest.GuestInfo);
            }

        }

        private static void RequestGuestInfo()
        {
            string moreGuests = "";

            do
            {
                GuestModel guest = new();

                guest.FirstName = GetGuestInfo("What is your first name: ");
                guest.LastName = GetGuestInfo("What is your last name: ");
                guest.MessageToHost = GetGuestInfo("What is your message to the host: ");

                bool isNumberParty = false;
                do
                {
                    string numberText = GetGuestInfo("How many are in your party: ");
                    isNumberParty = int.TryParse(numberText, out int numberInParty);

                    if (!isNumberParty)
                    {
                        Console.WriteLine("That is not a valid number. Please try again.");
                    }

                    guest.NumberInParty = numberInParty;

                } while (!isNumberParty);

                moreGuests = GetGuestInfo("Do you want to add another guest? ");

                guests.Add(guest);
                Console.Clear();

            } while (moreGuests == "y");

            

        }

    }
}
