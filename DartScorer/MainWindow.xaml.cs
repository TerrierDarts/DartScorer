using DartSocket;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

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
            string player = PlayerNameBox.Text;
            int startScore = Convert.ToInt32(StartingScoreBox.Text);
            HandleData.DartData(player, startScore);
            UpdateStats();
            ScoreBox.Focus();
            WebSocketServerHelper.SetIpAndPort("127.0.0.1", 5010);
            
            
           
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
            if (newScore >= 0)
            {
                CurrentScore.Content = newScore;
            }
            else
            {
                scored = 0;
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
            JArray previousScoresList = UndoScore.GetLastScores();
            Debug.WriteLine(count100);
            int countDarts = HandleData.GetDartsThrown();
            double countAvg = HandleData.GetAverage();
            _180s.Content = "180s - " + count180.ToString();
            _170_.Content = "170+ - " + count170.ToString();
            _140_.Content = "140+ - " + count140.ToString();
            _100_.Content = "100+ - " + count100;
            PreviousScoresList.Text = "Previous Scores:" + previousScoresList.ToString();
            CurrentScore.Content = countScore;
            avg.Content = "Avg - " + countAvg.ToString("F2");
            thrown_count.Content = "Darts Thrown - " + countDarts.ToString();


        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            string filePath = "/data.json";
            // Create the file if it doesn't exist
            File.WriteAllText(filePath, "{}");
            string jsonString = File.ReadAllText(filePath);
            JObject data = JObject.Parse(jsonString);
            data["player"] = PlayerNameBox.Text;
            data["startingScore"] = Convert.ToInt32(StartingScoreBox.Text);
            string updatedJsonString = data.ToString();
            File.WriteAllText(filePath, updatedJsonString);
            UpdateStats();
            ScoreBox.Focus();
            UserName.Content = PlayerNameBox.Text;
            CurrentScore.Content = StartingScoreBox.Text;
        }

        private void Undo_Click(object sender, RoutedEventArgs e)
        {
            UndoScore.RemoveLastScore();
            UpdateStats();

        }
    }
}
