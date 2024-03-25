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
        
        
        public Character Character { get; set; }
        public int CharaterId { get; set; }

    }

    
}
