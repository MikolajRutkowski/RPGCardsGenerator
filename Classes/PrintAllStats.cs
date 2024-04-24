using RPGCardsGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCardsGenerator.Classes
{
    public class PrintAllStats : IPrintStatistic
    {
        public string   valuee { get; private set; }
        public int SepareteIdFromIdAndName(string suspect)
        {
            int x = 0;
            int space = 0;
            for (int i = 0; i < suspect.Length; i++)
            {
                if (suspect[i] == ' ')
                {
                    space = i;
                    break;
                }
            }
            suspect = suspect.Remove(space);
            x = int.Parse(suspect); // tu nie dzidała 
            return x;
        }


        public string PrintStatistic(int id)
        {
            throw new NotImplementedException();
        }

        public string PrintHead(int id)
        {
            throw new NotImplementedException();
        }

        public string PrintSkils(int id)
        {
            throw new NotImplementedException();
        }

        public PrintAllStats(string longstinrg)
        {
            int id = SepareteIdFromIdAndName(longstinrg);
           valuee = PrintStatistic(id);
        }
        public PrintAllStats(int id)
        {
           valuee = PrintStatistic(id);
        }


    }
}
