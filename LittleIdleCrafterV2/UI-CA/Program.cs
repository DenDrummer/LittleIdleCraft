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
            Console.WriteLine("*1) See all items*");
            Console.WriteLine("*2) See all crafters*");
            Console.WriteLine("*3) Find required items for item*");
            Console.WriteLine("*4) Find items an item is required for*");
            Console.WriteLine("*5) Open Research menu*");
            Console.WriteLine(" 0) Quit");
            Console.Write("Choice -> ");
            int choice;
        }
    }
}
