using ConsoleApp1.Rule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class State
    {
        public string Name { get; private set; }
    
        private Dictionary<string, Transition> TransitionsDictionary = new Dictionary<string, Transition>();

        public State (string name) {
            this.Name = name;
        }

        public void AddTransition(String transitionName, Transition transition)
        {
            TransitionsDictionary.Add(transitionName, transition);
        }

        public State CheckTrasitionRules(Dictionary<String, Variable> variables)
        {
            foreach (KeyValuePair<string, Transition> entry in TransitionsDictionary)
            {
                AbstractRule rule = entry.Value.Rule;
                Variable variable = variables[rule.VariableName];

                if (rule.SatisfyAbstractRule(variable.Value))
                {
                    return entry.Value.ResultState.CheckTrasitionRules(variables);
                }
            }
            return this;
        }
    }
}
