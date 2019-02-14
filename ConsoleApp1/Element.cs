using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Element : Entity
    {
        public Element (string name) : base(name)
        {
        }

        public void Init()
        {
            CurrentState = CurrentState.CheckTrasitionRules(this.Variables);
        }

    }
}
