using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Rule
{
    public abstract class AbstractIntegerRule : AbstractRule
    {

        protected int TargetValue;

        protected AbstractIntegerRule(string variable, int targetValue) : base (variable)
        {
            this.TargetValue = targetValue;
        }

        public override Boolean SatisfyAbstractRule(Object input)
        {
            try
            {
                int i = (int)input;
                return SatisfyIntRule(i);
            }
            catch (InvalidCastException)
            {
                //Input is not a number so will fail
                return false;
            }
        }
        protected abstract Boolean SatisfyIntRule(int input);

    }
}
