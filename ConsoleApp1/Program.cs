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
            Console.WriteLine("Starting Temperature: " + water.GetVariable("Temperature").Value);
            Console.WriteLine("Starting State: " + water.GetState());
            water.IncreaseIntVariable("Temperature", 100);
            water.DecreaseIntVariable("Temperature", 30);
            water.DecreaseIntVariable("Temperature", 100);
            water.IncreaseIntVariable("Temperature", 40);
            water.IncreaseIntVariable("Temperature", 20);
        }
    }
}
