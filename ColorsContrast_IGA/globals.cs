using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace ColorsContrastIGA
{
    class globals
    {
        static Random rnd = new Random();
        public static int mutProb = 50;
        public static int crossProb = 90;

        public static int[] newBackR = { rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255) };
        public static int[] newBackG = { rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255) };
        public static int[] newBackB = { rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255) };

        public static int[] newBannR = { rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255) };
        public static int[] newBannG = { rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255) };
        public static int[] newBannB = { rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255) };

        public static int[] newBoldR = { rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255) };
        public static int[] newBoldG = { rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255) };
        public static int[] newBoldB = { rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255) };

        public static int[] newNormR = { rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255) };
        public static int[] newNormG = { rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255) };
        public static int[] newNormB = { rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255) };

        public static int[] newButtbackR = { rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255) };
        public static int[] newButtbackG = { rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255) };
        public static int[] newButtbackB = { rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255) };

        public static int[] newMainbackR = { rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255) };
        public static int[] newMainbackG = { rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255) };
        public static int[] newMainbackB = { rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255) };

        public static int[] newButtForeR = { rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255) };
        public static int[] newButtForeG = { rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255) };
        public static int[] newButtForeB = { rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255) };

        
        public static bool lockBack = false;
        public static bool lockBann = false;
        public static bool lockBold = false;
        public static bool lockNorm = false;
        public static bool lockButtBack = false;
        public static bool lockMainBack = false;
        public static bool lockButtFore = false;


        public static Color aesthBanner;
        public static Color aesthBold;
        public static Color aesthNormal;


        public static bool LockBack
        {
            get { return lockBack; }
            set { lockBack = value; }
        }

        public static bool LockButtFore
        {
            get { return lockButtFore; }
            set { lockButtFore = value; }
        }

        public static bool LockBann
        {
            get { return lockBann; }
            set { lockBann = value; }
        }
        
        public static bool LockBold
        {
            get { return lockBold; }
            set { lockBold = value; }
        }
        
        public static bool LockNorm
        {
            get { return lockNorm; }
            set { lockNorm = value; }
        }

        public static bool LockButtBack
        {
            get { return lockButtBack; }
            set { lockButtBack = value; }
        }

        public static bool LockMainBack
        {
            get { return lockMainBack; }
            set { lockMainBack = value; }
        }


        public static int MutProb
        {
            get { return mutProb; }
            set { mutProb = value; }
        }
        public static int CrossProb
        {
            get { return crossProb; }
            set { crossProb = value; }
        }

        public static int[] NewButtbackR
        {
            get { return newButtbackR; }
            set { newButtbackR = value; }
        }

        public static int[] NewButtbackG
        {
            get { return newButtbackG; }
            set { newButtbackG = value; }
        }

        public static int[] NewButtbackB
        {
            get { return newButtbackB; }
            set { newButtbackB = value; }
        }

        public static int[] NewMainbackR
        {
            get { return newMainbackR; }
            set { newMainbackR = value; }
        }

        public static int[] NewMainbackG
        {
            get { return newMainbackG; }
            set { newMainbackG = value; }
        }

        public static int[] NewMainbackB
        {
            get { return newMainbackB; }
            set { newMainbackB = value; }
        }

        public static int[] NewButtForeR
        {
            get { return newButtForeR; }
            set { newButtForeR = value; }
        }

        public static int[] NewButtForeG
        {
            get { return newButtForeG; }
            set { newButtForeG = value; }
        }

        public static int[] NewButtForeB
        {
            get { return newButtForeB; }
            set { newButtForeB = value; }
        }


        public static int[] NewBackR
        {
            get { return newBackR; }
            set { newBackR = value; }
        }

        public static int[] NewBackG
        {
            get { return newBackG; }
            set { newBackG = value; }
        }
        public static int[] NewBackB
        {
            get { return newBackB; }
            set { newBackB = value; }
        }

       
        public static int[] NewBannR
        {
            get { return newBannR; }
            set { newBackR = value; }
        }

        public static int[] NewBannG
        {
            get { return newBannG; }
            set { newBackG = value; }
        }
        public static int[] NewBannB
        {
            get { return newBannB; }
            set { newBackB = value; }
        }


        public static int[] NewBoldR
        {
            get { return newBoldR; }
            set { newBoldR = value; }
        }

        public static int[] NewBoldG
        {
            get { return newBoldG; }
            set { newBoldG = value; }
        }
        public static int[] NewBoldB
        {
            get { return newBoldB; }
            set { newBoldB = value; }
        }


        public static int[] NewNormR
        {
            get { return newNormR; }
            set { newNormR = value; }
        }

        public static int[] NewNormG
        {
            get { return newNormG; }
            set { newNormG = value; }
        }
        public static int[] NewNormB
        {
            get { return newNormB; }
            set { newNormB = value; }
        }
        
    }
}
