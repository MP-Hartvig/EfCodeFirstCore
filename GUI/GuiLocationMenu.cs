using EfCodeFirstCore.Managers;
using EfCodeFirstCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCodeFirstCore.GUI
{
    internal class GuiLocationMenu
    {
        InitializationManager iManager = new InitializationManager();
        string navigationMessage = "Press enter twice to go to the next step, or escape to go to the start menu \n";

        public void LocationMenu()
        {
            GuiMenuHeader menuHeader = new GuiMenuHeader();
            menuHeader.MenuHeader("Location menu");

            Console.WriteLine("1. Create location");
            Console.WriteLine("2. Update location [WIP]");
            Console.WriteLine("3. Delete location [WIP]");
            Console.WriteLine("4. Show all location");
            Console.WriteLine("5. Go back \n");
            Console.Write("Press a number.");

            bool menuControl = true;

            while (menuControl)
            {
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        CreateMenu();
                        break;
                    case '2':

                        break;
                    case '3':

                        break;
                    case '4':
                        ShowAllLocations();
                        break;
                    case '5':
                        GoBack();
                        break;
                    default:
                        break;
                }
            }
        }

        private void CreateMenu()
        {
            Console.WriteLine(navigationMessage);
            Console.WriteLine("Write the location name: \n");

            bool menuBool = true;

            while (menuBool)
            {
                string input = Console.ReadLine()!;

                if (input != string.Empty)
                {
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        if (iManager.CreateLocation(input))
                        {
                            Console.WriteLine("Location was succesfully created");
                            Console.WriteLine("Press escape to go back to the start menu");
                        }
                        else
                        {
                            Console.WriteLine("Location failed to be created");
                            Console.WriteLine("Press escape to go back to the start menu");
                        }
                    }
                }

                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    GoBack();
                }
            }
        }

        private void ShowAllLocations()
        {
            List<Location> locations = iManager.GetLocationList();

            Console.Clear();

            foreach (Location item in locations)
            {
                Console.WriteLine("Location name: " + item.city);
                Console.WriteLine("\n-----------------------------------------------\n");
            }
        }

        private void GoBack()
        {
            GuiManager guiManager = new GuiManager();
            guiManager.GuiInitializer();
        }
    }
}
