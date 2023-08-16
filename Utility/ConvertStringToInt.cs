using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCodeFirstCore.Utility
{
    internal class ConvertStringToInt
    {
        public int ConvertStringToIntWithErrorHandling(string value)
        {
			try
			{
				return Convert.ToInt32(value);
			}
			catch (FormatException e)
			{
				throw new FormatException("Convert from string to int failed with the following message: " + e.Message);
			}
            catch (OverflowException e)
            {
                throw new OverflowException("Convert from string to int failed with the following message: " + e.Message);
            }
        }
    }
}
