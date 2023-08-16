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
    internal class DeveloperDataHandler : IDeveloperInfo
    {
        private readonly EfCodeFirstCoreContext context;
        private CheckObjectForNull checker = new CheckObjectForNull();
        private SaveChangesWithErrorHandling save = new SaveChangesWithErrorHandling();

        public DeveloperDataHandler(EfCodeFirstCoreContext ctx)
        {
            this.context = ctx;
        }

        public Developer SelectDeveloper(int id)
        {
            if (id.Equals(null))
            {
                throw new ArgumentNullException("Id cannot be null!");
            }

            return context.developer.FirstOrDefault(x => x.Id == id)!;
        }

        public bool CreateDeveloper(Developer developer)
        {
            checker.CheckForNull(developer);
            context.developer.Add(developer);
            return save.SaveChanges(context);
        }

        public bool UpdateDeveloper(Developer developer)
        {
            checker.CheckForNull(developer);
            context.developer.Update(developer);
            return save.SaveChanges(context);
        }

        public bool DeleteDeveloper(Developer developer)
        {
            checker.CheckForNull(developer);
            context.developer.Remove(developer);
            return save.SaveChanges(context);
        }

        public List<Developer> SelectAllDevelopers()
        {
            return context.developer.ToList<Developer>();
        }
    }
}
