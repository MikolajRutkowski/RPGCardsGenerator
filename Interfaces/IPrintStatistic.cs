using RPGCardsGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace RPGCardsGenerator.Interfaces
{
    public interface IPrintStatistic
    {
        
        public List<String> ReturnListOfStatistic(int id, TypeOfCariables type);

        public string PrintOneSkils(Statistic stat);

        public Table ReturnTableForRichTextBox(List<String> listOfStrings, int x, int y);
  


    }
}
