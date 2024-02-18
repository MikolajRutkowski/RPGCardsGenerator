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
        public Statistic Strength;
        public Statistic Dexterity;
        public Statistic Force;
        public Statistic Fitness;
        public Statistic Appearance;
        public Statistic strength;
        public Statistic Education;
        public Statistic Physique;
        public Statistic Intelligence;
        public Statistic Move;
        public ListOfStatisci(int idOfCharacter)
        {
            this.IdOfCharacter = idOfCharacter;
            Strength = new Statistic("Siła", TypeOfCariables.characteristic);
        Dexterity = new Statistic("Siła", TypeOfCariables.characteristic);
       Force = new Statistic("Siła", TypeOfCariables.characteristic);
         Fitness = new Statistic("Siła", TypeOfCariables.characteristic);
         Appearance = new Statistic("Siła", TypeOfCariables.characteristic);
         strength = new Statistic("Siła", TypeOfCariables.characteristic);
         Education = new Statistic("Siła", TypeOfCariables.characteristic);
         Physique = new Statistic("Siła", TypeOfCariables.characteristic);
         Intelligence = new Statistic("Siła", TypeOfCariables.characteristic);
        Move = new Statistic("Siła", TypeOfCariables.characteristic);
    }

    }
}
