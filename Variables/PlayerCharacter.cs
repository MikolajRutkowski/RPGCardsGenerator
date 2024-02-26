using System;

namespace RPGCardsGenerator.Variables
{
    public class PlayerCharacter : Character
    {
        public PlayerCharacter(string name) : base(name)
        {
        }

        public string NameOfPlayer { get;  set; }

        

        
    }
}