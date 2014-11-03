using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoSim_C
{
    class Event
    {
        public static int eventID = 0;
        private struct randEvent
        {
           public string eTitle, eText, eC1text, eC2text;
        }
        private static randEvent[] eventsList = new randEvent [1];
        private static void eventAssign()
        {
            eventsList[0].eTitle = "-- Training Session! --";
            eventsList[0].eText = "Having trained hard before your next battle, your skill has increased!";
            eventsList[0].eC1text = "1: Increase Attack by 1";
            eventsList[0].eC2text = "2: Increase Defence by 1";
        }
        public static void eventCall(Generation.Organism org)
        {
            eventAssign();
            Random rand = new Random();
            randEvent e = eventsList[rand.Next(0, eventsList.Length-1)];
            Console.Write("{0}\n{1}\n{2}\n{3}\nSelection: ", e.eTitle, e.eText, e.eC1text, e.eC2text);
            retry:
            bool eventFired = false;
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    eventID = 1001;
                    break;
                case 2:
                    eventID = 1002;
                    break;
                default:
                    goto retry;
            }
        }
    }
}
