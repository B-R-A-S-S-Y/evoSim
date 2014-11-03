﻿using System;
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
            Generation.Organism empty = new Generation.Organism();
            empty.oAttack = 0; empty.oDefence = 0; empty.oHealth = 0; empty.oName = "Zombie";
            Random attackRoll = new Random();
            int oHealth1 = orgsList[org1num].oHealth, oHealth2 = orgsList[org2num].oHealth; 
            while (orgsList[org1num].oHealth >= 0 && orgsList[org2num].oHealth >= 0)
            {
                if (org1mdm > 0)
                {
                    orgsList[org2num].oHealth -= attackRoll.Next(0, org1mdm + 1);
                }
                if (org2mdm > 0)
                {
                    orgsList[org2num].oHealth -= attackRoll.Next(0, org2mdm + 1);
                }
                else if (org1mdm <= 0 && org2mdm <= 0)
                {
                    orgsList[attackRoll.Next(org1num, org2num + 1)].oHealth = 0;
                    break;
                }
            }
            Thread.Sleep(10);
            if (orgsList[org1num].oHealth <= 0 && orgsList[org2num].oHealth > 0 || orgsList[org2num].oName == "Zombie")
            {
                Console.WriteLine("\t\t{0} is victorious!", orgsList[org2num].oName);
                orgsList[org2num].oHealth = oHealth2;
                return orgsList[org2num];
            }
            else if (orgsList[org2num].oHealth <= 0 && orgsList[org1num].oHealth > 0 || orgsList[org2num].oName == "Zombie")
            {
                Console.WriteLine("\t\t{0} is victorious!", orgsList[org1num].oName);
                orgsList[org1num].oHealth = oHealth1;
                return orgsList[org1num];
            }
            else
            {
                Console.WriteLine("\t\tBoth {0} and {1} die.", orgsList[org1num].oName, orgsList[org2num].oName);
                return empty;
            }
        }
    }
}
