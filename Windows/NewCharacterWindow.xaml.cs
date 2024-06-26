﻿using RPGCardsGenerator.Classes;
using RPGCardsGenerator.Variables;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Media;


namespace RPGCardsGenerator
{
    /// <summary>
    /// Interaction logic for NewCharacterWindow.xaml
    /// </summary>
    public partial class NewCharacterWindow : Window
    {
        private int IdOfExaple = 1005;

        private SolidColorBrush Red = Brushes.Red;
        private SolidColorBrush Green = Brushes.Green;
        private SolidColorBrush Yellow = Brushes.Yellow;
        private bool isOk = false;

        public NewCharacterWindow()
        {
            InitializeComponent();
            AddAllTablesInNewCharacterWindow(false);
        }



        private void Add_New_Character(object sender, RoutedEventArgs e)
        {
            AddCellBorders(MainInformationOfCharacter, Yellow, 1);
            AddCellBorders(SkilsOfCharacter, Yellow, 1);
            AddCellBorders(StatsOfCharacter, Yellow, 1);
            CheckAllFilds();
            if (isOk)
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
                    dbContext.Characters.Add(NewCharacter);
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
                        item.Type = TypeOfCariables.skill;
                        dbContext.Statistics.Add(item);
                    }

                    dbContext.SaveChanges();

                }
            }
        }

        void Random_Stats(object sender, RoutedEventArgs e)
        {

            AddAllTablesInNewCharacterWindow(true);
        }

        void Chec_Stats(object sender, RoutedEventArgs e)
        {
            CheckAllFilds(); //git status

        }


        private bool CheckAllFilds()
        {

            bool returnBool = true;


            GenerateNewCharacter charactorGenerator = new GenerateNewCharacter();

            List<string> StatsOfCharacterListOfString = charactorGenerator.GetLinesFromRichTextBox(StatsOfCharacter);
            foreach (string str in StatsOfCharacterListOfString) {
                if (!ChcekIsOnlyOne(str, StatsOfCharacterListOfString)) {
                    
                }
            }
            
            
            

            



            return returnBool;
        }
        public void AddCellBorders(System.Windows.Controls.RichTextBox richTextBox, SolidColorBrush borderBrush, double borderThickness)
        {
            // Ensure the RichTextBox has a FlowDocument
            if (richTextBox.Document == null)
                return;

            // Loop through all blocks in the FlowDocument
            foreach (Block block in richTextBox.Document.Blocks)
            {
                // Only process Table elements
                if (block is Table table)
                {
                    foreach (TableRowGroup rowGroup in table.RowGroups)
                    {
                        foreach (TableRow row in rowGroup.Rows)
                        {
                            foreach (TableCell cell in row.Cells)
                            {
                                // Set the border properties for the cell
                                cell.BorderBrush = borderBrush;
                                cell.BorderThickness = new Thickness(borderThickness);
                            }
                        }
                    }
                }
            }
        }
        bool ChcekIsOnlyOne(string x, List<string> list)
        {
            foreach (string s in list) {
                if (s == x) { return false; }

            }
            return true;
        }
        bool IsEmptyAfterInt(string x)
        {
            int lastInt = FindLastIntId(x);
            if(lastInt == )
            return true;
        }
        int FindLastIntId(string x) { 
           int returnInt = 0;
            int counter = 0;
            List<char> list = new List<char> {
            '0','1','2','3','4','5','6','7','8','9'

            };
            foreach(char c in x)
            {
                foreach (char s in list) { 
                if(s==c) { returnInt = counter;  }
                }
                counter++;
            }

            return returnInt;
        } 

        public void MakeCellColor(string badString, System.Windows.Controls.RichTextBox richTextBox, SolidColorBrush colorBrush)
        {
            // Ensure the RichTextBox has a FlowDocument
            if (richTextBox.Document == null)
                return;

            // Loop through all blocks in the FlowDocument
            foreach (Block block in richTextBox.Document.Blocks)
            {
                // Only process Table elements
                if (block is Table table)
                {
                    foreach (TableRowGroup rowGroup in table.RowGroups)
                    {
                        foreach (TableRow row in rowGroup.Rows)
                        {
                            foreach (TableCell cell in row.Cells)
                            {
                                // Get the text content of the cell
                                string cellText = new TextRange(cell.ContentStart, cell.ContentEnd).Text.Trim();

                                // Check if the cell text matches the badString exactly
                                if (cellText == badString)
                                {
                                    // Change the background color of the cell
                                    cell.Background = colorBrush;
                                }
                            }
                        }
                    }
                }
            }
        }

        #region SetRandomStats

        void AddAllTablesInNewCharacterWindow(bool randomStats )
        {
            AddSkils AddNewCharacterGenerator = new AddSkils();
            List<Statistic> BaseListOfSkils = AddNewCharacterGenerator.BaseSkils;
            List<Statistic> BaseListOfCharacter = AddNewCharacterGenerator.BaseCharacteristic;
            foreach (Statistic statistic in BaseListOfSkils)
            {
                statistic.Value = SetRandomStats(randomStats ,statistic);
            }
            foreach (Statistic statistic in BaseListOfCharacter)
            {
                statistic.Value = SetRandomStats(randomStats, statistic);
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

        
        private int SetRandomStats(bool random = true, Statistic stat = null)
        {
            int randomvalue = 0;
            if (!random) {
                return 1;
            }
            AddSkils AddNewCharacterGenerator = new AddSkils();

            if (stat != null) {
                foreach( Statistic BaseSkil in AddNewCharacterGenerator.BaseCharacteristic)
                {
                    if (BaseSkil.Name == stat.Name) 
                    {
                        randomvalue = BaseSkil.Value;
                        return randomvalue;
                    }
                }
                foreach (Statistic BaseSkil in AddNewCharacterGenerator.BaseSkils)
                {
                    if (BaseSkil.Name == stat.Name)
                    {
                        randomvalue = BaseSkil.Value;
                        return randomvalue;
                    }
                }
            }

            return randomvalue;
        }

        #endregion
    }
}
