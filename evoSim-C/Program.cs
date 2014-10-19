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
            start:
            Generation.Organism[] orgsList = Generation.GenPhase(64);
            int roundNum = 1;
            for (int i = 0; i < orgsList.Length; i++)
            {
                if ((i+1) % 4 != 0)
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
            string porgName = orgsList[playerOrg].oName;
            bool endGame = false;
            while (orgsList.Length > 1 && !endGame)
            {
                if (playerOrg < orgsList.Length)
                {
                    Console.WriteLine("Round {0}:", roundNum);
                    orgsList = Combat.Init(orgsList);
                    roundNum++;
                    for (int i = 0; i < orgsList.Length; i++)
                    {
                        if (orgsList[i].oName == porgName)
                        {
                            playerOrg = i;
                            break;
                        }
                        else if (orgsList[i].oName != porgName && i == orgsList.Length - 1)
                        {
                            Console.Clear();
                            Console.WriteLine("Game Over");
                            endGame = true;
                            break;
                        }
                    }
                }
            }
            ConsoleKeyInfo yRead = new ConsoleKeyInfo();
            Console.Write("Press Y to restart or any other key to break shit!");
            yRead = Console.ReadKey(false);
            if (yRead.Key == ConsoleKey.Y)
            {
                Console.Clear();
                goto start;
            }
        }

    }
}
