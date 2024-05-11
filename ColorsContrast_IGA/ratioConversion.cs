using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColorsContrastIGA
{
    class ratioConversion
    {
        public int converBitToInt(int find, int[] minMax)
        {
            float input;
            int inputMin = 0, inputMax = 255, outputMin = minMax[0], outputMax = minMax[1];
            double ratio = (float)(outputMax - outputMin) / (float)(inputMax - inputMin);
            input = outputMin + (float)(find * ratio);
            return Convert.ToInt32(input);
        }

        public double converBitToDouble(double find, double[] minMax)
        {
            double input;
            int inputMin = 0, inputMax = 255;
            double outputMin = minMax[0], outputMax = minMax[1];
            double ratio = (float)(outputMax - outputMin) / (float)(inputMax - inputMin);
            input = outputMin + (float)(find * ratio);
            return input;
        }

        public int convertIntToBit(int find, int[] minMax)
        {
            float input;
            int inputMin = 0, inputMax = 255, outputMin = minMax[0], outputMax = minMax[1];
            double ratio = (float)(outputMax - outputMin) / (float)(inputMax - inputMin);
            input = (float)(find - outputMin) / (float)ratio;
            return Convert.ToInt32(input);
        }

        public double convertDoubleToBit(double find, double[] minMax)
        {
            float input;
            int inputMin = 0, inputMax = 255;
            double outputMin = minMax[0], outputMax = minMax[1];
            double ratio = (float)(outputMax - outputMin) / (float)(inputMax - inputMin);
            input = (float)(find - outputMin) / (float)ratio;
            return input;
        }
    }
}
