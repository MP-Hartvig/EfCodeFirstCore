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
    internal class LocationDataHandler : ILocationInfo
    {
        private readonly EfCodeFirstCoreContext context;
        private CheckObjectForNull checker = new CheckObjectForNull();
        private SaveChangesWithErrorHandling save = new SaveChangesWithErrorHandling();

        public LocationDataHandler(EfCodeFirstCoreContext ctx)
        {
            this.context = ctx;
        }

        public Location SelectLocation(int id)
        {
            if (id.Equals(null) | id == 0)
            {
                throw new ArgumentNullException("Id cant be null or 0!");
            }

            return context.location.FirstOrDefault(x => x.id == id)!;
        }

        public bool CreateLocation(Location location)
        {
            checker.CheckForNull(location);
            context.location.Add(location);
            return save.SaveChanges(context);
        }

        public bool UpdateLocation(Location location)
        {
            checker.CheckForNull(location);
            context.location.Update(location);
            return save.SaveChanges(context);
        }

        public bool DeleteLocation(Location location)
        {
            checker.CheckForNull(location);
            context.location.Remove(location);
            return save.SaveChanges(context);
        }

        public List<Location> SelectAllLocations()
        {
            return context.location.ToList<Location>();
        }
    }
}
