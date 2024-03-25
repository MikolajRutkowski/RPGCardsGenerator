using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using RPGCardsGenerator.Variables;
using System.Windows.Forms;
using System.ComponentModel.Design.Serialization;
using System.Collections.Generic;
using System;


namespace RPGCardsGenerator
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int x;
        static bool PlayerCharacterOrNPC = false;
        public delegate void Reload();
        public event EventHandler PlayerCharacterChanged;

        public MainWindow()
        {
            x = 1;

            
            InitializeComponent();
            //PrintAll(true);
        }
        public void PrintAll(bool WithStats = false)
        {
            NpcOrCharacterTextBlockMain.Text = "";
            using (var dbContext = new BoardsContext())
            {
                var list2 = dbContext.Statistics.ToList();

                if (PlayerCharacterOrNPC)
                {
                   var list = dbContext.NPCs.ToList();
                    if (list.Count > 0)
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            NpcOrCharacterTextBlockMain.Text += (list[i].Id + " Imie: " + list[i].Name + '\n');
                            
                            if (WithStats)
                            {
                                for(int j =  0; j < list2.Count; j++)
                                {
                                    if (list[i].Id == list2[j].CharaterId)
                                    {
                                        NpcOrCharacterTextBlockMain.Text += (list2[j].Id + " Nazwa: " + list2[j].Name + " " + list2[j].Value);
                                    }
                                }
                                NpcOrCharacterTextBlockMain.Text += '\n';
                            }

                        }
                    }
                    else
                    {
                        NpcOrCharacterTextBlockMain.Text = "Brak postaci NPC";
                    }
                }
                else
                {
                  var list = dbContext.PlayerCharacters.ToList();
                    if (list.Count > 0)
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            NpcOrCharacterTextBlockMain.Text += ( list[i].Id.ToString() + " Imie: " + list[i].Name.ToString() + '\n');
                            if (WithStats)
                            {
                                for (int j = 0; j < list2.Count; j++)
                                {
                                    if (list[i].Id == list2[j].CharaterId)
                                    {
                                        NpcOrCharacterTextBlockMain.Text += (list2[j].Id + " Nazwa: " + list2[j].Name + " " + list2[j].Value);
                                    }
                                }
                                NpcOrCharacterTextBlockMain.Text += '\n';
                            }
                        }
                    }
                    else
                    {
                        NpcOrCharacterTextBlockMain.Text = "Brak postaci Graczy";
                    }
                }
                
                    

                
            }
        }

        #region Buttons
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string returnString = "";
            using (var dbContext = new BoardsContext() )
            {


                dbContext.PlayerCharacters.Add(new PlayerCharacter("Testowy Gracz nr:" + x.ToString()) );
                dbContext.SaveChanges();
                var ListOfPlayers = dbContext.PlayerCharacters.ToList();

                foreach ( PlayerCharacter player in ListOfPlayers)
                {
                    returnString += "Postać: " + player.Name + " Jego statsy:"  + '\n';
                    var listofStatsOfMyPlayer = player.Stats.ToList();
                    foreach(Statistic statistic in listofStatsOfMyPlayer) {
                        returnString += "Statystyka nr" + statistic.Id + " jej wartośc: " + statistic.Value + '\n'; 
                    }
                    returnString += '\n';
                }

               // JEDEN.Text =  returnString;
                x++;
            }




        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            string returnString = "";
            using (var dbContext = new BoardsContext())
            {
                
                dbContext.SaveChanges();
                var postac  = dbContext.PlayerCharacters.ToList();
                for ( int i = 0; i < postac.Count; i++)
                {
                    returnString = postac[i].Name;
                }
                
                
               
            }

            //JEDEN.Text += returnString;


        }

       



        /*
        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            //dodac nowa statystyke testowa
            using(var dbContext = new BoardsContext())
            {
                var listCharacter = dbContext.PlayerCharacters.ToList();
                dbContext.Statistics.Add(new Statistic()
                {
                    CharaterId = listCharacter[0].Id,
                    Value = new Random().Next(50),
                    Name = "Siła",
                    Type = TypeOfCariables.characteristic

                }) ;
                dbContext.SaveChanges();
            }



        }
        */
        private void NPCToCharacterAndBack(object sender, RoutedEventArgs e)
        {
            PlayerCharacterOrNPC = !PlayerCharacterOrNPC;
            if (PlayerCharacterOrNPC)
            {
                NpcOrCharacterTextBlockTop.Text = "NPC";
            }
            else
            {
                NpcOrCharacterTextBlockTop.Text = "PlayeCharacter";
            }
            PrintAll();

        }

        /*
            private void Button_Click_1(object sender, RoutedEventArgs e)
{
   using(var dbContext = new BoardsContext())
   {
       dbContext.Statistics.Add(new Statistic()
       {
           CharaterId = 1002,
           Value = new Random().Next(50),
           Name = "Statytstyka testowa nr:"  + x.ToString()

       });
       dbContext.SaveChanges();
   }



}

*/
        #endregion
    }
}