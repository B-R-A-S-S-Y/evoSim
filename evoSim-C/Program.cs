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
            for (int i = 0; i < orgsList.Length; i++)
            {
                if ((i+1) % 8 != 0)
                {
                    Console.Write("{0}: {1}\t", i+1, orgsList[i].oName);
                }
                else
                {
                    Console.Write("{0}: {1}\n", i+1, orgsList[i].oName);
                }

            }
            Console.Write("Select your organism: ");
            int playerOrg = int.Parse(Console.ReadLine())-1;
            Console.Clear();
            orgsList[playerOrg].oName = orgsList[playerOrg].oName.ToUpper();
            while (orgsList.Length > 1 && orgsList[playerOrg].oHealth > 0 && orgsList[playerOrg].oName != "Zombie")
            {
                Console.WriteLine("Round {0}!", roundNum);
                orgsList = Combat.Init(orgsList);
                roundNum++;
                Console.ReadKey();
                Console.Clear();
                if (orgsList[playerOrg].oHealth == 0)
                {
                    Console.WriteLine("Game Over: Your organism was defeated in battle.");
                    goto fin;
                }
                else
                {
                    Event.eventCall(orgsList[playerOrg]);
                    Console.Clear();
                }
                if (orgsList.Length == 2)
                {
                    Console.WriteLine("FINAL ROUND: {0} VS {1}", orgsList[0].oName, orgsList[1].oName);
                    Combat.Init(orgsList);
                }
            }
            fin:
            Console.ReadKey();
        }
    }
}
