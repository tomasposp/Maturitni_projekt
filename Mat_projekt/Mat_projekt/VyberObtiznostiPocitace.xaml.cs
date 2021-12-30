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
    /// Interakční logika pro VyberObtiznostiPocitace.xaml
    /// </summary>
    public partial class VyberObtiznostiPocitace : Window
    {
        public VyberObtiznostiPocitace()
        {
            InitializeComponent();
        }

        private void Easy_Click(object sender, RoutedEventArgs e)
        {
            Class1.Easy = true;
            MainWindow win = new MainWindow();
            win.Show();
            this.Close();
        }

        private void Medium_Click(object sender, RoutedEventArgs e)
        {
            Class1.Medium = true;
            MainWindow win = new MainWindow();
            win.Show();
            this.Close();
        }

        private void Back_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SingleVyber win = new SingleVyber();
            win.Show();
            this.Close();
        }
    }
}
