using DartSocket;
using System.Windows;
using System.IO;
using System;
using System.Windows.Navigation;

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

            WebSocketServerHelper.SetIpAndPort("127.0.0.1", 5010);



        }


        private void Marathon_Start_Click(object sender, RoutedEventArgs e)
        {
            MarathonScorer pg = new MarathonScorer();
            this.Content = pg;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string filePath = "/data.json";
            if (!File.Exists(filePath))
            {
                // Create the file if it doesn't exist
                File.WriteAllText(filePath, "{}");
            }
            File.WriteAllText(filePath, "{}");

            MarathonScorer pg = new MarathonScorer();
            this.Content = pg;
        }

    }
}
