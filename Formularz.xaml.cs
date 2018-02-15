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
    /// Interaction logic for Formularz.xaml
    /// </summary>
    public partial class Formularz : Window
    {
        public Formularz()
        {
            InitializeComponent();
        }

        private void PodanoButton_Click(object sender, RoutedEventArgs e)
        {
            int wybranaFunkcja = RodzajFunkcjiComboBox.SelectedIndex;
            if (PomiaryBlock.Visibility == Visibility.Hidden)
            {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.DefaultExt = ".txt";
                Nullable<bool> result = dlg.ShowDialog();
                string path = null;
                if (result == true)
                {
                    path = dlg.FileName;
                }
                MessageBox.Show("Wybrano: " + path);

                double[] x = null;
                double[] y = null;

                InputOutput.Odczyt(path, ref x, ref y);
                if (wybranaFunkcja != 6)
                {
                    Wyniki w = new Wyniki(wybranaFunkcja, x, y);
                    w.Show();
                    this.Close();
                    return;
                }
            }
            int liczbaPomiarow = int.Parse(PomiaryBox.Text);
            
            if (wybranaFunkcja != 6)
            {
                Dane d = new Dane(liczbaPomiarow, wybranaFunkcja);
                d.Show();
                this.Close();
            }
            else
            {
                Dane2 d = new Dane2(liczbaPomiarow, wybranaFunkcja);
                d.Show();
                this.Close();
            }

        }
    }
}
