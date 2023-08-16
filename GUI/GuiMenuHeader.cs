using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCodeFirstCore.GUI
{
    internal class GuiMenuHeader
    {
        public void MenuHeader(string title)
        {
            Console.Clear();
            Console.WriteLine("==================================================");
            Console.WriteLine("              " + title);
            Console.WriteLine("================================================== \n\n");
        }
    }
}
