﻿using RPGCardsGenerator.Classes;
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
            StatsOfCharacter.Document.Blocks.Add(new PrintAllStats(BaseListOfCharacter).SkilTable);
            StatsOfCharacter.Document.Blocks.Add(new PrintAllStats(BaseListOfSkils).SkilTable);
            StatsOfCharacter.EndChange();

            
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
