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
            Console.Write("Select your organism: ");
            int playerOrg = int.Parse(Console.ReadLine());
            orgsList[playerOrg].oName = orgsList[playerOrg].oName.ToUpper();
            while (orgsList.Length > 2 && orgsList[playerOrg].oHealth >= 0)
            {
                Console.WriteLine("Round {0}!", roundNum);
                orgsList = Combat.Init(orgsList);
                roundNum++;
                Console.ReadKey();
                Console.Clear();
                Event.eventCall(orgsList[playerOrg]);
            }
            Console.WriteLine("FINAL ROUND: {0} VS {1}", orgsList[0].oName, orgsList[1].oName);
            Combat.Init(orgsList);
            Console.ReadKey();
        }
    }
}
