using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

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
