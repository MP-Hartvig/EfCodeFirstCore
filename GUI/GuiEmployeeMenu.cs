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
    internal class GuiEmployeeMenu
    {
        string navigationMessage = "Press enter twice to go to the next step, or escape to go to the start menu \n";

        InitializationManager iManager = new InitializationManager();

        public void EmployeeCrudMenu(string type)
        {
            GuiMenuHeader menuHeader = new GuiMenuHeader();
            menuHeader.MenuHeader(type + " menu");

            Console.WriteLine("1. Create " + type);
            Console.WriteLine("2. Update " + type + "[WIP]");
            Console.WriteLine("3. Delete " + type + "[WIP]");
            Console.WriteLine("4. Show all " + type);
            Console.WriteLine("5. Go back \n");
            Console.Write("Press a number.\n");

            bool menuControl = true;

            while (menuControl)
            {
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        CreateMenu(type, "first name");
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

        private void CreateMenu(string type, string step)
        {
            Console.WriteLine(navigationMessage);
            Console.WriteLine("Write the " + step + ": \n");

            bool menuBool = true;

            List<string> inputStrings = new List<string>();

            // Dont like this, but didnt have time to refactor
            while (menuBool)
            {
                string input = Console.ReadLine()!;

                if (input != string.Empty)
                {
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        inputStrings.Add(input);

                        if (inputStrings.Count == 2)
                        {
                            CreateMenu(type, "last name");
                        }
                        else if (inputStrings.Count == 3)
                        {
                            CreateMenu(type, "street name");
                        }
                        else if (inputStrings.Count == 4)
                        {
                            CreateMenu(type, "street number");
                        }
                        else if (inputStrings.Count == 5)
                        {
                            CreateMenu(type, "private phone");
                        }
                        else if (inputStrings.Count == 6)
                        {
                            CreateMenu(type, "primary programming language");
                        }
                        else 
                        {
                            DepartmentMenu(type, inputStrings);
                        }
                    }
                }

                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    GoBack();
                }
            }
        }

        private void DepartmentMenu(string type, List<string> inputStrings)
        {
            List<Department> departments = iManager.GetDepartmentList();

            Console.WriteLine(navigationMessage);

            for (int i = 0; i < departments.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + departments[i].name);
            }

            Console.Write("Press a number.");

            bool menuBool = true;

            while (menuBool)
            {
                string departmentNumber = Console.ReadLine()!;

                if (departmentNumber != string.Empty)
                {
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        if (iManager.CreateEmployee(type, inputStrings, departmentNumber, departments))
                        {
                            Console.WriteLine("Employee was succesfully created");
                            Console.WriteLine("Press escape to go back to the start menu");
                        }
                        else
                        {
                            Console.WriteLine("Employee failed to be created");
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
