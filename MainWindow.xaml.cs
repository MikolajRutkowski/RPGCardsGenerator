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


namespace RPGCardsGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int x;

        public MainWindow()
        {
            x = 1; 

            
            InitializeComponent();
            
        }
        

        
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

                JEDEN.Text =  returnString;
                x++;
            }




        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            string returnString = "";
            using (var dbContext = new BoardsContext())
            {
                dbContext.Add(new PlayerCharacter("Ziomek"));
                dbContext.SaveChanges();
                var postac  = dbContext.NPCs.ToList();
                for ( int i = 0; i < postac.Count; i++)
                {
                    returnString = postac[i].Name;
                }
                
                
               
            }

            JEDEN.Text += returnString;


        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            //dodac nowa statystyke
            using(var dbContext = new BoardsContext())
            {
                var listCharacter = dbContext.PlayerCharacters.ToList();
                dbContext.Statistics.Add(new Statistic()
                {
                    CharaterId = listCharacter[0].Id,
                    Value = new Random().Next(50),
                    Name = "Statytstyka testowa nr:" + x.ToString()

                }) ;
                dbContext.SaveChanges();
            }



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

    }
}