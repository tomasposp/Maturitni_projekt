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

namespace Mat_projekt
{
    /// <summary>
    /// Interakční logika pro SingleVyber.xaml
    /// </summary>
    public partial class SingleVyber : Window
    {
        public SingleVyber()
        {
            InitializeComponent();
        }

        private void Pocitac_Click(object sender, RoutedEventArgs e)
        {
            VyberObtiznostiPocitace win = new VyberObtiznostiPocitace();
            win.Show();
            this.Close();
        }

        private void NabojovyMode_Click(object sender, RoutedEventArgs e)
        {
            NabojovyMode win = new NabojovyMode();
            win.Show();
            this.Close();
        }
    }
}
