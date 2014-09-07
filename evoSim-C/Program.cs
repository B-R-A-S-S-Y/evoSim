using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoSim_C
{
    class Program
    {
        static void Main(string[] args)
        {
            Generation gen = new Generation();
            Generation.Organism[] orgsList = Generation.GenPhase(64);
            Combat.Init(orgsList);
            Console.ReadKey();
        }
    }
}
