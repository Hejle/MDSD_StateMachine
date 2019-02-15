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

        public List<AbstractRule> Rules = new List<AbstractRule>();

        public string Name { get; private set; }

        public List<AbstractRule> GetRules()
        {
            return Rules;
        }

        public void AddRule(AbstractRule rule)
        {
            Rules.Add(rule);
        }

        public Transition(string name, State parentState)
        {
            this.Name = name;
            this.ParentState = parentState;
        }

    }
}
