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
    internal class ManagerDataHandler : IManagerInfo
    {
        private readonly EfCodeFirstCoreContext context;
        private CheckObjectForNull checker = new CheckObjectForNull();
        private SaveChangesWithErrorHandling save = new SaveChangesWithErrorHandling();

        public ManagerDataHandler(EfCodeFirstCoreContext ctx)
        {
            this.context = ctx;
        }

        public Manager SelectManager(int id)
        {
            if (id.Equals(null))
            {
                throw new ArgumentNullException("Id cannot be null!");
            }

            return context.manager.FirstOrDefault(x => x.Id == id)!;
        }

        public bool CreateManager(Manager manager)
        {
            checker.CheckForNull(manager);
            context.manager.Add(manager);
            return save.SaveChanges(context);
        }

        public bool UpdateManager(Manager manager)
        {
            checker.CheckForNull(manager);
            context.manager.Update(manager);
            return save.SaveChanges(context);
        }

        public bool DeleteManager(Manager manager)
        {
            checker.CheckForNull(manager);
            context.manager.Remove(manager);
            return save.SaveChanges(context);
        }

        public List<Manager> SelectAllManagers()
        {
            return context.manager.ToList<Manager>();
        }
    }
}
