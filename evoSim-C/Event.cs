using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace evoSim_C
{
    class Event
    {
        public static int eventID = 0;
        private struct sEvent
        {
            public string Title, Text, C1text, C2text;
            public int C1ID, C2ID;
        }
        private static sEvent eventAssign()
        {
            Random rand = new Random();
            Char[] f = { '-', ':' };
            StreamReader eStream = new StreamReader("gameData/events/events.txt");
            string[] a = eStream.ReadToEnd().Split(f[1]);
            string[] b = a[rand.Next(0, a.Length - 2)].Split(f, StringSplitOptions.RemoveEmptyEntries);
            sEvent c;
            c.Title = b[1];
            c.Text = b[2];
            c.C1text = b[3];
            c.C2text = b[4];
            c.C1ID = int.Parse(b[5]);
            c.C2ID = int.Parse(b[6]);
            return c;
        }
        public static void eventCall(Generation.Organism org)
        {
            sEvent e = eventAssign();
            Console.Write("{0}\n{1}\n{2}\n{3}\nSelection: ", e.Title, e.Text, e.C1text, e.C2text);
            retry:
            bool eventFired = false;
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    eventID = e.C1ID;
                    break;
                case 2:
                    eventID = e.C2ID;
                    break;
                default:
                    goto retry;
            }
        }
    }
}
