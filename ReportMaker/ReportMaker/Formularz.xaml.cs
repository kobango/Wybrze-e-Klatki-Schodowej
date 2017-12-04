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
            int liczbaPomiarow = int.Parse(PomiaryBox.Text);
            string wybranaFunkcja = RodzajFunkcjiComboBox.SelectionBoxItem.ToString();
            Dane d = new Dane(liczbaPomiarow, wybranaFunkcja);
            d.Show();
            this.Close();
            
        }
    }
}
