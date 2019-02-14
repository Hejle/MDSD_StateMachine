using ConsoleApp1.Rule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Transition {

        public State ParentState { get; private set; }

        public State ResultState { get; set; }

        public AbstractRule Rule { get; set; }

        public String Name { get; private set; }

        public Transition(String name, State parentState)
        {
            this.Name = name;
            this.ParentState = parentState;
        }

    }
}
