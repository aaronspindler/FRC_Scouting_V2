//*********************************License***************************************
//===============================================================================
//The MIT License (MIT)

//Copyright (c) 2014 FRC_Scouting_V2

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.
//===============================================================================
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
