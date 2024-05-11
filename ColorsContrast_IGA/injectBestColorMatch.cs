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
    class injectBestColorMatch
    {
        bestPickedColors bestPick;
        aesthticRankedColors ranked;

        public void injectBannerColors(ArrayList initial)
        {
            for (int i = 0; i < globals.newBannR.Length; i++)
            {
                globals.NewBannR[i] = ((bestPickedColors)initial[i]).bannerColors.R;
                globals.NewBannG[i] = ((bestPickedColors)initial[i]).bannerColors.G;
                globals.NewBannB[i] = ((bestPickedColors)initial[i]).bannerColors.B;
            }

        }
        public void injectBoldColors(ArrayList initial)
        {
            for (int i = 0; i < globals.newBannR.Length; i++)
            {
                globals.NewBoldR[i] = ((bestPickedColors)initial[i]).boldColors.R;
                globals.NewBoldG[i] = ((bestPickedColors)initial[i]).boldColors.G;
                globals.NewBoldB[i] = ((bestPickedColors)initial[i]).boldColors.B;
            }

        }

        public void injectMainBackColors(ArrayList initial)
        {
            for (int i = 0; i < globals.newBannR.Length; i++)
            {
                globals.NewMainbackR[i] = ((bestPickedColors)initial[i]).mainBackColors.R;
                globals.NewMainbackG[i] = ((bestPickedColors)initial[i]).mainBackColors.G;
                globals.NewMainbackB[i] = ((bestPickedColors)initial[i]).mainBackColors.B;
            }
        }

        public void injectNormalColors(ArrayList initial)
        {
            for (int i = 0; i < globals.newBannR.Length; i++)
            {
                globals.NewNormR[i] = ((bestPickedColors)initial[i]).normalColors.R;
                globals.NewNormG[i] = ((bestPickedColors)initial[i]).normalColors.G;
                globals.NewNormB[i] = ((bestPickedColors)initial[i]).normalColors.B;
            }

        }

        public void injectButtbackColors(ArrayList initial)
        {
            for (int i = 0; i < globals.newBannR.Length; i++)
            {
                globals.NewButtbackR[i] = ((bestPickedColors)initial[i]).buttBackColors.R;
                globals.NewButtbackG[i] = ((bestPickedColors)initial[i]).buttBackColors.G;
                globals.NewButtbackB[i] = ((bestPickedColors)initial[i]).buttBackColors.B;
            }

        }

        public void injectForeButtbackColors(ArrayList initial)
        {
            for (int i = 0; i < globals.newBannR.Length; i++)
            {
                globals.NewButtForeR[i] = ((bestPickedColors)initial[i]).buttForeColors.R;
                globals.NewButtForeG[i] = ((bestPickedColors)initial[i]).buttForeColors.G;
                globals.NewButtForeB[i] = ((bestPickedColors)initial[i]).buttForeColors.B;
            }

        }

        /*    public ArrayList getBannerranked(ArrayList allcolors)
            {

                ArrayList bannRanked;

                //
                //
                // 
                /* get ranked colors of newly generated banner colors 
    



                return bannRanked;
            } 
                 */
    }
}
