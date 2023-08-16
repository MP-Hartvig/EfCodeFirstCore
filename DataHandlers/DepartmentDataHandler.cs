using EfCodeFirstCore.DataContext;
using EfCodeFirstCore.Interfaces;
using EfCodeFirstCore.Models;
using EfCodeFirstCore.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCodeFirstCore.DataHandlers
{
    internal class DepartmentDataHandler : IDepartmentInfo
    {
        private readonly EfCodeFirstCoreContext context;
        private CheckObjectForNull checker = new CheckObjectForNull();
        private SaveChangesWithErrorHandling save = new SaveChangesWithErrorHandling();

        public DepartmentDataHandler(EfCodeFirstCoreContext ctx)
        {
            this.context = ctx;
        }

        public Department SelectDepartment(int id)
        {
            if (id.Equals(null) | id == 0)
            {
                throw new ArgumentNullException("Id cant be null or 0!");
            }

            return context.department.FirstOrDefault(x => x.id == id)!;
        }

        public bool CreateDepartment(Department department)
        {
            checker.CheckForNull(department);
            context.department.Add(department);
            return save.SaveChanges(context);
        }

        public bool UpdateDepartment(Department department)
        {
            checker.CheckForNull(department);
            context.department.Update(department);
            return save.SaveChanges(context);
        }

        public bool DeleteDepartment(Department department)
        {
            checker.CheckForNull(department);
            context.department.Remove(department);
            return save.SaveChanges(context);
        }

        public List<Department> SelectAllDepartments()
        {
            return context.department.ToList<Department>();
        }
    }
}
