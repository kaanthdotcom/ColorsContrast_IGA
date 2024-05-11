using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ColorsContrastIGA
{
    class crossOverMutation
    {
        
        convert change = new convert();
        string conP1 = "", conP2 = "";
        int basevalue = 2;
        rankedColors rankV;  // ranked pop can be obtained as follows method
        allColors initV; 
        Selection select = new Selection();
        ratioConversion ratioConvert = new ratioConversion();
        int[] newR = new int[12];
        int[] newG = new int[12];
        int[] newB = new int[12];

        static Random rnd = new Random();
        int probCheck = rnd.Next(1, 100);

      
        public void doCrossMut(ArrayList rank, ArrayList init)
        {
            int index = 0;
            
            //No crossover and mutation is performed if they are locked

            if (!globals.lockBack)
            {
                for (int j = 0; j < 6; j++)
                {

                    int[] offsprings = new int[2];
                    int p1, p2;
                    int a, b;
                    string rank1file = ((rankedColors)rank[0]).panelName;
                    string rank2file = ((rankedColors)rank[1]).panelName;
                    string rank3file = ((rankedColors)rank[2]).panelName;

                    do
                    {

                        a = select.selectParent();
                        b = select.selectParent();

                    } while (a == b);

                    //Parent A
                    //if the rnd value lies in rank arraylist then, the values is taken from rank object orelse in initValues object
                    if (a <= 3)
                    {
                        rankV = (rankedColors)rank[a];
                        p1 = rankV.RBack;
                        //p1 = (Convert.ToInt32(rankV.water)) / 10;

                    }
                    else
                    {
                        do
                        {
                            initV = (allColors)init[rnd.Next(0, 11)];
                        } while (initV.name == rank1file || initV.name == rank2file || initV.name == rank3file);

                        p1 = initV.RBackValues;
                        //p1 = (initV.waterValues) / 10;

                    }


                    //Parent B
                    if (b <= 3)
                    {
                        rankV = (rankedColors)rank[b];
                        p2 = rankV.RBack;
                        //p2 = (Convert.ToInt32(rankV.water)) / 10;

                    }
                    else
                    {
                        do
                        {
                            initV = (allColors)init[rnd.Next(0, 11)];
                        } while (initV.name == rank1file || initV.name == rank2file || initV.name == rank3file);
                        p2 = initV.RBackValues;
                        // p2 = (initV.waterValues) / 10;

                    }



                    //crossover begins here...
                    if (probCheck <= globals.crossProb)
                    {
                        offsprings = doCrossover(p1, p2);
                        // insert into newPopulation on updating the indexvalues all the times
                        globals.NewBackR[index] = offsprings[0];
                        index++;
                        globals.NewBackR[index] = offsprings[1];
                        index++;
                    }
                    else
                    {
                        globals.NewBackR[index] = p1;
                        index++;
                        globals.NewBackR[index] = p2;
                        index++;
                    }
                }

                // mutation process of R
                doMutation(globals.NewBackR);
                doMutation(globals.NewBackR);
                index = 0;

                //G value crossover

                for (int j = 0; j < 6; j++)
                {
                    int[] offsprings = new int[2];
                    int probCheck = rnd.Next(1, 100);
                    int p1, p2;
                    int a, b;
                    string rank1file = ((rankedColors)rank[0]).panelName;
                    string rank2file = ((rankedColors)rank[1]).panelName;
                    string rank3file = ((rankedColors)rank[2]).panelName;

                    do
                    {

                        a = select.selectParent();
                        b = select.selectParent();

                    } while (a == b);

                    //if the rnd value lies in rank arraylist then, the values is taken from rank object orelse in initValues object
                    if (a <= 3)
                    {
                        rankV = (rankedColors)rank[a];
                        p1 = rankV.GBack;
                        //p1 = (Convert.ToInt32(rankV.water)) / 10;

                    }
                    else
                    {
                        do
                        {
                            initV = (allColors)init[rnd.Next(0, 11)];
                        } while (initV.name == rank1file || initV.name == rank2file || initV.name == rank3file);

                        p1 = initV.GBackValues;
                        //p1 = (initV.waterValues) / 10;

                    }

                    if (b <= 3)
                    {
                        rankV = (rankedColors)rank[b];
                        p2 = rankV.GBack;
                        //p2 = (Convert.ToInt32(rankV.water)) / 10;

                    }
                    else
                    {
                        do
                        {
                            initV = (allColors)init[rnd.Next(0, 11)];
                        } while (initV.name == rank1file || initV.name == rank2file || initV.name == rank3file);
                        p2 = initV.GBackValues;
                        // p2 = (initV.waterValues) / 10;

                    }

                    if (probCheck <= globals.crossProb)
                    {
                        offsprings = doCrossover(p1, p2);

                        // insert into newPopulation on updating the indexvalues all the times
                        globals.NewBackG[index] = offsprings[0];
                        index++;
                        globals.NewBackG[index] = offsprings[1];
                        index++;
                    }
                    else
                    {
                        globals.NewBackG[index] = p1;
                        index++;
                        globals.NewBackG[index] = p2;
                        index++;
                    }
                }

                // mutation process of G
                doMutation(globals.NewBackG);
                doMutation(globals.NewBackG);
                index = 0;

                //Crossover of B Values
                for (int j = 0; j < 6; j++)
                {
                    int[] offsprings = new int[2];
                    int probCheck = rnd.Next(1, 100);
                    int p1, p2;
                    int a, b;
                    string rank1file = ((rankedColors)rank[0]).panelName;
                    string rank2file = ((rankedColors)rank[1]).panelName;
                    string rank3file = ((rankedColors)rank[2]).panelName;

                    do
                    {

                        a = select.selectParent();
                        b = select.selectParent();

                    } while (a == b);

                    //if the rnd value lies in rank arraylist then, the values is taken from rank object orelse in initValues object
                    if (a <= 3)
                    {
                        rankV = (rankedColors)rank[a];
                        p1 = rankV.BBack;
                        //p1 = (Convert.ToInt32(rankV.water)) / 10;

                    }
                    else
                    {
                        do
                        {
                            initV = (allColors)init[rnd.Next(0, 11)];
                        } while (initV.name == rank1file || initV.name == rank2file || initV.name == rank3file);

                        p1 = initV.BBackValues;
                        //p1 = (initV.waterValues) / 10;

                    }

                    if (b <= 3)
                    {
                        rankV = (rankedColors)rank[b];
                        p2 = rankV.BBack;
                        //p2 = (Convert.ToInt32(rankV.water)) / 10;

                    }
                    else
                    {
                        do
                        {
                            initV = (allColors)init[rnd.Next(0, 11)];
                        } while (initV.name == rank1file || initV.name == rank2file || initV.name == rank3file);
                        p2 = initV.BBackValues;
                        // p2 = (initV.waterValues) / 10;

                    }

                    if (probCheck <= globals.crossProb)
                    {
                        offsprings = doCrossover(p1, p2);
                        // insert into newPopulation on updating the indexvalues all the times
                        globals.NewBackB[index] = offsprings[0];
                        index++;
                        globals.NewBackB[index] = offsprings[1];
                        index++;
                    }
                    else
                    {
                        globals.NewBackB[index] = p1;
                        index++;
                        globals.NewBackB[index] = p2;
                        index++;
                    }
                }

                // mutation process of G
                doMutation(globals.NewBackB);
                doMutation(globals.NewBackB);
                index = 0;

            }




            if (!globals.lockBann)
            {
                //banner RGB crossover and muatation
                //Crossover of R Values
                for (int j = 0; j < 6; j++)
                {
                    int[] offsprings = new int[2];
                    int probCheck = rnd.Next(1, 100);
                    int p1, p2;
                    int a, b;
                    string rank1file = ((rankedColors)rank[0]).panelName;
                    string rank2file = ((rankedColors)rank[1]).panelName;
                    string rank3file = ((rankedColors)rank[2]).panelName;

                    do
                    {

                        a = select.selectParent();
                        b = select.selectParent();

                    } while (a == b);

                    //if the rnd value lies in rank arraylist then, the values is taken from rank object orelse in initValues object
                    if (a <= 3)
                    {
                        rankV = (rankedColors)rank[a];
                        p1 = rankV.RBann;
                        //p1 = (Convert.ToInt32(rankV.water)) / 10;

                    }
                    else
                    {
                        do
                        {
                            initV = (allColors)init[rnd.Next(0, 11)];
                        } while (initV.name == rank1file || initV.name == rank2file || initV.name == rank3file);

                        p1 = initV.RBannValues;
                        //p1 = (initV.waterValues) / 10;

                    }

                    if (b <= 3)
                    {
                        rankV = (rankedColors)rank[b];
                        p2 = rankV.RBann;
                        //p2 = (Convert.ToInt32(rankV.water)) / 10;

                    }
                    else
                    {
                        do
                        {
                            initV = (allColors)init[rnd.Next(0, 11)];
                        } while (initV.name == rank1file || initV.name == rank2file || initV.name == rank3file);
                        p2 = initV.RBannValues;
                        // p2 = (initV.waterValues) / 10;

                    }

                    if (probCheck <= globals.crossProb)
                    {
                        offsprings = doCrossover(p1, p2);
                        // insert into newPopulation on updating the indexvalues all the times
                        globals.NewBannR[index] = offsprings[0];
                        index++;
                        globals.NewBannR[index] = offsprings[1];
                        index++;
                    }
                    else
                    {
                        globals.NewBannR[index] = p1;
                        index++;
                        globals.NewBannR[index] = p2;
                        index++;
                    }
                }

                // mutation process of G
                doMutation(globals.NewBannR);
                doMutation(globals.NewBannR);
                index = 0;

                //crossover of G values
                for (int j = 0; j < 6; j++)
                {
                    int[] offsprings = new int[2];
                    int probCheck = rnd.Next(1, 100);
                    int p1, p2;
                    int a, b;
                    string rank1file = ((rankedColors)rank[0]).panelName;
                    string rank2file = ((rankedColors)rank[1]).panelName;
                    string rank3file = ((rankedColors)rank[2]).panelName;

                    do
                    {

                        a = select.selectParent();
                        b = select.selectParent();

                    } while (a == b);

                    //if the rnd value lies in rank arraylist then, the values is taken from rank object orelse in initValues object
                    if (a <= 3)
                    {
                        rankV = (rankedColors)rank[a];
                        p1 = rankV.GBann;
                        //p1 = (Convert.ToInt32(rankV.water)) / 10;

                    }
                    else
                    {
                        do
                        {
                            initV = (allColors)init[rnd.Next(0, 11)];
                        } while (initV.name == rank1file || initV.name == rank2file || initV.name == rank3file);

                        p1 = initV.GBannValues;
                        //p1 = (initV.waterValues) / 10;

                    }

                    if (b <= 3)
                    {
                        rankV = (rankedColors)rank[b];
                        p2 = rankV.GBann;
                        //p2 = (Convert.ToInt32(rankV.water)) / 10;

                    }
                    else
                    {
                        do
                        {
                            initV = (allColors)init[rnd.Next(0, 11)];
                        } while (initV.name == rank1file || initV.name == rank2file || initV.name == rank3file);
                        p2 = initV.GBannValues;
                        // p2 = (initV.waterValues) / 10;

                    }

                    if (probCheck <= globals.crossProb)
                    {
                        offsprings = doCrossover(p1, p2);
                        // insert into newPopulation on updating the indexvalues all the times
                        globals.NewBannG[index] = offsprings[0];
                        index++;
                        globals.NewBannG[index] = offsprings[1];
                        index++;
                    }
                    else
                    {
                        globals.NewBannG[index] = p1;
                        index++;
                        globals.NewBannG[index] = p2;
                        index++;
                    }
                }

                // mutation process of G
                doMutation(globals.NewBannG);
                doMutation(globals.NewBannG);
                index = 0;

                //Crossover of B Banner values 

                for (int j = 0; j < 6; j++)
                {
                    int[] offsprings = new int[2];
                    int probCheck = rnd.Next(1, 100);
                    int p1, p2;
                    int a, b;
                    string rank1file = ((rankedColors)rank[0]).panelName;
                    string rank2file = ((rankedColors)rank[1]).panelName;
                    string rank3file = ((rankedColors)rank[2]).panelName;

                    do
                    {

                        a = select.selectParent();
                        b = select.selectParent();

                    } while (a == b);

                    //if the rnd value lies in rank arraylist then, the values is taken from rank object orelse in initValues object
                    if (a <= 3)
                    {
                        rankV = (rankedColors)rank[a];
                        p1 = rankV.BBann;
                        //p1 = (Convert.ToInt32(rankV.water)) / 10;

                    }
                    else
                    {
                        do
                        {
                            initV = (allColors)init[rnd.Next(0, 11)];
                        } while (initV.name == rank1file || initV.name == rank2file || initV.name == rank3file);

                        p1 = initV.BBannValues;
                        //p1 = (initV.waterValues) / 10;

                    }

                    if (b <= 3)
                    {
                        rankV = (rankedColors)rank[b];
                        p2 = rankV.BBann;
                        //p2 = (Convert.ToInt32(rankV.water)) / 10;

                    }
                    else
                    {
                        do
                        {
                            initV = (allColors)init[rnd.Next(0, 11)];
                        } while (initV.name == rank1file || initV.name == rank2file || initV.name == rank3file);
                        p2 = initV.BBannValues;
                        // p2 = (initV.waterValues) / 10;

                    }

                    if (probCheck <= globals.crossProb)
                    {
                        offsprings = doCrossover(p1, p2);
                        // insert into newPopulation on updating the indexvalues all the times
                        globals.NewBannB[index] = offsprings[0];
                        index++;
                        globals.NewBannB[index] = offsprings[1];
                        index++;
                    }
                    else
                    {
                        globals.NewBannB[index] = p1;
                        index++;
                        globals.NewBannB[index] = p2;
                        index++;
                    }
                }

                // mutation process of G
                doMutation(globals.NewBannB);
                doMutation(globals.NewBannB);
                index = 0;


            }





            if (!globals.lockBold)
            {
                //Bold RGB crossover and mutation
                //Crossover of R Values
                for (int j = 0; j < 6; j++)
                {
                    int[] offsprings = new int[2];
                    int probCheck = rnd.Next(1, 100);
                    int p1, p2;
                    int a, b;
                    string rank1file = ((rankedColors)rank[0]).panelName;
                    string rank2file = ((rankedColors)rank[1]).panelName;
                    string rank3file = ((rankedColors)rank[2]).panelName;

                    do
                    {

                        a = select.selectParent();
                        b = select.selectParent();

                    } while (a == b);

                    //if the rnd value lies in rank arraylist then, the values is taken from rank object orelse in initValues object
                    if (a <= 3)
                    {
                        rankV = (rankedColors)rank[a];
                        p1 = rankV.RBold;
                        //p1 = (Convert.ToInt32(rankV.water)) / 10;

                    }
                    else
                    {
                        do
                        {
                            initV = (allColors)init[rnd.Next(0, 11)];
                        } while (initV.name == rank1file || initV.name == rank2file || initV.name == rank3file);

                        p1 = initV.RBoldValues;
                        //p1 = (initV.waterValues) / 10;

                    }

                    if (b <= 3)
                    {
                        rankV = (rankedColors)rank[b];
                        p2 = rankV.RBold;
                        //p2 = (Convert.ToInt32(rankV.water)) / 10;

                    }
                    else
                    {
                        do
                        {
                            initV = (allColors)init[rnd.Next(0, 11)];
                        } while (initV.name == rank1file || initV.name == rank2file || initV.name == rank3file);
                        p2 = initV.RBoldValues;
                        // p2 = (initV.waterValues) / 10;

                    }

                    if (probCheck <= globals.crossProb)
                    {
                        offsprings = doCrossover(p1, p2);
                        // insert into newPopulation on updating the indexvalues all the times
                        globals.NewBoldR[index] = offsprings[0];
                        index++;
                        globals.NewBoldR[index] = offsprings[1];
                        index++;
                    }
                    else
                    {
                        globals.NewBoldR[index] = p1;
                        index++;
                        globals.NewBoldR[index] = p2;
                        index++;
                    }
                }

                // mutation process of G
                doMutation(globals.NewBoldR);
                doMutation(globals.NewBoldR);
                index = 0;


                //crossover of G values in BOLD letters
                for (int j = 0; j < 6; j++)
                {
                    int[] offsprings = new int[2];
                    int probCheck = rnd.Next(1, 100);
                    int p1, p2;
                    int a, b;
                    string rank1file = ((rankedColors)rank[0]).panelName;
                    string rank2file = ((rankedColors)rank[1]).panelName;
                    string rank3file = ((rankedColors)rank[2]).panelName;

                    do
                    {

                        a = select.selectParent();
                        b = select.selectParent();

                    } while (a == b);

                    //if the rnd value lies in rank arraylist then, the values is taken from rank object orelse in initValues object
                    if (a <= 3)
                    {
                        rankV = (rankedColors)rank[a];
                        p1 = rankV.GBold;
                        //p1 = (Convert.ToInt32(rankV.water)) / 10;

                    }
                    else
                    {
                        do
                        {
                            initV = (allColors)init[rnd.Next(0, 11)];
                        } while (initV.name == rank1file || initV.name == rank2file || initV.name == rank3file);

                        p1 = initV.GBoldValues;
                        //p1 = (initV.waterValues) / 10;

                    }

                    if (b <= 3)
                    {
                        rankV = (rankedColors)rank[b];
                        p2 = rankV.GBold;
                        //p2 = (Convert.ToInt32(rankV.water)) / 10;

                    }
                    else
                    {
                        do
                        {
                            initV = (allColors)init[rnd.Next(0, 11)];
                        } while (initV.name == rank1file || initV.name == rank2file || initV.name == rank3file);
                        p2 = initV.GBoldValues;
                        // p2 = (initV.waterValues) / 10;

                    }

                    if (probCheck <= globals.crossProb)
                    {
                        offsprings = doCrossover(p1, p2);
                        // insert into newPopulation on updating the indexvalues all the times
                        globals.NewBoldG[index] = offsprings[0];
                        index++;
                        globals.NewBoldG[index] = offsprings[1];
                        index++;
                    }
                    else
                    {
                        globals.NewBoldG[index] = p1;
                        index++;
                        globals.NewBoldG[index] = p2;
                        index++;
                    }
                }

                // mutation process of G
                doMutation(globals.NewBoldG);
                doMutation(globals.NewBoldG);
                index = 0;





                //crossover of B values in BOLD letters
                for (int j = 0; j < 6; j++)
                {
                    int[] offsprings = new int[2];
                    int probCheck = rnd.Next(1, 100);
                    int p1, p2;
                    int a, b;
                    string rank1file = ((rankedColors)rank[0]).panelName;
                    string rank2file = ((rankedColors)rank[1]).panelName;
                    string rank3file = ((rankedColors)rank[2]).panelName;

                    do
                    {

                        a = select.selectParent();
                        b = select.selectParent();

                    } while (a == b);

                    //if the rnd value lies in rank arraylist then, the values is taken from rank object orelse in initValues object
                    if (a <= 3)
                    {
                        rankV = (rankedColors)rank[a];
                        p1 = rankV.BBold;
                        //p1 = (Convert.ToInt32(rankV.water)) / 10;

                    }
                    else
                    {
                        do
                        {
                            initV = (allColors)init[rnd.Next(0, 11)];
                        } while (initV.name == rank1file || initV.name == rank2file || initV.name == rank3file);

                        p1 = initV.BBoldValues;
                        //p1 = (initV.waterValues) / 10;

                    }

                    if (b <= 3)
                    {
                        rankV = (rankedColors)rank[b];
                        p2 = rankV.BBold;
                        //p2 = (Convert.ToInt32(rankV.water)) / 10;

                    }
                    else
                    {
                        do
                        {
                            initV = (allColors)init[rnd.Next(0, 11)];
                        } while (initV.name == rank1file || initV.name == rank2file || initV.name == rank3file);
                        p2 = initV.BBoldValues;
                        // p2 = (initV.waterValues) / 10;

                    }

                    if (probCheck <= globals.crossProb)
                    {
                        offsprings = doCrossover(p1, p2);
                        // insert into newPopulation on updating the indexvalues all the times
                        globals.NewBoldB[index] = offsprings[0];
                        index++;
                        globals.NewBoldB[index] = offsprings[1];
                        index++;
                    }
                    else
                    {
                        globals.NewBoldB[index] = p1;
                        index++;
                        globals.NewBoldB[index] = p2;
                        index++;
                    }
                }

                // mutation process of G
                doMutation(globals.NewBoldB);
                doMutation(globals.NewBoldB);
                index = 0;


            }



            if (!globals.lockNorm)
            {
                //Normal RGB crossover and muatation


                //Crossover of R Values in Normal letters


                for (int j = 0; j < 6; j++)
                {
                    int[] offsprings = new int[2];
                    int probCheck = rnd.Next(1, 100);
                    int p1, p2;
                    int a, b;
                    string rank1file = ((rankedColors)rank[0]).panelName;
                    string rank2file = ((rankedColors)rank[1]).panelName;
                    string rank3file = ((rankedColors)rank[2]).panelName;

                    do
                    {

                        a = select.selectParent();
                        b = select.selectParent();

                    } while (a == b);

                    //if the rnd value lies in rank arraylist then, the values is taken from rank object orelse in initValues object
                    if (a <= 3)
                    {
                        rankV = (rankedColors)rank[a];
                        p1 = rankV.RNorm;
                        //p1 = (Convert.ToInt32(rankV.water)) / 10;

                    }
                    else
                    {
                        do
                        {
                            initV = (allColors)init[rnd.Next(0, 11)];
                        } while (initV.name == rank1file || initV.name == rank2file || initV.name == rank3file);

                        p1 = initV.RNormValues;
                        //p1 = (initV.waterValues) / 10;

                    }

                    if (b <= 3)
                    {
                        rankV = (rankedColors)rank[b];
                        p2 = rankV.RNorm;
                        //p2 = (Convert.ToInt32(rankV.water)) / 10;

                    }
                    else
                    {
                        do
                        {
                            initV = (allColors)init[rnd.Next(0, 11)];
                        } while (initV.name == rank1file || initV.name == rank2file || initV.name == rank3file);
                        p2 = initV.RNormValues;
                        // p2 = (initV.waterValues) / 10;

                    }

                    if (probCheck <= globals.crossProb)
                    {
                        offsprings = doCrossover(p1, p2);
                        // insert into newPopulation on updating the indexvalues all the times
                        globals.NewNormR[index] = offsprings[0];
                        index++;
                        globals.NewNormR[index] = offsprings[1];
                        index++;
                    }
                    else
                    {
                        globals.NewNormR[index] = p1;
                        index++;
                        globals.NewNormR[index] = p2;
                        index++;
                    }
                }

                // mutation process of G
                doMutation(globals.NewNormR);
                doMutation(globals.NewNormR);
                index = 0;




                //Crossover of G Values in Normal letters

                for (int j = 0; j < 6; j++)
                {
                    int[] offsprings = new int[2];
                    int probCheck = rnd.Next(1, 100);
                    int p1, p2;
                    int a, b;
                    string rank1file = ((rankedColors)rank[0]).panelName;
                    string rank2file = ((rankedColors)rank[1]).panelName;
                    string rank3file = ((rankedColors)rank[2]).panelName;

                    do
                    {

                        a = select.selectParent();
                        b = select.selectParent();

                    } while (a == b);

                    //if the rnd value lies in rank arraylist then, the values is taken from rank object orelse in initValues object
                    if (a <= 3)
                    {
                        rankV = (rankedColors)rank[a];
                        p1 = rankV.GNorm;
                        //p1 = (Convert.ToInt32(rankV.water)) / 10;

                    }
                    else
                    {
                        do
                        {
                            initV = (allColors)init[rnd.Next(0, 11)];
                        } while (initV.name == rank1file || initV.name == rank2file || initV.name == rank3file);

                        p1 = initV.GNormValues;
                        //p1 = (initV.waterValues) / 10;

                    }

                    if (b <= 3)
                    {
                        rankV = (rankedColors)rank[b];
                        p2 = rankV.GNorm;
                        //p2 = (Convert.ToInt32(rankV.water)) / 10;

                    }
                    else
                    {
                        do
                        {
                            initV = (allColors)init[rnd.Next(0, 11)];
                        } while (initV.name == rank1file || initV.name == rank2file || initV.name == rank3file);
                        p2 = initV.GNormValues;
                        // p2 = (initV.waterValues) / 10;

                    }

                    if (probCheck <= globals.crossProb)
                    {
                        offsprings = doCrossover(p1, p2);
                        // insert into newPopulation on updating the indexvalues all the times
                        globals.NewNormG[index] = offsprings[0];
                        index++;
                        globals.NewNormG[index] = offsprings[1];
                        index++;
                    }
                    else
                    {
                        globals.NewNormG[index] = p1;
                        index++;
                        globals.NewNormG[index] = p2;
                        index++;
                    }
                }

                // mutation process of G
                doMutation(globals.NewNormG);
                doMutation(globals.NewNormG);
                index = 0;




                //Crossover of B Values in Normal letters


                for (int j = 0; j < 6; j++)
                {
                    int[] offsprings = new int[2];
                    int probCheck = rnd.Next(1, 100);
                    int p1, p2;
                    int a, b;
                    string rank1file = ((rankedColors)rank[0]).panelName;
                    string rank2file = ((rankedColors)rank[1]).panelName;
                    string rank3file = ((rankedColors)rank[2]).panelName;

                    do
                    {

                        a = select.selectParent();
                        b = select.selectParent();

                    } while (a == b);

                    //if the rnd value lies in rank arraylist then, the values is taken from rank object orelse in initValues object
                    if (a <= 3)
                    {
                        rankV = (rankedColors)rank[a];
                        p1 = rankV.BNorm;
                        //p1 = (Convert.ToInt32(rankV.water)) / 10;

                    }
                    else
                    {
                        do
                        {
                            initV = (allColors)init[rnd.Next(0, 11)];
                        } while (initV.name == rank1file || initV.name == rank2file || initV.name == rank3file);

                        p1 = initV.BNormValues;
                        //p1 = (initV.waterValues) / 10;

                    }

                    if (b <= 3)
                    {
                        rankV = (rankedColors)rank[b];
                        p2 = rankV.BNorm;
                        //p2 = (Convert.ToInt32(rankV.water)) / 10;

                    }
                    else
                    {
                        do
                        {
                            initV = (allColors)init[rnd.Next(0, 11)];
                        } while (initV.name == rank1file || initV.name == rank2file || initV.name == rank3file);
                        p2 = initV.BNormValues;
                        // p2 = (initV.waterValues) / 10;

                    }

                    if (probCheck <= globals.crossProb)
                    {
                        offsprings = doCrossover(p1, p2);
                        // insert into newPopulation on updating the indexvalues all the times
                        globals.NewNormB[index] = offsprings[0];
                        index++;
                        globals.NewNormB[index] = offsprings[1];
                        index++;
                    }
                    else
                    {
                        globals.NewNormB[index] = p1;
                        index++;
                        globals.NewNormB[index] = p2;
                        index++;
                    }
                }

                // mutation process of G
                doMutation(globals.NewNormB);
                doMutation(globals.NewNormB);
                index = 0;


            }



            //crossover of button back colors

            if (!globals.lockButtBack)
            {
                for (int j = 0; j < 6; j++)
                {

                    int[] offsprings = new int[2];
                    int p1, p2;
                    int a, b;
                    string rank1file = ((rankedColors)rank[0]).panelName;
                    string rank2file = ((rankedColors)rank[1]).panelName;
                    string rank3file = ((rankedColors)rank[2]).panelName;

                    do
                    {

                        a = select.selectParent();
                        b = select.selectParent();

                    } while (a == b);

                    //Parent A
                    //if the rnd value lies in rank arraylist then, the values is taken from rank object orelse in initValues object
                    if (a <= 3)
                    {
                        rankV = (rankedColors)rank[a];
                        p1 = rankV.RButtBack;
                        //p1 = (Convert.ToInt32(rankV.water)) / 10;

                    }
                    else
                    {
                        do
                        {
                            initV = (allColors)init[rnd.Next(0, 11)];
                        } while (initV.name == rank1file || initV.name == rank2file || initV.name == rank3file);

                        p1 = initV.RButtBackValues;
                        //p1 = (initV.waterValues) / 10;

                    }


                    //Parent B
                    if (b <= 3)
                    {
                        rankV = (rankedColors)rank[b];
                        p2 = rankV.RButtBack;
                        //p2 = (Convert.ToInt32(rankV.water)) / 10;

                    }
                    else
                    {
                        do
                        {
                            initV = (allColors)init[rnd.Next(0, 11)];
                        } while (initV.name == rank1file || initV.name == rank2file || initV.name == rank3file);
                        p2 = initV.RButtBackValues;
                        // p2 = (initV.waterValues) / 10;

                    }



                    //crossover begins here...
                    if (probCheck <= globals.crossProb)
                    {
                        offsprings = doCrossover(p1, p2);
                        // insert into newPopulation on updating the indexvalues all the times
                        globals.newButtbackR[index] = offsprings[0];
                        index++;
                        globals.newButtbackR[index] = offsprings[1];
                        index++;
                    }
                    else
                    {
                        globals.newButtbackR[index] = p1;
                        index++;
                        globals.newButtbackR[index] = p2;
                        index++;
                    }
                }

                // mutation process of R
                doMutation(globals.newButtbackR);
                doMutation(globals.newButtbackR);
                index = 0;

                //G value crossover

                for (int j = 0; j < 6; j++)
                {
                    int[] offsprings = new int[2];
                    int probCheck = rnd.Next(1, 100);
                    int p1, p2;
                    int a, b;
                    string rank1file = ((rankedColors)rank[0]).panelName;
                    string rank2file = ((rankedColors)rank[1]).panelName;
                    string rank3file = ((rankedColors)rank[2]).panelName;

                    do
                    {

                        a = select.selectParent();
                        b = select.selectParent();

                    } while (a == b);

                    //if the rnd value lies in rank arraylist then, the values is taken from rank object orelse in initValues object
                    if (a <= 3)
                    {
                        rankV = (rankedColors)rank[a];
                        p1 = rankV.GButtBack;
                        //p1 = (Convert.ToInt32(rankV.water)) / 10;

                    }
                    else
                    {
                        do
                        {
                            initV = (allColors)init[rnd.Next(0, 11)];
                        } while (initV.name == rank1file || initV.name == rank2file || initV.name == rank3file);

                        p1 = initV.GButtBackValues;
                        //p1 = (initV.waterValues) / 10;

                    }

                    if (b <= 3)
                    {
                        rankV = (rankedColors)rank[b];
                        p2 = rankV.GButtBack;
                        //p2 = (Convert.ToInt32(rankV.water)) / 10;

                    }
                    else
                    {
                        do
                        {
                            initV = (allColors)init[rnd.Next(0, 11)];
                        } while (initV.name == rank1file || initV.name == rank2file || initV.name == rank3file);
                        p2 = initV.GButtBackValues;
                        // p2 = (initV.waterValues) / 10;

                    }

                    if (probCheck <= globals.crossProb)
                    {
                        offsprings = doCrossover(p1, p2);

                        // insert into newPopulation on updating the indexvalues all the times
                        globals.NewButtbackG[index] = offsprings[0];
                        index++;
                        globals.NewButtbackG[index] = offsprings[1];
                        index++;
                    }
                    else
                    {
                        globals.NewButtbackG[index] = p1;
                        index++;
                        globals.NewButtbackG[index] = p2;
                        index++;
                    }
                }

                // mutation process of G
                doMutation(globals.NewButtbackG);
                doMutation(globals.NewButtbackG);
                index = 0;

                //Crossover of B Values
                for (int j = 0; j < 6; j++)
                {
                    int[] offsprings = new int[2];
                    int probCheck = rnd.Next(1, 100);
                    int p1, p2;
                    int a, b;
                    string rank1file = ((rankedColors)rank[0]).panelName;
                    string rank2file = ((rankedColors)rank[1]).panelName;
                    string rank3file = ((rankedColors)rank[2]).panelName;

                    do
                    {

                        a = select.selectParent();
                        b = select.selectParent();

                    } while (a == b);

                    //if the rnd value lies in rank arraylist then, the values is taken from rank object orelse in initValues object
                    if (a <= 3)
                    {
                        rankV = (rankedColors)rank[a];
                        p1 = rankV.BButtBack;
                        //p1 = (Convert.ToInt32(rankV.water)) / 10;

                    }
                    else
                    {
                        do
                        {
                            initV = (allColors)init[rnd.Next(0, 11)];
                        } while (initV.name == rank1file || initV.name == rank2file || initV.name == rank3file);

                        p1 = initV.BButtBackValues;
                        //p1 = (initV.waterValues) / 10;

                    }

                    if (b <= 3)
                    {
                        rankV = (rankedColors)rank[b];
                        p2 = rankV.BButtBack;
                        //p2 = (Convert.ToInt32(rankV.water)) / 10;

                    }
                    else
                    {
                        do
                        {
                            initV = (allColors)init[rnd.Next(0, 11)];
                        } while (initV.name == rank1file || initV.name == rank2file || initV.name == rank3file);
                        p2 = initV.BButtBackValues;
                        // p2 = (initV.waterValues) / 10;

                    }

                    if (probCheck <= globals.crossProb)
                    {
                        offsprings = doCrossover(p1, p2);
                        // insert into newPopulation on updating the indexvalues all the times
                        globals.NewButtbackB[index] = offsprings[0];
                        index++;
                        globals.NewButtbackB[index] = offsprings[1];
                        index++;
                    }
                    else
                    {
                        globals.NewButtbackB[index] = p1;
                        index++;
                        globals.NewButtbackB[index] = p2;
                        index++;
                    }
                }

                // mutation process of G
                doMutation(globals.NewButtbackB);
                doMutation(globals.NewButtbackB);
                index = 0;

            }


            if (!globals.lockMainBack)
            {
                for (int j = 0; j < 6; j++)
                {

                    int[] offsprings = new int[2];
                    int p1, p2;
                    int a, b;
                    string rank1file = ((rankedColors)rank[0]).panelName;
                    string rank2file = ((rankedColors)rank[1]).panelName;
                    string rank3file = ((rankedColors)rank[2]).panelName;

                    do
                    {

                        a = select.selectParent();
                        b = select.selectParent();

                    } while (a == b);

                    //Parent A
                    //if the rnd value lies in rank arraylist then, the values is taken from rank object orelse in initValues object
                    if (a <= 3)
                    {
                        rankV = (rankedColors)rank[a];
                        p1 = rankV.RMainBack;
                        //p1 = (Convert.ToInt32(rankV.water)) / 10;

                    }
                    else
                    {
                        do
                        {
                            initV = (allColors)init[rnd.Next(0, 11)];
                        } while (initV.name == rank1file || initV.name == rank2file || initV.name == rank3file);

                        p1 = initV.RMainBackValues;
                        //p1 = (initV.waterValues) / 10;

                    }


                    //Parent B
                    if (b <= 3)
                    {
                        rankV = (rankedColors)rank[b];
                        p2 = rankV.RMainBack;
                        //p2 = (Convert.ToInt32(rankV.water)) / 10;

                    }
                    else
                    {
                        do
                        {
                            initV = (allColors)init[rnd.Next(0, 11)];
                        } while (initV.name == rank1file || initV.name == rank2file || initV.name == rank3file);
                        p2 = initV.RMainBackValues;
                        // p2 = (initV.waterValues) / 10;

                    }



                    //crossover begins here...
                    if (probCheck <= globals.crossProb)
                    {
                        offsprings = doCrossover(p1, p2);
                        // insert into newPopulation on updating the indexvalues all the times
                        globals.NewMainbackR[index] = offsprings[0];
                        index++;
                        globals.NewMainbackR[index] = offsprings[1];
                        index++;
                    }
                    else
                    {
                        globals.NewMainbackR[index] = p1;
                        index++;
                        globals.NewMainbackR[index] = p2;
                        index++;
                    }
                }

                // mutation process of R
                doMutation(globals.NewMainbackR);
                doMutation(globals.NewMainbackR);
                index = 0;

                //G value crossover

                for (int j = 0; j < 6; j++)
                {
                    int[] offsprings = new int[2];
                    int probCheck = rnd.Next(1, 100);
                    int p1, p2;
                    int a, b;
                    string rank1file = ((rankedColors)rank[0]).panelName;
                    string rank2file = ((rankedColors)rank[1]).panelName;
                    string rank3file = ((rankedColors)rank[2]).panelName;

                    do
                    {

                        a = select.selectParent();
                        b = select.selectParent();

                    } while (a == b);

                    //if the rnd value lies in rank arraylist then, the values is taken from rank object orelse in initValues object
                    if (a <= 3)
                    {
                        rankV = (rankedColors)rank[a];
                        p1 = rankV.GMainBack;
                        //p1 = (Convert.ToInt32(rankV.water)) / 10;

                    }
                    else
                    {
                        do
                        {
                            initV = (allColors)init[rnd.Next(0, 11)];
                        } while (initV.name == rank1file || initV.name == rank2file || initV.name == rank3file);

                        p1 = initV.GMainBackValues;
                        //p1 = (initV.waterValues) / 10;

                    }

                    if (b <= 3)
                    {
                        rankV = (rankedColors)rank[b];
                        p2 = rankV.GMainBack;
                        //p2 = (Convert.ToInt32(rankV.water)) / 10;

                    }
                    else
                    {
                        do
                        {
                            initV = (allColors)init[rnd.Next(0, 11)];
                        } while (initV.name == rank1file || initV.name == rank2file || initV.name == rank3file);
                        p2 = initV.GMainBackValues;
                        // p2 = (initV.waterValues) / 10;

                    }

                    if (probCheck <= globals.crossProb)
                    {
                        offsprings = doCrossover(p1, p2);

                        // insert into newPopulation on updating the indexvalues all the times
                        globals.NewMainbackG[index] = offsprings[0];
                        index++;
                        globals.NewMainbackG[index] = offsprings[1];
                        index++;
                    }
                    else
                    {
                        globals.NewMainbackG[index] = p1;
                        index++;
                        globals.NewMainbackG[index] = p2;
                        index++;
                    }
                }

                // mutation process of G
                doMutation(globals.NewMainbackG);
                doMutation(globals.NewMainbackG);
                index = 0;

                //Crossover of B Values
                for (int j = 0; j < 6; j++)
                {
                    int[] offsprings = new int[2];
                    int probCheck = rnd.Next(1, 100);
                    int p1, p2;
                    int a, b;
                    string rank1file = ((rankedColors)rank[0]).panelName;
                    string rank2file = ((rankedColors)rank[1]).panelName;
                    string rank3file = ((rankedColors)rank[2]).panelName;

                    do
                    {

                        a = select.selectParent();
                        b = select.selectParent();

                    } while (a == b);

                    //if the rnd value lies in rank arraylist then, the values is taken from rank object orelse in initValues object
                    if (a <= 3)
                    {
                        rankV = (rankedColors)rank[a];
                        p1 = rankV.BMainBack;
                        //p1 = (Convert.ToInt32(rankV.water)) / 10;

                    }
                    else
                    {
                        do
                        {
                            initV = (allColors)init[rnd.Next(0, 11)];
                        } while (initV.name == rank1file || initV.name == rank2file || initV.name == rank3file);

                        p1 = initV.BMainBackValues;
                        //p1 = (initV.waterValues) / 10;

                    }

                    if (b <= 3)
                    {
                        rankV = (rankedColors)rank[b];
                        p2 = rankV.BMainBack;
                        //p2 = (Convert.ToInt32(rankV.water)) / 10;

                    }
                    else
                    {
                        do
                        {
                            initV = (allColors)init[rnd.Next(0, 11)];
                        } while (initV.name == rank1file || initV.name == rank2file || initV.name == rank3file);
                        p2 = initV.BMainBackValues;
                        // p2 = (initV.waterValues) / 10;

                    }

                    if (probCheck <= globals.crossProb)
                    {
                        offsprings = doCrossover(p1, p2);
                        // insert into newPopulation on updating the indexvalues all the times
                        globals.NewMainbackB[index] = offsprings[0];
                        index++;
                        globals.NewMainbackB[index] = offsprings[1];
                        index++;
                    }
                    else
                    {
                        globals.NewMainbackB[index] = p1;
                        index++;
                        globals.NewMainbackB[index] = p2;
                        index++;
                    }
                }

                // mutation process of G
                doMutation(globals.NewMainbackB);
                doMutation(globals.NewMainbackB);
                index = 0;

            }



            if (!globals.lockButtFore)
            {
                for (int j = 0; j < 6; j++)
                {

                    int[] offsprings = new int[2];
                    int p1, p2;
                    int a, b;
                    string rank1file = ((rankedColors)rank[0]).panelName;
                    string rank2file = ((rankedColors)rank[1]).panelName;
                    string rank3file = ((rankedColors)rank[2]).panelName;

                    do
                    {

                        a = select.selectParent();
                        b = select.selectParent();

                    } while (a == b);

                    //Parent A
                    //if the rnd value lies in rank arraylist then, the values is taken from rank object orelse in initValues object
                    if (a <= 3)
                    {
                        rankV = (rankedColors)rank[a];
                        p1 = rankV.RButtFore;
                        //p1 = (Convert.ToInt32(rankV.water)) / 10;

                    }
                    else
                    {
                        do
                        {
                            initV = (allColors)init[rnd.Next(0, 11)];
                        } while (initV.name == rank1file || initV.name == rank2file || initV.name == rank3file);

                        p1 = initV.RButtForeValues;
                        //p1 = (initV.waterValues) / 10;

                    }


                    //Parent B
                    if (b <= 3)
                    {
                        rankV = (rankedColors)rank[b];
                        p2 = rankV.RButtFore;
                        //p2 = (Convert.ToInt32(rankV.water)) / 10;

                    }
                    else
                    {
                        do
                        {
                            initV = (allColors)init[rnd.Next(0, 11)];
                        } while (initV.name == rank1file || initV.name == rank2file || initV.name == rank3file);
                        p2 = initV.RButtForeValues;
                        // p2 = (initV.waterValues) / 10;

                    }



                    //crossover begins here...
                    if (probCheck <= globals.crossProb)
                    {
                        offsprings = doCrossover(p1, p2);
                        // insert into newPopulation on updating the indexvalues all the times
                        globals.NewButtForeR[index] = offsprings[0];
                        index++;
                        globals.NewButtForeR[index] = offsprings[1];
                        index++;
                    }
                    else
                    {
                        globals.NewButtForeR[index] = p1;
                        index++;
                        globals.NewButtForeR[index] = p2;
                        index++;
                    }
                }

                // mutation process of R
                doMutation(globals.NewButtForeR);
                doMutation(globals.NewButtForeR);
                index = 0;

                //G value crossover

                for (int j = 0; j < 6; j++)
                {
                    int[] offsprings = new int[2];
                    int probCheck = rnd.Next(1, 100);
                    int p1, p2;
                    int a, b;
                    string rank1file = ((rankedColors)rank[0]).panelName;
                    string rank2file = ((rankedColors)rank[1]).panelName;
                    string rank3file = ((rankedColors)rank[2]).panelName;

                    do
                    {

                        a = select.selectParent();
                        b = select.selectParent();

                    } while (a == b);

                    //if the rnd value lies in rank arraylist then, the values is taken from rank object orelse in initValues object
                    if (a <= 3)
                    {
                        rankV = (rankedColors)rank[a];
                        p1 = rankV.GButtFore;
                        //p1 = (Convert.ToInt32(rankV.water)) / 10;

                    }
                    else
                    {
                        do
                        {
                            initV = (allColors)init[rnd.Next(0, 11)];
                        } while (initV.name == rank1file || initV.name == rank2file || initV.name == rank3file);

                        p1 = initV.GButtForeValues;
                        //p1 = (initV.waterValues) / 10;

                    }

                    if (b <= 3)
                    {
                        rankV = (rankedColors)rank[b];
                        p2 = rankV.GButtFore;
                        //p2 = (Convert.ToInt32(rankV.water)) / 10;

                    }
                    else
                    {
                        do
                        {
                            initV = (allColors)init[rnd.Next(0, 11)];
                        } while (initV.name == rank1file || initV.name == rank2file || initV.name == rank3file);
                        p2 = initV.GButtForeValues;
                        // p2 = (initV.waterValues) / 10;

                    }

                    if (probCheck <= globals.crossProb)
                    {
                        offsprings = doCrossover(p1, p2);

                        // insert into newPopulation on updating the indexvalues all the times
                        globals.NewButtForeG[index] = offsprings[0];
                        index++;
                        globals.NewButtForeG[index] = offsprings[1];
                        index++;
                    }
                    else
                    {
                        globals.NewButtForeG[index] = p1;
                        index++;
                        globals.NewButtForeG[index] = p2;
                        index++;
                    }
                }

                // mutation process of G
                doMutation(globals.NewButtForeG);
                doMutation(globals.NewButtForeG);
                index = 0;

                //Crossover of B Values
                for (int j = 0; j < 6; j++)
                {
                    int[] offsprings = new int[2];
                    int probCheck = rnd.Next(1, 100);
                    int p1, p2;
                    int a, b;
                    string rank1file = ((rankedColors)rank[0]).panelName;
                    string rank2file = ((rankedColors)rank[1]).panelName;
                    string rank3file = ((rankedColors)rank[2]).panelName;

                    do
                    {

                        a = select.selectParent();
                        b = select.selectParent();

                    } while (a == b);

                    //if the rnd value lies in rank arraylist then, the values is taken from rank object orelse in initValues object
                    if (a <= 3)
                    {
                        rankV = (rankedColors)rank[a];
                        p1 = rankV.BButtFore;
                        //p1 = (Convert.ToInt32(rankV.water)) / 10;

                    }
                    else
                    {
                        do
                        {
                            initV = (allColors)init[rnd.Next(0, 11)];
                        } while (initV.name == rank1file || initV.name == rank2file || initV.name == rank3file);

                        p1 = initV.BButtForeValues;
                        //p1 = (initV.waterValues) / 10;

                    }

                    if (b <= 3)
                    {
                        rankV = (rankedColors)rank[b];
                        p2 = rankV.BButtFore;
                        //p2 = (Convert.ToInt32(rankV.water)) / 10;

                    }
                    else
                    {
                        do
                        {
                            initV = (allColors)init[rnd.Next(0, 11)];
                        } while (initV.name == rank1file || initV.name == rank2file || initV.name == rank3file);
                        p2 = initV.BButtForeValues;
                        // p2 = (initV.waterValues) / 10;

                    }

                    if (probCheck <= globals.crossProb)
                    {
                        offsprings = doCrossover(p1, p2);
                        // insert into newPopulation on updating the indexvalues all the times
                        globals.NewButtForeB[index] = offsprings[0];
                        index++;
                        globals.NewButtForeB[index] = offsprings[1];
                        index++;
                    }
                    else
                    {
                        globals.NewButtForeB[index] = p1;
                        index++;
                        globals.NewButtForeB[index] = p2;
                        index++;
                    }
                }

                // mutation process of G
                doMutation(globals.NewButtForeB);
                doMutation(globals.NewButtForeB);
                index = 0;

            }


        }

        
        public void doMutation(int[] newPop)
        {
            //mutation probability changing from tacking bar value
            //if the tracking bar is 1 then it is considered as 10% in which one bit
            //in the chromosome is been changed respectively upto 100%.

            string afterMutH;
            // pick one individual from the final population

            int probCheck = rnd.Next(1, 100);

            if (probCheck <= globals.mutProb)
            {
                int getMutH = (int)(12 * rnd.NextDouble());

                int mutBit = rnd.Next(1, 8);
                StringBuilder sbH = new StringBuilder();

                int mutationH = newPop[getMutH];
                string MutIndH = (change.DecimalToBase(mutationH, basevalue).PadLeft(8, '0'));
                string mutParentH = MutIndH.Substring(mutBit - 1, 1);

                if (mutParentH == "0")
                {
                    sbH.Append(MutIndH);
                    sbH.Remove(mutBit - 1, 1);
                    sbH.Insert(mutBit - 1, "1");
                    afterMutH = sbH.ToString();
                }
                else
                {
                    sbH.Append(MutIndH);
                    sbH.Remove(mutBit - 1, 1);
                    sbH.Insert(mutBit - 1, "0");
                    afterMutH = sbH.ToString();
                }
                int insertMutH = change.BaseToDecimal(afterMutH, basevalue);
                newPop[getMutH] = insertMutH;
            }

        }

        public int[] doCrossover(int p1, int p2)
        {
            int[] results = new int[2];


            if (p1 < 0)
            {
                conP1 = (change.NegativeDecimalToBase(p1));
            }
            else
            {
                conP1 = (change.DecimalToBase(p1, basevalue).PadLeft(8, '0'));
            }

            if (p2 < 0)
            {
                conP2 = (change.NegativeDecimalToBase(p2));
            }
            else
            {
                conP2 = (change.DecimalToBase(p2, basevalue).PadLeft(8, '0'));
            }

            int crossOverPoint = rnd.Next(0, 8);

            string conParent1 = conP1.Substring(crossOverPoint);
            string conParent2 = conP2.Substring(crossOverPoint);

            string c1 = conP1.Substring(0, crossOverPoint);
            string c2 = conP2.Substring(0, crossOverPoint);

            StringBuilder off1 = new StringBuilder(c1);
            StringBuilder off2 = new StringBuilder(c2);

            off1.Append(conParent2);
            off2.Append(conParent1);

            string newoff1 = off1.ToString();
            string newoff2 = off2.ToString();

            int newIndi1, newIndi2;

            if (p1 < 0)
            {
                newIndi1 = change.NegativeBaseToDecimal(newoff1);
            }
            else
            {
                newIndi1 = change.BaseToDecimal(newoff1, basevalue);
            }

            if (p2 < 0)
            {
                newIndi2 = change.NegativeBaseToDecimal(newoff2);
            }
            else
            {
                newIndi2 = change.BaseToDecimal(newoff2, basevalue);
            }


            results[0] = newIndi1;
            results[1] = newIndi2;


            return results;
        }
    }
}
