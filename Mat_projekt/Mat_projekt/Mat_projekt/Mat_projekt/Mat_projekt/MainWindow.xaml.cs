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

namespace Mat_projekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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




        int[,] PoleLodi = new int[12, 12]; // velikost pole
        int[,] PoleLodi2 = new int[12, 12]; // velikost pole

        Rectangle[,] PoleRect;
        Rectangle[,] PoleRect2;

        int indx;
        int indx2;

        int indy;
        int indy2;

        public MainWindow()
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

                    //Console.WriteLine(PoleRect[row, col].Tag);
                    //Console.WriteLine(PoleLodi[row,col]);

                }
           
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


            if (trojovka > 0)
            {
                for (int i = 0; i < trojovka; i++)
                {
                    Random rnd = new Random();
                    int cislo1 = rnd.Next(2, 10);
                    int cislo2 = rnd.Next(2, 10);
                    int otocka = rnd.Next(0, 2);

                    if (otocka == 1)
                    {
                        while (true)
                        {

                            if (PoleLodi[cislo1 - 1, cislo2] == 2 ||
                                                    PoleLodi[cislo1 + 1, cislo2] == 2 ||
                                                    PoleLodi[cislo1, cislo2 - 2] == 2 ||
                                                    PoleLodi[cislo1, cislo2 - 1] == 2 ||
                                                    PoleLodi[cislo1, cislo2 + 1] == 2 ||
                                                    PoleLodi[cislo1 + 1, cislo2 + 1] == 2 ||
                                                    PoleLodi[cislo1 - 1, cislo2 + 1] == 2 ||
                                                    PoleLodi[cislo1 + 1, cislo2 - 1] == 2 ||
                                                    PoleLodi[cislo1 - 1, cislo2 - 1] == 2 ||
                                                    PoleLodi[cislo1 - 2, cislo2] == 2 ||
                                                    PoleLodi[cislo1 + 2, cislo2] == 2 ||
                                                    PoleLodi[cislo1, cislo2 - 2] == 2 ||
                                                    PoleLodi[cislo1, cislo2 + 2] == 2 ||
                                                    PoleLodi[cislo1 + 2, cislo2 + 2] == 2 ||
                                                    PoleLodi[cislo1 - 2, cislo2 + 2] == 2 ||
                                                    PoleLodi[cislo1 + 2, cislo2 - 2] == 2 ||
                                                    PoleLodi[cislo1 - 2, cislo2 - 2] == 2 ||
                                                    PoleLodi[cislo1 - 1, cislo2] == 5 ||
                                                    PoleLodi[cislo1 + 1, cislo2] == 5 ||
                                                    PoleLodi[cislo1, cislo2 - 2] == 5 ||
                                                    PoleLodi[cislo1, cislo2 - 1] == 5 ||
                                                    PoleLodi[cislo1, cislo2 + 1] == 5 ||
                                                    PoleLodi[cislo1 + 1, cislo2 + 1] == 5 ||
                                                    PoleLodi[cislo1 - 1, cislo2 + 1] == 5 ||
                                                    PoleLodi[cislo1 + 1, cislo2 - 1] == 5 ||
                                                    PoleLodi[cislo1 - 1, cislo2 - 1] == 5 ||
                                                    PoleLodi[cislo1 - 2, cislo2] == 5 ||
                                                    PoleLodi[cislo1 + 2, cislo2] == 5 ||
                                                    PoleLodi[cislo1, cislo2 - 2] == 5 ||
                                                    PoleLodi[cislo1, cislo2 + 2] == 5 ||
                                                    PoleLodi[cislo1 + 2, cislo2 + 2] == 5 ||
                                                    PoleLodi[cislo1 - 2, cislo2 + 2] == 5 ||
                                                    PoleLodi[cislo1 + 2, cislo2 - 2] == 5 ||
                                                    PoleLodi[cislo1 - 2, cislo2 - 2] == 5)
                            {
                                cislo1 = rnd.Next(2, 10);
                                cislo2 = rnd.Next(2, 10);

                            }
                            else
                            {
                                PoleRect[cislo1, cislo2].Tag = 6;
                                PoleLodi[cislo1, cislo2] = 6;
                                PoleRect[cislo1 + 1, cislo2].Tag = 6;
                                PoleLodi[cislo1 + 1, cislo2] = 6;
                                PoleRect[cislo1 - 1, cislo2].Tag = 6;
                                PoleLodi[cislo1 - 1, cislo2] = 6;
                                Uri lod;
                                lod = new Uri("pack://application:,,,/Pictures/SecretLod.PNG");
                                PoleRect[cislo1, cislo2].Fill = new ImageBrush(new BitmapImage(lod));
                                PoleRect[cislo1 + 1, cislo2].Fill = new ImageBrush(new BitmapImage(lod));
                                PoleRect[cislo1 - 1, cislo2].Fill = new ImageBrush(new BitmapImage(lod));
                                //PoleRect[cislo1 + 1, cislo2].Fill = Brushes.Brown;
                                //PoleRect[cislo1 - 1, cislo2].Fill = Brushes.Brown;
                                //PoleRect[cislo1, cislo2].Fill = Brushes.Brown;
                                lode = lode + 3;

                                break;
                            }

                        }
                    }

                    if (otocka == 0)
                    {


                        while (true)
                        {
                            if (PoleLodi[cislo1 - 1, cislo2] == 2 ||
                                                    PoleLodi[cislo1 + 1, cislo2] == 2 ||
                                                    PoleLodi[cislo1, cislo2 - 2] == 2 ||
                                                    PoleLodi[cislo1, cislo2 - 1] == 2 ||
                                                    PoleLodi[cislo1, cislo2 + 1] == 2 ||
                                                    PoleLodi[cislo1 + 1, cislo2 + 1] == 2 ||
                                                    PoleLodi[cislo1 - 1, cislo2 + 1] == 2 ||
                                                    PoleLodi[cislo1 + 1, cislo2 - 1] == 2 ||
                                                    PoleLodi[cislo1 - 1, cislo2 - 1] == 2 ||
                                                    PoleLodi[cislo1 - 2, cislo2] == 2 ||
                                                    PoleLodi[cislo1 + 2, cislo2] == 2 ||
                                                    PoleLodi[cislo1, cislo2 - 2] == 2 ||
                                                    PoleLodi[cislo1, cislo2 + 2] == 2 ||
                                                    PoleLodi[cislo1 + 2, cislo2 + 2] == 2 ||
                                                    PoleLodi[cislo1 - 2, cislo2 + 2] == 2 ||
                                                    PoleLodi[cislo1 + 2, cislo2 - 2] == 2 ||
                                                    PoleLodi[cislo1 - 2, cislo2 - 2] == 2 ||
                                                    PoleLodi[cislo1 - 1, cislo2] == 5 ||
                                                    PoleLodi[cislo1 + 1, cislo2] == 5 ||
                                                    PoleLodi[cislo1, cislo2 - 2] == 5 ||
                                                    PoleLodi[cislo1, cislo2 - 1] == 5 ||
                                                    PoleLodi[cislo1, cislo2 + 1] == 5 ||
                                                    PoleLodi[cislo1 + 1, cislo2 + 1] == 5 ||
                                                    PoleLodi[cislo1 - 1, cislo2 + 1] == 5 ||
                                                    PoleLodi[cislo1 + 1, cislo2 - 1] == 5 ||
                                                    PoleLodi[cislo1 - 1, cislo2 - 1] == 5 ||
                                                    PoleLodi[cislo1 - 2, cislo2] == 5 ||
                                                    PoleLodi[cislo1 + 2, cislo2] == 5 ||
                                                    PoleLodi[cislo1, cislo2 - 2] == 5 ||
                                                    PoleLodi[cislo1, cislo2 + 2] == 5 ||
                                                    PoleLodi[cislo1 + 2, cislo2 + 2] == 5 ||
                                                    PoleLodi[cislo1 - 2, cislo2 + 2] == 5 ||
                                                    PoleLodi[cislo1 + 2, cislo2 - 2] == 5 ||
                                                    PoleLodi[cislo1 - 2, cislo2 - 2] == 5)
                            {
                                cislo1 = rnd.Next(2, 10);
                                cislo2 = rnd.Next(2, 10);
                            }
                            else
                            {
                                PoleRect[cislo1, cislo2].Tag = 6;
                                PoleLodi[cislo1, cislo2] = 6;
                                PoleRect[cislo1, cislo2 + 1].Tag = 6;
                                PoleLodi[cislo1, cislo2 + 1] = 6;
                                PoleRect[cislo1, cislo2 - 1].Tag = 6;
                                PoleLodi[cislo1, cislo2 - 1] = 6;
                                Uri lod;
                                lod = new Uri("pack://application:,,,/Pictures/SecretLod.PNG");
                                PoleRect[cislo1, cislo2].Fill = new ImageBrush(new BitmapImage(lod));
                                PoleRect[cislo1, cislo2 + 1].Fill = new ImageBrush(new BitmapImage(lod));
                                PoleRect[cislo1, cislo2 - 1].Fill = new ImageBrush(new BitmapImage(lod));
                                //PoleRect[cislo1, cislo2 + 1].Fill = Brushes.Brown;
                                //PoleRect[cislo1, cislo2 - 1].Fill = Brushes.Brown;
                                //PoleRect[cislo1, cislo2].Fill = Brushes.Brown;
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
                    int cislo1 = rnd.Next(2, 11);
                    int cislo2 = rnd.Next(1, 11);
                    int otocka = rnd.Next(0, 2);
                    //int otocka = 0;
                    if (otocka == 1)
                    {
                        while (true)
                        {

                            if (PoleLodi[cislo1 - 1, cislo2] == 5 ||
                                                    PoleLodi[cislo1 + 1, cislo2] == 5 ||
                                                    PoleLodi[cislo1 - 2, cislo2] == 5 ||
                                                    PoleLodi[cislo1, cislo2 - 1] == 5 ||
                                                    PoleLodi[cislo1, cislo2 + 1] == 5 ||
                                                    PoleLodi[cislo1 + 1, cislo2 + 1] == 5 ||
                                                    PoleLodi[cislo1 - 1, cislo2 + 1] == 5 ||
                                                    PoleLodi[cislo1 + 1, cislo2 - 1] == 5 ||
                                                    PoleLodi[cislo1 - 1, cislo2 - 1] == 5 ||
                                                    PoleLodi[cislo1 - 1, cislo2] == 2 ||
                                                    PoleLodi[cislo1 + 1, cislo2] == 2 ||
                                                    PoleLodi[cislo1 - 2, cislo2] == 2 ||
                                                    PoleLodi[cislo1, cislo2 - 1] == 2 ||
                                                    PoleLodi[cislo1, cislo2 + 1] == 2 ||
                                                    PoleLodi[cislo1 + 1, cislo2 + 1] == 2 ||
                                                    PoleLodi[cislo1 - 1, cislo2 + 1] == 2 ||
                                                    PoleLodi[cislo1 + 1, cislo2 - 1] == 2 ||
                                                    PoleLodi[cislo1 - 1, cislo2 - 1] == 2 ||
                                                    PoleLodi[cislo1 - 1, cislo2] == 6 ||
                                                    PoleLodi[cislo1 + 1, cislo2] == 6 ||
                                                    PoleLodi[cislo1 - 2, cislo2] == 6 ||
                                                    PoleLodi[cislo1, cislo2 - 1] == 6 ||
                                                    PoleLodi[cislo1, cislo2 + 1] == 6 ||
                                                    PoleLodi[cislo1 + 1, cislo2 + 1] == 6 ||
                                                    PoleLodi[cislo1 - 1, cislo2 + 1] == 6 ||
                                                    PoleLodi[cislo1 + 1, cislo2 - 1] == 6 ||
                                                    PoleLodi[cislo1 - 1, cislo2 - 1] == 6 ||
                                                    PoleLodi[cislo1 - 1, cislo2] == 1 ||
                                                    PoleLodi[cislo1 + 1, cislo2] == 1 ||
                                                    //PoleLodi[cislo1 - 2, cislo2] == 1||
                                                    PoleLodi[cislo1, cislo2 - 1] == 1 ||
                                                    PoleLodi[cislo1, cislo2 + 1] == 1 ||
                                                    PoleLodi[cislo1 + 1, cislo2 + 1] == 1 ||
                                                    PoleLodi[cislo1 - 1, cislo2 + 1] == 1 ||
                                                    PoleLodi[cislo1 + 1, cislo2 - 1] == 1 ||
                                                    PoleLodi[cislo1 - 1, cislo2 - 1] == 1 ||
                                                    PoleLodi[cislo1, cislo2] == 1 ||
                                                    PoleLodi[cislo1, cislo2] == 2 ||
                                                    PoleLodi[cislo1, cislo2] == 5 ||
                                                    PoleLodi[cislo1, cislo2] == 6)
                            {
                                cislo1 = rnd.Next(2, 11);
                                cislo2 = rnd.Next(1, 11);

                            }
                            else
                            {
                                PoleRect[cislo1, cislo2].Tag = 5;
                                PoleLodi[cislo1, cislo2] = 5;
                                PoleRect[cislo1 - 1, cislo2].Tag = 5;
                                PoleLodi[cislo1 - 1, cislo2] = 5;
                                Uri lod;
                                lod = new Uri("pack://application:,,,/Pictures/SecretLod.PNG");
                                PoleRect[cislo1, cislo2].Fill = new ImageBrush(new BitmapImage(lod));
                                PoleRect[cislo1 - 1, cislo2].Fill = new ImageBrush(new BitmapImage(lod));
                                //PoleRect[cislo1, cislo2].Fill = Brushes.Pink;
                                //PoleRect[cislo1 - 1, cislo2].Fill = Brushes.Pink;
                                lode = lode + 2;

                                break;
                            }

                        }
                    }

                    if (otocka == 0)
                    {


                        while (true)
                        {
                            if (PoleLodi[cislo1 - 1, cislo2] == 5 ||
                                                    PoleLodi[cislo1 + 1, cislo2] == 5 ||
                                                    PoleLodi[cislo1 - 2, cislo2] == 5 ||
                                                    PoleLodi[cislo1, cislo2 - 1] == 5 ||
                                                    PoleLodi[cislo1, cislo2 + 1] == 5 ||
                                                    PoleLodi[cislo1 + 1, cislo2 + 1] == 5 ||
                                                    PoleLodi[cislo1 - 1, cislo2 + 1] == 5 ||
                                                    PoleLodi[cislo1 + 1, cislo2 - 1] == 5 ||
                                                    PoleLodi[cislo1 - 1, cislo2 - 1] == 5 ||
                                                    PoleLodi[cislo1 - 1, cislo2] == 2 ||
                                                    PoleLodi[cislo1 + 1, cislo2] == 2 ||
                                                    PoleLodi[cislo1 - 2, cislo2] == 2 ||
                                                    PoleLodi[cislo1, cislo2 - 1] == 2 ||
                                                    PoleLodi[cislo1, cislo2 + 1] == 2 ||
                                                    PoleLodi[cislo1 + 1, cislo2 + 1] == 2 ||
                                                    PoleLodi[cislo1 - 1, cislo2 + 1] == 2 ||
                                                    PoleLodi[cislo1 + 1, cislo2 - 1] == 2 ||
                                                    PoleLodi[cislo1 - 1, cislo2 - 1] == 2 ||
                                                    PoleLodi[cislo1 - 1, cislo2] == 6 ||
                                                    PoleLodi[cislo1 + 1, cislo2] == 6 ||
                                                    PoleLodi[cislo1 - 2, cislo2] == 6 ||
                                                    PoleLodi[cislo1, cislo2 - 1] == 6 ||
                                                    PoleLodi[cislo1, cislo2 + 1] == 6 ||
                                                    PoleLodi[cislo1 + 1, cislo2 + 1] == 6 ||
                                                    PoleLodi[cislo1 - 1, cislo2 + 1] == 6 ||
                                                    PoleLodi[cislo1 + 1, cislo2 - 1] == 6 ||
                                                    PoleLodi[cislo1 - 1, cislo2 - 1] == 6 ||
                                                    PoleLodi[cislo1 - 1, cislo2] == 1 ||
                                                    PoleLodi[cislo1 + 1, cislo2] == 1 ||
                                                    //PoleLodi[cislo1 - 2, cislo2] == 1 ||
                                                    PoleLodi[cislo1, cislo2 - 1] == 1 ||
                                                    PoleLodi[cislo1, cislo2 + 1] == 1 ||
                                                    PoleLodi[cislo1 + 1, cislo2 + 1] == 1 ||
                                                    PoleLodi[cislo1 - 1, cislo2 + 1] == 1 ||
                                                    PoleLodi[cislo1 + 1, cislo2 - 1] == 1 ||
                                                    PoleLodi[cislo1 - 1, cislo2 - 1] == 1 ||
                                                    PoleLodi[cislo1, cislo2] == 1 ||
                                                    PoleLodi[cislo1, cislo2] == 2 ||
                                                    PoleLodi[cislo1, cislo2] == 5 ||
                                                    PoleLodi[cislo1, cislo2] == 6)
                            {
                                cislo1 = rnd.Next(2, 11);
                                cislo2 = rnd.Next(1, 11);
                            }
                            else
                            {

                                PoleRect[cislo1, cislo2].Tag = 5;
                                PoleLodi[cislo1, cislo2] = 5;
                                PoleRect[cislo1, cislo2 - 1].Tag = 5;
                                PoleLodi[cislo1, cislo2 - 1] = 5;
                                Uri lod;
                                lod = new Uri("pack://application:,,,/Pictures/SecretLod.PNG");
                                PoleRect[cislo1, cislo2].Fill = new ImageBrush(new BitmapImage(lod));
                                PoleRect[cislo1, cislo2 - 1].Fill = new ImageBrush(new BitmapImage(lod));
                                //PoleRect[cislo1, cislo2].Fill = Brushes.Pink;
                                //PoleRect[cislo1, cislo2 - 1].Fill = Brushes.Pink;
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
                    Console.WriteLine(jednotka);
                    Console.WriteLine(i);
                    Random rnd = new Random();
                    int cislo1 = rnd.Next(1, 11);
                    int cislo2 = rnd.Next(1, 11);
                    while (true)
                    {

                        Console.WriteLine(cislo1);
                        if (PoleLodi[cislo1 - 1, cislo2] == 2 ||
                                            PoleLodi[cislo1 + 1, cislo2] == 2 ||
                                            PoleLodi[cislo1, cislo2 - 1] == 2 ||
                                            PoleLodi[cislo1, cislo2 + 1] == 2 ||
                                            PoleLodi[cislo1 - 1, cislo2] == 5 ||
                                            PoleLodi[cislo1 + 1, cislo2] == 5 ||
                                            PoleLodi[cislo1, cislo2 - 1] == 5 ||
                                            PoleLodi[cislo1, cislo2 + 1] == 5 ||
                                            PoleLodi[cislo1 - 1, cislo2] == 6 ||
                                            PoleLodi[cislo1 + 1, cislo2] == 6 ||
                                            PoleLodi[cislo1, cislo2 - 1] == 6 ||
                                            PoleLodi[cislo1, cislo2 + 1] == 6 ||
                                            PoleLodi[cislo1 - 1, cislo2] == 1 ||
                                            PoleLodi[cislo1 + 1, cislo2] == 1 ||
                                            PoleLodi[cislo1, cislo2 - 1] == 1 ||
                                            PoleLodi[cislo1, cislo2 + 1] == 1 ||
                                            PoleLodi[cislo1, cislo2] == 1 ||
                                            PoleLodi[cislo1, cislo2] == 2 ||
                                            PoleLodi[cislo1, cislo2] == 5 ||
                                            PoleLodi[cislo1, cislo2] == 6)
                        {
                            cislo1 = rnd.Next(1, 11);
                            cislo2 = rnd.Next(1, 11);
                        }
                        else//(PoleLodi[cislo1 - 1, cislo2] != 2 &&
                            //PoleLodi[cislo1 + 1, cislo2] != 2 &&
                            //PoleLodi[cislo1, cislo2 - 1] != 2 &&
                            //PoleLodi[cislo1, cislo2 + 1] != 2 &&
                            //PoleLodi[cislo1 - 1, cislo2] != 5 &&
                            //PoleLodi[cislo1 + 1, cislo2] != 5 &&
                            //PoleLodi[cislo1, cislo2 - 1] != 5 &&
                            //PoleLodi[cislo1, cislo2 + 1] != 5 &&
                            //PoleLodi[cislo1 - 1, cislo2] != 6 &&
                            //PoleLodi[cislo1 + 1, cislo2] != 6 &&
                            //PoleLodi[cislo1, cislo2 - 1] != 6 &&
                            //PoleLodi[cislo1, cislo2 + 1] != 6)
                        {
                            PoleRect[cislo1, cislo2].Tag = 2;
                            PoleLodi[cislo1, cislo2] = 2;
                            Uri lod;
                            lod = new Uri("pack://application:,,,/Pictures/SecretLod.PNG");
                            PoleRect[cislo1, cislo2].Fill = new ImageBrush(new BitmapImage(lod));
                            //PoleRect[cislo1, cislo2].Fill = Brushes.Gray;
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

                    //Console.WriteLine(PoleRect2[row, col].Tag);
                    //Console.WriteLine(PoleLodi[row,col]);

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
                            if (PoleLodi2[r, s] == 1) PoleRect2[r, s].Tag = 1;
                            else if (PoleLodi2[r, s] == 0) PoleRect2[r, s].Tag = 0;
                            else if (PoleLodi2[r, s] == 2) PoleRect2[r, s].Tag = 2;
                            //else if (PoleLodi2[r, s] == 2) lode2++;
                            else if ((int)PoleRect2[r, s].Tag == 3) PoleLodi2[r, s] = 3;



                        }

                    }

                    Rec.Tag = 4;

                    for (int r = 0; r < PoleLodi2.GetLength(0); r++)
                    {
                        for (int s = 0; s < PoleLodi2.GetLength(1); s++)
                        {

                            if ((int)PoleRect2[r, s].Tag == 4)
                            {

                                if (JednaLod == true)
                                {
                                    if (PoleLodi2[r, s] == 0)
                                    {
                                        if (PoleLodi2[r - 1, s] != 2 &&
                                            PoleLodi2[r + 1, s] != 2 &&
                                            PoleLodi2[r, s - 1] != 2 &&
                                            PoleLodi2[r, s + 1] != 2 &&
                                            PoleLodi2[r - 1, s] != 5 &&
                                            PoleLodi2[r + 1, s] != 5 &&
                                            PoleLodi2[r, s - 1] != 5 &&
                                            PoleLodi2[r, s + 1] != 5 &&
                                            PoleLodi2[r - 1, s] != 6 &&
                                            PoleLodi2[r + 1, s] != 6 &&
                                            PoleLodi2[r, s - 1] != 6 &&
                                            PoleLodi2[r, s + 1] != 6)
                                        {
                                            PoleRect2[r, s].Tag = 2;
                                            PoleLodi2[r, s] = 2;
                                            Uri lod;
                                            lod = new Uri("pack://application:,,,/Pictures/JednickovaLod.jpg");
                                            PoleRect2[r, s].Fill = new ImageBrush(new BitmapImage(lod));
                                            //PoleRect2[r, s].Fill = Brushes.Yellow;
                                            lode2++;
                                            jednicka--;
                                            jednotka++;

                                        }


                                        //SingleLod.Content = jednicka;

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

                                    if (PoleLodi2[r, s] == 0)
                                    {

                                        if (otoceni == true)
                                        {
                                            if (PoleLodi2[r - 1, s] != 1 && PoleLodi2[r, s] == 0)
                                            {


                                                if (PoleLodi2[r - 1, s] != 5 &&
                                                    PoleLodi2[r + 1, s] != 5 &&
                                                    PoleLodi2[r - 2, s] != 5 &&
                                                    PoleLodi2[r, s - 1] != 5 &&
                                                    PoleLodi2[r, s + 1] != 5 &&
                                                    PoleLodi2[r + 1, s + 1] != 5 &&
                                                    PoleLodi2[r - 1, s + 1] != 5 &&
                                                    PoleLodi2[r + 1, s - 1] != 5 &&
                                                    PoleLodi2[r - 1, s - 1] != 5 &&
                                                    PoleLodi2[r - 1, s] != 2 &&
                                                    PoleLodi2[r + 1, s] != 2 &&
                                                    PoleLodi2[r - 2, s] != 2 &&
                                                    PoleLodi2[r, s - 1] != 2 &&
                                                    PoleLodi2[r, s + 1] != 2 &&
                                                    PoleLodi2[r + 1, s + 1] != 2 &&
                                                    PoleLodi2[r - 1, s + 1] != 2 &&
                                                    PoleLodi2[r + 1, s - 1] != 2 &&
                                                    PoleLodi2[r - 1, s - 1] != 2 &&
                                                    PoleLodi2[r - 1, s] != 6 &&
                                                    PoleLodi2[r + 1, s] != 6 &&
                                                    PoleLodi2[r - 2, s] != 6 &&
                                                    PoleLodi2[r, s - 1] != 6 &&
                                                    PoleLodi2[r, s + 1] != 6 &&
                                                    PoleLodi2[r + 1, s + 1] != 6 &&
                                                    PoleLodi2[r - 1, s + 1] != 6 &&
                                                    PoleLodi2[r + 1, s - 1] != 6 &&
                                                    PoleLodi2[r - 1, s - 1] != 6)
                                                {
                                                    PoleRect2[r, s].Tag = 5;
                                                    PoleLodi2[r, s] = 5;
                                                    PoleRect2[r - 1, s].Tag = 5;
                                                    PoleLodi2[r - 1, s] = 5;
                                                    Uri lod;
                                                    Uri lod1;
                                                    lod = new Uri("pack://application:,,,/Pictures/LodPredek.jpg");
                                                    lod1 = new Uri("pack://application:,,,/Pictures/LodZada.jpg");
                                                    PoleRect2[r, s].Fill = new ImageBrush(new BitmapImage(lod1));
                                                    PoleRect2[r - 1, s].Fill = new ImageBrush(new BitmapImage(lod));

                                                    //PoleRect2[r, s].Fill = Brushes.Pink;
                                                    //PoleRect2[r - 1, s].Fill = Brushes.Pink;
                                                    lode2 = lode2 + 2;
                                                    dvojka--;
                                                    dvojovka++;
                                                }

                                                //else if (PoleLodi2[r - 1, s] != 6 && PoleLodi2[r + 1, s] != 6 && PoleLodi2[r, s - 1] != 6 && PoleLodi2[r, s + 1] != 6 && PoleLodi2[r + 1, s + 1] != 6 && PoleLodi2[r - 1, s + 1] != 6 && PoleLodi2[r + 1, s - 1] != 6 && PoleLodi2[r - 1, s - 1] != 6)
                                                //{
                                                //    PoleRect2[r, s].Tag = 5;
                                                //    PoleLodi2[r, s] = 5;
                                                //    PoleRect2[r - 1, s].Tag = 5;
                                                //    PoleLodi2[r - 1, s] = 5;
                                                //    PoleRect2[r, s].Fill = Brushes.Pink;
                                                //    PoleRect2[r - 1, s].Fill = Brushes.Pink;
                                                //    lode2 = lode2 + 2;
                                                //    dvojka--;
                                                //    dvojovka++;
                                                //}

                                                if (dvojka == 0)
                                                {
                                                    DoubleLod.IsEnabled = false;
                                                    DoubleLod_LBL.IsEnabled = false;
                                                    DveLode = false;
                                                }
                                            }


                                        }
                                        else if (PoleLodi2[r, s - 1] != 1 && PoleLodi2[r, s] == 0)
                                        {
                                            if (PoleLodi2[r - 1, s] != 5 &&
                                                PoleLodi2[r + 1, s] != 5 &&
                                                PoleLodi2[r, s - 2] != 5 &&
                                                PoleLodi2[r, s - 1] != 5 &&
                                                PoleLodi2[r, s + 1] != 5 &&
                                                PoleLodi2[r + 1, s + 1] != 5 &&
                                                PoleLodi2[r - 1, s + 1] != 5 &&
                                                PoleLodi2[r + 1, s - 1] != 5 &&
                                                PoleLodi2[r - 1, s - 1] != 5 &&
                                                PoleLodi2[r - 1, s] != 2 &&
                                                PoleLodi2[r + 1, s] != 2 &&
                                                PoleLodi2[r, s - 2] != 2 &&
                                                PoleLodi2[r, s - 1] != 2 &&
                                                PoleLodi2[r, s + 1] != 2 &&
                                                PoleLodi2[r + 1, s + 1] != 2 &&
                                                PoleLodi2[r - 1, s + 1] != 2 &&
                                                PoleLodi2[r + 1, s - 1] != 2 &&
                                                PoleLodi2[r - 1, s - 1] != 2 &&
                                                PoleLodi2[r - 1, s] != 6 &&
                                                PoleLodi2[r + 1, s] != 6 &&
                                                PoleLodi2[r, s - 2] != 6 &&
                                                PoleLodi2[r, s - 1] != 6 &&
                                                PoleLodi2[r, s + 1] != 6 &&
                                                PoleLodi2[r + 1, s + 1] != 6 &&
                                                PoleLodi2[r - 1, s + 1] != 6 &&
                                                PoleLodi2[r + 1, s - 1] != 6 &&
                                                PoleLodi2[r - 1, s - 1] != 6)
                                            {


                                                PoleRect2[r, s].Tag = 5;
                                                PoleLodi2[r, s] = 5;
                                                PoleRect2[r, s - 1].Tag = 5;
                                                PoleLodi2[r, s - 1] = 5;
                                                Uri lod;
                                                Uri lod1;
                                                lod = new Uri("pack://application:,,,/Pictures/LodPredek.jpg");
                                                lod1 = new Uri("pack://application:,,,/Pictures/LodZada.jpg");
                                                PoleRect2[r, s].Fill = new ImageBrush(new BitmapImage(lod1));
                                                PoleRect2[r, s - 1].Fill = new ImageBrush(new BitmapImage(lod));
                                                //PoleRect2[r, s].Fill = Brushes.Pink;
                                                //PoleRect2[r, s - 1].Fill = Brushes.Pink;
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
                                    if (PoleLodi2[r, s] == 0)
                                    {
                                        Random rnd = new Random();
                                        int cislo1 = rnd.Next(1, 11);
                                        int cislo2 = rnd.Next(1, 11);


                                        if (otoceni == true)
                                        {
                                            if (PoleLodi2[r - 1, s] == 1)
                                            {
                                                PoleLodi2[r - 1, s] = 1;
                                            }
                                            else if (PoleLodi2[r + 1, s] == 1)
                                            {
                                                PoleLodi2[r + 1, s] = 1;
                                            }

                                            if (PoleLodi2[r - 1, s] != 2 &&
                                                PoleLodi2[r + 1, s] != 2 &&

                                                PoleLodi2[r - 1, s] != 5 &&
                                                PoleLodi2[r + 1, s] != 5 &&


                                                PoleLodi2[r - 1, s] != 1 &&
                                                PoleLodi2[r + 1, s] != 1 

                                                )
                                            {
                                                PoleRect2[r, s].Tag = 6;
                                                PoleLodi2[r, s] = 6;
                                                PoleRect2[r + 1, s].Tag = 6;
                                                PoleLodi2[r + 1, s] = 6;
                                                PoleRect2[r - 1, s].Tag = 6;
                                                PoleLodi2[r - 1, s] = 6;
                                                Uri lod;
                                                Uri lod1;
                                                Uri lod2;
                                                lod = new Uri("pack://application:,,,/Pictures/LodPredek.jpg");
                                                lod1 = new Uri("pack://application:,,,/Pictures/LodZada.jpg");
                                                lod2 = new Uri("pack://application:,,,/Pictures/LodStred.jpg");
                                                PoleRect2[r, s].Fill = new ImageBrush(new BitmapImage(lod2));
                                                PoleRect2[r - 1, s].Fill = new ImageBrush(new BitmapImage(lod));
                                                PoleRect2[r + 1, s].Fill = new ImageBrush(new BitmapImage(lod1));
                                                //PoleRect2[r + 1, s].Fill = Brushes.Brown;
                                                //PoleRect2[r - 1, s].Fill = Brushes.Brown;
                                                //PoleRect2[r, s].Fill = Brushes.Brown;
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

                                            if (PoleLodi2[r, s - 1] == 1)
                                            {
                                                PoleLodi2[r, s - 1] = 1;
                                            }
                                            else if (PoleLodi2[r, s + 1] == 1)
                                            {
                                                PoleLodi2[r, s + 1] = 1;
                                            }
                                            else if (PoleLodi2[r - 1, s] != 2 &&
                                                    PoleLodi2[r + 1, s] != 2 &&
                                                    PoleLodi2[r, s - 2] != 2 &&
                                                    PoleLodi2[r, s - 1] != 2 &&
                                                    PoleLodi2[r, s + 1] != 2 &&
                                                    PoleLodi2[r + 1, s + 1] != 2 &&
                                                    PoleLodi2[r - 1, s + 1] != 2 &&
                                                    PoleLodi2[r + 1, s - 1] != 2 &&
                                                    PoleLodi2[r - 1, s - 1] != 2 &&
                                                    PoleLodi2[r, s - 2] != 2 &&
                                                    PoleLodi2[r, s + 2] != 2 &&
                                                    PoleLodi2[r - 1, s] != 5 &&
                                                    PoleLodi2[r + 1, s] != 5 &&
                                                    PoleLodi2[r, s - 2] != 5 &&
                                                    PoleLodi2[r, s - 1] != 5 &&
                                                    PoleLodi2[r, s + 1] != 5 &&
                                                    PoleLodi2[r + 1, s + 1] != 5 &&
                                                    PoleLodi2[r - 1, s + 1] != 5 &&
                                                    PoleLodi2[r + 1, s - 1] != 5 &&
                                                    PoleLodi2[r - 1, s - 1] != 5 &&
                                                    PoleLodi2[r, s - 2] != 5 &&
                                                    PoleLodi2[r, s + 2] != 5 
                                                    )
                                            {


                                                PoleRect2[r, s].Tag = 6;
                                                PoleLodi2[r, s] = 6;
                                                PoleRect2[r, s + 1].Tag = 6;
                                                PoleLodi2[r, s + 1] = 6;
                                                PoleRect2[r, s - 1].Tag = 6;
                                                PoleLodi2[r, s - 1] = 6;
                                                Uri lod;
                                                Uri lod1;
                                                Uri lod2;
                                                lod = new Uri("pack://application:,,,/Pictures/LodPredek.jpg");
                                                lod1 = new Uri("pack://application:,,,/Pictures/LodZada.jpg");
                                                lod2 = new Uri("pack://application:,,,/Pictures/LodStred.jpg");
                                                PoleRect2[r, s].Fill = new ImageBrush(new BitmapImage(lod2));
                                                PoleRect2[r, s - 1].Fill = new ImageBrush(new BitmapImage(lod));
                                                PoleRect2[r, s + 1].Fill = new ImageBrush(new BitmapImage(lod1));
                                                //PoleRect2[r, s + 1].Fill = Brushes.Brown;
                                                //PoleRect2[r, s - 1].Fill = Brushes.Brown;
                                                //PoleRect2[r, s].Fill = Brushes.Brown;
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
                                    if (PoleLodi2[r, s] == 2)
                                    {
                                        PoleRect2[r, s].Tag = 0;
                                        PoleLodi2[r, s] = 0;
                                        PoleRect2[r, s].Fill = Brushes.White;
                                        lode2--;
                                        jednicka++;
                                        jednotka--;
                                        Console.WriteLine(mazani);

                                        if (jednicka > 0)
                                        {
                                            SingleLod.IsEnabled = true;
                                            SingleLod_LBL.IsEnabled = true;
                                            JednaLod = true;
                                            
                                        }

                                    }

                                    else if (PoleLodi2[r, s] == 5)
                                    {
                                        PoleRect2[r, s].Tag = 0;
                                        PoleLodi2[r, s] = 0;
                                        PoleRect2[r, s].Fill = Brushes.White;
                                        if (PoleLodi2[r - 1, s] == 5)
                                        {
                                            PoleRect2[r - 1, s].Tag = 0;
                                            PoleLodi2[r - 1, s] = 0;
                                            PoleRect2[r - 1, s].Fill = Brushes.White;
                                        }
                                        else if (PoleLodi2[r + 1, s] == 5)
                                        {
                                            PoleRect2[r + 1, s].Tag = 0;
                                            PoleLodi2[r + 1, s] = 0;
                                            PoleRect2[r + 1, s].Fill = Brushes.White;
                                        }
                                        else if (PoleLodi2[r, s + 1] == 5)
                                        {
                                            PoleRect2[r, s + 1].Tag = 0;
                                            PoleLodi2[r, s + 1] = 0;
                                            PoleRect2[r, s + 1].Fill = Brushes.White;
                                        }
                                        else if (PoleLodi2[r, s - 1] == 5)
                                        {
                                            PoleRect2[r, s - 1].Tag = 0;
                                            PoleLodi2[r, s - 1] = 0;
                                            PoleRect2[r, s - 1].Fill = Brushes.White;
                                        }

                                        lode2 = lode2-2;
                                        dvojka++;
                                        dvojovka--;
                                        Console.WriteLine(mazani);

                                        if (dvojka > 0)
                                        {
                                            DoubleLod.IsEnabled = true;
                                            DoubleLod_LBL.IsEnabled = true;
                                            DveLode = true;
                                        }
                                    }




                                    else if (PoleLodi2[r, s] == 6)
                                    {
                                        
                                        if (PoleLodi2[r + 1, s] == 1)
                                        {
                                            if (PoleLodi2[r, s + 2] == 6)
                                            {
                                                PoleRect2[r, s + 2].Tag = 0;
                                                PoleLodi2[r, s + 2] = 0;
                                                PoleRect2[r, s + 2].Fill = Brushes.White;
                                            }
                                            if (PoleLodi2[r, s - 2] == 6)
                                            {
                                                PoleRect2[r, s - 2].Tag = 0;
                                                PoleLodi2[r, s - 2] = 0;
                                                PoleRect2[r, s - 2].Fill = Brushes.White;
                                            }
                                            if (PoleLodi2[r - 2, s] == 6)
                                            {
                                                PoleRect2[r - 2, s].Tag = 0;
                                                PoleLodi2[r - 2, s] = 0;
                                                PoleRect2[r - 2, s].Fill = Brushes.White;
                                            }
                                        }
                                        else if (PoleLodi2[r - 1, s] == 1)
                                        {
                                            if (PoleLodi2[r, s + 2] == 6)
                                            {
                                                PoleRect2[r, s + 2].Tag = 0;
                                                PoleLodi2[r, s + 2] = 0;
                                                PoleRect2[r, s + 2].Fill = Brushes.White;
                                            }
                                            if (PoleLodi2[r, s - 2] == 6)
                                            {
                                                PoleRect2[r, s - 2].Tag = 0;
                                                PoleLodi2[r, s - 2] = 0;
                                                PoleRect2[r, s - 2].Fill = Brushes.White;
                                            }
                                            if (PoleLodi2[r + 2, s] == 6)
                                            {
                                                PoleRect2[r + 2, s].Tag = 0;
                                                PoleLodi2[r + 2, s] = 0;
                                                PoleRect2[r + 2, s].Fill = Brushes.White;
                                            }
                                        }
                                        else if (PoleLodi2[r , s + 1] == 1)
                                        {
                                            if (PoleLodi2[r + 2, s] == 6)
                                            {
                                                PoleRect2[r + 2, s].Tag = 0;
                                                PoleLodi2[r + 2, s] = 0;
                                                PoleRect2[r + 2, s].Fill = Brushes.White;
                                            }
                                            if (PoleLodi2[r, s - 2] == 6)
                                            {
                                                PoleRect2[r, s - 2].Tag = 0;
                                                PoleLodi2[r, s - 2] = 0;
                                                PoleRect2[r, s - 2].Fill = Brushes.White;
                                            }
                                            if (PoleLodi2[r - 2, s] == 6)
                                            {
                                                PoleRect2[r - 2, s].Tag = 0;
                                                PoleLodi2[r - 2, s] = 0;
                                                PoleRect2[r - 2, s].Fill = Brushes.White;
                                            }
                                        }
                                        else if (PoleLodi2[r, s - 1] == 1)
                                        {
                                            if (PoleLodi2[r + 2, s] == 6)
                                            {
                                                PoleRect2[r + 2, s].Tag = 0;
                                                PoleLodi2[r + 2, s] = 0;
                                                PoleRect2[r + 2, s].Fill = Brushes.White;
                                            }
                                            if (PoleLodi2[r, s + 2] == 6)
                                            {
                                                PoleRect2[r, s + 2].Tag = 0;
                                                PoleLodi2[r, s + 2] = 0;
                                                PoleRect2[r, s + 2].Fill = Brushes.White;
                                            }
                                            if (PoleLodi2[r - 2, s] == 6)
                                            {
                                                PoleRect2[r - 2, s].Tag = 0;
                                                PoleLodi2[r - 2, s] = 0;
                                                PoleRect2[r - 2, s].Fill = Brushes.White;
                                            }
                                        }



                                        //if (PoleLodi2[r + 1, s - 1] == 1)
                                        //{
                                        //    if (PoleLodi2[r, s + 2] == 6)
                                        //    {
                                        //        PoleRect2[r, s + 2].Tag = 0;
                                        //        PoleLodi2[r, s + 2] = 0;
                                        //        PoleRect2[r, s + 2].Fill = Brushes.Gray;
                                        //    }
                                        //    else if (PoleLodi2[r - 2, s] == 6)
                                        //    {
                                        //        PoleRect2[r - 2, s].Tag = 0;
                                        //        PoleLodi2[r - 2, s] = 0;
                                        //        PoleRect2[r - 2, s].Fill = Brushes.Gray;
                                        //    }
                                        //}

                                        //else if (PoleLodi2[r - 1, s + 1] == 1)
                                        //{
                                        //    if (PoleLodi2[r, s - 2] == 6)
                                        //    {
                                        //        PoleRect2[r, s - 2].Tag = 0;
                                        //        PoleLodi2[r, s - 2] = 0;
                                        //        PoleRect2[r, s - 2].Fill = Brushes.Gray;
                                        //    }
                                        //    else if (PoleLodi2[r + 2, s] == 6)
                                        //    {
                                        //        PoleRect2[r + 2, s].Tag = 0;
                                        //        PoleLodi2[r + 2, s] = 0;
                                        //        PoleRect2[r + 2, s].Fill = Brushes.Gray;
                                        //    }
                                        //}

                                        //else if (PoleLodi2[r + 1, s + 1] == 1)
                                        //{
                                        //    if (PoleLodi2[r, s - 2] == 6)
                                        //    {
                                        //        PoleRect2[r, s - 2].Tag = 0;
                                        //        PoleLodi2[r, s - 2] = 0;
                                        //        PoleRect2[r, s - 2].Fill = Brushes.Gray;
                                        //    }
                                        //    else if (PoleLodi2[r - 2, s] == 6)
                                        //    {
                                        //        PoleRect2[r - 2, s].Tag = 0;
                                        //        PoleLodi2[r - 2, s] = 0;
                                        //        PoleRect2[r - 2, s].Fill = Brushes.Gray;
                                        //    }
                                        //}

                                        //else if (PoleLodi2[r - 1, s - 1] == 1)
                                        //{
                                        //    if (PoleLodi2[r, s + 2] == 6)
                                        //    {
                                        //        PoleRect2[r, s + 2].Tag = 0;
                                        //        PoleLodi2[r, s + 2] = 0;
                                        //        PoleRect2[r, s + 2].Fill = Brushes.Gray;
                                        //    }
                                        //    else if (PoleLodi2[r + 2, s] == 6)
                                        //    {
                                        //        PoleRect2[r + 2, s].Tag = 0;
                                        //        PoleLodi2[r + 2, s] = 0;
                                        //        PoleRect2[r + 2, s].Fill = Brushes.Gray;
                                        //    }
                                        //}



                                        else
                                        {
                                            if (PoleLodi2[r - 2, s] == 6)
                                            {
                                                PoleRect2[r - 2, s].Tag = 0;
                                                PoleLodi2[r - 2, s] = 0;
                                                PoleRect2[r - 2, s].Fill = Brushes.White;
                                            }
                                            if (PoleLodi2[r + 2, s] == 6)
                                            {
                                                PoleRect2[r + 2, s].Tag = 0;
                                                PoleLodi2[r + 2, s] = 0;
                                                PoleRect2[r + 2, s].Fill = Brushes.White;
                                            }
                                            if (PoleLodi2[r, s - 2] == 6)
                                            {
                                                PoleRect2[r, s - 2].Tag = 0;
                                                PoleLodi2[r, s - 2] = 0;
                                                PoleRect2[r, s - 2].Fill = Brushes.White;
                                            }
                                            if (PoleLodi2[r, s + 2] == 6)
                                            {
                                                PoleRect2[r, s + 2].Tag = 0;
                                                PoleLodi2[r, s + 2] = 0;
                                                PoleRect2[r, s + 2].Fill = Brushes.White;
                                            }
                                        }

                                        PoleRect2[r, s].Tag = 0;
                                        PoleLodi2[r, s] = 0;
                                        PoleRect2[r, s].Fill = Brushes.White;
                                        if (PoleLodi2[r - 1, s] == 6)
                                        {
                                            PoleRect2[r - 1, s].Tag = 0;
                                            PoleLodi2[r - 1, s] = 0;
                                            PoleRect2[r - 1, s].Fill = Brushes.White;
                                        }
                                        if (PoleLodi2[r + 1, s] == 6)
                                        {
                                            PoleRect2[r + 1, s].Tag = 0;
                                            PoleLodi2[r + 1, s] = 0;
                                            PoleRect2[r + 1, s].Fill = Brushes.White;
                                        }
                                        if (PoleLodi2[r, s + 1] == 6)
                                        {
                                            PoleRect2[r, s + 1].Tag = 0;
                                            PoleLodi2[r, s + 1] = 0;
                                            PoleRect2[r, s + 1].Fill = Brushes.White;
                                        }
                                        if (PoleLodi2[r, s - 1] == 6)
                                        {
                                            PoleRect2[r, s - 1].Tag = 0;
                                            PoleLodi2[r, s - 1] = 0;
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
                            if (PoleLodi[r, s] == 1) PoleRect[r, s].Tag = 1;
                            else if (PoleLodi[r, s] == 0) PoleRect[r, s].Tag = 0;
                            else if (PoleLodi[r, s] == 2) PoleRect[r, s].Tag = 2;
                            else if (PoleLodi[r, s] == 2) lode++;
                            else if ((int)PoleRect[r, s].Tag == 3) PoleLodi[r, s] = 3;

                            //Console.Write(PoleRect[r, s].Tag);
                            //Console.WriteLine(PoleLodi[r,s]);

                        }
                        Console.WriteLine();
                    }


                    Rec.Tag = 4;
                    

                    for (int r = 0; r < PoleLodi.GetLength(0); r++)
                    {
                        for (int s = 0; s < PoleLodi.GetLength(1); s++)
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
                                        PoleLodi[r, s] = 3;
                                        r--;

                                    }

                                    if ((int)PoleRect[r, s].Tag == 2)
                                    {
                                        PoleRect[r, s].Tag = 9;
                                        PoleLodi[r, s] = 9;
                                        //PoleRect[r, s].Fill = Brushes.Green;
                                        Uri hit;
                                        hit = new Uri("pack://application:,,,/Pictures/LodeHit.jpg");
                                        PoleRect[r, s].Fill = new ImageBrush(new BitmapImage(hit));
                                    }


                                    if (PoleLodi[r, s] == 9)
                                    {
                                        indx = r;
                                        indy = s;

                                        PoleRect[r, s].Tag = 9;
                                        PoleLodi[r, s] = 9;
                                    }

                                    if (PoleLodi[r, s] == 1)
                                    {
                                        indx = r;
                                        indy = s;

                                        PoleRect[r, s].Tag = 1;
                                        PoleLodi[r, s] = 1;

                                        s--;


                                    }





                                    else if ((int)PoleRect[r, s].Tag == 4)
                                    {

                                        indx = r;
                                        indy = s;

                                        PoleRect[r, s].Tag = 4;
                                        PoleLodi[r, s] = 4;




                                        if (PoleRect[r, s].Fill == Brushes.White)
                                        {
                                            Uri miss;
                                            miss = new Uri("pack://application:,,,/Pictures/LodeMiss.jpg");
                                            PoleRect[r, s].Fill = new ImageBrush(new BitmapImage(miss));

                                           // PoleRect[r, s].Fill = Brushes.Red;

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
                                else if (PoleLodi[r, s] == 2 || PoleLodi[r, s] == 5 || PoleLodi[r, s] == 6)
                                {

                                    indx = r;
                                    indy = s;


                                    //PoleRect[r, s].Tag = 2;
                                    //PoleLodi[r, s] = 2;

                                    if (PoleLodi[r, s] == 2)
                                    {
                                        PoleRect[r, s].Tag = 2;
                                        PoleLodi[r, s] = 2;


                                    }
                                    else if (PoleLodi[r, s] == 5)
                                    {
                                        PoleRect[r, s].Tag = 5;
                                        PoleLodi[r, s] = 5;

                                    }
                                    else if (PoleLodi[r, s] == 6)
                                    {
                                        PoleRect[r, s].Tag = 6;
                                        PoleLodi[r, s] = 6;

                                    }




                                    if ((int)PoleRect[r, s].Tag == 2)
                                    {
                                        PoleRect[r, s].Tag = 9;
                                        PoleLodi[r, s] = 9;
                                        //PoleRect[r, s].Fill = Brushes.Green;
                                        Uri hit;
                                        hit = new Uri("pack://application:,,,/Pictures/LodeHit.jpg");
                                        PoleRect[r, s].Fill = new ImageBrush(new BitmapImage(hit));
                                        lode--;
                                        jednotka1--;

                                    }

                                    else if ((int)PoleRect[r, s].Tag == 5)
                                    {
                                        PoleRect[r, s].Tag = 9;
                                        PoleLodi[r, s] = 9;
                                        //PoleRect[r, s].Fill = Brushes.Green;
                                        Uri hit;
                                        hit = new Uri("pack://application:,,,/Pictures/LodeHit.jpg");
                                        PoleRect[r, s].Fill = new ImageBrush(new BitmapImage(hit));
                                        lode--;
                                        dva--;
                                        if (dva % 2 == 0)
                                        {
                                            dvojovka1--;
                                            DvojkovalodHrac.Content = dvojovka1;
                                        }
                                    }


                                    else if ((int)PoleRect[r, s].Tag == 6)
                                    {
                                        PoleRect[r, s].Tag = 9;
                                        PoleLodi[r, s] = 9;
                                        //PoleRect[r, s].Fill = Brushes.Green;
                                        Uri hit;
                                        hit = new Uri("pack://application:,,,/Pictures/LodeHit.jpg");
                                        PoleRect[r, s].Fill = new ImageBrush(new BitmapImage(hit));
                                        lode--;
                                        tri--;

                                        if (tri == 0)
                                        {
                                            trojovka1--;
                                            TrojkovalodHrac.Content = trojovka1;
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
                    MessageBox.Show("Hráč vyhrál");
                    this.Close();
                }


            }
            

            JednickovalodPC.Content = jednotka;
            DvojkovalodPC.Content = dvojovka;
            TrojkovalodPC.Content = trojovka;
            JednickovalodHrac.Content = jednotka1;
            DvojkovalodHrac.Content = dvojovka1;
            TrojkovalodHrac.Content = trojovka1;

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


            //Class1.Rec2 = PoleRect2[cislo1, cislo2];


            for (int r = 0; r < PoleRect.GetLength(0); r++)
            {
                for (int s = 0; s < PoleRect.GetLength(1); s++)
                {
                    if (PoleLodi2[r, s] == 1) PoleRect2[r, s].Tag = 1;
                    if (PoleLodi2[r, s] == 0) PoleRect2[r, s].Tag = 0;
                    if (PoleLodi2[r, s] == 2) PoleRect2[r, s].Tag = 2;
                    if (PoleLodi2[r, s] == 5) PoleRect2[r, s].Tag = 6;
                    if (PoleLodi2[r, s] == 6) PoleRect2[r, s].Tag = 5;
                    //if (PoleLodi2[r, s] == 2) lode2++;
                    if ((int)PoleRect2[r, s].Tag == 3) PoleLodi2[r, s] = 3;
                }

            }

            while (true)
            {
                if (PoleLodi2[cislo1, cislo2] == 3 || PoleLodi2[cislo1, cislo2] == 1 || PoleLodi2[cislo1, cislo2] == 9)
                {

                    cislo1 = rnd.Next(1, 11);
                    cislo2 = rnd.Next(1, 11);
                    Console.WriteLine(cislo1);
                    Console.WriteLine(cislo2);
                    Class1.Rec2 = PoleRect2[cislo1, cislo2];
                }

                else
                {
                    Class1.Rec2 = PoleRect2[cislo1, cislo2];
                    break;
                }
            }


            Class1.Rec2.Tag = 4;

            for (int r = 0; r < PoleLodi2.GetLength(0); r++)
            {
                Console.WriteLine();

                for (int s = 0; s < PoleLodi2.GetLength(1); s++)
                {


                    //Console.WriteLine(lode2);
                    //Console.Write((int)PoleRect2[r, s].Tag);



                    if ((int)PoleRect2[r, s].Tag == 4)
                    {


                        if ((int)PoleRect2[r, s].Tag == 9)
                        {

                            indx2 = r;
                            indy2 = s;

                            PoleRect2[r, s].Tag = 9;
                            PoleLodi2[r, s] = 9;
                        }

                        else if (PoleLodi2[r, s] == 2 || PoleLodi2[r, s] == 5 || PoleLodi2[r, s] == 6)
                        {

                            indx2 = r;
                            indy2 = s;

                            PoleRect2[r, s].Tag = 2;
                            PoleLodi2[r, s] = 2;


                            if ((int)PoleRect2[r, s].Tag == 2 || (int)PoleRect2[r, s].Tag == 5 || (int)PoleRect2[r, s].Tag == 6)
                            {
                                PoleRect2[r, s].Tag = 9;
                                PoleLodi2[r, s] = 9;
                                Uri hit;
                                hit = new Uri("pack://application:,,,/Pictures/LodeHit.jpg");
                                PoleRect2[r, s].Fill = new ImageBrush(new BitmapImage(hit));
                                //PoleRect2[r, s].Fill = Brushes.Green;
                                lode2--;
                            }

                        }
                        else
                        {
                            indx2 = r;
                            indy2 = s;

                            PoleRect2[r, s].Tag = 3;
                            PoleLodi2[r, s] = 3;
                            if ((int)PoleRect2[r, s].Tag == 3)
                            {
                                Uri miss;
                                miss = new Uri("pack://application:,,,/Pictures/LodeMiss.jpg");
                                PoleRect2[r, s].Fill = new ImageBrush(new BitmapImage(miss));
                                //PoleRect2[r, s].Fill = Brushes.Red;
                            }


                        }


                    }


                }
                //PoleRect2[indx2, indy2].Tag = 3;

            }
            if (lode2 == 0)
            {
                MessageBox.Show("Počítač vyhrál");
                this.Close();
            }

        }

        private void Pocitac2()
        {
            Random rnd = new Random();
            int cislo1 = rnd.Next(1, 11);
            int cislo2 = rnd.Next(1, 11);


            //Class1.Rec2 = PoleRect2[cislo1, cislo2];


            for (int r = 0; r < PoleRect.GetLength(0); r++)
            {
                for (int s = 0; s < PoleRect.GetLength(1); s++)
                {
                    if (PoleLodi2[r, s] == 1) PoleRect2[r, s].Tag = 1;
                    if (PoleLodi2[r, s] == 0) PoleRect2[r, s].Tag = 0;
                    if (PoleLodi2[r, s] == 2) PoleRect2[r, s].Tag = 2;
                    if (PoleLodi2[r, s] == 5) PoleRect2[r, s].Tag = 6;
                    if (PoleLodi2[r, s] == 6) PoleRect2[r, s].Tag = 5;
                    //if (PoleLodi2[r, s] == 2) lode2++;
                    if ((int)PoleRect2[r, s].Tag == 3) PoleLodi2[r, s] = 3;
                }

            }

            while (true)
            {
                if (PoleLodi2[cislo1, cislo2] == 3 || PoleLodi2[cislo1, cislo2] == 1 || PoleLodi2[cislo1, cislo2] == 9)
                {

                    cislo1 = rnd.Next(1, 11);
                    cislo2 = rnd.Next(1, 11);
                    Console.WriteLine(cislo1);
                    Console.WriteLine(cislo2);
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


                for (int r = 0; r < PoleLodi2.GetLength(0); r++)
                {
                    Console.WriteLine();

                    for (int s = 0; s < PoleLodi2.GetLength(1); s++)
                    {


                        //Console.WriteLine(lode2);
                        //Console.Write((int)PoleRect2[r, s].Tag);



                        if ((int)PoleRect2[r, s].Tag == 4)
                        {


                            if ((int)PoleRect2[r, s].Tag == 9)
                            {

                                indx2 = r;
                                indy2 = s;

                                PoleRect2[r, s].Tag = 9;
                                PoleLodi2[r, s] = 9;
                            }



                            else if (PoleLodi2[r, s] == 2 || PoleLodi2[r, s] == 5 || PoleLodi2[r, s] == 6)
                            {

                                indx2 = r;
                                indy2 = s;

                                //if (PoleLodi2[r, s] == 2)
                                //{
                                //    jednotka--;
                                //}

                                //else if (PoleLodi2[r, s] == 5)
                                //{
                                //    dvaPC--;
                                //}

                                //else if (PoleLodi2[r, s] == 6)
                                //{
                                //    triPC--;
                                //}
                                PoleRect2[r, s].Tag = 5;
                                PoleLodi2[r, s] = 5;

                                //JednickovalodPC.Content = jednotka;
                                //if (dvaPC % 2 == 0)
                                //{
                                //    dvojovka--;
                                //    DvojkovalodPC.Content = dvojovka;
                                //}
                                //if (triPC % 3 == 0)
                                //{
                                //    trojovka--;
                                //    TrojkovalodPC.Content = trojovka;
                                //}

                                if ((int)PoleRect2[r, s].Tag == 2 || (int)PoleRect2[r, s].Tag == 5 || (int)PoleRect2[r, s].Tag == 6)
                                {
                                    lode2--;
                                    
                                    a = r;
                                    b = s;





                                    PoleRect2[r, s].Tag = 9;
                                    PoleLodi2[r, s] = 9;
                                   //PoleRect2[r, s].Fill = Brushes.Green;
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
                                PoleLodi2[r, s] = 3;
                                if ((int)PoleRect2[r, s].Tag == 3)
                                {
                                    Uri miss;
                                    miss = new Uri("pack://application:,,,/Pictures/LodeMiss.jpg");
                                    PoleRect2[r, s].Fill = new ImageBrush(new BitmapImage(miss));
                                    //PoleRect2[r, s].Fill = Brushes.Red;
                                }
                            }
                        }
                    }
                    //PoleRect2[indx2, indy2].Tag = 3;

                }
                if (lode2 == 0)
                {
                    MessageBox.Show("Počítač vyhrál");
                    this.Close();

                }
            }

            else if (a > 0)
            {
                if ((int)PoleRect2[a - 1, b].Tag == 5 || (int)PoleRect2[a - 1, b].Tag == 6)
                {
                    PoleRect2[a - 1, b].Tag = 9;
                    PoleLodi2[a - 1, b] = 9;
                    //PoleRect2[a - 1, b].Fill = Brushes.Green;
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
                    PoleLodi2[a + 1, b] = 9;
                    //PoleRect2[a + 1, b].Fill = Brushes.Green;
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
                    PoleLodi2[a, b - 1] = 9;
                    //PoleRect2[a, b - 1].Fill = Brushes.Green;
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
                    PoleLodi2[a, b + 1] = 9;
                    Uri hit;
                    hit = new Uri("pack://application:,,,/Pictures/LodeHit.jpg");
                    PoleRect2[a, b + 1].Fill = new ImageBrush(new BitmapImage(hit));
                    //PoleRect2[a, b + 1].Fill = Brushes.Green;
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
                        if (PoleLodi2[cislo1, cislo2] == 3 || PoleLodi2[cislo1, cislo2] == 1 || PoleLodi2[cislo1, cislo2] == 9)
                        {

                            cislo1 = rnd.Next(1, 11);
                            cislo2 = rnd.Next(1, 11);
                            Console.WriteLine(cislo1);
                            Console.WriteLine(cislo2);
                            Class1.Rec2 = PoleRect2[cislo1, cislo2];
                        }

                        else
                        {
                            Class1.Rec2 = PoleRect2[cislo1, cislo2];
                            break;
                        }
                    }

                    for (int r = 0; r < PoleLodi2.GetLength(0); r++)
                    {
                        Console.WriteLine();

                        for (int s = 0; s < PoleLodi2.GetLength(1); s++)
                        {


                            //Console.WriteLine(lode2);
                            //Console.Write((int)PoleRect2[r, s].Tag);



                            if ((int)PoleRect2[r, s].Tag == 4)
                            {


                                if ((int)PoleRect2[r, s].Tag == 9)
                                {

                                    indx2 = r;
                                    indy2 = s;

                                    PoleRect2[r, s].Tag = 9;
                                    PoleLodi2[r, s] = 9;
                                }



                                else if (PoleLodi2[r, s] == 2 || PoleLodi2[r, s] == 5 || PoleLodi2[r, s] == 6)
                                {

                                    indx2 = r;
                                    indy2 = s;

                                    PoleRect2[r, s].Tag = 5;
                                    PoleLodi2[r, s] = 5;

                                    if ((int)PoleRect2[r, s].Tag == 2 || (int)PoleRect2[r, s].Tag == 5 || (int)PoleRect2[r, s].Tag == 6)
                                    {
                                        PoleRect2[r, s].Tag = 9;
                                        PoleLodi2[r, s] = 9;
                                        Uri hit;
                                        hit = new Uri("pack://application:,,,/Pictures/LodeHit.jpg");
                                        PoleRect2[r, s].Fill = new ImageBrush(new BitmapImage(hit));
                                        //PoleRect2[r, s].Fill = Brushes.Green;
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
                                    PoleLodi2[r, s] = 3;
                                    if ((int)PoleRect2[r, s].Tag == 3)
                                    {
                                        Uri miss;
                                        miss = new Uri("pack://application:,,,/Pictures/LodeMiss.jpg");
                                        PoleRect2[r, s].Fill = new ImageBrush(new BitmapImage(miss));
                                        //PoleRect2[r, s].Fill = Brushes.Red;
                                    }
                                }
                            }
                        }
                        //PoleRect2[indx2, indy2].Tag = 3;

                    }
                }

                //cislo1 = rnd.Next(1, 11);
                //cislo2 = rnd.Next(1, 11);
                //cislo1 = r;
                //cislo2 = s;


            }


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
            win.Show();
            this.Close();

        }

        private void Napoveda_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("");
            
        }
    }
}