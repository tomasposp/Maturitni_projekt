using SimpleTCP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using System.Windows.Threading;
using System.Xml.Serialization;

namespace Mat_projekt
{
    /// <summary>
    /// Interakční logika pro Multiplayer.xaml
    /// </summary>
    public partial class Multiplayer : Window
    {



        Rectangle[,] PoleRect;
        Rectangle[,] PoleRect2;
        int lode = 0;
        int indx;
        int indy;
        bool isHost;
        bool hrajes;
        

        SimpleTcpServer server;
        SimpleTcpClient client;


        public Multiplayer(bool isHost, string ip = null)
        {

            InitializeComponent();

           

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0,0,0,0,100);
            timer.Tick += Timer_Tick;
            timer.Start();

            this.isHost = isHost;

            PoleRect = new Rectangle[12, 12];
            PoleRect2 = new Rectangle[12, 12];


            if (isHost)
            {
                server = new SimpleTcpServer();
                server.Start(6969);
                int clientsConnected = server.ConnectedClientsCount;


                server.DelimiterDataReceived += Server_DataReceived;

                hrajes = true;
            }
            else
            {
                try
                {
                    client = new SimpleTcpClient().Connect("127.0.0.1", 6969);
                    var replyMsg = client.WriteLineAndGetReply("Hello world!", TimeSpan.FromSeconds(3));
                    client.DataReceived += Client_DataReceived;

                    hrajes = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }





            VytvoreniPanelu(PoleRect);
            for (int i = 0; i < pole.PoleLodi.GetLength(0); i++)
            {
                for (int y = 0; y < pole.PoleLodi.GetLength(1); y++)
                {
                    PoleRect[i, y].MouseDown += Multiplayer_MouseDown;

                    if (i == 0 || i == 11)
                    {
                        pole.PoleLodi[i, y] = 1;
                    }
                    else if (y == 0 || y == 11)
                    {
                        pole.PoleLodi[i, y] = 1;
                    }
                    else pole.PoleLodi[i, y] = 0;

                    if (pole.PoleLodi[i, y] == 1)
                    {
                        PoleRect[i, y].Tag = 1;
                        pole.PoleLodi[i, y] = 1;

                        PoleRect[i, y].Fill = Brushes.Blue;
                    }

                }
            }

            VytvoreniPanelu2(PoleRect2);

            for (int i = 0; i < pole.PoleLodi2.GetLength(0); i++)
            {
                for (int y = 0; y < pole.PoleLodi2.GetLength(1); y++)
                {
                    PoleRect2[i, y].MouseDown += mrizka2_MouseDown;

                    if (i == 0 || i == 11)
                    {
                        pole.PoleLodi2[i, y] = 1;
                    }
                    else if (y == 0 || y == 11)
                    {
                        pole.PoleLodi2[i, y] = 1;
                    }
                    else pole.PoleLodi2[i, y] = 0;


                    if (pole.PoleLodi2[i, y] == 1)
                    {
                        PoleRect2[i, y].Tag = 1;
                        pole.PoleLodi2[i, y] = 1;

                        PoleRect2[i, y].Fill = Brushes.Blue;
                    }

                }
            }
            pole.PoleLodi[1, 1] = 2;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!isHost)
            { 
                for (int i = 0; i < pole.PoleLodi.GetLength(0); i++)
                {
                    for (int y = 0; y < pole.PoleLodi.GetLength(1); y++)
                    {
                        if (pole.PoleLodi[i,y] == 4 || pole.PoleLodi[i, y] == 3)
                        {
                            Uri miss;
                            miss = new Uri("pack://application:,,,/Pictures/LodeMiss.jpg");
                            PoleRect[i, y].Fill = new ImageBrush(new BitmapImage(miss));
                        }
                        if (pole.PoleLodi[i, y] == 9)
                        {
                            Uri hit;
                            hit = new Uri("pack://application:,,,/Pictures/LodeHit.jpg");
                            PoleRect[i, y].Fill = new ImageBrush(new BitmapImage(hit));
                        }

                    }

                }
            }

            if (isHost)
            {
                for (int i = 0; i < pole.PoleLodi2.GetLength(0); i++)
                {
                    for (int y = 0; y < pole.PoleLodi2.GetLength(1); y++)
                    {
                        if (pole.PoleLodi2[i, y] == 4 || pole.PoleLodi2[i, y] == 3)
                        {
                            Uri miss;
                            miss = new Uri("pack://application:,,,/Pictures/LodeMiss.jpg");
                            PoleRect2[i, y].Fill = new ImageBrush(new BitmapImage(miss));
                        }
                        if (pole.PoleLodi[i, y] == 9)
                        {
                            Uri hit;
                            hit = new Uri("pack://application:,,,/Pictures/LodeHit.jpg");
                            PoleRect[i, y].Fill = new ImageBrush(new BitmapImage(hit));
                        }

                    }

                }
            }
        }

        private void Multiplayer_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Rectangle Rec && hrajes == true)
            {

                hrajes = false;

                for (int r = 0; r < PoleRect.GetLength(0); r++)
                {
                    for (int s = 0; s < PoleRect.GetLength(1); s++)
                    {
                        if (pole.PoleLodi[r, s] == 1) PoleRect[r, s].Tag = 1;
                        else if (pole.PoleLodi[r, s] == 0) PoleRect[r, s].Tag = 0;
                        else if (pole.PoleLodi[r, s] == 2) PoleRect[r, s].Tag = 2;
                        else if (pole.PoleLodi[r, s] == 2) lode++;
                        else if ((int)PoleRect[r, s].Tag == 3) pole.PoleLodi[r, s] = 3;


                    }

                }


                Rec.Tag = 4;


                for (int r = 0; r < pole.PoleLodi.GetLength(0); r++)
                {
                    for (int s = 0; s < pole.PoleLodi.GetLength(1); s++)
                    {

                        if ((int)PoleRect[r, s].Tag == 4)
                        {
                            if (PoleRect[r, s].Fill == Brushes.White)
                            {


                                if ((int)PoleRect[r, s].Tag == 3)
                                {
                                    indx = r;
                                    indy = s;

                                    PoleRect[r, s].Tag = 3;
                                    pole.PoleLodi[r, s] = 3;
                                    r--;

                                }

                                if (pole.PoleLodi[r, s]== 2)
                                {
                                    PoleRect[r, s].Tag = 9;
                                    pole.PoleLodi[r, s] = 9;
                                    Uri hit;
                                    hit = new Uri("pack://application:,,,/Pictures/LodeHit.jpg");
                                    PoleRect[r, s].Fill = new ImageBrush(new BitmapImage(hit));
                                }


                                if (pole.PoleLodi[r, s] == 9)
                                {
                                    indx = r;
                                    indy = s;

                                    PoleRect[r, s].Tag = 9;
                                    pole.PoleLodi[r, s] = 9;
                                }

                                if (pole.PoleLodi[r, s] == 1)
                                {
                                    indx = r;
                                    indy = s;

                                    PoleRect[r, s].Tag = 1;
                                    pole.PoleLodi[r, s] = 1;

                                    s--;


                                }

                                else if ((int)PoleRect[r, s].Tag == 4)
                                {

                                    indx = r;
                                    indy = s;

                                    PoleRect[r, s].Tag = 4;
                                    pole.PoleLodi[r, s] = 4;




                                    if (PoleRect[r, s].Fill == Brushes.White)
                                    {
                                        Uri miss;
                                        miss = new Uri("pack://application:,,,/Pictures/LodeMiss.jpg");
                                        PoleRect[r, s].Fill = new ImageBrush(new BitmapImage(miss));


                                    }
                                }
                            }
                            else if (pole.PoleLodi[r, s] == 2 || pole.PoleLodi[r, s] == 5 || pole.PoleLodi[r, s] == 6)
                            {

                                indx = r;
                                indy = s;

                                if (pole.PoleLodi[r, s] == 2)
                                {
                                    PoleRect[r, s].Tag = 2;
                                    pole.PoleLodi[r, s] = 2;


                                }
                                else if (pole.PoleLodi[r, s] == 5)
                                {
                                    PoleRect[r, s].Tag = 5;
                                    pole.PoleLodi[r, s] = 5;

                                }
                                else if (pole.PoleLodi[r, s] == 6)
                                {
                                    PoleRect[r, s].Tag = 6;
                                    pole.PoleLodi[r, s] = 6;

                                }




                                if (pole.PoleLodi[r, s]== 2)
                                {
                                    PoleRect[r, s].Tag = 9;
                                    pole.PoleLodi[r, s] = 9;
                                    Uri hit;
                                    hit = new Uri("pack://application:,,,/Pictures/LodeHit.jpg");
                                    PoleRect[r, s].Fill = new ImageBrush(new BitmapImage(hit));
                                    lode--;


                                }

                                else if ((int)PoleRect[r, s].Tag == 5)
                                {
                                    PoleRect[r, s].Tag = 9;
                                    pole.PoleLodi[r, s] = 9;
                                    Uri hit;
                                    hit = new Uri("pack://application:,,,/Pictures/LodeHit.jpg");
                                    PoleRect[r, s].Fill = new ImageBrush(new BitmapImage(hit));
                                    lode--;

                                }


                                else if ((int)PoleRect[r, s].Tag == 6)
                                {
                                    PoleRect[r, s].Tag = 9;
                                    pole.PoleLodi[r, s] = 9;
                                    Uri hit;
                                    hit = new Uri("pack://application:,,,/Pictures/LodeHit.jpg");
                                    PoleRect[r, s].Fill = new ImageBrush(new BitmapImage(hit));
                                    lode--;

                                }

                            }


                        }

                    }
                    

                    PoleRect[indx, indy].Tag = 3;


                }


            }

            if (isHost)
            {
                int[] tmp = new int[12 * 12];
                int poradi = 0;
                for (int i = 0; i < 12; i++)
                    for (int n = 0; n < 12; n++)
                    {
                        tmp[poradi++] = pole.PoleLodi[i, n];
                    }
                server.Broadcast(Lode.SerializeXml<int[]>(tmp));
                
            }

        }

        private void Client_DataReceived(object sender, Message e)
        {
            int[] tmp = Lode.DeserializeXml<int[]>(e.MessageString);
 
            int poradi = 0;

            hrajes = true;

            for (int i = 0; i < 12; i++)
            {
                
                for (int n = 0; n < 12; n++)
                {
                    pole.PoleLodi[i, n] = tmp[poradi++];


                    

                }
               
            }
            


        }

        private void Server_DataReceived(object sender, Message e)
        {
            int[] tmp = Lode.DeserializeXml<int[]>(e.MessageString);

            int poradi = 0;

            hrajes = true;
            for (int i = 0; i < 12; i++)
            {

                for (int n = 0; n < 12; n++)
                {
                    pole.PoleLodi2[i, n] = tmp[poradi++];


                

                }
               
            }
        }

        private void VytvoreniPanelu(Rectangle[,] pole)
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
                    //pole[row, col].MouseLeftButtonDown += Multiplayer_MouseLeftButtonDown;



                    pole[row, col].Height = mrizka.Height / pole.GetLength(0);
                    pole[row, col].Width = mrizka.Width / pole.GetLength(1);
                    Grid.SetColumn(pole[row, col], col);
                    Grid.SetRow(pole[row, col], row);
                    Grid.SetZIndex(pole[row, col], 0);
                    mrizka.Children.Add(pole[row, col]);



                }

        }

        private void VytvoreniPanelu2(Rectangle[,] pole2)
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

                    //pole2[row, col].MouseLeftButtonDown += Multiplayer_MouseLeftButtonDown1;
                    pole2[row, col].StrokeThickness = 0.2;
                    pole2[row, col].Stroke = Brushes.Black;
                    pole2[row, col].Height = mrizka2.Height / pole2.GetLength(0);
                    pole2[row, col].Width = mrizka2.Width / pole2.GetLength(1);
                    Grid.SetColumn(pole2[row, col], col);
                    Grid.SetRow(pole2[row, col], row);
                    Grid.SetZIndex(pole2[row, col], 0);
                    mrizka2.Children.Add(pole2[row, col]);

                }

        }



        public bool IsDisposed { get; }

        private void mrizka_MouseDown(object sender, MouseButtonEventArgs e)
        {
            }

        private void mrizka2_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (sender is Rectangle Rec && hrajes == true)
            {
                hrajes = false;
                for (int r = 0; r < PoleRect2.GetLength(0); r++)
                {
                    for (int s = 0; s < PoleRect2.GetLength(1); s++)
                    {
                        if (pole.PoleLodi2[r, s] == 1) PoleRect2[r, s].Tag = 1;
                        else if (pole.PoleLodi2[r, s] == 0) PoleRect2[r, s].Tag = 0;
                        else if (pole.PoleLodi2[r, s] == 2) PoleRect2[r, s].Tag = 2;
                        else if (pole.PoleLodi2[r, s] == 2) lode++;
                        else if ((int)PoleRect2[r, s].Tag == 3) pole.PoleLodi2[r, s] = 3;


                    }

                }


                Rec.Tag = 4;


                for (int r = 0; r < pole.PoleLodi2.GetLength(0); r++)
                {
                    for (int s = 0; s < pole.PoleLodi2.GetLength(1); s++)
                    {

                        if ((int)PoleRect2[r, s].Tag == 4)
                        {
                            if (PoleRect2[r, s].Fill == Brushes.White)
                            {


                                if ((int)PoleRect2[r, s].Tag == 3)
                                {
                                    indx = r;
                                    indy = s;

                                    PoleRect2[r, s].Tag = 3;
                                    pole.PoleLodi2[r, s] = 3;
                                    r--;

                                }

                                if (pole.PoleLodi2[r, s] == 2)
                                {
                                    PoleRect2[r, s].Tag = 9;
                                    pole.PoleLodi2[r, s] = 9;
                                    Uri hit;
                                    hit = new Uri("pack://application:,,,/Pictures/LodeHit.jpg");
                                    PoleRect2[r, s].Fill = new ImageBrush(new BitmapImage(hit));
                                }


                                if (pole.PoleLodi2[r, s] == 9)
                                {
                                    indx = r;
                                    indy = s;

                                    PoleRect2[r, s].Tag = 9;
                                    pole.PoleLodi2[r, s] = 9;
                                }

                                if (pole.PoleLodi2[r, s] == 1)
                                {
                                    indx = r;
                                    indy = s;

                                    PoleRect2[r, s].Tag = 1;
                                    pole.PoleLodi2[r, s] = 1;

                                    s--;


                                }

                                else if ((int)PoleRect2[r, s].Tag == 4)
                                {

                                    indx = r;
                                    indy = s;

                                    PoleRect2[r, s].Tag = 4;
                                    pole.PoleLodi2[r, s] = 4;




                                    if (PoleRect2[r, s].Fill == Brushes.White)
                                    {
                                        Uri miss;
                                        miss = new Uri("pack://application:,,,/Pictures/LodeMiss.jpg");
                                        PoleRect2[r, s].Fill = new ImageBrush(new BitmapImage(miss));


                                    }
                                }


                            }
                            else if (pole.PoleLodi2[r, s] == 2 || pole.PoleLodi2[r, s] == 5 || pole.PoleLodi2[r, s] == 6)
                            {

                                indx = r;
                                indy = s;

                                if (pole.PoleLodi2[r, s] == 2)
                                {
                                    PoleRect2[r, s].Tag = 2;
                                    pole.PoleLodi2[r, s] = 2;


                                }
                                else if (pole.PoleLodi2[r, s] == 5)
                                {
                                    PoleRect2[r, s].Tag = 5;
                                    pole.PoleLodi2[r, s] = 5;

                                }
                                else if (pole.PoleLodi2[r, s] == 6)
                                {
                                    PoleRect2[r, s].Tag = 6;
                                    pole.PoleLodi2[r, s] = 6;

                                }




                                if (pole.PoleLodi2[r, s] == 2)
                                {
                                    PoleRect2[r, s].Tag = 9;
                                    pole.PoleLodi2[r, s] = 9;
                                    Uri hit;
                                    hit = new Uri("pack://application:,,,/Pictures/LodeHit.jpg");
                                    PoleRect2[r, s].Fill = new ImageBrush(new BitmapImage(hit));
                                    lode--;


                                }

                                else if ((int)PoleRect2[r, s].Tag == 5)
                                {
                                    PoleRect2[r, s].Tag = 9;
                                    pole.PoleLodi2[r, s] = 9;
                                    Uri hit;
                                    hit = new Uri("pack://application:,,,/Pictures/LodeHit.jpg");
                                    PoleRect2[r, s].Fill = new ImageBrush(new BitmapImage(hit));
                                    lode--;

                                }


                                else if ((int)PoleRect2[r, s].Tag == 6)
                                {
                                    PoleRect2[r, s].Tag = 9;
                                    pole.PoleLodi2[r, s] = 9;
                                    Uri hit;
                                    hit = new Uri("pack://application:,,,/Pictures/LodeHit.jpg");
                                    PoleRect2[r, s].Fill = new ImageBrush(new BitmapImage(hit));
                                    lode--;

                                }

                            }


                        }

                    }
                    

                    PoleRect2[indx, indy].Tag = 3;


                }


            }

            int[] tmp = new int[12 * 12];
            int poradi = 0;
            for (int i = 0; i < 12; i++)
                for (int n = 0; n < 12; n++)
                {
                    tmp[poradi++] = pole.PoleLodi2[i, n];
                }
            client.WriteLineAndGetReply(Lode.SerializeXml<int[]>(tmp),new TimeSpan(0));
            
        }

    }


}







