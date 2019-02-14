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
    
        private Dictionary<String, Transition> transitionsDictionary = new Dictionary<string, Transition>();

        public State (String name) {
            this.Name = name;
        }

        public void AddTransition(String transitionName, Transition transition)
        {
            transitionsDictionary.Add(transitionName, transition);
        }

        public State CheckTrasitionRules(int temperature)
        {
            foreach (KeyValuePair<string, Transition> entry in transitionsDictionary)
            {
                if (entry.Value.Rule.SatisfyAbstractRule(temperature))
                {
                    return entry.Value.ResultState.CheckTrasitionRules(temperature);
                }
            }
            return this;
        }
    }
}
