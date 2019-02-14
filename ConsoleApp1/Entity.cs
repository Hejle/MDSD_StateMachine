using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class Entity
    {
        //Metamodel?
        private List<State> PossibleStates = new List<State>();

        public State CurrentState {get; set;}

        public string Name { get; private set; }

        public Entity(string name)
        {
            this.Name = name;
        }

        public string PrintState()
        {
            return CurrentState.Name;
        }

    }
}
