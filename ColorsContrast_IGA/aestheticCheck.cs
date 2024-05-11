using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ColorsContrastIGA
{
    class aestheticCheck
    {

        public double L1, L2, sRGB, rRGB, Brgb;
        decimal finalRatio;

        public string[] checkContrast(Color color1, Color color2)
        {
            string[] result = new string[3];
            L1 = 0.2126 * checkSRGB(color1.R) + 0.7152 * checkSRGB(color1.G) + 0.0722 * checkSRGB(color1.B);
            L2 = 0.2126 * checkSRGB(color2.R) + 0.7152 * checkSRGB(color2.G) + 0.0722 * checkSRGB(color2.B);
            
            double L1plus = L1 + 0.05;
            double L2plus = L2 + 0.05;

            int L1final = (int)Math.Abs(L1plus * 100);
            int L2final = (int)Math.Abs(L2plus * 100);
            int rdiff, gdiff, bdiff;

            if (L1 > L2)
            {
                result[0] = "" + ((int)(L1final / L2final)).ToString() +"";
            }
            else
            {
                result[0] = "" + ((int)(L2final / L1final)).ToString() + "";
            }

            rdiff = Math.Max(color1.R, color2.R);
            gdiff = Math.Max(color1.G, color2.G);
            bdiff = Math.Max(color1.B, color2.B);


            result[1] = "" + (rdiff + gdiff + bdiff).ToString() + "";
            result[2] = getColorBrightness(color1, color2);



            return result;
        }

        private double checkSRGB(double value)
        {
            double SRGBvalue = 0, convert, returnValue;

            convert = value / 255;

            if (convert <= 0.03928)
            {
                SRGBvalue = convert / 12.92;
                //returnValue = Math.Abs(SRGBvalue);
            }
            else if (convert == 1)
            {
                SRGBvalue = 1;
            }
            else
            {
                SRGBvalue = Math.Pow((float)((float)convert + 0.055) / (1.055), 2.4);
                SRGBvalue = SRGBvalue + 0.0001;
            }

            return SRGBvalue;
        }

        public string getColorBrightness(Color A, Color B)
        {
            string difference = "";
            double x1, x2;
            int roundoff;

            x1 = (float)((A.R * 299) + (A.G * 587) + (A.B * 114)) / (float)1000;
            x2 = (float)((B.R * 299) + (B.G * 587) + (B.B * 114)) / (float)1000;

            if (x1 > x2)
            {
                difference = (x1 - x2).ToString();
            }
            else
            {
                difference = (x2 - x1).ToString();
            }
            
            roundoff = Convert.ToInt32(x1-x2);
            

            return roundoff.ToString();
        }
        
        public int getPercentage(string[] array)
        {
            double ccr, cd, bd;
            double result;
            int roundoff;

           
            ccr = (float)(Convert.ToInt32(array[0]) * 75) / (float)21;


            if (Convert.ToInt32(array[1]) <= 500 && Convert.ToInt32(array[1]) >= 400)
            {
                cd = 5;
            }

            else if (Convert.ToInt32(array[1]) <= 400 && Convert.ToInt32(array[1]) >= 200)
            {
                cd = 3;
            }

            else if (Convert.ToInt32(array[1]) <= 200 && Convert.ToInt32(array[1]) >= 0)
            {
                cd = 1;
            }
            else
            {
                cd = (float)(Convert.ToInt32(array[1]) * 10) / (float)765;
            }



            if (Convert.ToInt32(array[2]) <= 125 && Convert.ToInt32(array[1]) >= 85)
            {
                bd = 10;
            }

            else if (Convert.ToInt32(array[2]) <= 85 && Convert.ToInt32(array[1]) >= 30)
            {
                bd = 5;
            }

            else if (Convert.ToInt32(array[2]) <= 30 && Convert.ToInt32(array[1]) >= 0)
            {
                bd = 1;
            }
            else
            {
                bd = (float)(Convert.ToInt32(array[2]) * 15) / (float)255;
            }

            roundoff = (int)ccr + (int)cd + (int)bd;

            return roundoff;
        }

        public string getComment(int percentage)
        {
            string comment = "";
            if (percentage < 10)
            {
                comment = "Worst";
            }
            if (percentage > 10 && percentage < 30)
            {
                comment = "Bad";
            }
            if (percentage > 30 && percentage < 40)
            {
                comment = "Good";
            }
            if (percentage > 40 && percentage < 50)
            {
                comment = "VGood";
            }
            if (percentage > 50)
            {
                comment = "Best";
            }

            return comment;
        }

    }
}
