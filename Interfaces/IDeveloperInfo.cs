using EfCodeFirstCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCodeFirstCore.Interfaces
{
    public interface IDeveloperInfo
    {
        Developer SelectDeveloper(int id);
        bool CreateDeveloper(Developer developer);
        bool UpdateDeveloper(Developer developer);
        bool DeleteDeveloper(Developer developer);
        List<Developer> SelectAllDevelopers();
    }
}
