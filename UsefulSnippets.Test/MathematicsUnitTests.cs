using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UsefulSnippets.Test
{
    [TestClass]
    public class MathematicsUnitTests
    {
        [TestMethod]
        public void CalculateStdDevTestMethod()
        {
            double[] testData = { 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0 };
            double actualValue = Mathematics.CalculateStdDev(testData.ToList());
            double expectedValue = Math.Sqrt(55.0 / 6.0);
            Assert.AreEqual(expectedValue, actualValue, "Standard Deviation is not as expected");
        }
    }
}