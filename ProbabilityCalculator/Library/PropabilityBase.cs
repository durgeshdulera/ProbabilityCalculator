using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbabilityCalculator.Library
{
    /// <summary>
    /// Base class for reusability and acts as an Interface within decorators.
    /// </summary>
    abstract class PropabilityBase
    {
        #region "Variables"
        //Holds input variables
        public float eventX { get; set; }
        public float eventY { get; set; }
        #endregion

        #region "Method"
        // This method is overriden by the sub class.
        public abstract float Calculate();
        public abstract float Multiply();
        #endregion
    }
}
