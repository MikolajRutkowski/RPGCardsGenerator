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
            return PrintSkils(id, TypeOfCariables.characteristic) + '\n' + PrintSkils(id, TypeOfCariables.skill); 
        }

        public string PrintHead(int id)
        {
            string returnValue = "";
            return returnValue;
        }

        public string PrintSkils(int id, TypeOfCariables type)
        {
            string returnValue = "";
            int enter = 0;
            using (var dbConext = new BoardsContext())
            {
                var list = dbConext.Statistics.ToList().Where(u => u.CharaterId == id);
                int maxLenght = 0;
                foreach (Statistic item in list)
                {
                    if(item.Type == type && maxLenght < item.Name.Length)
                    {
                        maxLenght = item.Name.Length;
                    }
                }
                foreach (Statistic characteristicc in list)
                {

                    if (characteristicc.Type == type)
                    {
                        returnValue += PrintOneSkils(characteristicc,maxLenght);
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

        public string PrintOneSkils(Statistic stat, int whiteSpace = 0)
        {
            string returnValue = stat.Name + " " + stat.Value;
            for (int i = 0;i <= 0; i++)
            {
                returnValue += " ";
            }
            return returnValue;
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
