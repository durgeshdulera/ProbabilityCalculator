using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProbabilityCalculator;
namespace ProbabilityTest
{
    [TestClass]
    public class CalculatorTest
    {
        //Test for two indepedent probabilities.
        [TestMethod]
        public void IndependentEvents()
        {
            float expected = 0.25F;
            float eventX = 0.5F;
            float eventY = 0.5F;
            

            ProbabilityCalculator.Library.Probability objProbability = new ProbabilityCalculator.Library.Probability();
            objProbability.eventX = eventX;
            objProbability.eventY = eventY;
            

            float probabilityresult = objProbability.Multiply();

            Assert.AreEqual(expected, probabilityresult);
        }

        //Test for two mutually non exclusive probabilities.
        [TestMethod]
        public void MutuallyNonExclusiveEvents()
        {
            float expected = 0.75F;
            float eventX = 0.5F;
            float eventY = 0.5F;

            ProbabilityCalculator.Library.Probability objProbability = new ProbabilityCalculator.Library.Probability();
            objProbability.eventX = eventX;
            objProbability.eventY = eventY;

            float probabilityresult = objProbability.Calculate();

            Assert.AreEqual(expected, probabilityresult);
        }

        //Test for three indepedent probabilities.
        [TestMethod]
        public void IndependentEvents_ThreeProbabilities()
        {
            float expected = 0.075F;
            float eventX = 0.5F;
            float eventY = 0.5F;
            float eventZ = 0.3F;

            ProbabilityCalculator.Library.Probability objProbability = new ProbabilityCalculator.Library.Probability();
            objProbability.eventX = eventX;
            objProbability.eventY = eventY;
            ProbabilityCalculator.Library.ProbabilityWrapper wrapper = new ProbabilityCalculator.Library.ProbabilityWrapper();
            wrapper.SetComponent(objProbability);
            wrapper.eventY = eventZ;

            float probabilityresult = wrapper.Multiply();

            Assert.AreEqual(expected, probabilityresult);
        }

        //Test for three mutually non exclusive probabilities.
        [TestMethod]
        public void MutuallyNonExclusiveEvents_ThreeProbabilities()
        {
            float expected = 0.825F;
            float eventX = 0.5F;
            float eventY = 0.5F;
            float eventZ = 0.3F;

            ProbabilityCalculator.Library.Probability objProbability = new ProbabilityCalculator.Library.Probability();
            objProbability.eventX = eventX;
            objProbability.eventY = eventY;
            ProbabilityCalculator.Library.ProbabilityWrapper wrapper = new ProbabilityCalculator.Library.ProbabilityWrapper();
            wrapper.SetComponent(objProbability);
            wrapper.eventY = eventZ;

            float probabilityresult = wrapper.Calculate();

            Assert.AreEqual(expected, probabilityresult);
        }

    }
}
