using EfCodeFirstCore.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCodeFirstCore.DataHandlers
{
    internal class SaveChangesWithErrorHandling
    {
        public bool SaveChanges(EfCodeFirstCoreContext context)
        {
            try
            {
                if (context.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbUpdateException("Unexpected number of rows affected, following error message was given: " + e.Message);
            }
            catch (DbUpdateException e)
            {
                throw new DbUpdateException("Failed to save context to the database with the following message: " + e.Message);
            }
        }
    }
}
