using System;
using System.Linq;

namespace LIC
{
    class Program
    {
        static MyDbContext ctx = new MyDbContext();
        static bool quit = false;
        static string prgmName = "Little Idle Crafter";
        static void Main(string[] args)
        {
            //ctx.Database.Log = query => Console.WriteLine(query);
            //ctx.Database.Initialize(false);
            Console.WriteLine($"Welcome to {prgmName}!");
            Console.WriteLine(new string('-', prgmName.Length + 12));
            Console.WriteLine();
            while (!quit)
            {
                ShowMenu();
            }
            Console.ReadKey();
        }

        private static void ShowMenu()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine(" 1) See all items");
            Console.WriteLine(" 2) See all crafters");
            Console.WriteLine(" 3) Find required items for item");
            Console.WriteLine("*4) Find items an item is required for*");
            Console.WriteLine("*5) Open Research menu*");
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
                        WriteItems();
                        break;
                    case 2:
                        WriteCrafters();
                        break;
                    case 3:
                        GetParentItems();
                        break;
                    case 4:
                        //GetChildItems();
                        //break;
                    case 5:
                        ComingSoon();
                        break;
                    case 0:
                        quit = true;
                        return;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
                Console.WriteLine();
            }
            catch(FormatException fe)
            {
                Console.WriteLine("Invalid input");
                Console.WriteLine();
            }
        }

        private static void GetChildItems()
        {
            Console.WriteLine();
        }

        private static void GetParentItems()
        {
            string itemName = AskItemName();
            Console.WriteLine();
            if (itemName.Equals("cancel"))
            {
                Console.WriteLine("Search cancelled.");
                Console.WriteLine();
                return;
            }
            else
            {
                Crafter crafter = ctx.Crafters.ToList().Find(c => c.Kid.Name.Equals(itemName));
                if (crafter != null)
                {
                    if (crafter.Researched)
                    {
                        if (crafter.Mom != null)
                        {
                            if (crafter.Dad != null)
                            {
                                Console.WriteLine($"To make {crafter.KidsMade} {itemName} you need {crafter.MomsNeeded} {crafter.Mom.Name} and {crafter.DadsNeeded} {crafter.Dad.Name}.");
                            }
                            else
                            {
                                Console.WriteLine($"To make {crafter.KidsMade} {itemName} you need {crafter.MomsNeeded} {crafter.Mom.Name}.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{itemName} is a starting item. You make {crafter.KidsMade} per cycle per level.");
                        }
                        return;
                    }
                    else
                    {
                        Console.WriteLine("This item has not been researched yet.");
                        Console.WriteLine();
                        GetParentItems();
                    }
                }
                else
                {
                    Console.WriteLine("This is not an item.");
                    Console.WriteLine();
                    GetParentItems();
                }

            }
        }

        private static string AskItemName()
        {
            bool validInput = false;
            string searchType;
            string itemName = Console.ReadLine();
            while (!validInput)
            {
                Console.WriteLine("Search by id or name?");
                Console.WriteLine("(You can type cancel any time to cancel your search)");
                searchType = Console.ReadLine();
                Console.WriteLine();

                Console.WriteLine("What item would you like to know more about?");
                switch (searchType)
                {
                    case "cancel":
                        return "cancel";
                    case "name":
                        itemName = AskItemByName();
                        break;
                    case "id":
                        itemName = AskItemById();
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }
                Console.WriteLine();
            }
            return itemName;
        }

        private static string AskItemByName()
        {
            string itemName;
            Console.Write("Name => ");
            itemName = Console.ReadLine();
            return itemName;
        }

        private static string AskItemById()
        {
            string itemName;
            int searchId = 0;
            try
            {
                searchId = int.Parse(Console.ReadLine());
            }
            catch(FormatException fe)
            {

            }
            itemName = ctx.Items.ToList().Find(i => i.Id == searchId).Name;
            return itemName;
        }

        private static void ComingSoon()
        {
            Console.WriteLine("Coming Soon!");
        }

        private static void WriteCrafters()
        {
            Console.WriteLine("CRAFTERS:");
            Console.WriteLine("---------");
            Console.WriteLine();
            foreach (Crafter c in ctx.Crafters.ToList())
            {
                if (c.Researched)
                {
                    Console.WriteLine(c.ToString());
                    Console.WriteLine();
                }
            }
            return;
        }

        private static void WriteItems()
        {
            Console.WriteLine("ITEMS:");
            Console.WriteLine("------");
            Console.WriteLine();
            foreach (Item i in ctx.Items.ToList())
            {
                if (i.Researched)
                {
                    Console.WriteLine(i.ToString());
                    Console.WriteLine();
                }
            }
            return;
        }
    }
}