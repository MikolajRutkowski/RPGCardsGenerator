using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCardsGenerator.Variables
{
    public class NPC : Character
    {
        public string reputacja { get; set; } = "";
        public NPC(string name) : base(name)
        {
        }
    }
}
