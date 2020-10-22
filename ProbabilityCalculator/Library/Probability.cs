using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbabilityCalculator.Library
{
   public class Probability : PropabilityBase
    {
        #region "Method"
        // Overriden method that calculates the probability of two events.
        public override float Calculate()
        {
            return (eventX + eventY) - Multiply();
        }

        public override float Multiply()
        {
            return (eventX * eventY);
        }

        #endregion
    }
}
