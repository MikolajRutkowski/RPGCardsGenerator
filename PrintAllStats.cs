using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCardsGenerator
{
    public class PrintAllStats
    {
        public int SepareteIdFromIdAndName(string suspect)
        {
            int x = 0;  
            int space = 0;
            for (int i = 0; i< suspect.Length; i++)
            {
                if (suspect[i] ==' ')
                {
                    space = i;
                    break;
                }
            }
            suspect.Remove(0,space);
            x = int.Parse(suspect);
            return x;
        }


        public string  Print(int Id)
        {
            return Id.ToString();
        }

        public PrintAllStats(string longstinrg)
        {
            int id = SepareteIdFromIdAndName(longstinrg);
            Print(id);
        }
        public PrintAllStats(int id)
        {
            Print(id);
        }
        

    }
}
