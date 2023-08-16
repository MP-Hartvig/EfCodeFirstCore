using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCodeFirstCore.Utility
{
    internal class CheckObjectForNull
    {
        public void CheckForNull(object value)
        {
            if (value.Equals(null))
            {
                throw new ArgumentNullException("Object: " + nameof(value) + " cannot be null!");
            }
        }
    }
}
