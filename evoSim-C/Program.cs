using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace evoSim_C
{
class Program
{
    static void Main(string[] args)
        {
        StreamReader siLog = new StreamReader("logfile/log.txt");
        string oldWin = siLog.ReadToEnd();
        if (oldWin.Length > 0)
        {
            Console.WriteLine("Previous Winners:");
            Console.Write(oldWin);
            Console.ReadKey();
        }
        siLog.Close();
        Console.Clear();
        start:
            StreamWriter soLog = new StreamWriter("logfile/log.txt", true);
            Generation.Organism[] orgsList = Generation.GenPhase(64);
            int roundNum = 1;
            for (int i = 0; i < orgsList.Length; i++)
            {
                if ((i + 1) % 4 != 0)
                {
                    Console.Write("{0}: {1}\t", i + 1, orgsList[i].oName);
                }
                else
                {
                    Console.Write("{0}: {1}\n", i + 1, orgsList[i].oName);
                }
            }
            Console.Write("Select your organism: ");
            int playerOrg;
            while (!int.TryParse(Console.ReadLine(), out playerOrg))
            {
                Console.Write("Select your organism: ");
            }
            playerOrg -= 1;
            Generation.Organism player = orgsList[playerOrg];
            Console.Write("\n\nYou selected {0}\nAttack: {1}\nDefence: {2}\nHealth: {3}\nPress Any Key to Begin", player.oName, player.oAttack, player.oDefence, player.oHealth);
            Console.ReadKey();
            Console.Clear();
            orgsList[playerOrg].oName = orgsList[playerOrg].oName.ToUpper();
            string porgName = orgsList[playerOrg].oName;
            bool endGame = false;
            while (orgsList.Length > 1)
            {
                Console.Clear();
                Console.WriteLine("Round {0}:", roundNum);
                orgsList = Combat.Init(orgsList);
                roundNum++;
                for (int i = 0; i < orgsList.Length; i++)
                {
                    if (orgsList[i].oName == porgName && orgsList.Length > 1)
                    {
                        playerOrg = i;
                        /*
                        Event.eventCall(orgsList[playerOrg]);
                        switch (Event.eventID)
                        {
                            case 1001:
                                orgsList[playerOrg].oAttack += 1;
                                break;
                            case 1002:
                                orgsList[playerOrg].oDefence += 1;
                                break;
                        } */
                        break;
                    }
                    else if (orgsList[i].oName != porgName && i == orgsList.Length - 1)
                    {
                        Console.WriteLine("------------------- Game Over! -------------------");
                        endGame = true;
                    }
                }
            }
            soLog.WriteLine("{0}\t\t-\t{1}",orgsList[0].oName,System.DateTime.Now);
            soLog.Close();
            Console.Write("Press Y to restart or any other key to break shit!");
            ConsoleKeyInfo yRead = Console.ReadKey();
            if (yRead.Key == ConsoleKey.Y)
            {
                Console.Clear();
                goto start;
            }
        }
    }
}