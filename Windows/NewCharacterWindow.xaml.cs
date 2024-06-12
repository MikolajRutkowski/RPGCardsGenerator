using RPGCardsGenerator.Classes;
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


        public NewCharacterWindow()
        {
            InitializeComponent();
            AddAllTablesInNewCharacterWindow(false);
        }



        private void Add_New_Character(object sender, RoutedEventArgs e)
        {
            if (CheckAllFilds())
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
            CheckAllFilds();
        }
        private bool CheckAllFilds()
        {
            bool returnBool = true;
            GenerateNewCharacter charactorGenerator = new GenerateNewCharacter(MainInformationOfCharacter, StatsOfCharacter, SkilsOfCharacter);

            
            List<String> listOfStats =  charactorGenerator.GetLinesFromRichTextBox(StatsOfCharacter);
            List<String> listOfSkils = charactorGenerator.GetLinesFromRichTextBox(SkilsOfCharacter);
            AddSkils addSkils = new AddSkils();
            List<string> coretStats = addSkils.BaseCharacteristicName;
            List<string> coretSkills = addSkils.BaseSkilsName;
            CheckIscorretStats(listOfStats, SkilsOfCharacter);
            foreach (String line in listOfStats) {
                
               if (IsInList(line, coretStats))
                {

                   // MakeCellCollor(line, SkilsOfCharacter, Brushes.Yellow);
                }


            }



            return returnBool;
        }
        void CheckIscorretStats( List<String> list, System.Windows.Controls.RichTextBox richTextBox)
        {
            foreach (String line in list)
            {
                if (!IsOnlyOneSpace(line)) {
                    MakeCellCollor(line, richTextBox, Brushes.Red);
                
                }
            }
        }
        bool IsOnlyOneSpace(string x)
        {
            int spaceIndex = 0;
            foreach(char character in x)
            {
                if(character == ' ') spaceIndex++;
            }
            if (spaceIndex == 1)
            {
                return true;
            }
            return false;
        }

        bool IsInList(string x, List<string> list)
        {
            foreach (String line in list)
            {
                if(line == x) return true;
            }
            return false;
        }

        void MakeCellCollor(string badString, System.Windows.Controls.RichTextBox richTextBox, SolidColorBrush colorBrush )
        {
            if (string.IsNullOrEmpty(badString) || richTextBox == null)
            {
                return;
            }

            // Pobierz cały tekst z RichTextBox
            TextRange textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);

            // Ustawienia domyślne dla wyszukiwania
            TextPointer currentPointer = textRange.Start;
            while (currentPointer != null && currentPointer.CompareTo(textRange.End) < 0)
            {
                // Znajdź pierwszy ciąg znaków odpowiadający badString
                TextRange foundRange = FindTextInRange(currentPointer, textRange.End, badString);
                if (foundRange == null)
                {
                    break; // Jeżeli nie znaleziono, przerwij pętlę
                }

                // Ustaw kolor tła na czerwony dla znalezionego zakresu
                foundRange.ApplyPropertyValue(TextElement.BackgroundProperty, colorBrush);

                // Przejdź do końca znalezionego zakresu, aby kontynuować wyszukiwanie
                currentPointer = foundRange.End;
            }
        }
        private TextRange FindTextInRange(TextPointer start, TextPointer end, string text)
        {
            while (start != null && start.CompareTo(end) < 0)
            {
                if (start.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.Text)
                {
                    string textRun = start.GetTextInRun(LogicalDirection.Forward);

                    // Znajdź indeks badString w textRun
                    int indexInRun = textRun.IndexOf(text);
                    if (indexInRun != -1)
                    {
                        TextPointer startPos = start.GetPositionAtOffset(indexInRun);
                        TextPointer endPos = startPos.GetPositionAtOffset(text.Length);
                        return new TextRange(startPos, endPos);
                    }
                }
                start = start.GetNextContextPosition(LogicalDirection.Forward);
            }
            return null;
        }

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
    } 
}
