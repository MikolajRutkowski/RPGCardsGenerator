using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media.Animation;

namespace RPGCardsGenerator.Variables
{
    public abstract class Character
    {
      
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Statistic> Stats { get; set; } = new List<Statistic>();

        public abstract List<string> ReturnMainInfo();
        
        public Character(string name)
        {
            this.Name = name;


        }

    }
}
