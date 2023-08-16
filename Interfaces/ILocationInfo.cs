using EfCodeFirstCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCodeFirstCore.Interfaces
{
    public interface ILocationInfo
    {
        bool CreateLocation(Location location);
        bool UpdateLocation(Location location);
        bool DeleteLocation(Location location);
        List<Location> SelectAllLocations();
    }
}
