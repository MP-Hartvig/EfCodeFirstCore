using EfCodeFirstCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCodeFirstCore.Interfaces
{
    public interface IDepartmentInfo
    {
        bool CreateDepartment(Department department);
        bool UpdateDepartment(Department department);
        bool DeleteDepartment(Department department);
        List<Department> SelectAllDepartments();
    }
}
