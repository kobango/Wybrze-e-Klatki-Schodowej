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
    /// Interaction logic for Wyniki.xaml
    /// </summary>
    public partial class Wyniki : Window
    {
        List<TextBox> listaBox = new List<TextBox>();
        double[] dX = null;
        double[] dY = null;
        double[] dF = null;
        double Xsr = 0;
        double Ysr = 0;
        double Fsr = 0;
        double[] X = null;
        double[] Y = null;

        public Wyniki(int f, double[] x, double[] y)
        {
            InitializeComponent();
            Utworz(x.Length);
            PrzepisXY(x, y);
            dX = new double[x.Length];
            dY = new double[x.Length];
            dF = new double[x.Length];
            X = x;
            Y = y;
            Oblicz.Count(x, y, f, ref Xsr, ref Ysr,ref dX, ref dY,ref dF, ref Fsr);

            PrzepiszReszte(dX, dY, dF);

            XsrBox.Text = Xsr.ToString();
            YsrBox.Text = Ysr.ToString();
            FsrBox.Text = Fsr.ToString();
            WynikBox.Text = XD(f).ToString();
        }

        public void Utworz(int liczbaPomiarów)
        {
            Tablica.ColumnDefinitions.Add(new ColumnDefinition());
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
            t2.Text = "Y";
            t2.TextAlignment = TextAlignment.Center;
            Tablica.Children.Add(t2);
            Grid.SetColumn(t2, 1);
            Grid.SetRow(t2, 0);
            t2 = new TextBlock();
            t2.Text = "dX";
            t2.TextAlignment = TextAlignment.Center;
            Tablica.Children.Add(t2);
            Grid.SetColumn(t2, 2);
            Grid.SetRow(t2, 0);
            t2 = new TextBlock();
            t2.Text = "dY";
            t2.TextAlignment = TextAlignment.Center;
            Tablica.Children.Add(t2);
            Grid.SetColumn(t2, 3);
            Grid.SetRow(t2, 0);
            t2 = new TextBlock();
            t2.Text = "dF";
            t2.TextAlignment = TextAlignment.Center;
            Tablica.Children.Add(t2);
            Grid.SetColumn(t2, 4);
            Grid.SetRow(t2, 0);
        }

        public void PrzepisXY(double[] x, double[] y)
        {
            int n = 0;
            for (int i = 0; i < listaBox.Count; i=i+5)
            {
                listaBox[i].Text = x[n].ToString();
                n++;
            }

            n = 0;
            for (int i = 1; i < listaBox.Count; i =i+5)
            {
                listaBox[i].Text = y[n].ToString();
                n++;
            }

        }

        public void PrzepiszReszte(double[] dX, double[] dY, double[] dF)
        {
            int n = 0;
            for (int i = 2; i < listaBox.Count; i = i + 5)
            {
                listaBox[i].Text = dX[n].ToString();
                n++;
            }

            n = 0;
            for (int i = 3; i < listaBox.Count; i = i + 5)
            {
                listaBox[i].Text = dY[n].ToString();
                n++;
            }

            n = 0;
            for (int i = 4; i < listaBox.Count; i = i + 5)
            {
                listaBox[i].Text = dF[n].ToString();
                n++;
            }
        }

        private void ZapiszWynikiButton_Click(object sender, RoutedEventArgs e)
        {
            InputOutput.Zapisz("wyniki"+ ".txt", X, Y, dX, dY, dF, Xsr, Ysr, Fsr, double.Parse(WynikBox.Text));
            MessageBox.Show("Zapisano wyniki!");
        }

        private void ZapiszPomiaryButton_Click(object sender, RoutedEventArgs e)
        {
            InputOutput.ZapiszW("dane" + ".txt", X, Y);
            MessageBox.Show("Zapisano dane!");
        }

        private double XD(int f)
        {
            switch (f)
            {
                case 0:
                    return Xsr + Ysr;
                case 1:
                    return Xsr - Ysr;
                case 2:
                    return Xsr * Ysr;
                case 3:
                    return Xsr / Ysr;
                case 4:
                    return Math.Log(Xsr);
                case 5:
                    return Math.Exp(Xsr);
            }
            return 0;
        }
    }
}
