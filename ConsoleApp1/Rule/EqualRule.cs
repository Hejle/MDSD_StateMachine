using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Rule
{
    public class EqualRule : AbstractIntegerRule
    {
        public EqualRule(int value)
        {
            this.targetValue = value;
        }

        protected override bool SatisfyIntRule(int input)
        {
            return input == targetValue;
        }
    }
}
