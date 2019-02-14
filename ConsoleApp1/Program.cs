using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DslStateMachine
{
    public class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.StateMachine();
            Console.Read();
        }

        public Program()
        {
        }

        public void StateMachine()
        {
            ElementBuilder eb = new ElementBuilder();
            Element water = (Element) eb.Build();
            Console.WriteLine(water.PrintState());
            water.IncreaseDegrees(100);
            water.DecreaseDegrees(30);
            water.DecreaseDegrees(100);
            water.IncreaseDegrees(40);
            
        }
    }
}
