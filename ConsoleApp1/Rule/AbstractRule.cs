using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Rule
{
    public abstract class AbstractRule
    {
        public abstract Boolean SatisfyAbstractRule(Object input);

        public string VariableName;

        public AbstractRule(string variableName)
        {
            this.VariableName = variableName;
        }
    }
}
