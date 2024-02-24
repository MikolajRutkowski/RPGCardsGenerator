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

        


        PlayerCharacter testOne;
        public MainWindow()
        {
           

            Console.WriteLine("sdssdd");
            InitializeComponent();
            Console.WriteLine("sdssdd");
        }
        int x = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            testOne = new PlayerCharacter(1,"GraczTestowy","CharakterTestowy01");

            
            
        }
    }
}