﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace RPGCardsGenerator.Variables
{
    public class NPC : Character
    {
        public string reputacja { get; set; } 
        public NPC(string name) : base(name)
        {
           
        }
        public NPC()
        {

        }
        public override List<string> ReturnMainInfo()
        {
            var returnList = new List<string>();
            returnList.Add(this.Id.ToString());
            returnList.Add(this.Name);
            returnList.Add(this.reputacja);
            return returnList;
        }
    }
}
