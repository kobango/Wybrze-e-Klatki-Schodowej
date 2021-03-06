﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReportMaker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NowyButton_Click(object sender, RoutedEventArgs e)
        {
            Formularz f = new Formularz();
            f.Show();
            this.Close();
        }

        private void WczytajButton_Click(object sender, RoutedEventArgs e)
        {
            Formularz f = new Formularz();
            f.PomiaryBlock.Visibility = Visibility.Hidden;
            f.PomiaryBox.Visibility = Visibility.Hidden;
            f.Show();
            this.Close();
        }
    }
}
