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

        Rectangle[,] PoleRect;

        int indx;
        int indy;

        public MainWindow()
        {
            InitializeComponent();


            PoleRect = new Rectangle[12, 12];

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

                }
            }


















        }


        private void TagToIntPole(Rectangle[,] pole, int[,] newPole)
        {
            for (int r = 0; r < pole.GetLength(0); r++)
            {
                for (int s = 0; s < pole.GetLength(1); s++)
                {
                    //if (r == 0 || r == 11)
                    //{
                    //    PoleRect[r, s].Tag = 1;
                    //}
                    //else if (s == 0 || s == 11)
                    //{
                    //    PoleRect[r, s].Tag = 1;
                    //}
                    //else PoleRect[r, s].Tag = 0;

                    //Console.WriteLine(PoleRect[r, s].Tag);

                    // newPole[r, s] = (int)pole[r, s].Tag;
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
            pole[indx, indy].Fill = Brushes.Red;
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
                        else if ((int)PoleRect[r, s].Tag == 2) PoleLodi[r, s] = 2;

                        Console.Write(PoleRect[r, s].Tag);


                    }
                    Console.WriteLine();
                }

                Rec.Tag = 2;
                TagToIntPole(PoleRect, PoleLodi);




                for (int r = 0; r < PoleLodi.GetLength(0); r++)
                {
                    for (int s = 0; s < PoleLodi.GetLength(1); s++)
                    {
                        if ((int)PoleRect[r, s].Tag == 2)
                        {
                            indx = r;
                            indy = s;
                            mrizka.Children.Remove(PoleRect[indx, indy]);
                            PoleRect[r, s].Tag = 2;
                            PoleLodi[r, s] = 2;
                        }
                        //else if ((int)PoleRect[r, s].Tag == 1)
                        //{
                        //    r--;
                        //}


                    }

                }
                Console.WriteLine(indx);
                Console.WriteLine(indy);
                PoleRect[indx, indy].Tag = 2;
                //strela.Margin = new Thickness(indy * 12, indx * 12, 0, 0);



            }






            //    //    if (PoleLodi[r, s] == 1)
            //    //{
            //    //    PoleLodi[r, s] = 1;
            //    //}
            //    //else
            //    //{
            //    //    PoleLodi[r, s] = 2;
            //    //}
            //    //Console.Write(PoleLodi[r, s]);

            //}

        }
    }
}