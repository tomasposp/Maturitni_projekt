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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Mat_projekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public static class pole
    {

        public static int[,] PoleLodi = new int[12, 12]; // velikost pole
        public static int[,] PoleLodi2 = new int[12, 12]; // velikost pole
        public static int cislo1;
        public static int cislo2;
    }

    public partial class MainWindow : Window
    {
        int lode = 0;
        bool zapnuty = false;
        int lode2 = 0;
        bool JednaLod = false;
        bool DveLode = false;
        bool TriLode = false;
        int jednicka = 5;
        int dvojka = 3;
        int trojka = 1;
        bool otoceni = false;
        bool mazani = false;
        int jednotka;
        int dvojovka;
        int trojovka;
        int a = 0;
        int b = 0;
        int jednotka1;
        int dvojovka1;
        int trojovka1;
        int dva;
        int tri;
        int dvaPC;
        int triPC;





        Rectangle[,] PoleRect;
        Rectangle[,] PoleRect2;

        int indx;
        int indx2;

        int indy;
        int indy2;

        public MainWindow()
        {
            Random rnd = new Random();


            int cislo3 = rnd.Next(1, 11);
            int cislo4 = rnd.Next(1, 11);




            InitializeComponent();


            PoleRect = new Rectangle[12, 12];
            PoleRect2 = new Rectangle[12, 12];

            VytvoreniPanelu(PoleRect);


            for (int i = 0; i < pole.PoleLodi.GetLength(0); i++)
            {
                for (int y = 0; y < pole.PoleLodi.GetLength(1); y++)
                {
                    if (i == 0 || i == 11)
                    {
                        pole.PoleLodi[i, y] = 1;
                    }
                    else if (y == 0 || y == 11)
                    {
                        pole.PoleLodi[i, y] = 1;
                    }
                    else pole.PoleLodi[i, y] = 0;
                    // Console.Write(pole.PoleLodi[i, y]);


                    if (pole.PoleLodi[i, y] == 1)
                    {
                        indx = i;
                        indy = y;
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
                        indx2 = i;
                        indy2 = y;
                        PoleRect2[i, y].Tag = 1;
                        pole.PoleLodi2[i, y] = 1;

                        PoleRect2[i, y].Fill = Brushes.Blue;
                    }

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
                    pole[row,col].StrokeThickness = 0.2;
                    pole[row, col].Stroke = Brushes.Black;
                    pole[row, col].MouseLeftButtonDown += MainWindow_MouseLeftButtonDown;


                   
                    pole[row, col].Height = mrizka.Height / pole.GetLength(0);
                    pole[row, col].Width = mrizka.Width / pole.GetLength(1);
                    Grid.SetColumn(pole[row, col], col);
                    Grid.SetRow(pole[row, col], row);
                    Grid.SetZIndex(pole[row, col], 0);
                    mrizka.Children.Add(pole[row, col]);



                }
            mrizka.Visibility = Visibility.Hidden;
        }
        

        private void Start_Click(object sender, RoutedEventArgs e)
        {

            zapnuty = true;

            Start.IsEnabled = false;
            Start_LBL.IsEnabled = false;
            Start_LBL.Visibility = Visibility.Hidden;
            Start.Visibility = Visibility.Hidden;
            Delete.Visibility = Visibility.Hidden;
            Delete_LBL.Visibility = Visibility.Hidden;
            SingleLod.Visibility = Visibility.Hidden;
            SingleLod_LBL.Visibility = Visibility.Hidden;
            DoubleLod.Visibility = Visibility.Hidden;
            DoubleLod_LBL.Visibility = Visibility.Hidden;
            TripleLod.Visibility = Visibility.Hidden;
            TripleLod_LBL.Visibility = Visibility.Hidden;
            Napoveda.Visibility = Visibility.Visible;
            JednickovalodPC.Content = jednotka;
            DvojkovalodPC.Content = dvojovka;
            TrojkovalodPC.Content = trojovka;
            JednickovalodHrac.Content = jednotka;
            DvojkovalodHrac.Content = dvojovka;
            TrojkovalodHrac.Content = trojovka;
            JednickovalodHrac.Visibility = Visibility.Visible;
            DvojkovalodHrac.Visibility = Visibility.Visible;
            TrojkovalodHrac.Visibility = Visibility.Visible;
            JednickovaLodPoStartu.Visibility = Visibility.Visible;
            JednickovaLodPredStartem.Visibility = Visibility.Hidden;
            DvojkovaLodPoStartu.Visibility = Visibility.Visible;
            DvojkovaLodPredStartem.Visibility = Visibility.Hidden;
            TrojkovaLodPoStartu.Visibility = Visibility.Visible;
            TrojkovaLodPredStartem.Visibility = Visibility.Hidden;
            JednickovalodPC.Visibility = Visibility.Hidden;
            DvojkovalodPC.Visibility = Visibility.Hidden;
            TrojkovalodPC.Visibility = Visibility.Hidden;


            jednotka1 = jednotka;
            dvojovka1 = dvojovka;
            trojovka1 = trojovka;
            dva = dvojovka1 * 2;
            tri = trojovka1 * 3;
            dvaPC = dvojovka * 2;
            triPC = trojovka * 3;

            mrizka.Visibility = Visibility.Visible;
            mrizka2.Width = 120;
            mrizka2.Height = 120;
            mrizka2.Margin = new Thickness(69, 61, 597, 232);
            mrizka.Width = 300;
            mrizka.Height = 300;
            mrizka.Margin = new Thickness(244, 61, 239, 38);


            if (trojovka > 0)
            {
                for (int i = 0; i < trojovka; i++)
                {
                    Random rnd = new Random();
                    pole.cislo1 = rnd.Next(2, 10);
                    pole.cislo2 = rnd.Next(2, 10);
                    int otocka = rnd.Next(0, 2);

                    if (otocka == 1)
                    {
                        while (true)
                        {

                            if (Lode.TriMetoda())
                            {
                                pole.cislo1 = rnd.Next(2, 10);
                                pole.cislo2 = rnd.Next(2, 10);

                            }
                            else
                            {
                                PoleRect[pole.cislo1, pole.cislo2].Tag = 6;
                                pole.PoleLodi[pole.cislo1, pole.cislo2] = 6;
                                PoleRect[pole.cislo1 + 1, pole.cislo2].Tag = 6;
                                pole.PoleLodi[pole.cislo1 + 1, pole.cislo2] = 6;
                                PoleRect[pole.cislo1 - 1, pole.cislo2].Tag = 6;
                                pole.PoleLodi[pole.cislo1 - 1, pole.cislo2] = 6;
                                Uri lod;
                                lod = new Uri("pack://application:,,,/Pictures/SecretLod.PNG");
                                PoleRect[pole.cislo1, pole.cislo2].Fill = new ImageBrush(new BitmapImage(lod));
                                PoleRect[pole.cislo1 + 1, pole.cislo2].Fill = new ImageBrush(new BitmapImage(lod));
                                PoleRect[pole.cislo1 - 1, pole.cislo2].Fill = new ImageBrush(new BitmapImage(lod));
                                lode = lode + 3;

                                break;
                            }

                        }
                    }

                    if (otocka == 0)
                    {


                        while (true)
                        {
                            if (Lode.TriMetodaNeotocena())
                            {
                                pole.cislo1 = rnd.Next(2, 10);
                                pole.cislo2 = rnd.Next(2, 10);
                            }
                            else
                            {
                                PoleRect[pole.cislo1, pole.cislo2].Tag = 6;
                                pole.PoleLodi[pole.cislo1, pole.cislo2] = 6;
                                PoleRect[pole.cislo1, pole.cislo2 + 1].Tag = 6;
                                pole.PoleLodi[pole.cislo1, pole.cislo2 + 1] = 6;
                                PoleRect[pole.cislo1, pole.cislo2 - 1].Tag = 6;
                                pole.PoleLodi[pole.cislo1, pole.cislo2 - 1] = 6;
                                Uri lod;
                                lod = new Uri("pack://application:,,,/Pictures/SecretLod.PNG");
                                PoleRect[pole.cislo1, pole.cislo2].Fill = new ImageBrush(new BitmapImage(lod));
                                PoleRect[pole.cislo1, pole.cislo2 + 1].Fill = new ImageBrush(new BitmapImage(lod));
                                PoleRect[pole.cislo1, pole.cislo2 - 1].Fill = new ImageBrush(new BitmapImage(lod));
                                lode = lode + 3;

                                break;
                            }
                        }
                    }

                    if (trojka == 0)
                    {
                        DoubleLod.IsEnabled = false;
                        DoubleLod_LBL.IsEnabled = false;
                        DveLode = false;
                    }

                }
            }


            if (dvojovka > 0)
            {

                for (int i = 0; i < dvojovka; i++)
                {
                    Random rnd = new Random();
                    pole.cislo1 = rnd.Next(2, 11);
                    pole.cislo2 = rnd.Next(1, 11);
                    int otocka = rnd.Next(0, 2);
                    if (otocka == 1)
                    {
                        while (true)
                        {

                            if (Lode.DvaMetoda())
                            {
                                pole.cislo1 = rnd.Next(2, 11);
                                pole.cislo2 = rnd.Next(1, 11);

                            }
                            else
                            {
                                PoleRect[pole.cislo1, pole.cislo2].Tag = 5;
                                pole.PoleLodi[pole.cislo1, pole.cislo2] = 5;
                                PoleRect[pole.cislo1 - 1, pole.cislo2].Tag = 5;
                                pole.PoleLodi[pole.cislo1 - 1, pole.cislo2] = 5;
                                Uri lod;
                                lod = new Uri("pack://application:,,,/Pictures/SecretLod.PNG");
                                PoleRect[pole.cislo1, pole.cislo2].Fill = new ImageBrush(new BitmapImage(lod));
                                PoleRect[pole.cislo1 - 1, pole.cislo2].Fill = new ImageBrush(new BitmapImage(lod));
                                lode = lode + 2;

                                break;
                            }

                        }
                    }

                    if (otocka == 0)
                    {


                        while (true)
                        {
                            if (Lode.DvaMetodaNeotocena())
                            {
                                pole.cislo1 = rnd.Next(2, 11);
                                pole.cislo2 = rnd.Next(1, 11);
                            }
                            else
                            {

                                PoleRect[pole.cislo1, pole.cislo2].Tag = 5;
                                pole.PoleLodi[pole.cislo1, pole.cislo2] = 5;
                                PoleRect[pole.cislo1, pole.cislo2 - 1].Tag = 5;
                                pole.PoleLodi[pole.cislo1, pole.cislo2 - 1] = 5;
                                Uri lod;
                                lod = new Uri("pack://application:,,,/Pictures/SecretLod.PNG");
                                PoleRect[pole.cislo1, pole.cislo2].Fill = new ImageBrush(new BitmapImage(lod));
                                PoleRect[pole.cislo1, pole.cislo2 - 1].Fill = new ImageBrush(new BitmapImage(lod));
                                lode = lode + 2;
                                break;
                            }
                        }
                    }

                    if (dvojka == 0)
                    {
                        DoubleLod.IsEnabled = false;
                        DoubleLod_LBL.IsEnabled = false;
                        DveLode = false;
                    }

                }
            }


            if (jednotka > 0)
            {
                for (int i = 0; i < jednotka; i++)
                {

                    Random rnd = new Random();
                    pole.cislo1 = rnd.Next(1, 11);
                    pole.cislo2 = rnd.Next(1, 11);
                    while (true)
                    {

                       
                        if (Lode.JednaMetoda())
                        {
                            pole.cislo1 = rnd.Next(1, 11);
                            pole.cislo2 = rnd.Next(1, 11);
                        }
                        else
                        {
                            PoleRect[pole.cislo1, pole.cislo2].Tag = 2;
                            pole.PoleLodi[pole.cislo1, pole.cislo2] = 2;
                            Uri lod;
                            lod = new Uri("pack://application:,,,/Pictures/SecretLod.PNG");
                            PoleRect[pole.cislo1, pole.cislo2].Fill = new ImageBrush(new BitmapImage(lod));
                            lode++;
                            break;

                        }

                    }
                }

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

                    pole2[row, col].MouseLeftButtonDown += MainWindow_MouseLeftButtonDown;
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







        private void MainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (zapnuty == false)
            {

                if (sender is Rectangle Rec)
                {

                    for (int r = 0; r < PoleRect2.GetLength(0); r++)
                    {
                        for (int s = 0; s < PoleRect2.GetLength(1); s++)
                        {
                            if (pole.PoleLodi2[r, s] == 1) PoleRect2[r, s].Tag = 1;
                            else if (pole.PoleLodi2[r, s] == 0) PoleRect2[r, s].Tag = 0;
                            else if (pole.PoleLodi2[r, s] == 2) PoleRect2[r, s].Tag = 2;
                            else if ((int)PoleRect2[r, s].Tag == 3) pole.PoleLodi2[r, s] = 3;

                            

                        }

                    }

                    Rec.Tag = 4;
                   

                    for (int r = 0; r < pole.PoleLodi2.GetLength(0); r++)
                    {
                        Console.WriteLine();
                        for (int s = 0; s < pole.PoleLodi2.GetLength(1); s++)
                        {

                            if ((int)PoleRect2[r, s].Tag == 4)
                            {

                                if (JednaLod == true)
                                {
                                    if (pole.PoleLodi2[r, s] == 0)
                                    {
                                        if (pole.PoleLodi2[r - 1, s] != 2 &&
                                            pole.PoleLodi2[r + 1, s] != 2 &&
                                            pole.PoleLodi2[r, s - 1] != 2 &&
                                            pole.PoleLodi2[r, s + 1] != 2 &&
                                            pole.PoleLodi2[r - 1, s] != 5 &&
                                            pole.PoleLodi2[r + 1, s] != 5 &&
                                            pole.PoleLodi2[r, s - 1] != 5 &&
                                            pole.PoleLodi2[r, s + 1] != 5 &&
                                            pole.PoleLodi2[r - 1, s] != 6 &&
                                            pole.PoleLodi2[r + 1, s] != 6 &&
                                            pole.PoleLodi2[r, s - 1] != 6 &&
                                            pole.PoleLodi2[r, s + 1] != 6)
                                        {
                                            PoleRect2[r, s].Tag = 2;
                                            pole.PoleLodi2[r, s] = 2;
                                            Uri lod;
                                            lod = new Uri("pack://application:,,,/Pictures/JednickovaLod.jpg");
                                            PoleRect2[r, s].Fill = new ImageBrush(new BitmapImage(lod));

                                            lode2++;
                                            jednicka--;
                                            jednotka++;

                                        }


                                        if (jednicka == 0)
                                        {
                                            SingleLod.IsEnabled = false;
                                            SingleLod_LBL.IsEnabled = false;
                                            JednaLod = false;
                                        }
                                    }


                                }

                                else if (DveLode == true)
                                {

                                    if (pole.PoleLodi2[r, s] == 0)
                                    {

                                        if (otoceni == true)
                                        {
                                            if (pole.PoleLodi2[r - 1, s] != 1 && pole.PoleLodi2[r, s] == 0)
                                            {


                                                if (pole.PoleLodi2[r - 1, s] != 5 &&
                                                    pole.PoleLodi2[r + 1, s] != 5 &&
                                                    pole.PoleLodi2[r - 2, s] != 5 &&
                                                    pole.PoleLodi2[r, s - 1] != 5 &&
                                                    pole.PoleLodi2[r, s + 1] != 5 &&
                                                    pole.PoleLodi2[r + 1, s + 1] != 5 &&
                                                    pole.PoleLodi2[r - 1, s + 1] != 5 &&
                                                    pole.PoleLodi2[r + 1, s - 1] != 5 &&
                                                    pole.PoleLodi2[r - 1, s - 1] != 5 &&
                                                    pole.PoleLodi2[r - 1, s] != 2 &&
                                                    pole.PoleLodi2[r + 1, s] != 2 &&
                                                    pole.PoleLodi2[r - 2, s] != 2 &&
                                                    pole.PoleLodi2[r, s - 1] != 2 &&
                                                    pole.PoleLodi2[r, s + 1] != 2 &&
                                                    pole.PoleLodi2[r + 1, s + 1] != 2 &&
                                                    pole.PoleLodi2[r - 1, s + 1] != 2 &&
                                                    pole.PoleLodi2[r + 1, s - 1] != 2 &&
                                                    pole.PoleLodi2[r - 1, s - 1] != 2 &&
                                                    pole.PoleLodi2[r - 1, s] != 6 &&
                                                    pole.PoleLodi2[r + 1, s] != 6 &&
                                                    pole.PoleLodi2[r - 2, s] != 6 &&
                                                    pole.PoleLodi2[r, s - 1] != 6 &&
                                                    pole.PoleLodi2[r, s + 1] != 6 &&
                                                    pole.PoleLodi2[r + 1, s + 1] != 6 &&
                                                    pole.PoleLodi2[r - 1, s + 1] != 6 &&
                                                    pole.PoleLodi2[r + 1, s - 1] != 6 &&
                                                    pole.PoleLodi2[r - 1, s - 1] != 6)
                                                {
                                                    PoleRect2[r, s].Tag = 5;
                                                    pole.PoleLodi2[r, s] = 5;
                                                    PoleRect2[r - 1, s].Tag = 5;
                                                    pole.PoleLodi2[r - 1, s] = 5;
                                                    Uri lod;
                                                    Uri lod1;
                                                    lod = new Uri("pack://application:,,,/Pictures/LodPredek_nahoru.jpg");
                                                    lod1 = new Uri("pack://application:,,,/Pictures/LodZada_nahoru.jpg");
                                                    PoleRect2[r, s].Fill = new ImageBrush(new BitmapImage(lod1));
                                                    PoleRect2[r - 1, s].Fill = new ImageBrush(new BitmapImage(lod));

                                                    lode2 = lode2 + 2;
                                                    dvojka--;
                                                    dvojovka++;
                                                }


                                                if (dvojka == 0)
                                                {
                                                    DoubleLod.IsEnabled = false;
                                                    DoubleLod_LBL.IsEnabled = false;
                                                    DveLode = false;
                                                }
                                            }


                                        }
                                        else if (pole.PoleLodi2[r, s - 1] != 1 && pole.PoleLodi2[r, s] == 0)
                                        {
                                            if (pole.PoleLodi2[r - 1, s] != 5 &&
                                                pole.PoleLodi2[r + 1, s] != 5 &&
                                                pole.PoleLodi2[r, s - 2] != 5 &&
                                                pole.PoleLodi2[r, s - 1] != 5 &&
                                                pole.PoleLodi2[r, s + 1] != 5 &&
                                                pole.PoleLodi2[r + 1, s + 1] != 5 &&
                                                pole.PoleLodi2[r - 1, s + 1] != 5 &&
                                                pole.PoleLodi2[r + 1, s - 1] != 5 &&
                                                pole.PoleLodi2[r - 1, s - 1] != 5 &&
                                                pole.PoleLodi2[r - 1, s] != 2 &&
                                                pole.PoleLodi2[r + 1, s] != 2 &&
                                                pole.PoleLodi2[r, s - 2] != 2 &&
                                                pole.PoleLodi2[r, s - 1] != 2 &&
                                                pole.PoleLodi2[r, s + 1] != 2 &&
                                                pole.PoleLodi2[r + 1, s + 1] != 2 &&
                                                pole.PoleLodi2[r - 1, s + 1] != 2 &&
                                                pole.PoleLodi2[r + 1, s - 1] != 2 &&
                                                pole.PoleLodi2[r - 1, s - 1] != 2 &&
                                                pole.PoleLodi2[r - 1, s] != 6 &&
                                                pole.PoleLodi2[r + 1, s] != 6 &&
                                                pole.PoleLodi2[r, s - 2] != 6 &&
                                                pole.PoleLodi2[r, s - 1] != 6 &&
                                                pole.PoleLodi2[r, s + 1] != 6 &&
                                                pole.PoleLodi2[r + 1, s + 1] != 6 &&
                                                pole.PoleLodi2[r - 1, s + 1] != 6 &&
                                                pole.PoleLodi2[r + 1, s - 1] != 6 &&
                                                pole.PoleLodi2[r - 1, s - 1] != 6)
                                            {


                                                PoleRect2[r, s].Tag = 5;
                                                pole.PoleLodi2[r, s] = 5;
                                                PoleRect2[r, s - 1].Tag = 5;
                                                pole.PoleLodi2[r, s - 1] = 5;
                                                Uri lod;
                                                Uri lod1;
                                                lod = new Uri("pack://application:,,,/Pictures/LodPredek.jpg");
                                                lod1 = new Uri("pack://application:,,,/Pictures/LodZada.jpg");
                                                PoleRect2[r, s].Fill = new ImageBrush(new BitmapImage(lod1));
                                                PoleRect2[r, s - 1].Fill = new ImageBrush(new BitmapImage(lod));
                                                lode2 = lode2 + 2;
                                                dvojka--;
                                                dvojovka++;
                                            }




                                            if (dvojka == 0)
                                            {
                                                DoubleLod.IsEnabled = false;
                                                DoubleLod_LBL.IsEnabled = false;
                                                DveLode = false;
                                            }
                                        }

                                    }
                                }

                                else if (TriLode == true)
                                {
                                    if (pole.PoleLodi2[r, s] == 0)
                                    {
                                        Random rnd = new Random();
                                        int cislo1 = rnd.Next(1, 11);
                                        int cislo2 = rnd.Next(1, 11);


                                        if (otoceni == true)
                                        {
                                            if (pole.PoleLodi2[r - 1, s] == 1)
                                            {
                                                pole.PoleLodi2[r - 1, s] = 1;
                                            }
                                            else if (pole.PoleLodi2[r + 1, s] == 1)
                                            {
                                                pole.PoleLodi2[r + 1, s] = 1;
                                            }

                                            if (pole.PoleLodi2[r - 1, s] != 2 &&
                                                pole.PoleLodi2[r + 1, s] != 2 &&

                                                pole.PoleLodi2[r - 1, s] != 5 &&
                                                pole.PoleLodi2[r + 1, s] != 5 &&


                                                pole.PoleLodi2[r - 1, s] != 1 &&
                                                pole.PoleLodi2[r + 1, s] != 1 

                                                )
                                            {
                                                PoleRect2[r, s].Tag = 6;
                                                pole.PoleLodi2[r, s] = 6;
                                                PoleRect2[r + 1, s].Tag = 6;
                                                pole.PoleLodi2[r + 1, s] = 6;
                                                PoleRect2[r - 1, s].Tag = 6;
                                                pole.PoleLodi2[r - 1, s] = 6;


                                                Uri lod;
                                                Uri lod1;
                                                Uri lod2;
                                                lod = new Uri("pack://application:,,,/Pictures/LodPredek_nahoru.jpg");
                                                lod1 = new Uri("pack://application:,,,/Pictures/LodZada_Nahoru.jpg");
                                                lod2 = new Uri("pack://application:,,,/Pictures/LodStred_nahoru.jpg");
                                                PoleRect2[r, s].Fill = new ImageBrush(new BitmapImage(lod2));
                                                PoleRect2[r - 1, s].Fill = new ImageBrush(new BitmapImage(lod));
                                                PoleRect2[r + 1, s].Fill = new ImageBrush(new BitmapImage(lod1));
                                                lode2 = lode2 + 3;
                                                trojka--;
                                                trojovka++;
                                            }






                                            if (trojka == 0)
                                            {
                                                TripleLod.IsEnabled = false;
                                                TripleLod_LBL.IsEnabled = false;
                                                TriLode = false;
                                            }
                                        }

                                        else
                                        {

                                            if (pole.PoleLodi2[r, s - 1] == 1)
                                            {
                                                pole.PoleLodi2[r, s - 1] = 1;
                                            }
                                            else if (pole.PoleLodi2[r, s + 1] == 1)
                                            {
                                                pole.PoleLodi2[r, s + 1] = 1;
                                            }
                                            else if (pole.PoleLodi2[r - 1, s] != 2 &&
                                                    pole.PoleLodi2[r + 1, s] != 2 &&
                                                    pole.PoleLodi2[r, s - 2] != 2 &&
                                                    pole.PoleLodi2[r, s - 1] != 2 &&
                                                    pole.PoleLodi2[r, s + 1] != 2 &&
                                                    pole.PoleLodi2[r + 1, s + 1] != 2 &&
                                                    pole.PoleLodi2[r - 1, s + 1] != 2 &&
                                                    pole.PoleLodi2[r + 1, s - 1] != 2 &&
                                                    pole.PoleLodi2[r - 1, s - 1] != 2 &&
                                                    pole.PoleLodi2[r, s - 2] != 2 &&
                                                    pole.PoleLodi2[r, s + 2] != 2 &&
                                                    pole.PoleLodi2[r - 1, s] != 5 &&
                                                    pole.PoleLodi2[r + 1, s] != 5 &&
                                                    pole.PoleLodi2[r, s - 2] != 5 &&
                                                    pole.PoleLodi2[r, s - 1] != 5 &&
                                                    pole.PoleLodi2[r, s + 1] != 5 &&
                                                    pole.PoleLodi2[r + 1, s + 1] != 5 &&
                                                    pole.PoleLodi2[r - 1, s + 1] != 5 &&
                                                    pole.PoleLodi2[r + 1, s - 1] != 5 &&
                                                    pole.PoleLodi2[r - 1, s - 1] != 5 &&
                                                    pole.PoleLodi2[r, s - 2] != 5 &&
                                                    pole.PoleLodi2[r, s + 2] != 5 
                                                    )
                                            {


                                                PoleRect2[r, s].Tag = 6;
                                                pole.PoleLodi2[r, s] = 6;
                                                PoleRect2[r, s + 1].Tag = 6;
                                                pole.PoleLodi2[r, s + 1] = 6;
                                                PoleRect2[r, s - 1].Tag = 6;
                                                pole.PoleLodi2[r, s - 1] = 6;
                                                Uri lod;
                                                Uri lod1;
                                                Uri lod2;
                                                lod = new Uri("pack://application:,,,/Pictures/LodPredek.jpg");
                                                lod1 = new Uri("pack://application:,,,/Pictures/LodZada.jpg");
                                                lod2 = new Uri("pack://application:,,,/Pictures/LodStred.jpg");
                                                PoleRect2[r, s].Fill = new ImageBrush(new BitmapImage(lod2));
                                                PoleRect2[r, s - 1].Fill = new ImageBrush(new BitmapImage(lod));
                                                PoleRect2[r, s + 1].Fill = new ImageBrush(new BitmapImage(lod1));
                                                lode2 = lode2 + 3;
                                                trojka--;
                                                trojovka++;
                                            }


                                            if (trojka == 0)
                                            {
                                                TripleLod.IsEnabled = false;
                                                TripleLod_LBL.IsEnabled = false;
                                                TriLode = false;
                                            }
                                        }

                                    }
                                }

                                if (mazani == true)
                                {
                                    if (pole.PoleLodi2[r, s] == 2)
                                    {
                                        PoleRect2[r, s].Tag = 0;
                                        pole.PoleLodi2[r, s] = 0;
                                        PoleRect2[r, s].Fill = Brushes.White;
                                        lode2--;
                                        jednicka++;
                                        jednotka--;

                                        if (jednicka > 0)
                                        {
                                            SingleLod.IsEnabled = true;
                                            SingleLod_LBL.IsEnabled = true;
                                            JednaLod = true;
                                            
                                        }

                                    }

                                    else if (pole.PoleLodi2[r, s] == 5)
                                    {
                                        PoleRect2[r, s].Tag = 0;
                                        pole.PoleLodi2[r, s] = 0;
                                        PoleRect2[r, s].Fill = Brushes.White;
                                        if (pole.PoleLodi2[r - 1, s] == 5)
                                        {
                                            PoleRect2[r - 1, s].Tag = 0;
                                            pole.PoleLodi2[r - 1, s] = 0;
                                            PoleRect2[r - 1, s].Fill = Brushes.White;
                                        }
                                        else if (pole.PoleLodi2[r + 1, s] == 5)
                                        {
                                            PoleRect2[r + 1, s].Tag = 0;
                                            pole.PoleLodi2[r + 1, s] = 0;
                                            PoleRect2[r + 1, s].Fill = Brushes.White;
                                        }
                                        else if (pole.PoleLodi2[r, s + 1] == 5)
                                        {
                                            PoleRect2[r, s + 1].Tag = 0;
                                            pole.PoleLodi2[r, s + 1] = 0;
                                            PoleRect2[r, s + 1].Fill = Brushes.White;
                                        }
                                        else if (pole.PoleLodi2[r, s - 1] == 5)
                                        {
                                            PoleRect2[r, s - 1].Tag = 0;
                                            pole.PoleLodi2[r, s - 1] = 0;
                                            PoleRect2[r, s - 1].Fill = Brushes.White;
                                        }

                                        lode2 = lode2-2;
                                        dvojka++;
                                        dvojovka--;

                                        if (dvojka > 0)
                                        {
                                            DoubleLod.IsEnabled = true;
                                            DoubleLod_LBL.IsEnabled = true;
                                            DveLode = true;
                                        }
                                    }




                                    else if (pole.PoleLodi2[r, s] == 6)
                                    {
                                        
                                        if (pole.PoleLodi2[r + 1, s] == 1)
                                        {
                                            if (pole.PoleLodi2[r, s + 2] == 6)
                                            {
                                                PoleRect2[r, s + 2].Tag = 0;
                                                pole.PoleLodi2[r, s + 2] = 0;
                                                PoleRect2[r, s + 2].Fill = Brushes.White;
                                            }
                                            if (pole.PoleLodi2[r, s - 2] == 6)
                                            {
                                                PoleRect2[r, s - 2].Tag = 0;
                                                pole.PoleLodi2[r, s - 2] = 0;
                                                PoleRect2[r, s - 2].Fill = Brushes.White;
                                            }
                                            if (pole.PoleLodi2[r - 2, s] == 6)
                                            {
                                                PoleRect2[r - 2, s].Tag = 0;
                                                pole.PoleLodi2[r - 2, s] = 0;
                                                PoleRect2[r - 2, s].Fill = Brushes.White;
                                            }
                                        }
                                        else if (pole.PoleLodi2[r - 1, s] == 1)
                                        {
                                            if (pole.PoleLodi2[r, s + 2] == 6)
                                            {
                                                PoleRect2[r, s + 2].Tag = 0;
                                                pole.PoleLodi2[r, s + 2] = 0;
                                                PoleRect2[r, s + 2].Fill = Brushes.White;
                                            }
                                            if (pole.PoleLodi2[r, s - 2] == 6)
                                            {
                                                PoleRect2[r, s - 2].Tag = 0;
                                                pole.PoleLodi2[r, s - 2] = 0;
                                                PoleRect2[r, s - 2].Fill = Brushes.White;
                                            }
                                            if (pole.PoleLodi2[r + 2, s] == 6)
                                            {
                                                PoleRect2[r + 2, s].Tag = 0;
                                                pole.PoleLodi2[r + 2, s] = 0;
                                                PoleRect2[r + 2, s].Fill = Brushes.White;
                                            }
                                        }
                                        else if (pole.PoleLodi2[r , s + 1] == 1)
                                        {
                                            if (pole.PoleLodi2[r + 2, s] == 6)
                                            {
                                                PoleRect2[r + 2, s].Tag = 0;
                                                pole.PoleLodi2[r + 2, s] = 0;
                                                PoleRect2[r + 2, s].Fill = Brushes.White;
                                            }
                                            if (pole.PoleLodi2[r, s - 2] == 6)
                                            {
                                                PoleRect2[r, s - 2].Tag = 0;
                                                pole.PoleLodi2[r, s - 2] = 0;
                                                PoleRect2[r, s - 2].Fill = Brushes.White;
                                            }
                                            if (pole.PoleLodi2[r - 2, s] == 6)
                                            {
                                                PoleRect2[r - 2, s].Tag = 0;
                                                pole.PoleLodi2[r - 2, s] = 0;
                                                PoleRect2[r - 2, s].Fill = Brushes.White;
                                            }
                                        }
                                        else if (pole.PoleLodi2[r, s - 1] == 1)
                                        {
                                            if (pole.PoleLodi2[r + 2, s] == 6)
                                            {
                                                PoleRect2[r + 2, s].Tag = 0;
                                                pole.PoleLodi2[r + 2, s] = 0;
                                                PoleRect2[r + 2, s].Fill = Brushes.White;
                                            }
                                            if (pole.PoleLodi2[r, s + 2] == 6)
                                            {
                                                PoleRect2[r, s + 2].Tag = 0;
                                                pole.PoleLodi2[r, s + 2] = 0;
                                                PoleRect2[r, s + 2].Fill = Brushes.White;
                                            }
                                            if (pole.PoleLodi2[r - 2, s] == 6)
                                            {
                                                PoleRect2[r - 2, s].Tag = 0;
                                                pole.PoleLodi2[r - 2, s] = 0;
                                                PoleRect2[r - 2, s].Fill = Brushes.White;
                                            }
                                        }

                                        else
                                        {
                                            if (pole.PoleLodi2[r - 2, s] == 6)
                                            {
                                                PoleRect2[r - 2, s].Tag = 0;
                                                pole.PoleLodi2[r - 2, s] = 0;
                                                PoleRect2[r - 2, s].Fill = Brushes.White;
                                            }
                                            if (pole.PoleLodi2[r + 2, s] == 6)
                                            {
                                                PoleRect2[r + 2, s].Tag = 0;
                                                pole.PoleLodi2[r + 2, s] = 0;
                                                PoleRect2[r + 2, s].Fill = Brushes.White;
                                            }
                                            if (pole.PoleLodi2[r, s - 2] == 6)
                                            {
                                                PoleRect2[r, s - 2].Tag = 0;
                                                pole.PoleLodi2[r, s - 2] = 0;
                                                PoleRect2[r, s - 2].Fill = Brushes.White;
                                            }
                                            if (pole.PoleLodi2[r, s + 2] == 6)
                                            {
                                                PoleRect2[r, s + 2].Tag = 0;
                                                pole.PoleLodi2[r, s + 2] = 0;
                                                PoleRect2[r, s + 2].Fill = Brushes.White;
                                            }
                                        }

                                        PoleRect2[r, s].Tag = 0;
                                        pole.PoleLodi2[r, s] = 0;
                                        PoleRect2[r, s].Fill = Brushes.White;
                                        if (pole.PoleLodi2[r - 1, s] == 6)
                                        {
                                            PoleRect2[r - 1, s].Tag = 0;
                                            pole.PoleLodi2[r - 1, s] = 0;
                                            PoleRect2[r - 1, s].Fill = Brushes.White;
                                        }
                                        if (pole.PoleLodi2[r + 1, s] == 6)
                                        {
                                            PoleRect2[r + 1, s].Tag = 0;
                                            pole.PoleLodi2[r + 1, s] = 0;
                                            PoleRect2[r + 1, s].Fill = Brushes.White;
                                        }
                                        if (pole.PoleLodi2[r, s + 1] == 6)
                                        {
                                            PoleRect2[r, s + 1].Tag = 0;
                                            pole.PoleLodi2[r, s + 1] = 0;
                                            PoleRect2[r, s + 1].Fill = Brushes.White;
                                        }
                                        if (pole.PoleLodi2[r, s - 1] == 6)
                                        {
                                            PoleRect2[r, s - 1].Tag = 0;
                                            pole.PoleLodi2[r, s - 1] = 0;
                                            PoleRect2[r, s - 1].Fill = Brushes.White;
                                        }





                                        lode2 = lode2-3;
                                        trojka++;
                                        trojovka--;

                                        if (trojka > 0)
                                        {
                                            TripleLod.IsEnabled = true;
                                            TripleLod_LBL.IsEnabled = true;
                                            TriLode = true;
                                        }
                                    }
                                }
                            }
                            Console.Write(pole.PoleLodi2[r, s]);
                            Console.Write(" ");
                        }
                    }
                }
            }


            else if (zapnuty == true)
            {
                

                if (sender is Rectangle Rec)
                {

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

                                    if ((int)PoleRect[r, s].Tag == 2)
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

                                        if (Class1.Easy == true)
                                        {
                                            Pocitac();
                                        }

                                        else if (Class1.Medium == true)
                                        {
                                            Pocitac2();
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




                                    if ((int)PoleRect[r, s].Tag == 2)
                                    {
                                        PoleRect[r, s].Tag = 9;
                                        pole.PoleLodi[r, s] = 9;
                                        Uri hit;
                                        hit = new Uri("pack://application:,,,/Pictures/LodeHit.jpg");
                                        PoleRect[r, s].Fill = new ImageBrush(new BitmapImage(hit));
                                        lode--;
                                        jednotka1--;

                                        PotopenaLodGrid.Visibility = Visibility.Visible;
                                        DispatcherTimer PotopenaTimerAnimace = new DispatcherTimer();

                                        PotopenaTimerAnimace.Tick += PotopenaTimerAnimace_Tick;
                                        PotopenaTimerAnimace.Interval = TimeSpan.FromMilliseconds(33);
                                        PotopenaTimerAnimace.Start();

                                    }

                                    else if ((int)PoleRect[r, s].Tag == 5)
                                    {
                                        PoleRect[r, s].Tag = 9;
                                        pole.PoleLodi[r, s] = 9;
                                        Uri hit;
                                        hit = new Uri("pack://application:,,,/Pictures/LodeHit.jpg");
                                        PoleRect[r, s].Fill = new ImageBrush(new BitmapImage(hit));
                                        lode--;
                                        dva--;
                                        if (dva % 2 == 0)
                                        {
                                            dvojovka1--;
                                            DvojkovalodHrac.Content = dvojovka1;

                                            PotopenaLodGrid.Visibility = Visibility.Visible;
                                            DispatcherTimer PotopenaTimerAnimace = new DispatcherTimer();

                                            PotopenaTimerAnimace.Tick += PotopenaTimerAnimace_Tick;
                                            PotopenaTimerAnimace.Interval = TimeSpan.FromMilliseconds(33);
                                            PotopenaTimerAnimace.Start();
                                        }
                                    }


                                    else if ((int)PoleRect[r, s].Tag == 6)
                                    {
                                        PoleRect[r, s].Tag = 9;
                                        pole.PoleLodi[r, s] = 9;
                                        Uri hit;
                                        hit = new Uri("pack://application:,,,/Pictures/LodeHit.jpg");
                                        PoleRect[r, s].Fill = new ImageBrush(new BitmapImage(hit));
                                        lode--;
                                        tri--;

                                        if (tri == 0)
                                        {
                                            trojovka1--;
                                            TrojkovalodHrac.Content = trojovka1;

                                            PotopenaLodGrid.Visibility = Visibility.Visible;
                                            DispatcherTimer PotopenaTimerAnimace = new DispatcherTimer();

                                            PotopenaTimerAnimace.Tick += PotopenaTimerAnimace_Tick;
                                            PotopenaTimerAnimace.Interval = TimeSpan.FromMilliseconds(33);
                                            PotopenaTimerAnimace.Start();
                                        }
                                    }

                                    if (Class1.Easy == true)
                                    {
                                        Pocitac();
                                    }

                                    else if (Class1.Medium == true)
                                    {
                                        Pocitac2();
                                    }
                                }


                            }

                        }

                        PoleRect[indx, indy].Tag = 3;


                    }


                }

                if (lode == 0)
                {
                    VyhraGrid.Visibility = Visibility.Visible;
                    DispatcherTimer VyhraTimerAnimace = new DispatcherTimer();

                    VyhraTimerAnimace.Tick += VyhraTimerAnimace_Tick;
                    VyhraTimerAnimace.Interval = TimeSpan.FromMilliseconds(33);
                    VyhraTimerAnimace.Start();
                    
                    


                }


            }
            

            JednickovalodPC.Content = jednotka + "/5";
            DvojkovalodPC.Content = dvojovka + "/3";
            TrojkovalodPC.Content = trojovka + "/1";
            JednickovalodHrac.Content = jednotka1;
            DvojkovalodHrac.Content = dvojovka1;
            TrojkovalodHrac.Content = trojovka1;

        }

        private void PotopenaTimerAnimace_Tick(object sender, EventArgs e)
        {
            if (PotopenaLodGrid.Opacity < 1) PotopenaLodGrid.Opacity += 0.05;
            else ((DispatcherTimer)sender).Stop();

        }

        private void VyhraTimerAnimace_Tick(object sender, EventArgs e)
        {
            if (VyhraGrid.Opacity < 1) VyhraGrid.Opacity += 0.05;
        }
        private void Pokracovani_Click(object sender, RoutedEventArgs e)
        {        
            PotopenaLodGrid.Opacity = 0;
            PotopenaLodGrid.Visibility = Visibility.Hidden;
        }
            private void SingleLod_Click(object sender, RoutedEventArgs e)
        {
            JednaLod = true;
            DveLode = false;
            TriLode = false;
            mazani = false;
            if (JednaLod == true)
            {
                SingleLod.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/long_hover.png"));
            }
            if (TriLode == false || DveLode == false || mazani == false)
            {
                TripleLod.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/long.png"));
                DoubleLod.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/long.png"));
                Delete.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/long.png"));
            }
        }

        private void DoubleLod_Click(object sender, RoutedEventArgs e)
        {
            JednaLod = false;
            DveLode = true;
            TriLode = false;
            mazani = false;
            
            if (DveLode == true)
            {
                DoubleLod.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/long_hover.png"));
            }
            if (TriLode == false || JednaLod == false || mazani == false)
            {
                TripleLod.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/long.png"));
                SingleLod.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/long.png"));
                Delete.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/long.png"));
            }
        }

        private void TripleLod_Click(object sender, RoutedEventArgs e)
        {
            JednaLod = false;
            DveLode = false;
            TriLode = true;
            mazani = false;
            if (TriLode == true)
            {
                TripleLod.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/long_hover.png"));
            }
            if (DveLode == false || JednaLod == false || mazani == false)
            {
                DoubleLod.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/long.png"));
                SingleLod.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/long.png"));
                Delete.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/long.png"));
            }
            

        }


        private void Pocitac()
        {

            Random rnd = new Random();
            int cislo1 = rnd.Next(1, 11);
            int cislo2 = rnd.Next(1, 11);


            for (int r = 0; r < PoleRect.GetLength(0); r++)
            {
                for (int s = 0; s < PoleRect.GetLength(1); s++)
                {
                    if (pole.PoleLodi2[r, s] == 1) PoleRect2[r, s].Tag = 1;
                    if (pole.PoleLodi2[r, s] == 0) PoleRect2[r, s].Tag = 0;
                    if (pole.PoleLodi2[r, s] == 2) PoleRect2[r, s].Tag = 2;
                    if (pole.PoleLodi2[r, s] == 5) PoleRect2[r, s].Tag = 6;
                    if (pole.PoleLodi2[r, s] == 6) PoleRect2[r, s].Tag = 5;
                    if ((int)PoleRect2[r, s].Tag == 3) pole.PoleLodi2[r, s] = 3;
                }

            }

            while (true)
            {
                if (pole.PoleLodi2[cislo1, cislo2] == 3 || pole.PoleLodi2[cislo1, cislo2] == 1 || pole.PoleLodi2[cislo1, cislo2] == 9)
                {

                    cislo1 = rnd.Next(1, 11);
                    cislo2 = rnd.Next(1, 11);
                    Class1.Rec2 = PoleRect2[cislo1, cislo2];
                }

                else
                {
                    Class1.Rec2 = PoleRect2[cislo1, cislo2];
                    break;
                }
            }


            Class1.Rec2.Tag = 4;

            for (int r = 0; r < pole.PoleLodi2.GetLength(0); r++)
            {

                for (int s = 0; s < pole.PoleLodi2.GetLength(1); s++)
                {



                    if ((int)PoleRect2[r, s].Tag == 4)
                    {


                        if ((int)PoleRect2[r, s].Tag == 9)
                        {

                            indx2 = r;
                            indy2 = s;

                            PoleRect2[r, s].Tag = 9;
                            pole.PoleLodi2[r, s] = 9;
                        }

                        else if (pole.PoleLodi2[r, s] == 2 || pole.PoleLodi2[r, s] == 5 || pole.PoleLodi2[r, s] == 6)
                        {

                            indx2 = r;
                            indy2 = s;

                            PoleRect2[r, s].Tag = 2;
                            pole.PoleLodi2[r, s] = 2;


                            if ((int)PoleRect2[r, s].Tag == 2 || (int)PoleRect2[r, s].Tag == 5 || (int)PoleRect2[r, s].Tag == 6)
                            {
                                PoleRect2[r, s].Tag = 9;
                                pole.PoleLodi2[r, s] = 9;
                                Uri hit;
                                hit = new Uri("pack://application:,,,/Pictures/LodeHit.jpg");
                                PoleRect2[r, s].Fill = new ImageBrush(new BitmapImage(hit));
                                lode2--;
                            }

                        }
                        else
                        {
                            indx2 = r;
                            indy2 = s;

                            PoleRect2[r, s].Tag = 3;
                            pole.PoleLodi2[r, s] = 3;
                            if ((int)PoleRect2[r, s].Tag == 3)
                            {
                                Uri miss;
                                miss = new Uri("pack://application:,,,/Pictures/LodeMiss.jpg");
                                PoleRect2[r, s].Fill = new ImageBrush(new BitmapImage(miss));
                             
                            }


                        }


                    }


                }


            }
            if (lode2 == 0)
            {

                ProhraGrid.Visibility = Visibility.Visible;
                DispatcherTimer ProhraTimerAnimace = new DispatcherTimer();

                ProhraTimerAnimace.Tick += ProhraTimerAnimace_Tick;
                ProhraTimerAnimace.Interval = TimeSpan.FromMilliseconds(33);
                ProhraTimerAnimace.Start();
                

            }

        }

        private void ProhraTimerAnimace_Tick(object sender, EventArgs e)
        {
            if (ProhraGrid.Opacity < 1) ProhraGrid.Opacity += 0.05;
        }

        private void Pocitac2()
        {
            Random rnd = new Random();
            int cislo1 = rnd.Next(1, 11);
            int cislo2 = rnd.Next(1, 11);

            for (int r = 0; r < PoleRect.GetLength(0); r++)
            {
                for (int s = 0; s < PoleRect.GetLength(1); s++)
                {
                    if (pole.PoleLodi2[r, s] == 1) PoleRect2[r, s].Tag = 1;
                    if (pole.PoleLodi2[r, s] == 0) PoleRect2[r, s].Tag = 0;
                    if (pole.PoleLodi2[r, s] == 2) PoleRect2[r, s].Tag = 2;
                    if (pole.PoleLodi2[r, s] == 5) PoleRect2[r, s].Tag = 6;
                    if (pole.PoleLodi2[r, s] == 6) PoleRect2[r, s].Tag = 5;
                    if ((int)PoleRect2[r, s].Tag == 3) pole.PoleLodi2[r, s] = 3;
                }

            }

            while (true)
            {
                if (pole.PoleLodi2[cislo1, cislo2] == 3 || pole.PoleLodi2[cislo1, cislo2] == 1 || pole.PoleLodi2[cislo1, cislo2] == 9)
                {

                    cislo1 = rnd.Next(1, 11);
                    cislo2 = rnd.Next(1, 11);
                    Class1.Rec2 = PoleRect2[cislo1, cislo2];
                }

                else
                {
                    Class1.Rec2 = PoleRect2[cislo1, cislo2];
                    break;
                }
            }


            Class1.Rec2.Tag = 4;
            if (a == 0)
            {


                for (int r = 0; r < pole.PoleLodi2.GetLength(0); r++)
                {

                    for (int s = 0; s < pole.PoleLodi2.GetLength(1); s++)
                    {





                        if ((int)PoleRect2[r, s].Tag == 4)
                        {


                            if ((int)PoleRect2[r, s].Tag == 9)
                            {

                                indx2 = r;
                                indy2 = s;

                                PoleRect2[r, s].Tag = 9;
                                pole.PoleLodi2[r, s] = 9;
                            }



                            else if (pole.PoleLodi2[r, s] == 2 || pole.PoleLodi2[r, s] == 5 || pole.PoleLodi2[r, s] == 6)
                            {

                                indx2 = r;
                                indy2 = s;

                                PoleRect2[r, s].Tag = 5;
                                pole.PoleLodi2[r, s] = 5;


                                if ((int)PoleRect2[r, s].Tag == 2 || (int)PoleRect2[r, s].Tag == 5 || (int)PoleRect2[r, s].Tag == 6)
                                {
                                    lode2--;
                                    
                                    a = r;
                                    b = s;





                                    PoleRect2[r, s].Tag = 9;
                                    pole.PoleLodi2[r, s] = 9;
                                    Uri hit;
                                    hit = new Uri("pack://application:,,,/Pictures/LodeHit.jpg");
                                    PoleRect2[r, s].Fill = new ImageBrush(new BitmapImage(hit));

                                }


                            }
                            else
                            {
                                indx2 = r;
                                indy2 = s;

                                PoleRect2[r, s].Tag = 3;
                                pole.PoleLodi2[r, s] = 3;
                                if ((int)PoleRect2[r, s].Tag == 3)
                                {
                                    Uri miss;
                                    miss = new Uri("pack://application:,,,/Pictures/LodeMiss.jpg");
                                    PoleRect2[r, s].Fill = new ImageBrush(new BitmapImage(miss));

                                }
                            }
                        }
                    }

                }
                if (lode2 == 0)
                {
                    ProhraGrid.Visibility = Visibility.Visible;
                    DispatcherTimer ProhraTimerAnimace = new DispatcherTimer();

                    ProhraTimerAnimace.Tick += ProhraTimerAnimace_Tick2;
                    ProhraTimerAnimace.Interval = TimeSpan.FromMilliseconds(33);
                    ProhraTimerAnimace.Start();
                    

                }
            }

            else if (a > 0)
            {
                if ((int)PoleRect2[a - 1, b].Tag == 5 || (int)PoleRect2[a - 1, b].Tag == 6)
                {
                    PoleRect2[a - 1, b].Tag = 9;
                    pole.PoleLodi2[a - 1, b] = 9;
                    Uri hit;
                    hit = new Uri("pack://application:,,,/Pictures/LodeHit.jpg");
                    PoleRect2[a -1, b].Fill = new ImageBrush(new BitmapImage(hit));
                    lode2--;
                    a = 0;
                    b = 0;
                }

                else if ((int)PoleRect2[a + 1, b].Tag == 5 || (int)PoleRect2[a + 1, b].Tag == 6)
                {
                    PoleRect2[a + 1, b].Tag = 9;
                    pole.PoleLodi2[a + 1, b] = 9;
                    Uri hit;
                    hit = new Uri("pack://application:,,,/Pictures/LodeHit.jpg");
                    PoleRect2[a + 1, b].Fill = new ImageBrush(new BitmapImage(hit));
                    lode2--;
                    a = 0;
                    b = 0;
                }
                else if ((int)PoleRect2[a, b - 1].Tag == 5 || (int)PoleRect2[a, b - 1].Tag == 6)
                {
                    PoleRect2[a, b - 1].Tag = 9;
                    pole.PoleLodi2[a, b - 1] = 9;
                    Uri hit;
                    hit = new Uri("pack://application:,,,/Pictures/LodeHit.jpg");
                    PoleRect2[a, b-1].Fill = new ImageBrush(new BitmapImage(hit));
                    lode2--;
                    a = 0;
                    b = 0;
                }
                else if ((int)PoleRect2[a, b + 1].Tag == 5 || (int)PoleRect2[a, b + 1].Tag == 6)
                {
                    PoleRect2[a, b + 1].Tag = 9;
                    pole.PoleLodi2[a, b + 1] = 9;
                    Uri hit;
                    hit = new Uri("pack://application:,,,/Pictures/LodeHit.jpg");
                    PoleRect2[a, b + 1].Fill = new ImageBrush(new BitmapImage(hit));
                    lode2--;
                    a = 0;
                    b = 0;
                }
                else if ((int)PoleRect2[a, b + 1].Tag != 5 || (int)PoleRect2[a, b + 1].Tag != 6 || (int)PoleRect2[a, b - 1].Tag != 5 || (int)PoleRect2[a, b - 1].Tag != 6 || (int)PoleRect2[a + 1, b].Tag != 5 || (int)PoleRect2[a + 1, b].Tag != 6 || (int)PoleRect2[a - 1, b].Tag != 5 || (int)PoleRect2[a - 1, b].Tag != 6)
                {
                    a = 0;
                    b = 0;

                    while (true)
                    {
                        if (pole.PoleLodi2[cislo1, cislo2] == 3 || pole.PoleLodi2[cislo1, cislo2] == 1 || pole.PoleLodi2[cislo1, cislo2] == 9)
                        {

                            cislo1 = rnd.Next(1, 11);
                            cislo2 = rnd.Next(1, 11);
                            Class1.Rec2 = PoleRect2[cislo1, cislo2];
                        }

                        else
                        {
                            Class1.Rec2 = PoleRect2[cislo1, cislo2];
                            break;
                        }
                    }

                    for (int r = 0; r < pole.PoleLodi2.GetLength(0); r++)
                    {

                        for (int s = 0; s < pole.PoleLodi2.GetLength(1); s++)
                        {

                            if ((int)PoleRect2[r, s].Tag == 4)
                            {


                                if ((int)PoleRect2[r, s].Tag == 9)
                                {

                                    indx2 = r;
                                    indy2 = s;

                                    PoleRect2[r, s].Tag = 9;
                                    pole.PoleLodi2[r, s] = 9;
                                }



                                else if (pole.PoleLodi2[r, s] == 2 || pole.PoleLodi2[r, s] == 5 || pole.PoleLodi2[r, s] == 6)
                                {

                                    indx2 = r;
                                    indy2 = s;

                                    PoleRect2[r, s].Tag = 5;
                                    pole.PoleLodi2[r, s] = 5;

                                    if ((int)PoleRect2[r, s].Tag == 2 || (int)PoleRect2[r, s].Tag == 5 || (int)PoleRect2[r, s].Tag == 6)
                                    {
                                        PoleRect2[r, s].Tag = 9;
                                        pole.PoleLodi2[r, s] = 9;
                                        Uri hit;
                                        hit = new Uri("pack://application:,,,/Pictures/LodeHit.jpg");
                                        PoleRect2[r, s].Fill = new ImageBrush(new BitmapImage(hit));
                                        lode2--;
                                        a = r;
                                        b = s;

                                    }


                                }
                                else
                                {
                                    indx2 = r;
                                    indy2 = s;

                                    PoleRect2[r, s].Tag = 3;
                                    pole.PoleLodi2[r, s] = 3;
                                    if ((int)PoleRect2[r, s].Tag == 3)
                                    {
                                        Uri miss;
                                        miss = new Uri("pack://application:,,,/Pictures/LodeMiss.jpg");
                                        PoleRect2[r, s].Fill = new ImageBrush(new BitmapImage(miss));
                                    }
                                }
                            }
                        }

                    }
                }



            }


        }

        private void ProhraTimerAnimace_Tick2(object sender, EventArgs e)
        {
                if (ProhraGrid.Opacity < 1) ProhraGrid.Opacity += 0.05;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right)
            {
                otoceni = true;
            }
            else if (e.Key == Key.Left)
            {
                otoceni = false;
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            mazani = !mazani;
            if (mazani == true)
            {
                Delete.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/long_hover.png"));
                TripleLod.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/long.png"));
                DoubleLod.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/long.png"));
                SingleLod.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/long.png"));


            }

        }

        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            Window1 win = new Window1();
            win.Top = this.Top;
            win.Left = this.Left;
            win.Show();
            this.Close();

        }

        private void Napoveda_Click(object sender, RoutedEventArgs e)
        {
            if (Napoveda_Grid.Visibility == Visibility.Hidden)
            {
                Napoveda_Grid.Visibility = Visibility.Visible;
            }
            else if (Napoveda_Grid.Visibility == Visibility.Visible)
            {
                Napoveda_Grid.Visibility = Visibility.Hidden;
            }
            if (zapnuty == false)
            {
                if (Napoveda_Grid.Visibility == Visibility.Visible)
                {
                    Sipka1.Visibility = Visibility.Visible;
                    Sipka2.Visibility = Visibility.Visible;
                    Sipka3.Visibility = Visibility.Visible;
                    Sipka4.Visibility = Visibility.Visible;
                    Sipka5.Visibility = Visibility.Visible;
                    Sipka6.Visibility = Visibility.Visible;
                    Sipka7.Visibility = Visibility.Visible;
                    Sipka8.Visibility = Visibility.Visible;
                    Lode_LBL.Visibility = Visibility.Visible;
                    PlacedSingleLode_LBL.Visibility = Visibility.Visible;
                    PlacedDuoLode_LBL.Visibility = Visibility.Visible;
                    PlacedTrioLode_LBL.Visibility = Visibility.Visible;
                    Start_LBL1.Visibility = Visibility.Visible;
                    Delete_LBL1.Visibility = Visibility.Visible;
                    Delete_LBL2.Visibility = Visibility.Visible;

                }
                else if (Napoveda_Grid.Visibility == Visibility.Hidden)
                {
                    Sipka1.Visibility = Visibility.Hidden;
                    Sipka2.Visibility = Visibility.Hidden;
                    Sipka3.Visibility = Visibility.Hidden;
                    Sipka4.Visibility = Visibility.Hidden;
                    Sipka5.Visibility = Visibility.Hidden;
                    Sipka6.Visibility = Visibility.Hidden;
                    Sipka7.Visibility = Visibility.Hidden;
                    Sipka8.Visibility = Visibility.Hidden;
                    Lode_LBL.Visibility = Visibility.Hidden;
                    PlacedSingleLode_LBL.Visibility = Visibility.Hidden;
                    PlacedDuoLode_LBL.Visibility = Visibility.Hidden;
                    PlacedTrioLode_LBL.Visibility = Visibility.Hidden;
                    Start_LBL1.Visibility = Visibility.Hidden;
                    Delete_LBL1.Visibility = Visibility.Hidden;
                    Delete_LBL2.Visibility = Visibility.Hidden;
                }
            }
            
            if (zapnuty == true)
            {
                if (Napoveda_Grid.Visibility == Visibility.Visible)
                {
                    HracovoPole.Visibility = Visibility.Visible;
                    PoleNepritele.Visibility = Visibility.Visible;
                }

                else if (Napoveda_Grid.Visibility == Visibility.Hidden)
                {
                    HracovoPole.Visibility = Visibility.Hidden;
                    PoleNepritele.Visibility = Visibility.Hidden;
                }
            }
            
        }
    }
}