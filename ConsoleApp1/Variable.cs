using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Variable
    {
        public string Name { get; private set; }

        public object Value;

        public string Type;

        public Variable(string name, object value, string type)
        {
            this.Name = name;
            this.Value = value;
            this.Type = type;
        }

    }
}
