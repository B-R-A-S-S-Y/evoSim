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
            Generation.Organism[] orgsList = Generation.GenPhase(64);
            int roundNum = 1;
            while (orgsList.Length > 2)
            {
                Console.WriteLine("Round {0}!", roundNum);
                orgsList = Combat.Init(orgsList);
                roundNum++;
            }
            Console.ReadKey();
            Console.WriteLine("FINAL ROUND", orgsList[0].oName, orgsList[1].oName);
            Combat.Init(orgsList);
            Console.ReadKey();
        }
    }
}
