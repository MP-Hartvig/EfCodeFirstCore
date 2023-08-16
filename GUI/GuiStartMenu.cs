using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using EfCodeFirstCore.Managers;

namespace EfCodeFirstCore.GUI
{
    internal class GuiStartMenu
    {
        public void StartMenu()
        {
            Console.WriteLine("1. Developers");
            Console.WriteLine("2. Managers");
            Console.WriteLine("3. Departments");
            Console.WriteLine("4. Locations");
            Console.WriteLine("5. Exit \n");
            Console.Write("Press a number.");
        }
    }
}
