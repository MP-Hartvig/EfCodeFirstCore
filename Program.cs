using EfCodeFirstCore.GUI;
using EfCodeFirstCore.Managers;

namespace EfCodeFirstCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GuiManager guiManager = new GuiManager();
            guiManager.GuiInitializer();
        }
    }
}