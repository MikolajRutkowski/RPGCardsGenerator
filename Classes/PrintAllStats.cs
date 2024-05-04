using RPGCardsGenerator.Interfaces;
using RPGCardsGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace RPGCardsGenerator.Classes
{
    public class PrintAllStats : IPrintStatistic
    {
        public string valuee { get; private set; }
        public Table MainTable { get; private set; }
        public Table SkilTable { get; private set; }
        public Table CharacterTable { get; private set; }
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

        public string PrintOneSkils(Statistic stat)
        {
            string returnValue = stat.Name + " " + stat.Value;
            return returnValue;
        }

        public List<Statistic> ReturnListOfStatistic(int id, TypeOfCariables type)
        {
            var returnList = new List<Statistic>();
            using (var dbConext = new BoardsContext())
            {
                var list = dbConext.Statistics.ToList().Where(u => u.CharaterId == id);
                foreach (Statistic characteristicc in list)
                {

                    if (characteristicc.Type == type)
                    {
                        returnList.Add(characteristicc);

                    }
                }
            }
            return returnList;
        }

        public PrintAllStats(string longstinrg)
        {
            int id = SepareteIdFromIdAndName(longstinrg);
            List<Statistic> list1 = ReturnListOfStatistic(id, TypeOfCariables.characteristic);
            CharacterTable = ReturnTableForRichTextBox(list1);
        }
        public PrintAllStats(int id)
        {
            List<Statistic> list1 = ReturnListOfStatistic(id, TypeOfCariables.characteristic);
            CharacterTable = ReturnTableForRichTextBox(list1);
        }

        public Table ReturnTableForRichTextBox(List<Statistic> listOfStatistic, int x = 3, int y = 3)
        {
            var returnTable = new System.Windows.Documents.Table();
            if (y == 0)
            {
                y = SetY(listOfStatistic.Capacity);
            }




            return returnTable;
        }
        private int SetY(int listOfElement) {
            
            return 3;
        }
    }
}
