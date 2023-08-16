using EfCodeFirstCore.DataContext;
using EfCodeFirstCore.Interfaces;
using EfCodeFirstCore.Models;
using EfCodeFirstCore.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCodeFirstCore.DataHandlers
{
    internal class ComputerDataHandler : IComputerInfo
    {
        private readonly EfCodeFirstCoreContext context;
        private CheckObjectForNull checker = new CheckObjectForNull();
        private SaveChangesWithErrorHandling save = new SaveChangesWithErrorHandling();

        public ComputerDataHandler(EfCodeFirstCoreContext ctx)
        {
            this.context = ctx;
        }

        public Computer SelectComputer(int id)
        {
            if (id.Equals(null))
            {
                throw new ArgumentNullException("Id cannot be null!");
            }

            return context.computer.FirstOrDefault(x => x.id == id)!;
        }

        public bool CreateComputer(Computer computer)
        {
            checker.CheckForNull(computer);
            context.computer.Add(computer);
            return save.SaveChanges(context);
        }

        public bool UpdateComputer(Computer computer)
        {
            checker.CheckForNull(computer);
            context.computer.Update(computer);
            return save.SaveChanges(context);
        }

        public bool DeleteComputer(Computer computer)
        {
            checker.CheckForNull(computer);
            context.computer.Remove(computer);
            return save.SaveChanges(context);
        }

        public List<Computer> SelectAllComputers()
        {
            return context.computer.ToList<Computer>();
        }
    }
}
