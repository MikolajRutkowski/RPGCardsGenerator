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

namespace RPGCardsGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PlayerCharacter testOne;
        public MainWindow()
        {
            
            InitializeComponent();
        }
        int x = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            testOne = new PlayerCharacter("Testowiec");
            string costdd = string.Empty;
            TextBlockTest.Text = testOne.NameOfPalyer;
            
        }
    }
}