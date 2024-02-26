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




       
        public MainWindow()
        {
           

            
            InitializeComponent();
            
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string returnString = "";
            using (var dbContext = new BoardsContext() )
            {
                int x = 1;
                
                dbContext.NPCs.Add(new NPC("Testowy Ziomek nr " + x.ToString()));
                dbContext.SaveChanges();

                var Npcs = dbContext.NPCs.ToList();

                foreach ( var npc in Npcs )
                {
                    returnString = returnString + "Imie:" + npc.Name + "Id: " + npc.Id +"\n";
                }
                TextBlockTest.Text = returnString;
                x++;
            }




        }
    }
}