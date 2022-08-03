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
    /// Interakční logika pro Connect.xaml
    /// </summary>
    public partial class Connect : Window
    {
        public Connect()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            Multiplayer newGame = new Multiplayer(false, TextIP.Text);
            this.Close();
            if (!newGame.IsDisposed)
            {
                newGame.ShowDialog();
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            Multiplayer newGame = new Multiplayer(true);
            this.Close();
            if (!newGame.IsDisposed)
            {
                newGame.ShowDialog();              
            }
        }
        private void Back_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Window1 win = new Window1();
            win.Top = this.Top;
            win.Left = this.Left;
            win.Show();
            this.Close();
        }
    }
}
