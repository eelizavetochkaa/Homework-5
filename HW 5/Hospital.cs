using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_5
{
    internal class Hospital
    {
        public string Name { get; }
        public List<string> TreatableDiseases { get; }
        public int Capacity { get; }
        public Queue<Babushka> Patients { get; } = new Queue<Babushka>();

        public Hospital(string name, List<string> treatableDiseases, int capacity)
        {
            Name = name;
            TreatableDiseases = treatableDiseases;
            Capacity = capacity;
        }

        public bool CanTreat(Babushka babushka)
        {
            int treatableCount = babushka.Diseases.Count(d => TreatableDiseases.Contains(d));
            return treatableCount >= babushka.Diseases.Count / 2;
        }

        public override string ToString()
        {
            double percentFilled = (double)Patients.Count / Capacity * 100;
            return $"{Name}, болезни: {string.Join(", ", TreatableDiseases)}, " +
                $"пациенты: {Patients.Count}, заполненность: {percentFilled}%";
        }

        public bool HasCapacity()
        {
            return Patients.Count < Capacity;
        }

        public void AddPatient(Babushka babushka)
        {
            Patients.Enqueue(babushka);
        }
    }
}
