using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DslStateMachine
{
    public abstract class Entity
    {
        private List<State> PossibleStates = new List<State>();

        private protected Dictionary<String, Variable> Variables = new Dictionary<String, Variable>();

        public State CurrentState {get; set;}

        public string Name { get; private set; }

        public Entity(string name)
        {
            this.Name = name;
        }

        public void AddVariable(Variable variable)
        {
            Variables.Add(variable.Name, variable);
        }

        public void Init()
        {
            CurrentState = CurrentState.CheckTrasitionRules(this.Variables);
        }

        public void IncreaseIntVariable(string variable, int input)
        {

            Variable var = Variables[variable];

            var.Value = (int)var.Value + input;
            Console.WriteLine("Current " + var.Name + ": " + var.Value);
            checkRules();
        }

        public void DecreaseIntVariable(string variable, int input)
        {
            Variable var = Variables[variable];
            var.Value = (int)var.Value - input;
            Console.WriteLine("Current " + var.Name + ": " + var.Value);
            checkRules();
        }

        public string GetState()
        {
            return CurrentState.Name;
        }

        public Variable GetVariable(string name)
        {
            return Variables[name];
        }

        private protected void checkRules()
        {
            State s = CurrentState.CheckTrasitionRules(this.Variables);

            if (!s.Equals(CurrentState))
            {
                CurrentState = s;
                Console.WriteLine("The new state is: " + CurrentState.Name);
            }

        }

    }
}
