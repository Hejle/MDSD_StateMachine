using DslStateMachine.Rule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DslStateMachine
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
                bool transition = true;
                foreach(AbstractRule rule in entry.Value.GetRules())
                {
                    if(transition)
                    {
                        Variable variable = variables[rule.VariableName];

                        transition = rule.SatisfyAbstractRule(variable.Value);
                    }
                }
                if (transition)
                {
                    return entry.Value.ResultState.CheckTrasitionRules(variables);
                }
            }
            return this;
        }
    }
}
