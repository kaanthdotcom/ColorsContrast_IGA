using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColorsContrastIGA
{
    class convert
    {
        static char[] cHexa = new char[] { 'A', 'B', 'C', 'D', 'E', 'F' };
        static int[] iHexaIndices = new int[] { 0, 1, 2, 3, 4, 5 };
        static int[] iHexaNumeric = new int[] { 10, 11, 12, 13, 14, 15 };
        static int[] mutaionMem = new int[2];
        //static int base10 = 10;
        const int asciiDiff = 48;

        public string NegativeDecimalToBase(int value)
        {
            string one = Convert.ToString(value, 2).PadLeft(8, '0');
            string two = one.Remove(0, 24);
            return two;
        }

        public int NegativeBaseToDecimal(string bas)
        {
            string one = bas.PadLeft(32, '1');
            int x = BaseToDecimal(one, 2);
            return x;
        }

        public string DecimalToBase(int iDec, int numbase)
        {
            string strBin = "";
            int[] result = new int[32];
            int MaxBit = 32;
            for (; iDec > 0; iDec /= numbase)
            {
                int rem = iDec % numbase;
                result[--MaxBit] = rem;
            }
            for (int i = 0; i < result.Length; i++)
                if ((int)result.GetValue(i) >= 10)
                    strBin += cHexa[(int)result.GetValue(i) % 10];
                else
                    strBin += result.GetValue(i);
            strBin = strBin.TrimStart(new char[] { '0' });
            return strBin;
        }

        public int BaseToDecimal(string sBase, int numbase)
        {
            int dec = 0;
            int b;
            int iProduct = 1;
            string sHexa = "";
            if (numbase > 10)
                for (int i = 0; i < cHexa.Length; i++)
                    sHexa += cHexa.GetValue(i).ToString();
            for (int i = sBase.Length - 1; i >= 0; i--, iProduct *= numbase)
            {
                string sValue = sBase[i].ToString();
                if (sValue.IndexOfAny(cHexa) >= 0)
                    b = iHexaNumeric[sHexa.IndexOf(sBase[i])];
                else
                    b = (int)sBase[i] - asciiDiff;
                dec += (b * iProduct);
            }
            return dec;
        }
    }
}
