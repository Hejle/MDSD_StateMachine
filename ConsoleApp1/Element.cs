using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Element : Entity
    {
        public int Temperature { get; set; }

        public Element (String name) : base(name)
        {
        }

        public void IncreaseDegrees(int input)
        {
            Temperature = Temperature + input;
            Console.WriteLine("Current Temperature: " + Temperature);
            checkRules();
        }

        public void DecreaseDegrees(int input)
        {
            Temperature = Temperature - input;
            Console.WriteLine("Current Temperature: " + Temperature);
            checkRules();
        }

        public void Init()
        {
            CurrentState = CurrentState.CheckTrasitionRules(Temperature);
        }

        private protected void checkRules()
        {
            State s = CurrentState.CheckTrasitionRules(Temperature);
            
            if(!s.Equals(CurrentState))
            {
                CurrentState = s;
                Console.WriteLine("The new state is: " + CurrentState.Name);
            }

        }

    }
}
