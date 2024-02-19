using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCardsGenerator.Variables
{
    public enum TypeOfCariables
    {
        characteristic,
        skill
    }

    public class Statistic
    {
        public string Name { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public int Value { get; private set; }
        TypeOfCariables Type { get;  set; }
        public Statistic(string name, TypeOfCariables type, int value = 1) {

            this.Name = name;
            this.Value = value;
            this.Type = type;
        }
        
        public void SetValue(int newValue)
        {
            this.Value = newValue;
        }
    }

    public class ListOfStatisci
    {
        public int IdOfCharacter { get; set; }
        public Statistic Strength; //1
        public Statistic Dexterity; //2
        public Statistic Force; //3
        public Statistic Fitness; //4
        public Statistic Appearance; //5
        public Statistic Education;//7
        public Statistic Physique;//8
        public Statistic Intelligence;
        public Statistic Move;
        public ListOfStatisci(int idOfCharacter)
        {
            this.IdOfCharacter = idOfCharacter;
            Strength = new Statistic("Siła", TypeOfCariables.characteristic);
            Dexterity = new Statistic("Zręczność", TypeOfCariables.characteristic);
            Force = new Statistic("Moc", TypeOfCariables.characteristic);
            Fitness = new Statistic("Kondycja", TypeOfCariables.characteristic);
            Appearance = new Statistic("Wygląd", TypeOfCariables.characteristic);
            Education = new Statistic("Wykształcenie", TypeOfCariables.characteristic);
            Physique = new Statistic("Budowa ciała", TypeOfCariables.characteristic);
            Intelligence = new Statistic("Inteligencja", TypeOfCariables.characteristic);
            Move = new Statistic("Ruch", TypeOfCariables.characteristic);
    }

    }
}
