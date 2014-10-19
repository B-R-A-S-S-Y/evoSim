using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoSim_C
{
    class Event
    {
        public struct randEvent
        {
           public string eTitle, eText, eC1text, eC2text;
        }
        private static randEvent[] eventsList = new randEvent [100];
        private static void eventAssign()
        {
            eventsList[0].eTitle = "-- Training Session! --";
            eventsList[0].eText = "Having trained hard before your next battle, your skill has increased!";
            eventsList[0].eC1text = "1: Increase Attack by 1";
            eventsList[0].eC2text = "2: Increase Defence by 1";

        }
        public static randEvent eventCall(Generation.Organism org)
        {
            eventAssign();
            Random rand = new Random();
            randEvent e = eventsList[0];
            Console.Write("{0}\n{1}\n{2}\n{3}\nSelection: ", e.eTitle, e.eText, e.eC1text, e.eC2text);
            retry:
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    org.oAttack += 1;
                    break;
                case 2:
                    org.oDefence += 1;
                    break;
                default:
                    goto retry;
            }
            return e;
        }
    }
}
