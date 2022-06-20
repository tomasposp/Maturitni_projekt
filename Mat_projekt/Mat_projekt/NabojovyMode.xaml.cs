using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;

namespace Mat_projekt
{
    /// <summary>
    /// Interakční logika pro NabojovyMode.xaml
    /// </summary>
    
    public static class mode{
        public static Rectangle[,] poleRect;
        public static int[,] poleLodi = new int[12, 12]; // velikost pole
        public static int lode = 10;
        public static int naboje = 30;
        public static int score = 300;
    }
   

    public partial class NabojovyMode : Window
    {

        

        bool radar = false;
        bool airstrike = false;
       

        int indx;
        int indy;

        public NabojovyMode()
        {
            InitializeComponent();
            mode.naboje = 30;
            mode.score = 300;
            mode.lode = 10;
            ScoreLBL.Content = "Skóre: " + mode.score;
            Naboje.Content = mode.naboje;


            mode.poleRect = new Rectangle[12, 12];


            VytvoreniPanelu(mode.poleRect);

            Random rnd = new Random();

            for (int x = 0; x <= mode.lode -1; x++)
            {
                int cislo1 = rnd.Next(1, 11);
                int cislo2 = rnd.Next(1, 11);
                if (mode.poleLodi[cislo1, cislo2] == 2)
                {
                    x--; continue;
                }

            for (int i = 0; i < mode.poleLodi.GetLength(0); i++)
            {
                for (int y = 0; y < mode.poleLodi.GetLength(1); y++)
                {
                    if (i == 0 || i == 11)
                    {
                        mode.poleLodi[i, y] = 1;
                    }
                    else if (y == 0 || y == 11)
                    {
                        mode.poleLodi[i, y] = 1;
                    }
                    else if (mode.poleLodi[i,y] == 2)
                        {
                            mode.poleLodi[i, y] = 2;
                        }
                    else mode.poleLodi[i, y] = 0;
                    


                    if (mode.poleLodi[i, y] == 1)
                    {
                        indx = i;
                        indy = y;
                        mode.poleRect[i, y].Tag = 1;
                        mode.poleLodi[i, y] = 1;

                        mode.poleRect[i, y].Fill = Brushes.Blue;
                    }

                }
            }
          
            mode.poleLodi[cislo1, cislo2] = 2;
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

                    pole[row, col].MouseLeftButtonDown += MainWindow_MouseLeftButtonDown;

                    pole[row, col].StrokeThickness = 0.2;
                    pole[row, col].Stroke = Brushes.Black;
                    pole[row, col].Height = mrizka.Height / pole.GetLength(0);
                    pole[row, col].Width = mrizka.Width / pole.GetLength(1);
                    Grid.SetColumn(pole[row, col], col);
                    Grid.SetRow(pole[row, col], row);
                    Grid.SetZIndex(pole[row, col], 0);
                    mrizka.Children.Add(pole[row, col]);


                }

        }








        private void MainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

                if (sender is Rectangle Rec)
                {

                    for (int r = 0; r < mode.poleRect.GetLength(0); r++)
                    {
                        for (int s = 0; s < mode.poleRect.GetLength(1); s++)
                        {
                            if (mode.poleLodi[r, s] == 1) mode.poleRect[r, s].Tag = 1;
                            else if (mode.poleLodi[r, s] == 0) mode.poleRect[r, s].Tag = 0;
                            else if (mode.poleLodi[r, s] == 2) mode.poleRect[r, s].Tag = 2;
                            else if (mode.poleLodi[r, s] == 2) mode.lode++;
                            else if ((int)mode.poleRect[r, s].Tag == 3) mode.poleLodi[r, s] = 3;

                            

                        }
                        
                    }


                    
                    Rec.Tag = 4;


                    for (int r = 0; r < mode.poleLodi.GetLength(0); r++)
                    {
                        for (int s = 0; s < mode.poleLodi.GetLength(1); s++)
                        {

                            if ((int)mode.poleRect[r, s].Tag == 4)
                            {

                            if (mode.poleRect[r, s].Fill == Brushes.White)
                            {


                                if ((int)mode.poleRect[r, s].Tag == 3)
                                {
                                    indx = r;
                                    indy = s;

                                    mode.poleRect[r, s].Tag = 3;
                                    mode.poleLodi[r, s] = 3;
                                    r--;

                                }


                                if (mode.poleLodi[r, s] == 9)
                                {
                                    indx = r;
                                    indy = s;

                                    mode.poleRect[r, s].Tag = 9;
                                    mode.poleLodi[r, s] = 9;
                                }

                                if (mode.poleLodi[r, s] == 1)
                                {
                                    indx = r;
                                    indy = s;

                                    mode.poleRect[r, s].Tag = 1;
                                    mode.poleLodi[r, s] = 1;

                                   
                                       s--;
                                       mode.naboje--;

                                }

                                else if (mode.poleLodi[r, s] == 2)
                                {

                                    indx = r;
                                    indy = s;

                                    mode.poleRect[r, s].Tag = 2;
                                    mode.poleLodi[r, s] = 2;



                                    if ((int)mode.poleRect[r, s].Tag == 2)
                                    {
                                        Lode.Zasah(r,s);
                                        ScoreLBL.Content = "Skóre: " + mode.score;
                                        mode.naboje--;
                                    }

                                }




                                else if ((int)mode.poleRect[r, s].Tag == 4)
                                {

                                    indx = r;
                                    indy = s;

                                    mode.poleRect[r, s].Tag = 4;
                                    mode.poleLodi[r, s] = 4;

                                    mode.naboje--;


                                    if (mode.poleRect[r, s].Fill == Brushes.White)
                                    {

                                        Uri miss;
                                        miss = new Uri("pack://application:,,,/Pictures/lodeMiss.jpg");
                                        mode.poleRect[r, s].Fill = new ImageBrush(new BitmapImage(miss));
                                        

                                    }

                                }
                            }

                            if (radar && mode.poleRect[r, s].Fill != Brushes.Blue)
                            {
                                for (int i = -1; i <= 1; i++)
                                {
                                    for (int y = -1; y <=1; y++)
                                    {
                                        if (mode.poleRect[r + i, s + y].Fill == Brushes.White)
                                        {

                                        
                                        if ((int)mode.poleRect[r + i, s + y].Tag == 2)
                                        {
                                            Lode.Zasah(r + i, s + y);
                                            ScoreLBL.Content = "Skóre: " + mode.score;
                                        }
                                        else
                                        {
                                            Uri miss;
                                            miss = new Uri("pack://application:,,,/Pictures/lodeMiss.jpg");
                                            mode.poleRect[r + i, s + y].Fill = new ImageBrush(new BitmapImage(miss));
                                        }
                                        }
                                    }
                                }
 

                                radar = false;
                            }

                            if (airstrike && mode.poleRect[r, s].Fill != Brushes.Blue)
                            {

                                    for (int y = 1; y <= 11; y++)
                                    {
                                        if (mode.poleRect[r, y].Fill == Brushes.White)
                                        {
                                            if ((int)mode.poleRect[r, y].Tag == 2)
                                            {
                                                Lode.Zasah(r,  y);
                                                ScoreLBL.Content = "Skóre: " + mode.score;
                                                Console.WriteLine(mode.lode);
                                            }
                                            else
                                            {
                                                Uri miss;
                                                miss = new Uri("pack://application:,,,/Pictures/lodeMiss.jpg");
                                                mode.poleRect[r, y].Fill = new ImageBrush(new BitmapImage(miss));
                                            }
                                        }
                                    }
                                


                                airstrike = false;
                            }



                        }

                        }

                        mode.poleRect[indx, indy].Tag = 3;
                        
                        Naboje.Content = mode.naboje;

                    }


                }
            if (mode.lode <= 0)
            {

                FinalniScoreGrid.Visibility = Visibility.Visible;
                DispatcherTimer ScoreTimerAnimace = new DispatcherTimer();

                ScoreTimerAnimace.Tick += ScoreTimerAnimace_Tick;
                ScoreTimerAnimace.Interval = TimeSpan.FromMilliseconds(33);
                ScoreTimerAnimace.Start();
                mode.score += 1000;
                FinalniScoreLBL.Content = "Gratuluji, tvoje finální skóre je: " + mode.score;
            }
            if (mode.naboje == 0)
            {
                FinalniScoreGrid.Visibility = Visibility.Visible;
                DispatcherTimer ScoreTimerAnimace = new DispatcherTimer();

                ScoreTimerAnimace.Tick += ScoreTimerAnimace_Tick;
                ScoreTimerAnimace.Interval = TimeSpan.FromMilliseconds(33);
                ScoreTimerAnimace.Start();
                FinalniScoreLBL.Content = "Gratuluji, tvoje finální skóre je: " + mode.score;
            }

        }

        private void ScoreTimerAnimace_Tick(object sender, EventArgs e)
        {
            if (FinalniScoreGrid.Opacity < 1) FinalniScoreGrid.Opacity += 0.05;

        }

        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            Window1 win = new Window1();
            win.Top = this.Top;
            win.Left = this.Left;
            win.Show();
            this.Close();

        }

        private void RadarBtn_Click(object sender, RoutedEventArgs e)
        {
            if (mode.score >= 300)
            {
                mode.score -= 300;
                ScoreLBL.Content = "Skóre: " + mode.score;
                radar = true;
                
            }
        }

        private void NabojeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (mode.score >= 500)
            {
                mode.score -= 500;
                ScoreLBL.Content = "Skóre: " + mode.score;
                mode.naboje += 10;
                Naboje.Content = mode.naboje;
               
            }
            
        }

        private void AirstrikeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (mode.score >= 400)
            {
                mode.score -= 400;
                ScoreLBL.Content = "Skóre: " + mode.score;
                airstrike = true;
            }
        }
    }

}

