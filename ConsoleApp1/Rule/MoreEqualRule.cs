using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Rule
{
    public class MoreEqualRule : AbstractIntegerRule
    {
        public MoreEqualRule(string variable, int value) : base(variable, value)
        {
        }

        protected override bool SatisfyIntRule(int input)
        {
            return input >= TargetValue;
        }
    }
}
