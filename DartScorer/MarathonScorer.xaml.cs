using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DartScorer
{
    /// <summary>
    /// Interaction logic for MarathonScorer.xaml
    /// </summary>
    public partial class MarathonScorer : Page
    {
        public MarathonScorer()
        {
            InitializeComponent();
            HandleData.DartData();
            UpdateStats();
            ScoreBox.Focus();
        }


        private void Return_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void One_Click(object sender, RoutedEventArgs e)
        {
            ScoreBox.Text = ScoreBox.Text + "1";
        }
        private void Two_Click(object sender, RoutedEventArgs e)
        {
            ScoreBox.Text = ScoreBox.Text + "2";
        }
        private void Three_Click(object sender, RoutedEventArgs e)
        {
            ScoreBox.Text = ScoreBox.Text + "3";
        }
        private void Four_Click(object sender, RoutedEventArgs e)
        {
            ScoreBox.Text = ScoreBox.Text + "4";
        }
        private void Five_Click(object sender, RoutedEventArgs e)
        {

            ScoreBox.Text = ScoreBox.Text + "5";
        }
        private void Six_Click(object sender, RoutedEventArgs e)
        {
            ScoreBox.Text = ScoreBox.Text + "6";
        }
        private void Seven_Click(object sender, RoutedEventArgs e)
        {
            ScoreBox.Text = ScoreBox.Text + "7";
        }
        private void Eight_Click(object sender, RoutedEventArgs e)
        {
            ScoreBox.Text = ScoreBox.Text + "8";
        }
        private void Nine_Click(object sender, RoutedEventArgs e)
        {
            ScoreBox.Text = ScoreBox.Text + "9";
        }
        private void Zero_Click(object sender, RoutedEventArgs e)
        {

            ScoreBox.Text = ScoreBox.Text + "0";
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            ScoreBox.Text = "";
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            EnterScore();

        }
        private void CheckEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                EnterScore();
            }
        }

        public bool EnterScore()
        {
            int currentScore = Convert.ToInt32(CurrentScore.Content);
            int scored;
            if (!int.TryParse(ScoreBox.Text, out scored))
            {
                scored = 0;
            }
            ScoreBox.Text = "";
            int newScore = currentScore - scored;
            if (newScore > 0)
            {
                CurrentScore.Content = newScore;
            }
            ScoreBox.Focus();
            HandleData.HandleScore(scored);
           
            UpdateStats();
            return true;
        }

        public void UpdateStats()
        {
            int count180 = HandleData.Get180Count();
            int count170 = HandleData.Get170Count();
            int count140 = HandleData.Get140Count();
            int count100 = HandleData.Get100Count();
            int countScore = HandleData.GetRemainingScore();
            Debug.WriteLine(count100);
            int countDarts = HandleData.GetDartsThrown();
            float countAvg = HandleData.GetAverage();
            _180s.Content = "180s - " + count180.ToString();
            _170_.Content = "170+ - " + count170.ToString();
            _140_.Content = "140+ - " + count140.ToString();
            _100_.Content = "100+ - " + count100;
            CurrentScore.Content = countScore;
            avg.Content = "Avg - " + countAvg.ToString("F2");
            thrown_count.Content = "Darts Thrown - " + countDarts.ToString();
            
        }
     

    }
}
