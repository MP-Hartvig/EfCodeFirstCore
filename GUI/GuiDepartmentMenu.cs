using EfCodeFirstCore.Managers;
using EfCodeFirstCore.Models;
using EfCodeFirstCore.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCodeFirstCore.GUI
{
    internal class GuiDepartmentMenu
    {
        InitializationManager iManager = new InitializationManager();
        string navigationMessage = "Press enter twice to go to the next step, or escape to go to the start menu \n";

        public void DepartmentMenu()
        {
            GuiMenuHeader menuHeader = new GuiMenuHeader();
            menuHeader.MenuHeader("Department menu");

            Console.WriteLine("1. Create department");
            Console.WriteLine("2. Update department [WIP]");
            Console.WriteLine("3. Delete department [WIP]");
            Console.WriteLine("4. Show all departments");
            Console.WriteLine("5. Go back \n");
            Console.Write("Press a number.\n");

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
                        ShowAllDevelopers();
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
            Console.WriteLine("Write the department name: \n");

            bool menuBool = true;

            while (menuBool)
            {
                string input = Console.ReadLine()!;

                if (input != string.Empty)
                {
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        LocationMenu(input);
                    }
                }

                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    GoBack();
                }
            }
        }

        private void LocationMenu(string input)
        {
            List<Location> locations = iManager.GetLocationList();

            Console.WriteLine(navigationMessage);

            for (int i = 0; i < locations.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + locations[i].city);
            }

            Console.Write("Press a number.\n");

            bool menuBool = true;

            while (menuBool)
            {
                string departmentNumber = Console.ReadLine()!;

                if (departmentNumber != string.Empty)
                {
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {                        
                        if (iManager.CreateDepartment(input, departmentNumber, locations))
                        {
                            Console.WriteLine("Department was succesfully created");
                            Console.WriteLine("Press escape to go back to the start menu");
                        }
                        else
                        {
                            Console.WriteLine("Department failed to be created");
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

        private void ShowAllDevelopers()
        {
            List<Developer> developers = iManager.GetDeveloperList();

            Console.Clear();

            foreach (Developer item in developers)
            {
                Console.WriteLine("First name: " + item.firstName);
                Console.WriteLine("Last name: " + item.lastName);
                Console.WriteLine("Street name: " + item.streetName);
                Console.WriteLine("Street number: " + item.streetNumber);
                Console.WriteLine("Private phone: " + item.privatePhone);
                Console.WriteLine("Primary programming language: " + item.primaryProgrammingLanguage);
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
