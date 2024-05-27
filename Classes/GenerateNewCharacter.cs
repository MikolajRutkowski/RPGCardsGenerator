using RPGCardsGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace RPGCardsGenerator.Classes
{
    public class GenerateNewCharacter
    {

        //1 = Imie 2 = Imie gracza 3 = liczba Ex
        public List<String> MainInfo;
        public List<Statistic> Characteristics;
        public List<Statistic> Skills;




        public GenerateNewCharacter(List<string> list) { }
        public GenerateNewCharacter(System.Windows.Controls.RichTextBox MainRichTextBox,
            System.Windows.Controls.RichTextBox CharacteristicsRichTextBox,
            System.Windows.Controls.RichTextBox SkillsRichTextBox) {
            MainInfo = GetLinesFromRichTextBox(MainRichTextBox);    
            Characteristics = FromStringToStatitic( GetLinesFromRichTextBox(CharacteristicsRichTextBox));
            Skills = FromStringToStatitic(GetLinesFromRichTextBox(SkillsRichTextBox));
        }

        public bool Check()
        {
            return true;
        }
        public List<Statistic> FromStringToStatitic(List<string> strings)
        {
            List<Statistic> stats = new List<Statistic>();
            foreach (string s in strings) { 
            
            }
            return stats;
        }


        public  List<string> GetLinesFromRichTextBox(System.Windows.Controls.RichTextBox richTextBox)
        {
            var lines = new List<string>();
            string text = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd).Text;
            string[] separators = ["\r\n", "\r", "\n", "\t"];
            string[] textLines = text.Split(separators, System.StringSplitOptions.RemoveEmptyEntries);
            lines.AddRange(textLines);

            return lines;
        }

        public bool AddToDataBase() { 
            
            return true; }

    }
}
