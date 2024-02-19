using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace RPGCardsGenerator.Variables
{
    internal abstract class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ListOfStatisci Stats;

        public Character(int id, string name) {
            this.Name = name;
            this.Id = id;
            Stats = new ListOfStatisci(Id);
        }
        
    }
}
