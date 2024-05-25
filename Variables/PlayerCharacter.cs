using System;

namespace RPGCardsGenerator.Variables
{
    public class PlayerCharacter : Character
    {
        public PlayerCharacter(string name) : base(name)
        {
            this.NameOfPlayer = "Imie gracza postaci: " +  name;
        }
        public PlayerCharacter()
        {

        }


        public string NameOfPlayer { get; set; } 
        public int Expiries { get; set; }

        public override List<string> ReturnMainInfo()
        {
            var returnList = new List<string>();
            returnList.Add(this.Id.ToString());
            returnList.Add(this.Name);
            returnList.Add(this.NameOfPlayer);
            returnList.Add("EX:" + this.Expiries.ToString());
            return returnList;
        }
    }
}