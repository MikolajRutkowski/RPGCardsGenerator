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
        public List<Statistics> Characteristics = new List<Statistics>();
        public Character() {
            Characteristics.Add(new Statistics("Siła", TypeOfCariables.characteristic));
        }
        
    }
}
