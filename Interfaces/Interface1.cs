using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RPGCardsGenerator.Interfaces
{
    public interface IPrintStatistic
    {
        public string PrintStatistic(int id);
        public string PrintHead(int id);
        public string PrintSkils(int id);



    }
}
