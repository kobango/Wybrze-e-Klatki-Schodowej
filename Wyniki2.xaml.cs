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
    /// Interaction logic for Wyniki2.xaml
    /// </summary>
    public partial class Wyniki2 : Window
    {
        List<TextBox> listaBox = new List<TextBox>();
        public Wyniki2(int f, double[] x, double[] y)
        {
            InitializeComponent();
            Utworz(x.Length);
            PrzepisX(x);

            double[] dX = new double[x.Length];
            double[] dY = new double[x.Length];
            double[] dF = new double[x.Length];
            double Xsr = 0;
            double Ysr = 0;
            double Fsr = 0;
            Oblicz.Count(x, y, f, ref Xsr, ref Ysr, ref dX, ref dY, ref dF, ref Fsr);

            PrzepiszReszte(dX, dF);

            XsrBox.Text = Xsr.ToString();
            FsrBox.Text = Fsr.ToString();
        }

        public void Utworz(int liczbaPomiarów)
        {
            Tablica.ColumnDefinitions.Add(new ColumnDefinition());
            Tablica.ColumnDefinitions.Add(new ColumnDefinition());
            Tablica.ColumnDefinitions.Add(new ColumnDefinition());
            Tablica.ColumnDefinitions.Add(new ColumnDefinition());
            for (int i = 0; i <= liczbaPomiarów; i++)
            {
                Tablica.RowDefinitions.Add(new RowDefinition());
            }
            Tablica.ShowGridLines = false;


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
            t2 = new TextBlock();
            t2.Text = "dX";
            t2.TextAlignment = TextAlignment.Center;
            Tablica.Children.Add(t2);
            Grid.SetColumn(t2, 1);
            Grid.SetRow(t2, 0);
            t2 = new TextBlock();
            t2.Text = "dF";
            t2.TextAlignment = TextAlignment.Center;
            Tablica.Children.Add(t2);
            Grid.SetColumn(t2, 2);
            Grid.SetRow(t2, 0);
        }

        public void PrzepisX(double[] x)
        {
            int n = 0;
            for (int i = 0; i < listaBox.Count; i = i + 3)
            {
                listaBox[i].Text = x[n].ToString();
                n++;
            }
        }

        public void PrzepiszReszte(double[] dX, double[] dF)
        {
            int n = 0;
            for (int i = 2; i < listaBox.Count; i = i + 3)
            {
                listaBox[i].Text = dX[n].ToString();
                n++;
            }

            n = 0;
            for (int i = 4; i < listaBox.Count; i = i + 3)
            {
                listaBox[i].Text = dF[n].ToString();
                n++;
            }
        }
    }
}
