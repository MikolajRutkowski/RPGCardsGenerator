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
using System.Windows.Media.TextFormatting;
using Microsoft.EntityFrameworkCore;
using RPGCardsGenerator.Classes;
using Microsoft.EntityFrameworkCore.Metadata.Internal;



namespace RPGCardsGenerator
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int Cotokurwajest;
        static bool PlayerCharacterOrNPC = false;
        public delegate void Reload();
        public event EventHandler PlayerCharacterChanged;

        public MainWindow()
        {
            Cotokurwajest = 1;


            InitializeComponent();
            PrintAll();

        }
        public void PrintAll()
        {
            PrintListOfCharacters printt = new PrintListOfCharacters(PlayerCharacterOrNPC, MainListBox);
        }



        #region Buttons
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string returnString = "";
            using (var dbContext = new BoardsContext())
            {


                dbContext.PlayerCharacters.Add(new PlayerCharacter("Testowy Gracz nr:" + Cotokurwajest.ToString()));
                dbContext.SaveChanges();
                var ListOfPlayers = dbContext.PlayerCharacters.ToList();

                foreach (PlayerCharacter player in ListOfPlayers)
                {
                    returnString += "Postać: " + player.Name + " Jego statsy:" + '\n';
                    var listofStatsOfMyPlayer = player.Stats.ToList();
                    foreach (Statistic statistic in listofStatsOfMyPlayer)
                    {
                        returnString += "Statystyka nr" + statistic.Id + " jej wartośc: " + statistic.Value + '\n';
                    }
                    returnString += '\n';
                }

                // JEDEN.Text =  returnString;
                Cotokurwajest++;
            }




        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            string returnString = "";
            using (var dbContext = new BoardsContext())
            {

                dbContext.SaveChanges();
                var postac = dbContext.PlayerCharacters.ToList();
                for (int i = 0; i < postac.Count; i++)
                {
                    returnString = postac[i].Name;
                }



            }

            //JEDEN.Text += returnString;


        }






        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            //dodac nowa statystyke testowa
            using (var dbContext = new BoardsContext())
            {
                var listCharacter = dbContext.PlayerCharacters.ToList();
                dbContext.Statistics.Add(new Statistic()
                {
                    CharaterId = listCharacter[0].Id,
                    Value = new Random().Next(50),
                    Name = "Archelogia",
                    Type = TypeOfCariables.skill

                });
                dbContext.SaveChanges();
            }



        }

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


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            using (var dbContext = new BoardsContext())
            {
                //2 lepszy
                var user = dbContext.Characters.Include(u => u.Stats).FirstOrDefault(c => c.Id == 1005);
                if (user == null)
                {

                }
                // sposób 1 gorszy bo 2 zapytania SQL
                // var ListOfcharacterStats = dbContext.Statistics.Where(Cotokurwajest => Cotokurwajest.CharaterId == user.Id).ToList();
                //2 lepszy
                var ListOfcharacterStats = user.Stats;

                System.Windows.MessageBox.Show(ListOfcharacterStats[5].Name);

            }

        }


        #endregion

        private void MainListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(MainListBox.SelectedItem != null)
            {
                string x = MainListBox.SelectedItem.ToString(); //MainListBox.SelectedIndex.ToString();
                                                              //StatsOfCharacter.AppendText(Cotokurwajest);
                StatsOfCharacter.BeginChange();
                StatsOfCharacter.Document.Blocks.Clear();
                StatsOfCharacter.Document.Blocks.Add(new PrintAllStats(x).MainTable);
                StatsOfCharacter.Document.Blocks.Add(new PrintAllStats(x).CharacterTable);
                StatsOfCharacter.Document.Blocks.Add(new PrintAllStats(x).SkilTable);
                StatsOfCharacter.EndChange();
            }
        }
        private void InsertTable(object sender, RoutedEventArgs e)
        {
            StatsOfCharacter.BeginChange();
            var table = new System.Windows.Documents.Table();
            var gridLenghtConvertor = new GridLengthConverter();
            table.Columns.Add(new TableColumn());
            table.Columns.Add(new TableColumn());
            table.Columns.Add(new TableColumn());

            table.RowGroups.Add(new TableRowGroup());
            for (int i = 0; i < 3; i++)
            {
                table.RowGroups[0].Rows.Add(new TableRow());
                table.RowGroups[0].Rows[i].Cells.Add(new TableCell());
                table.RowGroups[0].Rows[i].Cells.Add(new TableCell());
                table.RowGroups[0].Rows[i].Cells.Add(new TableCell());
            }
            StatsOfCharacter.Document.Blocks.Add(table);
            StatsOfCharacter.EndChange();
        }
    }
}