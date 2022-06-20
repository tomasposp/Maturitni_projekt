using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Mat_projekt
{
    
    public class Lode
    {


        public static bool TriMetoda()
        {
            if (pole.PoleLodi[pole.cislo1 - 1, pole.cislo2] == 2 ||
                                            pole.PoleLodi[pole.cislo1 + 1, pole.cislo2] == 2 ||
                                            pole.PoleLodi[pole.cislo1, pole.cislo2 - 2] == 2 ||
                                            pole.PoleLodi[pole.cislo1, pole.cislo2 - 1] == 2 ||
                                            pole.PoleLodi[pole.cislo1, pole.cislo2 + 1] == 2 ||
                                            pole.PoleLodi[pole.cislo1 + 1, pole.cislo2 + 1] == 2 ||
                                            pole.PoleLodi[pole.cislo1 - 1, pole.cislo2 + 1] == 2 ||
                                            pole.PoleLodi[pole.cislo1 + 1, pole.cislo2 - 1] == 2 ||
                                            pole.PoleLodi[pole.cislo1 - 1, pole.cislo2 - 1] == 2 ||
                                            pole.PoleLodi[pole.cislo1 - 2, pole.cislo2] == 2 ||
                                            pole.PoleLodi[pole.cislo1 + 2, pole.cislo2] == 2 ||
                                            pole.PoleLodi[pole.cislo1, pole.cislo2 - 2] == 2 ||
                                            pole.PoleLodi[pole.cislo1, pole.cislo2 + 2] == 2 ||
                                            pole.PoleLodi[pole.cislo1 + 2, pole.cislo2 + 2] == 2 ||
                                            pole.PoleLodi[pole.cislo1 - 2, pole.cislo2 + 2] == 2 ||
                                            pole.PoleLodi[pole.cislo1 + 2, pole.cislo2 - 2] == 2 ||
                                            pole.PoleLodi[pole.cislo1 - 2, pole.cislo2 - 2] == 2 ||
                                            pole.PoleLodi[pole.cislo1 - 1, pole.cislo2] == 5 ||
                                            pole.PoleLodi[pole.cislo1 + 1, pole.cislo2] == 5 ||
                                            pole.PoleLodi[pole.cislo1, pole.cislo2 - 2] == 5 ||
                                            pole.PoleLodi[pole.cislo1, pole.cislo2 - 1] == 5 ||
                                            pole.PoleLodi[pole.cislo1, pole.cislo2 + 1] == 5 ||
                                            pole.PoleLodi[pole.cislo1 + 1, pole.cislo2 + 1] == 5 ||
                                            pole.PoleLodi[pole.cislo1 - 1, pole.cislo2 + 1] == 5 ||
                                            pole.PoleLodi[pole.cislo1 + 1, pole.cislo2 - 1] == 5 ||
                                            pole.PoleLodi[pole.cislo1 - 1, pole.cislo2 - 1] == 5 ||
                                            pole.PoleLodi[pole.cislo1 - 2, pole.cislo2] == 5 ||
                                            pole.PoleLodi[pole.cislo1 + 2, pole.cislo2] == 5 ||
                                            pole.PoleLodi[pole.cislo1, pole.cislo2 - 2] == 5 ||
                                            pole.PoleLodi[pole.cislo1, pole.cislo2 + 2] == 5 ||
                                            pole.PoleLodi[pole.cislo1 + 2, pole.cislo2 + 2] == 5 ||
                                            pole.PoleLodi[pole.cislo1 - 2, pole.cislo2 + 2] == 5 ||
                                            pole.PoleLodi[pole.cislo1 + 2, pole.cislo2 - 2] == 5 ||
                                            pole.PoleLodi[pole.cislo1 - 2, pole.cislo2 - 2] == 5) return true;
            else return false;
        }


        public static bool TriMetodaNeotocena()
        {
            if (pole.PoleLodi[pole.cislo1 - 1, pole.cislo2] == 2 ||
                                                       pole.PoleLodi[pole.cislo1 + 1, pole.cislo2] == 2 ||
                                                       pole.PoleLodi[pole.cislo1, pole.cislo2 - 2] == 2 ||
                                                       pole.PoleLodi[pole.cislo1, pole.cislo2 - 1] == 2 ||
                                                       pole.PoleLodi[pole.cislo1, pole.cislo2 + 1] == 2 ||
                                                       pole.PoleLodi[pole.cislo1 + 1, pole.cislo2 + 1] == 2 ||
                                                       pole.PoleLodi[pole.cislo1 - 1, pole.cislo2 + 1] == 2 ||
                                                       pole.PoleLodi[pole.cislo1 + 1, pole.cislo2 - 1] == 2 ||
                                                       pole.PoleLodi[pole.cislo1 - 1, pole.cislo2 - 1] == 2 ||
                                                       pole.PoleLodi[pole.cislo1 - 2, pole.cislo2] == 2 ||
                                                       pole.PoleLodi[pole.cislo1 + 2, pole.cislo2] == 2 ||
                                                       pole.PoleLodi[pole.cislo1, pole.cislo2 - 2] == 2 ||
                                                       pole.PoleLodi[pole.cislo1, pole.cislo2 + 2] == 2 ||
                                                       pole.PoleLodi[pole.cislo1 + 2, pole.cislo2 + 2] == 2 ||
                                                       pole.PoleLodi[pole.cislo1 - 2, pole.cislo2 + 2] == 2 ||
                                                       pole.PoleLodi[pole.cislo1 + 2, pole.cislo2 - 2] == 2 ||
                                                       pole.PoleLodi[pole.cislo1 - 2, pole.cislo2 - 2] == 2 ||
                                                       pole.PoleLodi[pole.cislo1 - 1, pole.cislo2] == 5 ||
                                                       pole.PoleLodi[pole.cislo1 + 1, pole.cislo2] == 5 ||
                                                       pole.PoleLodi[pole.cislo1, pole.cislo2 - 2] == 5 ||
                                                       pole.PoleLodi[pole.cislo1, pole.cislo2 - 1] == 5 ||
                                                       pole.PoleLodi[pole.cislo1, pole.cislo2 + 1] == 5 ||
                                                       pole.PoleLodi[pole.cislo1 + 1, pole.cislo2 + 1] == 5 ||
                                                       pole.PoleLodi[pole.cislo1 - 1, pole.cislo2 + 1] == 5 ||
                                                       pole.PoleLodi[pole.cislo1 + 1, pole.cislo2 - 1] == 5 ||
                                                       pole.PoleLodi[pole.cislo1 - 1, pole.cislo2 - 1] == 5 ||
                                                       pole.PoleLodi[pole.cislo1 - 2, pole.cislo2] == 5 ||
                                                       pole.PoleLodi[pole.cislo1 + 2, pole.cislo2] == 5 ||
                                                       pole.PoleLodi[pole.cislo1, pole.cislo2 - 2] == 5 ||
                                                       pole.PoleLodi[pole.cislo1, pole.cislo2 + 2] == 5 ||
                                                       pole.PoleLodi[pole.cislo1 + 2, pole.cislo2 + 2] == 5 ||
                                                       pole.PoleLodi[pole.cislo1 - 2, pole.cislo2 + 2] == 5 ||
                                                       pole.PoleLodi[pole.cislo1 + 2, pole.cislo2 - 2] == 5 ||
                                                       pole.PoleLodi[pole.cislo1 - 2, pole.cislo2 - 2] == 5) return true;
            else return false;




        }
        public static bool DvaMetoda()
        {
            if (pole.PoleLodi[pole.cislo1 - 1, pole.cislo2] == 5 ||
                                                    pole.PoleLodi[pole.cislo1 + 1, pole.cislo2] == 5 ||
                                                    pole.PoleLodi[pole.cislo1 - 2, pole.cislo2] == 5 ||
                                                    pole.PoleLodi[pole.cislo1, pole.cislo2 - 1] == 5 ||
                                                    pole.PoleLodi[pole.cislo1, pole.cislo2 + 1] == 5 ||
                                                    pole.PoleLodi[pole.cislo1 + 1, pole.cislo2 + 1] == 5 ||
                                                    pole.PoleLodi[pole.cislo1 - 1, pole.cislo2 + 1] == 5 ||
                                                    pole.PoleLodi[pole.cislo1 + 1, pole.cislo2 - 1] == 5 ||
                                                    pole.PoleLodi[pole.cislo1 - 1, pole.cislo2 - 1] == 5 ||
                                                    pole.PoleLodi[pole.cislo1 - 1, pole.cislo2] == 2 ||
                                                    pole.PoleLodi[pole.cislo1 + 1, pole.cislo2] == 2 ||
                                                    pole.PoleLodi[pole.cislo1 - 2, pole.cislo2] == 2 ||
                                                    pole.PoleLodi[pole.cislo1, pole.cislo2 - 1] == 2 ||
                                                    pole.PoleLodi[pole.cislo1, pole.cislo2 + 1] == 2 ||
                                                    pole.PoleLodi[pole.cislo1 + 1, pole.cislo2 + 1] == 2 ||
                                                    pole.PoleLodi[pole.cislo1 - 1, pole.cislo2 + 1] == 2 ||
                                                    pole.PoleLodi[pole.cislo1 + 1, pole.cislo2 - 1] == 2 ||
                                                    pole.PoleLodi[pole.cislo1 - 1, pole.cislo2 - 1] == 2 ||
                                                    pole.PoleLodi[pole.cislo1 - 1, pole.cislo2] == 6 ||
                                                    pole.PoleLodi[pole.cislo1 + 1, pole.cislo2] == 6 ||
                                                    pole.PoleLodi[pole.cislo1 - 2, pole.cislo2] == 6 ||
                                                    pole.PoleLodi[pole.cislo1, pole.cislo2 - 1] == 6 ||
                                                    pole.PoleLodi[pole.cislo1, pole.cislo2 + 1] == 6 ||
                                                    pole.PoleLodi[pole.cislo1 + 1, pole.cislo2 + 1] == 6 ||
                                                    pole.PoleLodi[pole.cislo1 - 1, pole.cislo2 + 1] == 6 ||
                                                    pole.PoleLodi[pole.cislo1 + 1, pole.cislo2 - 1] == 6 ||
                                                    pole.PoleLodi[pole.cislo1 - 1, pole.cislo2 - 1] == 6 ||
                                                    pole.PoleLodi[pole.cislo1 - 1, pole.cislo2] == 1 ||
                                                    pole.PoleLodi[pole.cislo1 + 1, pole.cislo2] == 1 ||
                                                    pole.PoleLodi[pole.cislo1, pole.cislo2 - 1] == 1 ||
                                                    pole.PoleLodi[pole.cislo1, pole.cislo2 + 1] == 1 ||
                                                    pole.PoleLodi[pole.cislo1 + 1, pole.cislo2 + 1] == 1 ||
                                                    pole.PoleLodi[pole.cislo1 - 1, pole.cislo2 + 1] == 1 ||
                                                    pole.PoleLodi[pole.cislo1 + 1, pole.cislo2 - 1] == 1 ||
                                                    pole.PoleLodi[pole.cislo1 - 1, pole.cislo2 - 1] == 1 ||
                                                    pole.PoleLodi[pole.cislo1, pole.cislo2] == 1 ||
                                                    pole.PoleLodi[pole.cislo1, pole.cislo2] == 2 ||
                                                    pole.PoleLodi[pole.cislo1, pole.cislo2] == 5 ||
                                                    pole.PoleLodi[pole.cislo1, pole.cislo2] == 6) return true;
            else return false;

        }


        public static bool DvaMetodaNeotocena()
        {
            if(pole.PoleLodi[pole.cislo1 - 1, pole.cislo2] == 5 ||
                                                    pole.PoleLodi[pole.cislo1 + 1, pole.cislo2] == 5 ||
                                                    pole.PoleLodi[pole.cislo1 - 2, pole.cislo2] == 5 ||
                                                    pole.PoleLodi[pole.cislo1, pole.cislo2 - 1] == 5 ||
                                                    pole.PoleLodi[pole.cislo1, pole.cislo2 + 1] == 5 ||
                                                    pole.PoleLodi[pole.cislo1 + 1, pole.cislo2 + 1] == 5 ||
                                                    pole.PoleLodi[pole.cislo1 - 1, pole.cislo2 + 1] == 5 ||
                                                    pole.PoleLodi[pole.cislo1 + 1, pole.cislo2 - 1] == 5 ||
                                                    pole.PoleLodi[pole.cislo1 - 1, pole.cislo2 - 1] == 5 ||
                                                    pole.PoleLodi[pole.cislo1 - 1, pole.cislo2] == 2 ||
                                                    pole.PoleLodi[pole.cislo1 + 1, pole.cislo2] == 2 ||
                                                    pole.PoleLodi[pole.cislo1 - 2, pole.cislo2] == 2 ||
                                                    pole.PoleLodi[pole.cislo1, pole.cislo2 - 1] == 2 ||
                                                    pole.PoleLodi[pole.cislo1, pole.cislo2 + 1] == 2 ||
                                                    pole.PoleLodi[pole.cislo1 + 1, pole.cislo2 + 1] == 2 ||
                                                    pole.PoleLodi[pole.cislo1 - 1, pole.cislo2 + 1] == 2 ||
                                                    pole.PoleLodi[pole.cislo1 + 1, pole.cislo2 - 1] == 2 ||
                                                    pole.PoleLodi[pole.cislo1 - 1, pole.cislo2 - 1] == 2 ||
                                                    pole.PoleLodi[pole.cislo1 - 1, pole.cislo2] == 6 ||
                                                    pole.PoleLodi[pole.cislo1 + 1, pole.cislo2] == 6 ||
                                                    pole.PoleLodi[pole.cislo1 - 2, pole.cislo2] == 6 ||
                                                    pole.PoleLodi[pole.cislo1, pole.cislo2 - 1] == 6 ||
                                                    pole.PoleLodi[pole.cislo1, pole.cislo2 + 1] == 6 ||
                                                    pole.PoleLodi[pole.cislo1 + 1, pole.cislo2 + 1] == 6 ||
                                                    pole.PoleLodi[pole.cislo1 - 1, pole.cislo2 + 1] == 6 ||
                                                    pole.PoleLodi[pole.cislo1 + 1, pole.cislo2 - 1] == 6 ||
                                                    pole.PoleLodi[pole.cislo1 - 1, pole.cislo2 - 1] == 6 ||
                                                    pole.PoleLodi[pole.cislo1 - 1, pole.cislo2] == 1 ||
                                                    pole.PoleLodi[pole.cislo1 + 1, pole.cislo2] == 1 ||
                                                    pole.PoleLodi[pole.cislo1, pole.cislo2 - 1] == 1 ||
                                                    pole.PoleLodi[pole.cislo1, pole.cislo2 + 1] == 1 ||
                                                    pole.PoleLodi[pole.cislo1 + 1, pole.cislo2 + 1] == 1 ||
                                                    pole.PoleLodi[pole.cislo1 - 1, pole.cislo2 + 1] == 1 ||
                                                    pole.PoleLodi[pole.cislo1 + 1, pole.cislo2 - 1] == 1 ||
                                                    pole.PoleLodi[pole.cislo1 - 1, pole.cislo2 - 1] == 1 ||
                                                    pole.PoleLodi[pole.cislo1, pole.cislo2] == 1 ||
                                                    pole.PoleLodi[pole.cislo1, pole.cislo2] == 2 ||
                                                    pole.PoleLodi[pole.cislo1, pole.cislo2] == 5 ||
                                                    pole.PoleLodi[pole.cislo1, pole.cislo2] == 6) return true;
            else return false;
        }

        public static bool JednaMetoda()
        {
            if (pole.PoleLodi[pole.cislo1 - 1, pole.cislo2] == 2 ||
                                            pole.PoleLodi[pole.cislo1 + 1, pole.cislo2] == 2 ||
                                            pole.PoleLodi[pole.cislo1, pole.cislo2 - 1] == 2 ||
                                            pole.PoleLodi[pole.cislo1, pole.cislo2 + 1] == 2 ||
                                            pole.PoleLodi[pole.cislo1 - 1, pole.cislo2] == 5 ||
                                            pole.PoleLodi[pole.cislo1 + 1, pole.cislo2] == 5 ||
                                            pole.PoleLodi[pole.cislo1, pole.cislo2 - 1] == 5 ||
                                            pole.PoleLodi[pole.cislo1, pole.cislo2 + 1] == 5 ||
                                            pole.PoleLodi[pole.cislo1 - 1, pole.cislo2] == 6 ||
                                            pole.PoleLodi[pole.cislo1 + 1, pole.cislo2] == 6 ||
                                            pole.PoleLodi[pole.cislo1, pole.cislo2 - 1] == 6 ||
                                            pole.PoleLodi[pole.cislo1, pole.cislo2 + 1] == 6 ||
                                            pole.PoleLodi[pole.cislo1 - 1, pole.cislo2] == 1 ||
                                            pole.PoleLodi[pole.cislo1 + 1, pole.cislo2] == 1 ||
                                            pole.PoleLodi[pole.cislo1, pole.cislo2 - 1] == 1 ||
                                            pole.PoleLodi[pole.cislo1, pole.cislo2 + 1] == 1 ||
                                            pole.PoleLodi[pole.cislo1, pole.cislo2] == 1 ||
                                            pole.PoleLodi[pole.cislo1, pole.cislo2] == 2 ||
                                            pole.PoleLodi[pole.cislo1, pole.cislo2] == 5 ||
                                            pole.PoleLodi[pole.cislo1, pole.cislo2] == 6) return true;
            else return false;

        }

        public static void Zasah(int r, int s)
        {
            mode.poleRect[r, s].Tag = 9;
            mode.poleLodi[r, s] = 9;
            Uri hit;
            hit = new Uri("pack://application:,,,/Pictures/LodeHit.jpg");
            mode.poleRect[r, s].Fill = new ImageBrush(new BitmapImage(hit));
            mode.lode--;
            
            mode.score = mode.score + 100;

        }
        
        
    }
}
