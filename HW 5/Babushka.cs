using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_5
{
    internal class Babushka
    {
        public string Name { get; }
        public int Age { get; }
        public List<string> Diseases { get; }

        public Babushka(string name, int age, List<string> diseases)
        {
            Name = name;
            Age = age;
            Diseases = diseases;
        }

        public override string ToString()
        {
            return $"{Name}, возраст: {Age}, болезни: {string.Join(", ", Diseases)}";
        }
    }
}
