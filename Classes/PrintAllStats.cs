using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        public System.Windows.Documents.Table MainTable { get; private set; }
        public System.Windows.Documents.Table SkilTable { get; private set; }
        public System.Windows.Documents.Table CharacterTable { get; private set; }
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
            //czy to działa?
            string returnLi = returnList[0].Name;
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
        
        public System.Windows.Documents.Table ReturnTableForRichTextBox(List<Statistic> listOfStatistic, int x = 3, int y = 3)
        {

            if (y == 0)
            {
                y = SetY(listOfStatistic.Capacity);
            }
            // Deklaracja tabeli o 3 wierszach i 3 kolumnach
            var table = new System.Windows.Documents.Table();
            for (int i = 0; i < y; i++)
            {
                table.Columns.Add(new TableColumn());
            }
            
            // Utworzenie grupy wierszy
            table.RowGroups.Add(new TableRowGroup());

            int index = 0;
            string value = "";
            // Dodanie wierszy z danymi do tabeli
            for (int yy = 0; yy < y; yy++)
            {
                TableRow row = new TableRow();

                for (int xx = 0; xx < x; xx++)
                {
                    if(index > listOfStatistic.Count)
                    {
                        break;
                    }
                    // Tworzenie komórki i dodawanie do niej danych
                    value = "sdsdaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";//PrintOneSkils(listOfStatistic[0]);
                    TableCell cell = new TableCell(new Paragraph(new Run(value)));   
                    row.Cells.Add(cell);
                    index++;
                }
                table.RowGroups[0].Rows.Add(row);
            }


            return table;
        }
        private int SetY(int listOfElement) {
            
            return 3;
        }
    }
}
