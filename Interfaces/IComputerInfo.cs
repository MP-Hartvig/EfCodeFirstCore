using EfCodeFirstCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCodeFirstCore.Interfaces
{
    public interface IComputerInfo
    {
        bool CreateComputer(Computer developer);
        bool UpdateComputer(Computer developer);
        bool DeleteComputer(Computer developer);
        List<Computer> SelectAllComputers();
    }
}
