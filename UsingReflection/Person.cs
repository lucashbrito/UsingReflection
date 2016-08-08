using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingReflection
{
   public class Person
    {
        public Person()
        {
            Name = "Lucas";
        }
        public Person(string n)
        {
            Name = n;
        }

        public int Age { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Walk() { return "I walk!"; }
        public void See() { Console.WriteLine("I see!"); }
        public void Talk() { Console.WriteLine("I talk!"); }

    }
}
