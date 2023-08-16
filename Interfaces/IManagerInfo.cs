using EfCodeFirstCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCodeFirstCore.Interfaces
{
    public interface IManagerInfo
    {
        Manager SelectManager(int id);
        bool CreateManager(Manager developer);
        bool UpdateManager(Manager developer);
        bool DeleteManager(Manager developer);
        List<Manager> SelectAllManagers();
    }
}
