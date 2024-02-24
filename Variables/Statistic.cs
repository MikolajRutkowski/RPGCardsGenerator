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
        public Character Character { get; set; }
        public int CharaterId { get; set; }

    }

    
}
