using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace RPGCardsGenerator.Variables
{
    public enum TypeOfCariables
    {
        characteristic,
        skill
    }

    public class Statistic
    {
        public int Id { get; set; }
        public string Name { get;  set; }
        public string Description { get;  set; } = string.Empty;
        public int Value { get;  set; }
        public TypeOfCariables Type { get;  set; }
        public Statistic() {

            
        }
        public Statistic(int id, string name, string description, int value, TypeOfCariables type, Character character, int charaterId)
        {
            Id = id;
            Name = name;
            Description = description;
            Value = value;
            Type = type;
            Character = character;
            CharaterId = charaterId;
        }
        public Statistic(string NamePlusvalue)
        {
            Name = Separate(false, NamePlusvalue);
            Value = int.Parse(Separate(true, NamePlusvalue));
            int x = 0;
        }
        public string Separate(bool firstOrSecond, string input)
        {
            int spaceIndex = -1;
            
            for (int i = 0;  i < input.Length; i++)
            {
                if (input[i] == ' ')
                {
                    spaceIndex = i;
                    
                }
            }


            
            if (spaceIndex == -1)
            {
                
                return input;
            }

            string firstPart = input.Substring(0, spaceIndex);
            string secondPart = input.Substring(spaceIndex + 1);

            if (firstOrSecond)
            {
                return secondPart;
            }
            return firstPart;
        }

        public Statistic(string name, TypeOfCariables type, string description = "", params int[] values)
        {
            this.Name = name;
            this.Description = description;
            this.Type = type;
            this.Value = 0;
            for (int i = 0; i < values.Length; i++)
            {
                this.Value += values[i];
            }

        }

        public Character Character { get; set; }
        public int CharaterId { get; set; }

    }

    
}
