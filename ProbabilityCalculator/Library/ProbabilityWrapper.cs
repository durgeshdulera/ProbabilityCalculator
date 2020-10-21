using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbabilityCalculator.Library
{
    class ProbabilityWrapper : ProbabilityDecorator
    {
        public override float Calculate()
        {
            return base.Calculate();
        }
        public override float Multiply()
        {
            return base.Multiply();
        }
    }
}
