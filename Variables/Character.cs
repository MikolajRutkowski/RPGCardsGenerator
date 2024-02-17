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
            Characteristics.Add(new Statistics("Zręczność", TypeOfCariables.characteristic));
            Characteristics.Add(new Statistics("Moc", TypeOfCariables.characteristic));
            Characteristics.Add(new Statistics("Kondyccja", TypeOfCariables.characteristic));
            Characteristics.Add(new Statistics("Wygląd", TypeOfCariables.characteristic));
            Characteristics.Add(new Statistics("Wykształcenie", TypeOfCariables.characteristic));
            Characteristics.Add(new Statistics("Budowa Ciała", TypeOfCariables.characteristic));
            Characteristics.Add(new Statistics("Inteligencja", TypeOfCariables.characteristic));
            Characteristics.Add(new Statistics("Ruch", TypeOfCariables.characteristic));
        }
        
    }
}
