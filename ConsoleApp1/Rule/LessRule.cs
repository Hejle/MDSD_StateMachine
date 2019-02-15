using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DslStateMachine.Rule
{
    public class LessRule : AbstractIntegerRule
    {
        public LessRule(string variable, int value) : base(variable, value)
        {
        }

        protected override bool SatisfyIntRule(int input)
        {
            return input < TargetValue;
        }
    }
}
