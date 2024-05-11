using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColorsContrastIGA
{
    class Selection
    {
        public int selectParent()
        {
            Random rnd = new Random();
            int parent;
            int sel = rnd.Next(1, 100);



            // rank1 is given 35% of chance to be selected
            if (sel >= 1 && sel <= 35)
            {
                parent = 0;
            }
            // rank2 is given 30% of chance to be selected
            else if (sel > 35 && sel <= 65)
            {
                parent = 1;
            }
            // rank3 is given 20% of chance to be selected
            else if (sel > 65 && sel <= 85)
            {
                parent = 2;
            }
            else
            {
                parent = rnd.Next(4, 16);
            }




            return parent;
        }
    }
}
