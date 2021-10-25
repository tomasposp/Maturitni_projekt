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
    /// Interakční logika pro Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void SinglePlayer_Click(object sender, RoutedEventArgs e)
        {
            
            SingleVyber win = new SingleVyber();
            win.Show();
            this.Close();
        }

        private void MultiPlayer_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
