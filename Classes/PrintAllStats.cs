using RPGCardsGenerator.Interfaces;
using RPGCardsGenerator.Variables;
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
            return PrintHead(id) + '\n' + PrintSkils(id); 
        }

        public string PrintHead(int id)
        {
            string returnValue = "";
            int enter = 0;
            using(var dbConext = new BoardsContext())
            {
                var list = dbConext.Statistics.ToList().Where(u => u.CharaterId == id);
                foreach (Statistic characteristicc in list)
                {

               
                    if(characteristicc.Type == TypeOfCariables.characteristic)
                    {
                        returnValue += PrintOneSkils(characteristicc);
                        enter++;
                        if(enter == 3)
                        {
                            enter = 0;
                            returnValue += '\n';
                        }
                    }
                }

            }
            return returnValue;
        }

        public string PrintSkils(int id)
        {
            string returnValue = "";
            int enter = 0;
            using (var dbConext = new BoardsContext())
            {
                var list = dbConext.Statistics.ToList().Where(u => u.CharaterId == id);
                foreach (Statistic characteristicc in list)
                {

                    if (characteristicc.Type == TypeOfCariables.skill)
                    {
                        returnValue += PrintOneSkils(characteristicc);
                        enter++;
                        if (enter == 3)
                        {
                            enter = 0;
                            returnValue += '\n';
                        }
                    }
                }

            }
            return returnValue;
        }

        public string PrintOneSkils(Statistic stat)
        {
            return stat.Name + " " + stat.Value + " ";
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
