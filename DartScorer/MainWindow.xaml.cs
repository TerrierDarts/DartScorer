﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            var client = new WebSocketClient("wss://127.0.0.1:5010");  // Replace with your WebSocket server URL
            client.Connect();
            client.SendText("180 SCORED");


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
