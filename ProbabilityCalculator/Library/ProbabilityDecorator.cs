using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbabilityCalculator.Library
{
    /// <summary>
    /// This type acts as an decorator which set the probability object dynamically.
    /// </summary>
    public abstract class ProbabilityDecorator : PropabilityBase
    {
        // This variable hold reference to object passed dynamically.
        protected PropabilityBase ProBase;

        /// <summary>
        /// This is setter method which helps in wrapper the object.
        /// </summary>
        /// <param name="ProBase"></param>
        public void SetComponent(PropabilityBase ProBase)
        {
            this.ProBase = ProBase;
        }

        /// <summary>
        /// This method calculates the probability of decorator object.
        /// </summary>
        /// <returns></returns>
        public override float Calculate()
        {
            if (ProBase != null)
            {
                ProBase.eventX =  ProBase.Calculate();
                ProBase.eventY = this.eventY;
                return ProBase.Calculate();
            }
            return 0;
        }
        public override float Multiply()
        {
            if (ProBase != null)
            {
                ProBase.eventX = ProBase.Multiply();
                if (this.eventY != 0)
                {
                    ProBase.eventY = this.eventY;
                    return ProBase.Multiply();
                }
                return ProBase.eventX;
            }
            return 0;
        }

    }
}
