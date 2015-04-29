using System;
using System.Collections.Generic;
using System.Linq;

namespace UsefulSnippets
{
    public class Mathematics
    {
        public static double CalculateStdDev(IEnumerable<double> values)
        {
            double ret = 0;
            double[] enumerable = values as double[] ?? values.ToArray();
            if (!enumerable.Any()) return ret;
            //Compute the Average
            double avg = enumerable.Average();

            //Perform the Sum of (value-avg)^2
            double sum = enumerable.Sum(d => Math.Pow(d - avg, 2));

            //Put it all together
            ret = Math.Sqrt((sum) / enumerable.Count() - 1);
            return ret;
        }
    }
}
