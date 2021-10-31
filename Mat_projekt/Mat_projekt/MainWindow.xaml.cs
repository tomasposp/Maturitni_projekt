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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mat_projekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


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

                    pole[row, col].Fill = Brushes.Gray;

                    pole[row, col].MouseLeftButtonDown += MainWindow_MouseLeftButtonDown;


                    pole[row, col].StrokeThickness = 0;
                    pole[row, col].Height = mrizka.Height / pole.GetLength(0);
                    pole[row, col].Width = mrizka.Width / pole.GetLength(1);
                    Grid.SetColumn(pole[row, col], col);
                    Grid.SetRow(pole[row, col], row);
                    Grid.SetZIndex(pole[row, col], 0);
                    mrizka.Children.Add(pole[row, col]);

                    Console.WriteLine(PoleRect[row, col].Tag);

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

                    pole2[row, col].Fill = Brushes.Gray;

                    pole2[row, col].MouseLeftButtonDown += MainWindow_MouseLeftButtonDown;

                    pole2[row, col].StrokeThickness = 0;
                    pole2[row, col].Height = mrizka2.Height / pole2.GetLength(0);
                    pole2[row, col].Width = mrizka2.Width / pole2.GetLength(1);
                    Grid.SetColumn(pole2[row, col], col);
                    Grid.SetRow(pole2[row, col], row);
                    Grid.SetZIndex(pole2[row, col], 0);
                    mrizka2.Children.Add(pole2[row, col]);

                    Console.WriteLine(PoleRect2[row, col].Tag);

                }

        }

        int lode = 0;
        bool zapnuty = false;
        int lode2 = 0;
        bool JednaLod = false;
        bool DveLode = false;
        bool TriLode = false;
        int jednicka = 5;
        int dvojka = 3;
        int trojka = 2;
        bool otoceni = false;
        bool mazani = false;



        private void Start_Click(object sender, RoutedEventArgs e)
        {

            zapnuty = true;
        }

        private void MainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (zapnuty == true)
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

                        }
                        //Console.WriteLine();
                    }


                    // TagToIntPole(PoleRect, PoleLodi);
                    Rec.Tag = 4;


                    for (int r = 0; r < PoleLodi.GetLength(0); r++)
                    {
                        for (int s = 0; s < PoleLodi.GetLength(1); s++)
                        {

                            if ((int)PoleRect[r, s].Tag == 4)
                            {

                                if (PoleLodi[r, s] == 1)
                                {
                                    indx = r;
                                    indy = s;

                                    PoleRect[r, s].Tag = 1;
                                    PoleLodi[r, s] = 1;

                                    s--;


                                }


                                else if (PoleLodi[r, s] == 2 || PoleLodi[r, s] == 5 || PoleLodi[r,s] == 6)
                                {

                                    indx = r;
                                    indy = s;

                                    PoleRect[r, s].Tag = 2;
                                    PoleLodi[r, s] = 2;



                                    if ((int)PoleRect[r, s].Tag == 2 || (int)PoleRect[r, s].Tag == 5 || (int)PoleRect[r, s].Tag == 6)
                                    {
                                        PoleRect[r, s].Tag = 9;
                                        PoleLodi[r, s] = 9;
                                        PoleRect[r, s].Fill = Brushes.Green;
                                        lode--;

                                    }

                                }



                                else if ((int)PoleRect[r, s].Tag == 4)
                                {

                                    indx = r;
                                    indy = s;

                                    PoleRect[r, s].Tag = 4;
                                    PoleLodi[r, s] = 4;




                                    if ((int)PoleRect[r, s].Tag == 4)
                                    {
                                        PoleRect[r, s].Fill = Brushes.Red;


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




            else if (zapnuty == false)
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
                                        Random rnd = new Random();
                                        int cislo1 = rnd.Next(1, 11);
                                        int cislo2 = rnd.Next(1, 11);

                                        PoleRect2[r, s].Tag = 2;
                                        PoleLodi2[r, s] = 2;
                                        PoleRect2[r, s].Fill = Brushes.Yellow;
                                        lode2++;
                                        jednicka--;
                                        while (true)
                                        {
                                            if (PoleLodi[cislo1, cislo2] == 2 || PoleLodi[cislo1, cislo2] == 5 || PoleLodi[cislo1, cislo2] == 6)
                                            {
                                                cislo1 = rnd.Next(1, 11);
                                                cislo2 = rnd.Next(1, 11);


                                                Console.WriteLine("jsi kokot");
                                            }
                                            else
                                            {
                                                PoleRect[cislo1, cislo2].Tag = 2;
                                                PoleLodi[cislo1, cislo2] = 2;
                                                PoleRect[cislo1, cislo2].Fill = Brushes.Yellow;
                                                lode++;
                                                break;
                                            }
                                        }


                                        //SingleLod.Content = jednicka;
                                        if (jednicka == 0)
                                        {
                                            SingleLod.IsEnabled = false;
                                            JednaLod = false;
                                        }
                                    }

                                    if (mazani == true)
                                    {
                                        if (PoleLodi[r, s] == 2)
                                        {
                                            PoleRect2[r, s].Tag = 0;
                                            PoleLodi2[r, s] = 0;
                                            PoleRect2[r, s].Fill = Brushes.Gray;
                                            lode2--;
                                            jednicka++;
                                            Console.WriteLine(mazani);
                                        }

                                    }
                                }

                                else if (DveLode == true)
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
                                            if (PoleLodi2[r - 1, s] == 2)
                                            {
                                                PoleLodi2[r - 1, s] = 2;
                                            }
                                            else
                                            {



                                                PoleRect2[r, s].Tag = 5;
                                                PoleLodi2[r, s] = 5;
                                                PoleRect2[r - 1, s].Tag = 5;
                                                PoleLodi2[r - 1, s] = 5;
                                                PoleRect2[r, s].Fill = Brushes.Pink;
                                                PoleRect2[r - 1, s].Fill = Brushes.Pink;
                                                lode2 = lode2 + 2;
                                                dvojka--;

                                                while (true)
                                                {
                                                    if (PoleLodi[cislo1, cislo2] == 2 || PoleLodi[cislo1, cislo2] == 5 || PoleLodi[cislo1, cislo2] == 6)
                                                    {
                                                        cislo1 = rnd.Next(1, 11);
                                                        cislo2 = rnd.Next(1, 11);


                                                        Console.WriteLine("jsi kokot");
                                                    }
                                                    else
                                                    {
                                                        PoleRect[cislo1, cislo2].Tag = 5;
                                                        PoleLodi[cislo1, cislo2] = 5;
                                                        PoleRect[cislo1 - 1, cislo2].Tag = 5;
                                                        PoleLodi[cislo1 - 1, cislo2] = 5;
                                                        PoleRect[cislo1, cislo2].Fill = Brushes.Pink;
                                                        PoleRect[cislo1 - 1, cislo2].Fill = Brushes.Pink;
                                                        lode = lode + 2;

                                                        break;
                                                    }
                                                }

                                            }



                                            if (dvojka == 0)
                                            {
                                                DoubleLod.IsEnabled = false;
                                                DveLode = false;
                                            }
                                        }
                                        else
                                        {

                                            if (PoleLodi2[r, s - 1] == 1)
                                            {
                                                PoleLodi2[r, s - 1] = 1;
                                            }
                                            if (PoleLodi2[r, s - 1] == 2)
                                            {
                                                PoleLodi2[r, s - 1] = 2;
                                            }
                                            else
                                            {


                                                PoleRect2[r, s].Tag = 5;
                                                PoleLodi2[r, s] = 5;
                                                PoleRect2[r, s - 1].Tag = 5;
                                                PoleLodi2[r, s - 1] = 5;
                                                PoleRect2[r, s].Fill = Brushes.Pink;
                                                PoleRect2[r, s - 1].Fill = Brushes.Pink;
                                                lode2 = lode2 + 2;
                                                dvojka--;

                                                while (true)
                                                {
                                                    if (PoleLodi[cislo1, cislo2] == 2 || PoleLodi[cislo1, cislo2] == 5 || PoleLodi[cislo1, cislo2] == 6)
                                                    {
                                                        cislo1 = rnd.Next(1, 11);
                                                        cislo2 = rnd.Next(1, 11);


                                                        Console.WriteLine("jsi kokot");
                                                    }
                                                    else
                                                    {

                                                        PoleRect[cislo1, cislo2].Tag = 5;
                                                        PoleLodi[cislo1, cislo2] = 5;
                                                        PoleRect[cislo1, cislo2 - 1].Tag = 5;
                                                        PoleLodi[cislo1, cislo2 - 1] = 5;
                                                        PoleRect[cislo1, cislo2].Fill = Brushes.Pink;
                                                        PoleRect[cislo1, cislo2 - 1].Fill = Brushes.Pink;
                                                        lode = lode + 2;
                                                        break;
                                                    }
                                                }
                                            }

                                            if (dvojka == 0)
                                            {
                                                DoubleLod.IsEnabled = false;
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
                                            else
                                            {

                                            
                                            PoleRect2[r, s].Tag = 6;
                                            PoleLodi2[r, s] = 6;
                                            PoleRect2[r + 1, s].Tag = 6;
                                            PoleLodi2[r + 1, s] = 6;
                                            PoleRect2[r - 1, s].Tag = 6;
                                            PoleLodi2[r - 1, s] = 6;
                                            PoleRect2[r + 1, s].Fill = Brushes.Brown;
                                            PoleRect2[r - 1, s].Fill = Brushes.Brown;
                                            PoleRect2[r, s].Fill = Brushes.Brown;
                                            lode2 = lode2 + 3;
                                            trojka--;

                                            while (true)
                                            {
                                                if (PoleLodi[cislo1, cislo2] == 2 || PoleLodi[cislo1, cislo2] == 5 || PoleLodi[cislo1, cislo2] == 6)
                                                {
                                                    cislo1 = rnd.Next(1, 11);
                                                    cislo2 = rnd.Next(1, 11);


                                                    Console.WriteLine("jsi kokot");
                                                }
                                                else
                                                {
                                                    PoleRect[cislo1, cislo2].Tag = 6;
                                                    PoleLodi[cislo1, cislo2] = 6;
                                                    PoleRect[cislo1 + 1, cislo2].Tag = 6;
                                                    PoleLodi[cislo1 + 1, cislo2] = 6;
                                                    PoleRect[cislo1 - 1, cislo2].Tag = 6;
                                                    PoleLodi[cislo1 - 1, cislo2] = 6;
                                                    PoleRect[cislo1 + 1, cislo2].Fill = Brushes.Brown;
                                                    PoleRect[cislo1 - 1, cislo2].Fill = Brushes.Brown;
                                                    PoleRect[cislo1, cislo2].Fill = Brushes.Brown;
                                                    lode = lode + 3;

                                                    break;
                                                }
                                            }


                                            }



                                            if (trojka == 0)
                                            {
                                                TripleLod.IsEnabled = false;
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
                                            else
                                            {

                                            
                                            PoleRect2[r, s].Tag = 6;
                                            PoleLodi2[r, s] = 6;
                                            PoleRect2[r, s + 1].Tag = 6;
                                            PoleLodi2[r, s + 1] = 6;
                                            PoleRect2[r, s - 1].Tag = 6;
                                            PoleLodi2[r, s - 1] = 6;
                                            PoleRect2[r, s + 1].Fill = Brushes.Brown;
                                            PoleRect2[r, s - 1].Fill = Brushes.Brown;
                                            PoleRect2[r, s].Fill = Brushes.Brown;
                                            lode2 = lode2 + 3;
                                            trojka--;

                                            while (true)
                                            {
                                                if (PoleLodi[cislo1, cislo2] == 2 || PoleLodi[cislo1, cislo2] == 5 || PoleLodi[cislo1, cislo2] == 6)
                                                {
                                                    cislo1 = rnd.Next(1, 11);
                                                    cislo2 = rnd.Next(1, 11);


                                                    Console.WriteLine("jsi kokot");
                                                }
                                                else
                                                {
                                                    PoleRect[cislo1, cislo2].Tag = 6;
                                                    PoleLodi[cislo1, cislo2] = 6;
                                                    PoleRect[cislo1, cislo2 + 1].Tag = 6;
                                                    PoleLodi[cislo1, cislo2 + 1] = 6;
                                                    PoleRect[cislo1, cislo2 - 1].Tag = 6;
                                                    PoleLodi[cislo1, cislo2 - 1] = 6;
                                                    PoleRect[cislo1, cislo2 + 1].Fill = Brushes.Brown;
                                                    PoleRect[cislo1, cislo2 - 1].Fill = Brushes.Brown;
                                                    PoleRect[cislo1, cislo2].Fill = Brushes.Brown;
                                                    lode = lode + 3;

                                                    break;
                                                }
                                            }


                                            }


                                            if (trojka == 0)
                                            {
                                                TripleLod.IsEnabled = false;
                                                TriLode = false;
                                            }
                                        }

                                    }
                                }




                            }




                        }

                    }
                }

            }


        }



        private void SingleLod_Click(object sender, RoutedEventArgs e)
        {
            JednaLod = true;
            DveLode = false;
            TriLode = false;
            //SingleLod.Content = jednicka;
        }

        private void DoubleLod_Click(object sender, RoutedEventArgs e)
        {
            JednaLod = false;
            DveLode = true;
            TriLode = false;
        }

        private void TripleLod_Click(object sender, RoutedEventArgs e)
        {
            JednaLod = false;
            DveLode = false;
            TriLode = true;

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
                                PoleRect2[r, s].Fill = Brushes.Green;
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
                                PoleRect2[r, s].Fill = Brushes.Red;
                            }


                        }


                    }


                }
                //PoleRect2[indx2, indy2].Tag = 3;

            }
            if (lode2 == 0)
            {
                MessageBox.Show("Počítač vyhrál");
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
                                PoleRect2[r, s].Fill = Brushes.Green;
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
                                PoleRect2[r, s].Fill = Brushes.Red;
                            }


                        }


                    }


                }
                //PoleRect2[indx2, indy2].Tag = 3;

            }
            if (lode2 == 0)
            {
                MessageBox.Show("Počítač vyhrál");
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
        }
    }
}