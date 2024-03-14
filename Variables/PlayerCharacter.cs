using System;

namespace RPGCardsGenerator.Variables
{
    public class PlayerCharacter : Character
    {
        public PlayerCharacter(string name) : base(name)
        {
            this.NameOfPlayer = "Imie gracza postaci: " +  name;
        }

        public string NameOfPlayer { get;  set; }

        

        
    }
}