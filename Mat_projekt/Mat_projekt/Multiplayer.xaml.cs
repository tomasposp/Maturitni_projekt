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
        bool zapnuty = false;

        int souradniceX;
        int souradniceY;
        int souradniceX1;
        int souradniceY1;

        Rectangle[,] PoleRect;
        Rectangle[,] PoleRect2;

        int indx;
        int indx2;

        int indy;
        int indy2;

        int lode = 1;
        int lode2 = 1;

        int kolo = 0;

        public Multiplayer(bool isHost, string ip = null)
        {
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

                        pole2[row, col].MouseLeftButtonDown += Window_MouseLeftButtonDown;
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
                        pole[row, col].MouseLeftButtonDown += Window_MouseLeftButtonDown;
                        ////////////pole[row, col].MouseDown += Multiplayer_MouseDown;


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

                server = new TcpListener(System.Net.IPAddress.Any, 1234);
                server.Start();
                sock = server.AcceptSocket();
                mrizka2.IsEnabled = false;
                mrizka.IsEnabled = true;
                PoleRect[souradniceX1, souradniceY1].Fill = Brushes.Black;
                

                


                //test();
            }
            else
            {
                try
                {
                    client = new TcpClient(ip, 1234);
                    sock = client.Client;
                    MessageReceiver.RunWorkerAsync();
                    mrizka2.IsEnabled = true;
                    mrizka.IsEnabled = false;
                    PoleRect2[souradniceX1, souradniceY1].Fill = Brushes.Black;
                    


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();

                }
            }
            //mrizka.IsEnabled = false;
            //mrizka2.IsEnabled = false;

        }

        private void MessageReceiver_DoWork(object sender, DoWorkEventArgs e)
        {

            //return;

            Lbl.Content = "Hraje nepřítel";
            Kolo();
            Lbl.Content = "Tvoje kolo";



        }

        //////////////////private void Multiplayer_MouseDown(object sender, MouseButtonEventArgs e)
        //////////////////{
        //////////////////    throw new NotImplementedException();
        //////////////////}

        private void Kolo()
        {
            byte[] buffer = new byte[1];
            sock.Receive(buffer);
            Console.WriteLine(buffer[0]);

            if (buffer[0] == 1)
            {
                PoleRect[1, 1].Fill = Brushes.Green;
            }
            if (buffer[0] == 2)
            {
                PoleRect[1, 2].Fill = Brushes.Black;
            }
            if (buffer[0] == 3)
            {
                PoleRect[1, 3].Fill = Brushes.Black;
            }
            if (buffer[0] == 4)
            {
                PoleRect[1, 4].Fill = Brushes.Black;
            }
            if (buffer[0] == 5)
            {
                PoleRect[1, 5].Fill = Brushes.Black;
            }
            if (buffer[0] == 6)
            {
                PoleRect[1, 6].Fill = Brushes.Black;
            }
            if (buffer[0] == 7)
            {
                PoleRect[1, 7].Fill = Brushes.Black;
            }
            if (buffer[0] == 8)
            {
                PoleRect[1, 8].Fill = Brushes.Black;
            }
            if (buffer[0] == 9)
            {
                PoleRect[1, 9].Fill = Brushes.Black;
            }
            if (buffer[0] == 10)
            {
                PoleRect[1, 10].Fill = Brushes.Black;
            }

            if (buffer[0] == 11)
            {
                PoleRect[2, 1].Fill = Brushes.Black;
            }
            if (buffer[0] == 12)
            {
                PoleRect[2, 2].Fill = Brushes.Black;
            }
            if (buffer[0] == 13)
            {
                PoleRect[2, 3].Fill = Brushes.Black;
            }
            if (buffer[0] == 14)
            {
                PoleRect[2, 4].Fill = Brushes.Black;
            }
            if (buffer[0] == 15)
            {
                PoleRect[2, 5].Fill = Brushes.Black;
            }
            if (buffer[0] == 16)
            {
                PoleRect[2, 6].Fill = Brushes.Black;
            }
            if (buffer[0] == 17)
            {
                PoleRect[2, 7].Fill = Brushes.Black;
            }
            if (buffer[0] == 18)
            {
                PoleRect[2, 8].Fill = Brushes.Black;
            }
            if (buffer[0] == 19)
            {
                PoleRect[2, 9].Fill = Brushes.Black;
            }
            if (buffer[0] == 20)
            {
                PoleRect[2, 10].Fill = Brushes.Black;
            }

            if (buffer[0] == 21)
            {
                PoleRect[3, 1].Fill = Brushes.Black;
            }
            if (buffer[0] == 22)
            {
                PoleRect[3, 2].Fill = Brushes.Black;
            }
            if (buffer[0] == 23)
            {
                PoleRect[3, 3].Fill = Brushes.Black;
            }
            if (buffer[0] == 24)
            {
                PoleRect[3, 4].Fill = Brushes.Black;
            }
            if (buffer[0] == 25)
            {
                PoleRect[3, 5].Fill = Brushes.Black;
            }
            if (buffer[0] == 26)
            {
                PoleRect[3, 6].Fill = Brushes.Black;
            }
            if (buffer[0] == 27)
            {
                PoleRect[3, 7].Fill = Brushes.Black;
            }
            if (buffer[0] == 28)
            {
                PoleRect[3, 8].Fill = Brushes.Black;
            }
            if (buffer[0] == 29)
            {
                PoleRect[3, 9].Fill = Brushes.Black;
            }
            if (buffer[0] == 30)
            {
                PoleRect[3, 10].Fill = Brushes.Black;
            }

            if (buffer[0] == 31)
            {
                PoleRect[4, 1].Fill = Brushes.Black;
            }
            if (buffer[0] == 32)
            {
                PoleRect[4, 2].Fill = Brushes.Black;
            }
            if (buffer[0] == 33)
            {
                PoleRect[4, 3].Fill = Brushes.Black;
            }
            if (buffer[0] == 34)
            {
                PoleRect[4, 4].Fill = Brushes.Black;
            }
            if (buffer[0] == 35)
            {
                PoleRect[4, 5].Fill = Brushes.Black;
            }
            if (buffer[0] == 36)
            {
                PoleRect[4, 6].Fill = Brushes.Black;
            }
            if (buffer[0] == 37)
            {
                PoleRect[4, 7].Fill = Brushes.Black;
            }
            if (buffer[0] == 38)
            {
                PoleRect[4, 8].Fill = Brushes.Black;
            }
            if (buffer[0] == 39)
            {
                PoleRect[4, 9].Fill = Brushes.Black;
            }
            if (buffer[0] == 40)
            {
                PoleRect[4, 10].Fill = Brushes.Black;
            }

            if (buffer[0] == 41)
            {
                PoleRect[5, 1].Fill = Brushes.Black;
            }
            if (buffer[0] == 42)
            {
                PoleRect[5, 2].Fill = Brushes.Black;
            }
            if (buffer[0] == 43)
            {
                PoleRect[5, 3].Fill = Brushes.Black;
            }
            if (buffer[0] == 44)
            {
                PoleRect[5, 4].Fill = Brushes.Black;
            }
            if (buffer[0] == 45)
            {
                PoleRect[5, 5].Fill = Brushes.Black;
            }
            if (buffer[0] == 46)
            {
                PoleRect[5, 6].Fill = Brushes.Black;
            }
            if (buffer[0] == 47)
            {
                PoleRect[5, 7].Fill = Brushes.Black;
            }
            if (buffer[0] == 48)
            {
                PoleRect[5, 8].Fill = Brushes.Black;
            }
            if (buffer[0] == 49)
            {
                PoleRect[5, 9].Fill = Brushes.Black;
            }
            if (buffer[0] == 50)
            {
                PoleRect[5, 10].Fill = Brushes.Black;
            }

            if (buffer[0] == 51)
            {
                PoleRect[6, 1].Fill = Brushes.Black;
            }
            if (buffer[0] == 52)
            {
                PoleRect[6, 2].Fill = Brushes.Black;
            }
            if (buffer[0] == 53)
            {
                PoleRect[6, 3].Fill = Brushes.Black;
            }
            if (buffer[0] == 54)
            {
                PoleRect[6, 4].Fill = Brushes.Black;
            }
            if (buffer[0] == 55)
            {
                PoleRect[6, 5].Fill = Brushes.Black;
            }
            if (buffer[0] == 56)
            {
                PoleRect[6, 6].Fill = Brushes.Black;
            }
            if (buffer[0] == 57)
            {
                PoleRect[6, 7].Fill = Brushes.Black;
            }
            if (buffer[0] == 58)
            {
                PoleRect[6, 8].Fill = Brushes.Black;
            }
            if (buffer[0] == 59)
            {
                PoleRect[6, 9].Fill = Brushes.Black;
            }
            if (buffer[0] == 60)
            {
                PoleRect[6, 10].Fill = Brushes.Black;
            }

            if (buffer[0] == 61)
            {
                PoleRect[7, 1].Fill = Brushes.Black;
            }
            if (buffer[0] == 62)
            {
                PoleRect[7, 2].Fill = Brushes.Black;
            }
            if (buffer[0] == 63)
            {
                PoleRect[7, 3].Fill = Brushes.Black;
            }
            if (buffer[0] == 64)
            {
                PoleRect[7, 4].Fill = Brushes.Black;
            }
            if (buffer[0] == 65)
            {
                PoleRect[7, 5].Fill = Brushes.Black;
            }
            if (buffer[0] == 66)
            {
                PoleRect[7, 6].Fill = Brushes.Black;
            }
            if (buffer[0] == 67)
            {
                PoleRect[7, 7].Fill = Brushes.Black;
            }
            if (buffer[0] == 68)
            {
                PoleRect[7, 8].Fill = Brushes.Black;
            }
            if (buffer[0] == 69)
            {
                PoleRect[7, 9].Fill = Brushes.Black;
            }
            if (buffer[0] == 70)
            {
                PoleRect[7, 10].Fill = Brushes.Black;
            }

            if (buffer[0] == 71)
            {
                PoleRect[8, 1].Fill = Brushes.Black;
            }
            if (buffer[0] == 72)
            {
                PoleRect[8, 2].Fill = Brushes.Black;
            }
            if (buffer[0] == 73)
            {
                PoleRect[8, 3].Fill = Brushes.Black;
            }
            if (buffer[0] == 74)
            {
                PoleRect[8, 4].Fill = Brushes.Black;
            }
            if (buffer[0] == 75)
            {
                PoleRect[8, 5].Fill = Brushes.Black;
            }
            if (buffer[0] == 76)
            {
                PoleRect[8, 6].Fill = Brushes.Black;
            }
            if (buffer[0] == 77)
            {
                PoleRect[8, 7].Fill = Brushes.Black;
            }
            if (buffer[0] == 78)
            {
                PoleRect[8, 8].Fill = Brushes.Black;
            }
            if (buffer[0] == 79)
            {
                PoleRect[8, 9].Fill = Brushes.Black;
            }
            if (buffer[0] == 80)
            {
                PoleRect[8, 10].Fill = Brushes.Black;
            }

            if (buffer[0] == 81)
            {
                PoleRect[9, 1].Fill = Brushes.Black;
            }
            if (buffer[0] == 82)
            {
                PoleRect[9, 2].Fill = Brushes.Black;
            }
            if (buffer[0] == 83)
            {
                PoleRect[9, 3].Fill = Brushes.Black;
            }
            if (buffer[0] == 84)
            {
                PoleRect[9, 4].Fill = Brushes.Black;
            }
            if (buffer[0] == 85)
            {
                PoleRect[9, 5].Fill = Brushes.Black;
            }
            if (buffer[0] == 86)
            {
                PoleRect[9, 6].Fill = Brushes.Black;
            }
            if (buffer[0] == 87)
            {
                PoleRect[9, 7].Fill = Brushes.Black;
            }
            if (buffer[0] == 88)
            {
                PoleRect[9, 8].Fill = Brushes.Black;
            }
            if (buffer[0] == 89)
            {
                PoleRect[9, 9].Fill = Brushes.Black;
            }
            if (buffer[0] == 90)
            {
                PoleRect[9, 10].Fill = Brushes.Black;
            }

            if (buffer[0] == 91)
            {
                PoleRect[10, 1].Fill = Brushes.Black;
            }
            if (buffer[0] == 92)
            {
                PoleRect[10, 2].Fill = Brushes.Black;
            }
            if (buffer[0] == 93)
            {
                PoleRect[10, 3].Fill = Brushes.Black;
            }
            if (buffer[0] == 94)
            {
                PoleRect[10, 4].Fill = Brushes.Black;
            }
            if (buffer[0] == 95)
            {
                PoleRect[10, 5].Fill = Brushes.Black;
            }
            if (buffer[0] == 96)
            {
                PoleRect[10, 6].Fill = Brushes.Black;
            }
            if (buffer[0] == 97)
            {
                PoleRect[10, 7].Fill = Brushes.Black;
            }
            if (buffer[0] == 98)
            {
                PoleRect[10, 8].Fill = Brushes.Black;
            }
            if (buffer[0] == 99)
            {
                PoleRect[10, 9].Fill = Brushes.Black;
            }
            if (buffer[0] == 100)
            {
                PoleRect[10, 10].Fill = Brushes.Black;
            }

            //MessageReceiver.WorkerSupportsCancellation = true;
            //MessageReceiver.CancelAsync();

        }


        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Rectangle Rec)
            {
                for (int r = 0; r < PoleRect.GetLength(0); r++)
                {
                    for (int s = 0; s < PoleRect.GetLength(1); s++)
                    {
                        if (PoleLodi[r, s] == 1) PoleRect[r, s].Tag = 1;
                        else if (PoleLodi[r, s] == 0) PoleRect[r, s].Tag = 0;
                        else if (PoleLodi[r, s] == 2) PoleRect[r, s].Tag = 2;
                        else if (PoleLodi[r, s] == 2) lode++;
                        else if ((int)PoleRect[r, s].Tag == 3) PoleLodi[r, s] = 3;


                    }
                    //Console.WriteLine();
                }


                Rec.Tag = 4;

                for (int r = 0; r < PoleLodi.GetLength(0); r++)
                {
                    for (int s = 0; s < PoleLodi.GetLength(1); s++)
                    {
                        

                        if ((int)PoleRect[r, s].Tag == 4)
                        {
                            souradniceX = r;
                            souradniceY = s;

                            if (PoleRect[r, s].Fill == Brushes.White)
                            {
                                

                                if (PoleRect[r, s] == PoleRect [1,1])
                                {
                                    byte[] num = { 1 };
                                    sock.Send(num);
                                    //Console.WriteLine(num[0]);
                                    PoleRect[1, 1].Fill = Brushes.Red;
                                    MessageReceiver.RunWorkerAsync();
                                             
                                }
                                if (PoleRect[r, s] == PoleRect[1, 2])
                                {
                                    byte[] num = { 2 };
                                    sock.Send(num);
                                    Console.WriteLine(num[0]);
                                }
                                if (PoleRect[r, s] == PoleRect[1, 3])
                                {
                                    byte[] num = { 3 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[1, 4])
                                {
                                    byte[] num = { 4 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[1, 5])
                                {
                                    byte[] num = { 5 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[1, 6])
                                {
                                    byte[] num = { 6 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[1, 7])
                                {
                                    byte[] num = { 7 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[1, 8])
                                {
                                    byte[] num = { 8 };
                                    sock.Send(num);
                                    Console.WriteLine(num[0]);
                                }
                                if (PoleRect[r, s] == PoleRect[1, 9])
                                {
                                    byte[] num = { 9 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[1, 10])
                                {
                                    byte[] num = { 10 };
                                    sock.Send(num);
                                    Console.WriteLine(num[0]);
                                }
//dva
                                if (PoleRect[r, s] == PoleRect[2, 1])
                                {
                                    byte[] num = { 11 };
                                    sock.Send(num);
                                    Console.WriteLine(num[0]);
                                }
                                if (PoleRect[r, s] == PoleRect[2, 2])
                                {
                                    byte[] num = { 12 };
                                    sock.Send(num);
                                    Console.WriteLine(num[0]);
                                }
                                if (PoleRect[r, s] == PoleRect[2, 3])
                                {
                                    byte[] num = { 13 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[2, 4])
                                {
                                    byte[] num = { 14 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[2, 5])
                                {
                                    byte[] num = { 15 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[2, 6])
                                {
                                    byte[] num = { 16 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[2, 7])
                                {
                                    byte[] num = {17 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[2, 8])
                                {
                                    byte[] num = { 18 };
                                    sock.Send(num);
                                    Console.WriteLine(num[0]);
                                }
                                if (PoleRect[r, s] == PoleRect[2, 9])
                                {
                                    byte[] num = { 19 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[2, 10])
                                {
                                    byte[] num = { 20 };
                                    sock.Send(num);
                                    Console.WriteLine(num[0]);
                                }
//tri
                                if (PoleRect[r, s] == PoleRect[3, 1])
                                {
                                    byte[] num = { 21 };
                                    sock.Send(num);
                                    Console.WriteLine(num[0]);
                                }
                                if (PoleRect[r, s] == PoleRect[3, 2])
                                {
                                    byte[] num = { 22 };
                                    sock.Send(num);
                                    Console.WriteLine(num[0]);
                                }
                                if (PoleRect[r, s] == PoleRect[3, 3])
                                {
                                    byte[] num = { 23 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[3, 4])
                                {
                                    byte[] num = { 24 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[3, 5])
                                {
                                    byte[] num = { 25 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[3, 6])
                                {
                                    byte[] num = { 26 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[3, 7])
                                {
                                    byte[] num = { 27 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[3, 8])
                                {
                                    byte[] num = { 28 };
                                    sock.Send(num);
                                    Console.WriteLine(num[0]);
                                }
                                if (PoleRect[r, s] == PoleRect[3, 9])
                                {
                                    byte[] num = { 29 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[3, 10])
                                {
                                    byte[] num = { 30 };
                                    sock.Send(num);
                                    Console.WriteLine(num[0]);
                                }
//ctyri
                                if (PoleRect[r, s] == PoleRect[4, 1])
                                {
                                    byte[] num = { 31 };
                                    sock.Send(num);
                                    Console.WriteLine(num[0]);
                                }
                                if (PoleRect[r, s] == PoleRect[4, 2])
                                {
                                    byte[] num = { 32 };
                                    sock.Send(num);
                                    Console.WriteLine(num[0]);
                                }
                                if (PoleRect[r, s] == PoleRect[4, 3])
                                {
                                    byte[] num = { 33 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[4, 4])
                                {
                                    byte[] num = { 34 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[4, 5])
                                {
                                    byte[] num = { 35 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[4, 6])
                                {
                                    byte[] num = { 36 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[4, 7])
                                {
                                    byte[] num = { 37 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[4, 8])
                                {
                                    byte[] num = { 38 };
                                    sock.Send(num);
                                    Console.WriteLine(num[0]);
                                }
                                if (PoleRect[r, s] == PoleRect[4, 9])
                                {
                                    byte[] num = {39 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[4, 10])
                                {
                                    byte[] num = { 40 };
                                    sock.Send(num);
                                    Console.WriteLine(num[0]);
                                }
//pet
                                if (PoleRect[r, s] == PoleRect[5, 1])
                                {
                                    byte[] num = { 41 };
                                    sock.Send(num);
                                    Console.WriteLine(num[0]);
                                }
                                if (PoleRect[r, s] == PoleRect[5, 2])
                                {
                                    byte[] num = { 42 };
                                    sock.Send(num);
                                    Console.WriteLine(num[0]);
                                }
                                if (PoleRect[r, s] == PoleRect[5, 3])
                                {
                                    byte[] num = { 43 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[5, 4])
                                {
                                    byte[] num = { 44 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[5, 5])
                                {
                                    byte[] num = { 45 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[5, 6])
                                {
                                    byte[] num = { 46 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[5, 7])
                                {
                                    byte[] num = { 47 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[5, 8])
                                {
                                    byte[] num = { 48 };
                                    sock.Send(num);
                                    Console.WriteLine(num[0]);
                                }
                                if (PoleRect[r, s] == PoleRect[5, 9])
                                {
                                    byte[] num = { 49 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[5, 10])
                                {
                                    byte[] num = { 50 };
                                    sock.Send(num);
                                    Console.WriteLine(num[0]);
                                }
//sest
                                if (PoleRect[r, s] == PoleRect[6, 1])
                                {
                                    byte[] num = { 51 };
                                    sock.Send(num);
                                    Console.WriteLine(num[0]);
                                }
                                if (PoleRect[r, s] == PoleRect[6, 2])
                                {
                                    byte[] num = { 52 };
                                    sock.Send(num);
                                    Console.WriteLine(num[0]);
                                }
                                if (PoleRect[r, s] == PoleRect[6, 3])
                                {
                                    byte[] num = { 53 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[6, 4])
                                {
                                    byte[] num = { 54 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[6, 5])
                                {
                                    byte[] num = { 55 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[6, 6])
                                {
                                    byte[] num = { 56 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[6, 7])
                                {
                                    byte[] num = { 57 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[6, 8])
                                {
                                    byte[] num = { 58 };
                                    sock.Send(num);
                                    Console.WriteLine(num[0]);
                                }
                                if (PoleRect[r, s] == PoleRect[6, 9])
                                {
                                    byte[] num = { 59 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[6, 10])
                                {
                                    byte[] num = { 60 };
                                    sock.Send(num);
                                    Console.WriteLine(num[0]);
                                }
//sedm
                                if (PoleRect[r, s] == PoleRect[7, 1])
                                {
                                    byte[] num = { 61 };
                                    sock.Send(num);
                                    Console.WriteLine(num[0]);
                                }
                                if (PoleRect[r, s] == PoleRect[7, 2])
                                {
                                    byte[] num = { 62 };
                                    sock.Send(num);
                                    Console.WriteLine(num[0]);
                                }
                                if (PoleRect[r, s] == PoleRect[7, 3])
                                {
                                    byte[] num = { 63 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[7, 4])
                                {
                                    byte[] num = { 64 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[7, 5])
                                {
                                    byte[] num = { 65 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[7, 6])
                                {
                                    byte[] num = { 66 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[7, 7])
                                {
                                    byte[] num = { 67 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[7, 8])
                                {
                                    byte[] num = { 68 };
                                    sock.Send(num);
                                    Console.WriteLine(num[0]);
                                }
                                if (PoleRect[r, s] == PoleRect[7, 9])
                                {
                                    byte[] num = { 69 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[7, 10])
                                {
                                    byte[] num = { 70 };
                                    sock.Send(num);
                                    Console.WriteLine(num[0]);
                                }
//osm
                                if (PoleRect[r, s] == PoleRect[8, 1])
                                {
                                    byte[] num = { 71 };
                                    sock.Send(num);
                                    Console.WriteLine(num[0]);
                                }
                                if (PoleRect[r, s] == PoleRect[8, 2])
                                {
                                    byte[] num = { 72 };
                                    sock.Send(num);
                                    Console.WriteLine(num[0]);
                                }
                                if (PoleRect[r, s] == PoleRect[8, 3])
                                {
                                    byte[] num = { 73 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[8, 4])
                                {
                                    byte[] num = { 74 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[8, 5])
                                {
                                    byte[] num = { 75 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[8, 6])
                                {
                                    byte[] num = { 76 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[8, 7])
                                {
                                    byte[] num = { 77 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[8, 8])
                                {
                                    byte[] num = { 78 };
                                    sock.Send(num);
                                    Console.WriteLine(num[0]);
                                }
                                if (PoleRect[r, s] == PoleRect[8, 9])
                                {
                                    byte[] num = { 79 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[8, 10])
                                {
                                    byte[] num = { 80 };
                                    sock.Send(num);
                                    Console.WriteLine(num[0]);
                                }
//devět
                                if (PoleRect[r, s] == PoleRect[9, 1])
                                {
                                    byte[] num = { 81 };
                                    sock.Send(num);
                                    Console.WriteLine(num[0]);
                                }
                                if (PoleRect[r, s] == PoleRect[9, 2])
                                {
                                    byte[] num = { 82 };
                                    sock.Send(num);
                                    Console.WriteLine(num[0]);
                                }
                                if (PoleRect[r, s] == PoleRect[9, 3])
                                {
                                    byte[] num = { 83 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[9, 4])
                                {
                                    byte[] num = { 84 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[9, 5])
                                {
                                    byte[] num = { 85 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[9, 6])
                                {
                                    byte[] num = { 86 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[9, 7])
                                {
                                    byte[] num = { 87 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[9, 8])
                                {
                                    byte[] num = { 88 };
                                    sock.Send(num);
                                    Console.WriteLine(num[0]);
                                }
                                if (PoleRect[r, s] == PoleRect[9, 9])
                                {
                                    byte[] num = { 89 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[9, 10])
                                {
                                    byte[] num = { 90 };
                                    sock.Send(num);
                                    Console.WriteLine(num[0]);
                                }
//deset
                                if (PoleRect[r, s] == PoleRect[10, 1])
                                {
                                    byte[] num = { 91 };
                                    sock.Send(num);
                                    Console.WriteLine(num[0]);
                                }
                                if (PoleRect[r, s] == PoleRect[10, 2])
                                {
                                    byte[] num = { 92 };
                                    sock.Send(num);
                                    Console.WriteLine(num[0]);
                                }
                                if (PoleRect[r, s] == PoleRect[10, 3])
                                {
                                    byte[] num = { 93 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[10, 4])
                                {
                                    byte[] num = { 94 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[10, 5])
                                {
                                    byte[] num = { 95 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[10, 6])
                                {
                                    byte[] num = { 96 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[10, 7])
                                {
                                    byte[] num = { 97 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[10, 8])
                                {
                                    byte[] num = { 98 };
                                    sock.Send(num);
                                    Console.WriteLine(num[0]);
                                }
                                if (PoleRect[r, s] == PoleRect[10, 9])
                                {
                                    byte[] num = { 99 };
                                    sock.Send(num);
                                }
                                if (PoleRect[r, s] == PoleRect[10, 10])
                                {
                                    byte[] num = { 100 };
                                    sock.Send(num);
                                    Console.WriteLine(num[0]);
                                }




                                //byte[] num = { Convert.ToByte(1) };
                                //sock.Send(num);
                                //Kolo();
                                //Kolo(); Kolo2();

                            }


                        }

                    }
                    //Console.WriteLine(souradniceX);

                    PoleRect[indx, indy].Tag = 3;


                }

                for (int r = 0; r < PoleLodi2.GetLength(0); r++)
                {
                    for (int s = 0; s < PoleLodi2.GetLength(1); s++)
                    {


                        if ((int)PoleRect[r, s].Tag == 4)
                        {
                            souradniceX1 = r;
                            souradniceY1 = s;

                            if (PoleRect[r, s].Fill == Brushes.White)
                            {
                                if (kolo % 2 == 0)
                                {
                                    Lbl.Content = "Kolo nepřítele";
                                }
                                else if (kolo % 2 == 1)
                                {
                                    PoleRect[r, s].Fill = Brushes.Black;
                                    Lbl.Content = "Tvoje kolo";
                                }
                                kolo++;

                               



                                //byte[] num = { Convert.ToByte(1) };
                                //sock.Send(num);
                                //Kolo();
                                //Kolo();
                            }


                        }


                    }
                    //Console.WriteLine(souradniceX1);

                    PoleRect[indx, indy].Tag = 3;

                    //byte[] num = { Convert.ToByte(r) };
                    //sock.Send(num);
                    //Kolo();
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
        private Socket sock;
        private BackgroundWorker MessageReceiver = new BackgroundWorker();
        private TcpListener server = null;
        private TcpClient client;




        public bool IsDisposed { get; }

        

        private void Kolo2()
        {
            byte[] buffer = new byte[1];
            sock.Receive(buffer);
            if (buffer[1] == 1)
            {
                PoleRect2[souradniceX, souradniceY].Fill = Brushes.Black;
            }
            MessageReceiver.WorkerSupportsCancellation = true;
            MessageReceiver.CancelAsync();
        }

        private void mrizka2_MouseDown(object sender, MouseButtonEventArgs e)
        {  
            //Kolo2();
        }

        private void mrizka_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
           //Kolo();
        }
    }
}

















//if (lode > 0)
//{
//    //Console.WriteLine(souradniceX);

//    for (int r = 0; r < PoleRect2.GetLength(0); r++)
//    {
//        for (int s = 0; s < PoleLodi2.GetLength(1); s++)
//        {
//            byte[] num = { Convert.ToByte(r) };
//            sock.Send(num);

//            souradniceX = r;
//            souradniceY = s;
//            //Console.WriteLine(souradniceX);

//            //PoleRect[r, s].Fill = Brushes.Red;
//            //MessageReceiver.RunWorkerAsync();



//        }
//        Kolo(); Kolo2();
//        //mrizka.IsEnabled = false;
//    }

//}