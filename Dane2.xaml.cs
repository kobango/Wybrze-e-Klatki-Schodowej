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

namespace ReportMaker
{
    /// <summary>
    /// Interaction logic for Dane2.xaml
    /// </summary>
    public partial class Dane2 : Window
    {
        List<TextBox> listaBox = new List<TextBox>();
        public int wybranaF = 0;

        public Dane2(int liczbaPomiarów, int wybranaFunkcja)
        {
            InitializeComponent();
            Utworz(liczbaPomiarów);
            wybranaF = wybranaFunkcja;

        }
        public void Utworz(int liczbaPomiarów)
        {
            Tablica.ColumnDefinitions.Add(new ColumnDefinition());
            for (int i = 0; i <= liczbaPomiarów; i++)
            {
                Tablica.RowDefinitions.Add(new RowDefinition());
            }
            Tablica.ShowGridLines = true;


            for (int i = 1; i < Tablica.RowDefinitions.Count; i++)
            {
                for (int j = 0; j < Tablica.ColumnDefinitions.Count; j++)
                {
                    TextBox t = new TextBox();
                    listaBox.Add(t);
                    Tablica.Children.Add(t);
                    Grid.SetColumn(t, j);
                    Grid.SetRow(t, i);
                    t.TextAlignment = TextAlignment.Center;
                }
            }

            TextBlock t2 = new TextBlock();
            t2.Text = "X";
            t2.TextAlignment = TextAlignment.Center;
            Tablica.Children.Add(t2);
            Grid.SetColumn(t2, 0);
            Grid.SetRow(t2, 0);
        }

        public double[] DajX()
        {
            int n = 0;
            for (int i = 0; i < listaBox.Count; i = i + 2)
            {
                n++;
            }

            double[] lista = new double[n];
            int x = 0;
            for (int i = 0; i < listaBox.Count; i = i + 2)
            {
                lista[x] = double.Parse(listaBox[i].Text);
                x++;
            }
            return lista;
        }

        private void DalejButton_Click(object sender, RoutedEventArgs e)
        {
            double[] x = DajX();
            double[] y = new double[x.Length];
            int f = wybranaF;
            Wyniki2 w = new Wyniki2(f, x, y);
            w.Show();
            this.Close();
        }
    }
}
