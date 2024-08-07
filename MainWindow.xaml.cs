﻿using System.Text;
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
        static bool PlayerCharacterOrNPC = false;
        public delegate void Reload();
        public event EventHandler PlayerCharacterChanged;

        public MainWindow()
        {
            


            InitializeComponent();
            PrintAll();

        }
        public void PrintAll()
        {
            PrintListOfCharacters printt = new PrintListOfCharacters(PlayerCharacterOrNPC, MainListBox);
        }

        private void MainListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(MainListBox.SelectedItem != null)
            {
                string IdPlusName = MainListBox.SelectedItem.ToString(); 
                                                              
                StatsOfCharacter.BeginChange();
                StatsOfCharacter.Document.Blocks.Clear();
                StatsOfCharacter.Document.Blocks.Add(new PrintAllStats(IdPlusName).MainTable);
                StatsOfCharacter.Document.Blocks.Add(new PrintAllStats(IdPlusName).CharacterTable);
                StatsOfCharacter.Document.Blocks.Add(new PrintAllStats(IdPlusName).SkilTable);
                StatsOfCharacter.EndChange();
            }
        }

        #region Buttons

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
        private void Delet_Character(object sender, RoutedEventArgs e)
        {

        }

        private void CreatePDF(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        #region Controls

        private void CommandBinding_CanExecute_True(object sender, CanExecuteRoutedEventArgs e)
        {
        e.CanExecute = true;
        }

        private void CommandBinding_Exit(object sender, ExecutedRoutedEventArgs e)
        {
             App.Current.Shutdown();
          // var listOfNumber =  GetLinesFromRichTextBox(StatsOfCharacter);
            //int IdPlusName = 0 ;
        }

        private void CommandBinding_NewCharacter(object sender, ExecutedRoutedEventArgs e)
        {
            NewCharacterWindow newCharacterWindow = new NewCharacterWindow();
            newCharacterWindow.Show();
        }




        #endregion

        
    }
}