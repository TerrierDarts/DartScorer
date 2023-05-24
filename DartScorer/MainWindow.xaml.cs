using DartSocket;
using System.Windows;

namespace DartScorer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            _ = new WebSocketServerHelper("127.0.0.1", 5010);
           


        }
   

        private void Marathon_Start_Click(object sender, RoutedEventArgs e)
        {
            MarathonScorer pg = new MarathonScorer();
            this.Content = pg;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
