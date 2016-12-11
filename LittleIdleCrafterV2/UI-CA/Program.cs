using LIC.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIC.UI.CA
{
    class Program
    {
        static ItemManager ctx = new ItemManager();
        static bool quit = false;
        static string prgmName = "Little Idle Crafter";

        static void Main(string[] args)
        {
            Console.WriteLine($"Welcome to {prgmName}!");
            Console.WriteLine(new string('-', prgmName.Length + 12));
            Console.WriteLine();
            while (!quit)
            {
                ShowMenu();
            }
            Console.Write("<press any key to exit>");
            Console.ReadKey();
        }

        private static void ShowMenu()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("*1) See all items or crafters*");
            Console.WriteLine("*2) Open Research menu*");
            Console.WriteLine("*3) Find required items for item*");
            Console.WriteLine("*4) Find items an item is required for*");
            Console.WriteLine(" 0) Quit");
            Console.Write("Choice -> ");
            int choice;
            try
            {
                choice = int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (choice)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                        ComingSoon();
                        break;
                    case 0:
                        quit = true;
                        return;
                    default:
                        InvalidInput();
                        break;
                }
                Console.WriteLine();
            }
            catch (FormatException fe)
            {
                InvalidInput();
                Console.WriteLine();
            }
        }

        private static void InvalidInput(string extraInfo = "")
            => Console.WriteLine($"Invalid input! {(extraInfo.Equals("") ? "" : $"({extraInfo})")}");

        private static void ComingSoon()
            => Console.WriteLine("Coming Soon!");
    }
}
