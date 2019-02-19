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
            Console.WriteLine("Element is " + water.Name);
            Console.WriteLine("Starting Temperature: " + water.GetVariable("Temperature").Value);
            Console.WriteLine("Starting State: " + water.GetState());
            Console.WriteLine();
            water.IncreaseIntVariable("Temperature", 100); //GAS
            Console.WriteLine();
            water.IncreaseIntVariable("Energy", 9000);
            Console.WriteLine();
            water.DecreaseIntVariable("Temperature", 30); // LIQUID
            Console.WriteLine();
            water.DecreaseIntVariable("Temperature", 100); //SOLID
            Console.WriteLine();
            water.IncreaseIntVariable("Temperature", 40); //LIQUID
            Console.WriteLine();
            water.IncreaseIntVariable("Temperature", 20); // LIQUID
            Console.WriteLine();
            water.DecreaseIntVariable("Temperature", 70); // SOLID
            Console.WriteLine();
            water.IncreaseIntVariable("Temperature", 150); // GAS
            Console.WriteLine();

            /*
            Element iron = (Element)eb.Build("Iron", 0, 1538, 1538, 2861, 2891);
            Console.WriteLine("Element is " + iron.Name);
            Console.WriteLine("Starting Temperature: " + iron.GetVariable("Temperature").Value);
            Console.WriteLine("Starting State: " + iron.GetState());
            iron.IncreaseIntVariable("Temperature", 3000);
            iron.DecreaseIntVariable("Temperature", 1000);
            iron.DecreaseIntVariable("Temperature", 2000);
            iron.IncreaseIntVariable("Temperature", 1540);
            iron.IncreaseIntVariable("Temperature", 200); */


        }
    }
}
