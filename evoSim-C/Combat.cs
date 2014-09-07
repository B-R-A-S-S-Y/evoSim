using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoSim_C
{
    class Combat
    {
        public static void Init(Generation.Organism[] orgsList)
        {
            int match = 1;
            for (int i = 1; i < orgsList.Length; i+=2)
            {
                Console.WriteLine("Match {0}:\n\t {1} \tvs \t  {2}", match, orgsList[i-1].oName, orgsList[i].oName);
                match++;
            }
        }
    }
}
