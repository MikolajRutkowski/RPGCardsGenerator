using RPGCardsGenerator.Classes;
using RPGCardsGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RPGCardsGenerator
{
    /// <summary>
    /// Interaction logic for NewCharacterWindow.xaml
    /// </summary>
    public partial class NewCharacterWindow : Window
    {
        private int IdOfExaple = 1005;


        public NewCharacterWindow()
        {
            InitializeComponent();
            List<Statistic> BaseListOfSkils = AddSkils.BaseSkils;
            List<Statistic> BaseListOfCharacter = AddSkils.BaseCharacteristic;
            foreach (Statistic statistic in BaseListOfSkils)
            {
                statistic.Value = 0;
            }
            foreach (Statistic statistic in BaseListOfCharacter)
            {
                statistic.Value = 1;
            }
            StatsOfCharacter.BeginChange();
            StatsOfCharacter.Document.Blocks.Clear();
            StatsOfCharacter.Document.Blocks.Add(new PrintAllStats(BaseListOfCharacter).SkilTable);
            StatsOfCharacter.EndChange();
            SkilsOfCharacter.BeginChange();
            SkilsOfCharacter.Document.Blocks.Clear();
            SkilsOfCharacter.Document.Blocks.Add(new PrintAllStats(BaseListOfSkils).SkilTable);
            SkilsOfCharacter.EndChange();
            MainInformationOfCharacter.BeginChange();
            MainInformationOfCharacter.Document.Blocks.Clear();
            MainInformationOfCharacter.Document.Blocks.Add(new PrintAllStats(IdOfExaple).MainTable);
            MainInformationOfCharacter.EndChange();
        }



        private void Add_New_Character(object sender, RoutedEventArgs e)
        {
            GenerateNewCharacter charactorGenerator = new GenerateNewCharacter(MainInformationOfCharacter, StatsOfCharacter, SkilsOfCharacter);

            

            using (var dbContext = new BoardsContext())
            {


                PlayerCharacter NewCharacter = new PlayerCharacter()
                {
                    Name = charactorGenerator.MainInfo[1],
                    NameOfPlayer = charactorGenerator.MainInfo[2],
                  //  Expiries = int.Parse(charactorGenerator.MainInfo[3])

                };  
             //   dbContext.Characters.Add(NewCharacter);
                dbContext.SaveChanges();
                var x = dbContext.PlayerCharacters.ToList();
                int idOfNewCharacter = x.Last().Id;
                foreach (Statistic item in charactorGenerator.Characteristics) // lista jest równa 0 
                {
                    item.CharaterId = idOfNewCharacter;
                    dbContext.Statistics.Add(item);
                }
                foreach (Statistic item in charactorGenerator.Skills)
                {
                    item.CharaterId = idOfNewCharacter;
                    dbContext.Statistics.Add(item);
                }

                dbContext.SaveChanges();

            }
            


            
        }
        void Random_Stats(object sender, RoutedEventArgs e)
        {

        }

        void Chec_Stats(object sender, RoutedEventArgs e)
        {

        }
    } 
}
