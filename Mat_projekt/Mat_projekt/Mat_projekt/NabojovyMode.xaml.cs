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

namespace Mat_projekt
{
    /// <summary>
    /// Interakční logika pro NabojovyMode.xaml
    /// </summary>
    public partial class NabojovyMode : Window
    {

        int[,] PoleLodi = new int[12, 12]; // velikost pole
        int[,] PoleLodi2 = new int[12, 12]; // velikost pole

        int lode = 10;
        int naboje = 20;

        Rectangle[,] PoleRect;

        int indx;
        int indx2;

        int indy;
        int indy2;

        public NabojovyMode()
        {
            InitializeComponent();


            PoleRect = new Rectangle[12, 12];


            VytvoreniPanelu(PoleRect);

            Random rnd = new Random();

            for (int x = 0; x <= lode; x++)
            {
                int cislo1 = rnd.Next(1, 11);
                int cislo2 = rnd.Next(1, 11);

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
                    else if (PoleLodi[i,y] == 2)
                        {
                            PoleLodi[i, y] = 2;
                        }
                    else PoleLodi[i, y] = 0;
                    


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
          
            PoleLodi[cislo1, cislo2] = 2;
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

                    Console.WriteLine(PoleRect[row, col].Tag);

                }

        }








        private void MainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
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
                                       naboje--;

                                }

                                else if (PoleLodi[r, s] == 2)
                                {

                                    indx = r;
                                    indy = s;

                                    PoleRect[r, s].Tag = 2;
                                    PoleLodi[r, s] = 2;



                                    if ((int)PoleRect[r, s].Tag == 2)
                                    {
                                        PoleRect[r, s].Tag = 9;
                                        PoleLodi[r, s] = 9;
                                        Uri hit;
                                        hit = new Uri(Directory.GetCurrentDirectory() + @"\LodeHit.JPG");
                                        PoleRect[r, s].Fill = new ImageBrush(new BitmapImage(hit));
                                        //PoleRect[r, s].Fill = Brushes.Green;
                                        lode--;
                                        naboje--;
                                    }

                                }




                                else if ((int)PoleRect[r, s].Tag == 4)
                                {

                                    indx = r;
                                    indy = s;

                                    PoleRect[r, s].Tag = 4;
                                    PoleLodi[r, s] = 4;

                                    naboje--;


                                    if (PoleRect[r, s].Fill == Brushes.White)
                                    {

                                        Uri miss;
                                        miss = new Uri(Directory.GetCurrentDirectory() + @"\LodeMiss.JPG");
                                        PoleRect[r, s].Fill = new ImageBrush(new BitmapImage(miss));
                                        //PoleRect[r, s].Fill = Brushes.Red;

                                    }

                                }
                            }

                            //if (PoleLodi[r, s] == 1)
                            //{
                            //    indx = r;
                            //    indy = s;

                            //    PoleRect[r, s].Tag = 1;
                            //    PoleLodi[r, s] = 1;

                            //    s--;
                            //    naboje--;

                            //}


                            //else if (PoleLodi[r, s] == 2)
                            //{

                            //    indx = r;
                            //    indy = s;

                            //    PoleRect[r, s].Tag = 2;
                            //    PoleLodi[r, s] = 2;



                            //    if ((int)PoleRect[r, s].Tag == 2)
                            //    {
                            //        PoleRect[r, s].Tag = 9;
                            //        PoleLodi[r, s] = 9;
                            //        PoleRect[r, s].Fill = Brushes.Green;
                            //        lode--;
                            //        naboje--;
                            //    }

                            //}



                            //else if ((int)PoleRect[r, s].Tag == 4)
                            //{

                            //    indx = r;
                            //    indy = s;

                            //    PoleRect[r, s].Tag = 4;
                            //    PoleLodi[r, s] = 4;




                            //    if ((int)PoleRect[r, s].Tag == 4)
                            //    {
                            //        PoleRect[r, s].Fill = Brushes.Red;

                            //        naboje--;
                            //    }
                            //}



                        }

                        }

                        PoleRect[indx, indy].Tag = 3;
                        //Console.WriteLine(naboje);
                        Naboje.Content = naboje;

                    }


                }


                if (naboje == 0)
                {
                    MessageBox.Show("Zbývalo ti střelit " + lode + " lodí");
                this.Close();
            }

            
        }
    }
}

