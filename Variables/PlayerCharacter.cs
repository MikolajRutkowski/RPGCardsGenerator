using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCardsGenerator.Variables
{
    internal class PlayerCharacter : Character
    {
        public string NameOfPalyer { get; private set; }
        public PlayerCharacter (int id,string nameOfPalyer,string nameOfCharacter) : base(id,nameOfCharacter)
        {
            this.NameOfPalyer = nameOfPalyer;
        }
    }
}
