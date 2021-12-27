using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
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
    /// Interakční logika pro Multiplayer.xaml
    /// </summary>
    public partial class Multiplayer : Window
    {

        int[,] PoleLodi = new int[12, 12]; // velikost pole
        int[,] PoleLodi2 = new int[12, 12]; // velikost pole

        Rectangle[,] PoleRect;
        Rectangle[,] PoleRect2;

        int indx;
        int indx2;

        int indy;
        int indy2;

        int lode = 0;
        int lode2 = 0;

        public Multiplayer(bool isHost, string ip = null)
        {

          


            Random rnd = new Random();

            int cislo1 = rnd.Next(1, 11);
            int cislo2 = rnd.Next(1, 11);
            int cislo3 = rnd.Next(1, 11);
            int cislo4 = rnd.Next(1, 11);




            InitializeComponent();


            PoleRect = new Rectangle[12, 12];
            PoleRect2 = new Rectangle[12, 12];

            VytvoreniPanelu(PoleRect);


            for (int i = 0; i < PoleLodi.GetLength(0); i++)
            {
                for (int y = 0; y < PoleLodi.GetLength(1); y++)
                {
                    if (i == 0 || i == 11)
                    {
                        PoleLodi[i, y] = 1;
                    }
                    else if (y == 0 || y == 11)
                    {
                        PoleLodi[i, y] = 1;
                    }
                    else PoleLodi[i, y] = 0;
                    // Console.Write(PoleLodi[i, y]);


                    if (PoleLodi[i, y] == 1)
                    {
                        indx = i;
                        indy = y;
                        PoleRect[i, y].Tag = 1;
                        PoleLodi[i, y] = 1;

                        PoleRect[i, y].Fill = Brushes.Blue;
                    }

                }
            }
            VytvoreniPanelu2(PoleRect2);

            for (int i = 0; i < PoleLodi2.GetLength(0); i++)
            {
                for (int y = 0; y < PoleLodi2.GetLength(1); y++)
                {
                    if (i == 0 || i == 11)
                    {
                        PoleLodi2[i, y] = 1;
                    }
                    else if (y == 0 || y == 11)
                    {
                        PoleLodi2[i, y] = 1;
                    }
                    else PoleLodi2[i, y] = 0;


                    if (PoleLodi2[i, y] == 1)
                    {
                        indx2 = i;
                        indy2 = y;
                        PoleRect2[i, y].Tag = 1;
                        PoleLodi2[i, y] = 1;

                        PoleRect2[i, y].Fill = Brushes.Blue;
                    }

                }
            }


            //PoleLodi[cislo1, cislo2] = 2;
            //PoleLodi2[cislo3, cislo4] = 2;



            void VytvoreniPanelu2(Rectangle[,] pole2)
            {

                for (int i = 0; i < pole2.GetLength(1); i++)
                {
                    mrizka2.ColumnDefinitions.Add(new ColumnDefinition());
                }
                for (int i = 0; i < pole2.GetLength(0); i++)
                {
                    mrizka2.RowDefinitions.Add(new RowDefinition());
                }

                for (int row = 0; row < pole2.GetLength(0); row++)
                    for (int col = 0; col < pole2.GetLength(1); col++)
                    {
                        pole2[row, col] = new Rectangle();

                        pole2[row, col].Fill = Brushes.White;

                        pole2[row, col].MouseLeftButtonDown += Grid_MouseLeftButtonDown;
                        pole2[row, col].StrokeThickness = 0.2;
                        pole2[row, col].Stroke = Brushes.Black;
                        pole2[row, col].Height = mrizka2.Height / pole2.GetLength(0);
                        pole2[row, col].Width = mrizka2.Width / pole2.GetLength(1);
                        Grid.SetColumn(pole2[row, col], col);
                        Grid.SetRow(pole2[row, col], row);
                        Grid.SetZIndex(pole2[row, col], 0);
                        mrizka2.Children.Add(pole2[row, col]);

                        //Console.WriteLine(PoleRect2[row, col].Tag);
                        //Console.WriteLine(PoleLodi[row,col]);

                    }

            }




            void VytvoreniPanelu(Rectangle[,] pole)
            {

                for (int i = 0; i < pole.GetLength(1); i++)
                {
                    mrizka.ColumnDefinitions.Add(new ColumnDefinition());
                }
                for (int i = 0; i < pole.GetLength(0); i++)
                {
                    mrizka.RowDefinitions.Add(new RowDefinition());
                }

                for (int row = 0; row < pole.GetLength(0); row++)
                    for (int col = 0; col < pole.GetLength(1); col++)
                    {
                        pole[row, col] = new Rectangle();

                        pole[row, col].Fill = Brushes.White;
                        pole[row, col].StrokeThickness = 0.2;
                        pole[row, col].Stroke = Brushes.Black;
                        pole[row, col].MouseLeftButtonDown += Grid_MouseLeftButtonDown;



                        pole[row, col].Height = mrizka.Height / pole.GetLength(0);
                        pole[row, col].Width = mrizka.Width / pole.GetLength(1);
                        Grid.SetColumn(pole[row, col], col);
                        Grid.SetRow(pole[row, col], row);
                        Grid.SetZIndex(pole[row, col], 0);
                        mrizka.Children.Add(pole[row, col]);

                        //Console.WriteLine(PoleRect[row, col].Tag);
                        //Console.WriteLine(PoleLodi[row,col]);

                    }

            }





















            MessageReceiver.DoWork += MessageReceiver_DoWork;

            if (isHost)
            {
                server = new TcpListener(System.Net.IPAddress.Any, 1420);
                server.Start();
                sock = server.AcceptSocket();
            }
            else
            {
                try
                {
                    client = new TcpClient(ip, 1420);
                    sock = client.Client;
                    MessageReceiver.RunWorkerAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();

                }
            }





          




        }


        void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            for (int r = 0; r < PoleRect2.GetLength(0); r++)
            {
                for (int s = 0; s < PoleLodi2.GetLength(1); s++)
                {
                    byte[] num = { Convert.ToByte(r) };
                    sock.Send(num);
                    //PoleRect[r, s].Fill = Brushes.Red;
                    //MessageReceiver.RunWorkerAsync();

                    Kolo();
                }
            }
        }


        private void MessageReceiver_DoWork(object sender, DoWorkEventArgs e)
        {
            if (lode2 > 0)
            {
                return;
            }
            Lbl.Content = "Hraje nepřítel";
            Kolo();
            Lbl.Content = "Tvoje kolo";
        }

        private Socket sock;
        private BackgroundWorker MessageReceiver = new BackgroundWorker();
        private TcpListener server = null;
        private TcpClient client;
        public bool IsDisposed { get; }

        private void Kolo()
        {
            byte[] buffer = new byte[1];
            sock.Receive(buffer);
            if (buffer[0] == 1)
            {
                PoleRect2[1, 1].Fill = Brushes.Black;
            }
            if (buffer[0] == 2)
            {
                PoleRect2[2, 1].Fill = Brushes.Black;
            }
            if (buffer[0] == 3)
            {
                PoleRect2[3, 1].Fill = Brushes.Black;
            }
            if (buffer[0] == 4)
            {
                PoleRect2[4, 1].Fill = Brushes.Black;
            }
            if (buffer[0] == 5)
            {
                PoleRect2[5, 1].Fill = Brushes.Black;
            }
            if (buffer[0] == 6)
            {
                PoleRect2[6, 1].Fill = Brushes.Black;
            }
            if (buffer[0] == 7)
            {
                PoleRect2[7, 1].Fill = Brushes.Black;
            }
            if (buffer[0] == 8)
            {
                PoleRect2[8, 1].Fill = Brushes.Black;
            }
            if (buffer[0] == 9)
            {
                PoleRect2[9, 1].Fill = Brushes.Black;
            }
        }

    }
}
