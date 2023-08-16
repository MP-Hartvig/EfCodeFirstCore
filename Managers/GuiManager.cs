using EfCodeFirstCore.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCodeFirstCore.Managers
{
    /// <summary>
    /// Manages the initialization of the different gui components
    /// </summary>
    internal class GuiManager
    {
        GuiMenuHeader menuHeader = new GuiMenuHeader();
        GuiStartMenu startMenu = new GuiStartMenu();
        GuiEmployeeMenu employeeMenu = new GuiEmployeeMenu();
        GuiDepartmentMenu departmentMenu = new GuiDepartmentMenu();
        GuiLocationMenu locationMenu = new GuiLocationMenu();

        public void GuiInitializer()
        {
            menuHeader.MenuHeader("Welcome");

            startMenu.StartMenu();

            bool menuControl = true;

            while (menuControl)
            {
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        employeeMenu.EmployeeCrudMenu("Developer");
                        break;
                    case '2':
                        employeeMenu.EmployeeCrudMenu("Manager");
                        break;
                    case '3':
                        departmentMenu.DepartmentMenu();
                        break;
                    case '4':
                        locationMenu.LocationMenu();
                        break;
                    case '5':
                        ExitApplication();
                        break;
                    default:
                        break;
                }
            }
        }

        private void ExitApplication()
        {
            Environment.Exit(0);
        }
    }
}
