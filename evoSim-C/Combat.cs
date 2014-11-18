using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace evoSim_C
{
    class Combat
    {
        public static Generation.Organism[] Init(Generation.Organism[] orgsList)
        {
            Generation.Organism[] winList = new Generation.Organism[orgsList.Length / 2];
            int match = 1;
            for (int i = 1; i < orgsList.Length; i+=2)
            {
                Console.WriteLine("\tMatch {0}:\n\t {1} \tvs \t  {2}", match, orgsList[i-1].oName, orgsList[i].oName);
                Console.WriteLine("\t{0}-{1}-{2}\t\t\t{3}-{4}-{5}", orgsList[i - 1].oAttack, orgsList[i - 1].oDefence, orgsList[i - 1].oHealth, orgsList[i].oAttack, orgsList[i].oDefence, orgsList[i].oHealth);
                winList[match - 1] = CombatExec(orgsList, i-1, i);
                match++;
            }
            Console.ReadKey();
            Console.Clear();
            return winList;
        }
        private static Generation.Organism CombatExec(Generation.Organism[] orgsList, int org1num, int org2num)
        {
            int org1mdm = orgsList[org1num].oAttack - orgsList[org2num].oDefence;
            int org2mdm = orgsList[org2num].oAttack - orgsList[org1num].oDefence;
            int[] hltArray = new int[2];
            hltArray[0] = orgsList[org1num].oHealth;
            hltArray[1] = orgsList[org2num].oHealth;
            Generation.Organism empty = new Generation.Organism();
            empty.oAttack = 0; empty.oDefence = 0; empty.oHealth = 0; empty.oName = "Zombie";
            Random attackRoll = new Random();
            int endRound = 0;
            while (hltArray[0] > 0 && hltArray[1] > 0 && endRound < 5)
            {
                if (org1mdm > 0 && org2mdm > 0)
                {
                    int dmg1 = attackRoll.Next(0, org1mdm);
                    hltArray[1] -= dmg1;
                    Thread.Sleep(10);
                    int dmg2 = attackRoll.Next(0, org2mdm);
                    hltArray[0] -= dmg2;
                    Thread.Sleep(10);
                }
                else if (org1mdm <= 0 || org2mdm <= 0)
                {
                    hltArray[randKill()] = 0;
                    break;
                }
                endRound++;
            }
            if (hltArray[0] <= 0 && hltArray[1] > 0 || orgsList[org1num].oName != "Zombie")
            {
                Console.WriteLine("\t\t{0} is victorious!", orgsList[org2num].oName);
                return orgsList[org2num];
            }
            else if (hltArray[1] <= 0 && hltArray[0] > 0 || orgsList[org2num].oName != "Zombie")
            {
                Console.WriteLine("\t\t{0} is victorious!", orgsList[org1num].oName);
                return orgsList[org1num];
            }
            else
            {
                Console.WriteLine("\t\tBoth {0} and {1} die.", orgsList[org1num].oName, orgsList[org2num].oName);
                return empty;
            }
        }
        private static int randKill()
        {
            Random killRoll = new Random();
            return killRoll.Next(0, 2);
        }
    }
}
