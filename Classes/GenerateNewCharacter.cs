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
        
        public GenerateNewCharacter(List<string> list) { }
        public GenerateNewCharacter(System.Windows.Controls.RichTextBox richTextBox) { }

        public bool Check()
        {
            return true;
        }

        public static List<string> GetLinesFromRichTextBox(System.Windows.Controls.RichTextBox richTextBox)
        {
            var lines = new List<string>();
            string text = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd).Text;
            string[] separators = ["\r\n", "\r", "\n", "\t"];
            string[] textLines = text.Split(separators, System.StringSplitOptions.RemoveEmptyEntries);
            lines.AddRange(textLines);

            return lines;
        }


    }
}
