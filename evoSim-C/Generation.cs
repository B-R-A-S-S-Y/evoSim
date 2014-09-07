using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace evoSim_C
{
    class Generation
    {
        public struct Organism
        {
            public int oAttack; public int oDefence; public int oHealth;
            public string oName;
        }

        public static Organism[] GenPhase(int orgMax)
        {
            Organism[] orgsList = new Organism[orgMax];
            Random randNum = new Random();
            for (int n = 0; n < orgMax; n++)
            {
                orgsList[n].oAttack = randNum.Next(0, 6);
                orgsList[n].oDefence = randNum.Next(0, 6);
                orgsList[n].oHealth = randNum.Next(0, 6);
                orgsList[n].oName = NameGen(orgsList[n].oAttack, orgsList[n].oDefence, orgsList[n].oHealth);
                Thread.Sleep(1000/orgsList.Length);
            }
            return orgsList;
        }
        private static string NameGen(int a, int d, int h)
        {
            Random randNam = new Random();
            string name = "";
            string[,] cons = new string[2, 20];
            cons[0, 0] = "B"; cons[1, 0] = "Qu";
            cons[0, 1] = "C"; cons[1, 1] = "Ch";
            cons[0, 2] = "D"; cons[1, 2] = "Th";
            cons[0, 3] = "F"; cons[1, 3] = "Ph";
            cons[0, 4] = "G"; cons[1, 4] = "Sh";
            cons[0, 5] = "H"; cons[1, 5] = "Ng";
            cons[0, 6] = "J"; cons[1, 6] = "Br";
            cons[0, 7] = "K"; cons[1, 7] = "Dr";
            cons[0, 8] = "L"; cons[1, 8] = "Cr";
            cons[0, 9] = "M"; cons[1, 9] = "Fr";
            cons[0, 10] = "N"; cons[1, 10] = "Gr";
            cons[0, 11] = "P"; cons[1, 11] = "Kr";
            cons[0, 12] = "R"; cons[1, 12] = "Pr";
            cons[0, 13] = "S"; cons[1, 13] = "Tr";
            cons[0, 14] = "T"; cons[1, 14] = "St";
            cons[0, 15] = "V"; cons[1, 15] = "Sl";
            cons[0, 16] = "W"; cons[1, 16] = "Ts";
            cons[0, 17] = "X"; cons[1, 17] = "Zh";
            cons[0, 18] = "Y"; cons[1, 18] = "Ly";
            cons[0, 19] = "Z"; cons[1, 19] = "Kh";
            string[] vowl = new string[5];
            vowl[0] = "a";
            vowl[1] = "e";
            vowl[2] = "i";
            vowl[3] = "o";
            vowl[4] = "u";
            for (int i = 0; i < 5; i+=2)
            {
                if (i == 0)
                {
                    if (a == 5)
                    {
                        name += cons[1, randNam.Next(0, (cons.Length / 2))];
                    }
                    else
                    {
                        name += cons[0, randNam.Next(1, (cons.Length / 2))];
                    }
                    name += vowl[randNam.Next(0, vowl.Length)];
                }
                else if (i == 2)
                {
                    if (d == 5)
                    {
                        name += cons[1, randNam.Next(0, (cons.Length / 2))].ToLower();
                    }
                    else
                    {
                        name += cons[0, randNam.Next(1, (cons.Length / 2))].ToLower();
                    }
                    name += vowl[randNam.Next(0, vowl.Length)];
                }
                else if (i == 4)
                {
                    if (h == 5)
                    {
                        name += cons[1, randNam.Next(0, (cons.Length / 2))].ToLower();
                    }
                    else
                    {
                        name += cons[0, randNam.Next(0, (cons.Length / 2))].ToLower();
                    }
                    name += vowl[randNam.Next(0, vowl.Length)];
                }
            }
            return name;
        }

    }
}
