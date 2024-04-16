using RPGCardsGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace RPGCardsGenerator
{
    class PrintListOfCharacters
    {
        private void Print(bool playerCharacterOrNPC, ListBox exit, Window window)
        {
            using (var dbContext = new BoardsContext())
            {
                var listOfCards = new List<Character>();
                if (playerCharacterOrNPC)
                {
                    
                  var  listofNPC = dbContext.NPCs.ToList();
                    for(int i = 0; i < listofNPC.Count; i++)
                    {
                        listOfCards.Add(listofNPC[i]);
                    }
                }
                else
                {
                    var listofPlayersCharacter = dbContext.PlayerCharacters.ToList();
                    for (int i = 0; i < listofPlayersCharacter.Count; i++)
                    {
                        listOfCards.Add(listofPlayersCharacter[i]);
                    }
                }



            }
        }
        public PrintListOfCharacters(bool playerCharacterOrNPC, ListBox exit, Window  window)
        {
            
        }

    }
}
