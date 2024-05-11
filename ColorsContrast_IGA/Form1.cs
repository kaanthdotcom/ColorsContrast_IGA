using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Xml;
using System.Threading;
using System.Drawing.Imaging;

namespace ColorsContrastIGA
{
    public partial class Form1 : Form
    {
        int presentGeneration = 0;

        int totalColors = 12;
        crossOverMutation engineGA = new crossOverMutation();
        aestheticCrossMutation aesCrossMutt = new aestheticCrossMutation();
        injectBestColorMatch inject = new injectBestColorMatch();


      // private Bitmap bannerImage;
        private ArrayList bestPicked;
        private string imagePath = "C:\\ATGS\\ColorContrastIGA\\images\\";
        private int randomGenPickCount = 0;
        int[] averageRGB = new int[3];
        private int secondRandomGenPickCount = 0;
        private int bestBackMainColor = 0;
        private int bestButtonBackColor = 0;
        private string formatType;
        private ArrayList FileTypes;
        private bool formatFound, imageSelected;
        private string filename, filepath;


        private int nSelectedFile = -1;
        private ArrayList FileArray;
        public ArrayList colorSelected;
        private Label[] banner, bold, normal, aestLabel, aestResult, rankingInof;
        private Button[] preview;
        private Color backColor;
        private Color secondBackColor;
        private Color buttonBackColor;

        private Panel[] colorsPanel;
        private Panel[] colorsPanel2;
        private CheckBox[] checkboxes;
        private Panel[] infoPanel;
        private Panel[] optionsPanel;
        private int posX = 20;
        private int posY = 50;
        private int myHeight = 70;
        private int myWidth = 40;
        private int gap = 230;
        private ArrayList allColorsArray;
        private int selected_colors = 0;
        bool genRandom = false;
        int manualRankCount = 0;

        private bool backLockKey = false;
        private bool autoRun = false;
        private bool runSecondAestheticTest = false;
       
        //manual color picks trigger
        private bool backColorTrigger = false;
        private bool backButtonTrigger = false;
        private bool bannerTrigger = false;
        private bool boldTrigger = false;
        private bool normalTextTrigger = false;
        private bool textBackgroundTrigger = false;
        private bool buttForeTrigger = false;
        //manual color picks trigger counts
        private int backColorTriggerCount = 0;
        private int backButtonTriggerCount = 0;
        private int bannerTriggerCount = 0;
        private int boldTriggerCount = 0;
        private int normalTextTriggerCount = 0;
        private int textBackgroundTriggerCount = 0;
        private int buttForeTriggerCount = 0;
        



        private Button[] homeButt;
        private Button[] aboutButt;
        private Button[] contactButt;


        aestheticCheck getResults = new aestheticCheck();


        private Random rnd = new Random();



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // initialize the image types array
                FileTypes = new ArrayList();
                FileTypes.Add("*.JPG");
                FileTypes.Add("*.JPEG");
                FileTypes.Add("*.GIF");
                FileTypes.Add("*.BMP");
                FileTypes.Add("*.PNG");
                FileTypes.Add("*.TIF");
                FileTypes.Add("*.TIFF");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.ToString());
            }

            processLogic(presentGeneration);
        }

        private void processLogic(int presentGeneration)
        {
            homeButt = new Button[totalColors];
            aboutButt = new Button[totalColors];
            contactButt = new Button[totalColors];
            allColorsArray = new ArrayList();
            colorSelected = new ArrayList();
            colorsPanel = new Panel[totalColors];
            colorsPanel2 = new Panel[totalColors];
            infoPanel = new Panel[totalColors];
            optionsPanel = new Panel[totalColors];
            banner = new Label[totalColors];
            bold = new Label[totalColors];
            normal = new Label[totalColors];
            aestLabel = new Label[totalColors];
            aestResult = new Label[totalColors];
            preview = new Button[totalColors];
            checkboxes = new CheckBox[totalColors];
            rankingInof = new Label[totalColors];
            int bannerPer = 0, boldPer = 0, normalPer = 0;
            string bannerComment = "", boldComment = "", normalComment = "";
            
            

            Random rnd = new Random();

            int colNum = (int)Math.Floor((double)this.Width / (double)(myWidth + gap));
            int rowNum = (int)Math.Floor((double)this.Height / (double)(myHeight + gap));

            colNum = colNum - 2;

            int row = 0;

            for (int i = 0; i < totalColors; i++)
            {
                string[] bannerResult = new string[2];
                string[] boldResult = new string[2];
                string[] normalResult = new string[2];


                //assigning picture box dynamically for each image from the folder    
                allColors obj = new allColors();

                
                banner[i] = new Label();
                bold[i] = new Label();
                normal[i] = new Label();
                aestLabel[i] = new Label();
                aestResult[i] = new Label();
                rankingInof[i] = new Label();
                


                banner[i].AutoSize = true;
                banner[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                banner[i].Location = new System.Drawing.Point(posX + 1, posY + 5);
                banner[i].Name = "banner" + i + "";
                   banner[i].Size = new System.Drawing.Size(161, 25);
                banner[i].TabIndex = 32;
                banner[i].ForeColor = Color.FromArgb(globals.newBannR[i], globals.newBannG[i], globals.newBannB[i]);
                if (imageSelected)
                {
                    banner[i].Image = new Bitmap(imagePath + filename);
                }
                else
                {
                    banner[i].BackColor = Color.FromArgb(globals.newBackR[i], globals.newBackG[i], globals.newBackB[i]);
                }
                
                
                
                if (bannerText.Text == "")
                {
                    banner[i].Text = "  Banner";
                    banner[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                
                }
                else
                {
                    banner[i].Text = bannerText.Text;
                    banner[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                
                }
                banner[i].BringToFront();

                banner[i].Update();
                this.Controls.Add(banner[i]);


                //add extra button here for home, about and contact us

                //adding home button
                homeButt[i] = new Button();
                homeButt[i].Name = i.ToString();
                homeButt[i].Width = 82;
                homeButt[i].Height = 25;
                homeButt[i].ForeColor = Color.FromArgb(globals.NewButtForeR[i], globals.NewButtForeG[i], globals.NewButtForeB[i]);
                homeButt[i].BackColor = Color.FromArgb(globals.newButtbackR[i], globals.newButtbackG[i], globals.newButtbackB[i]);
                homeButt[i].FlatStyle = System.Windows.Forms.FlatStyle.Popup;
                homeButt[i].Text = "Home";
                homeButt[i].Location = new System.Drawing.Point(posX + 1, posY + 74);
                homeButt[i].BringToFront();
               

                this.Controls.Add(homeButt[i]);



                //adding home button
                aboutButt[i] = new Button();
                aboutButt[i].Name = i.ToString();
                aboutButt[i].Width = 82;
                aboutButt[i].Height = 25;
                aboutButt[i].ForeColor = Color.FromArgb(globals.NewButtForeR[i], globals.NewButtForeG[i], globals.NewButtForeB[i]);
                aboutButt[i].BackColor = Color.FromArgb(globals.newButtbackR[i], globals.newButtbackG[i], globals.newButtbackB[i]);
                aboutButt[i].FlatStyle = System.Windows.Forms.FlatStyle.Popup;
                aboutButt[i].Text = "About Us";
                aboutButt[i].Location = new System.Drawing.Point(posX + 84, posY + 74);
                aboutButt[i].BringToFront();


                this.Controls.Add(aboutButt[i]);


                //adding home button
                contactButt[i] = new Button();
                contactButt[i].Name = i.ToString();
                contactButt[i].Width = 82;
                contactButt[i].Height = 25;
                contactButt[i].ForeColor = Color.FromArgb(globals.NewButtForeR[i], globals.NewButtForeG[i], globals.NewButtForeB[i]);
                contactButt[i].BackColor = Color.FromArgb(globals.newButtbackR[i], globals.newButtbackG[i], globals.newButtbackB[i]);
                contactButt[i].FlatStyle = System.Windows.Forms.FlatStyle.Popup;
                contactButt[i].Text = "Contact Us";
                contactButt[i].Location = new System.Drawing.Point(posX + 167, posY + 74);
                contactButt[i].BringToFront();


                this.Controls.Add(contactButt[i]);


                bold[i].AutoSize = true;
                bold[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                bold[i].Location = new System.Drawing.Point(posX + 10, posY + 105);
                bold[i].Name = "bold" + i + "";
                bold[i].Size = new System.Drawing.Size(161, 25);
                bold[i].TabIndex = 32;
                bold[i].ForeColor = Color.FromArgb(globals.newBoldR[i], globals.newBoldG[i], globals.newBoldB[i]);
                bold[i].BackColor = Color.FromArgb(globals.newMainbackR[i], globals.newMainbackG[i], globals.newMainbackB[i]);
                bold[i].Text = "Sample Text in bold";
                bold[i].BringToFront();
                // bold[i].Update();
                bold[i].Refresh();

                this.Controls.Add(bold[i]);



                normal[i].AutoSize = true;
                normal[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                normal[i].Location = new System.Drawing.Point(posX + 50, posY + 135);
                normal[i].Name = "normal" + i + "";
                normal[i].Size = new System.Drawing.Size(161, 25);
                normal[i].TabIndex = 32;
                normal[i].ForeColor = Color.FromArgb(globals.newNormR[i], globals.newNormG[i], globals.newNormB[i]);
                normal[i].BackColor = Color.FromArgb(globals.newMainbackR[i], globals.newMainbackG[i], globals.newMainbackB[i]);
                normal[i].Text = "This is a normal text \n with font size 12";
                normal[i].BringToFront();

                normal[i].Update();
                this.Controls.Add(normal[i]);


                bannerResult = getResults.checkContrast(banner[i].ForeColor, Color.FromArgb(globals.newBackR[i], globals.newBackG[i], globals.newBackB[i]));
                boldResult = getResults.checkContrast(bold[i].ForeColor, Color.FromArgb(globals.newMainbackR[i], globals.newMainbackG[i], globals.newMainbackB[i]));
                normalResult = getResults.checkContrast(normal[i].ForeColor, Color.FromArgb(globals.newMainbackR[i], globals.newMainbackG[i], globals.newMainbackB[i]));

                bannerPer = getResults.getPercentage(bannerResult);
                boldPer = getResults.getPercentage(boldResult);
                normalPer = getResults.getPercentage(normalResult);

                bannerComment = getResults.getComment(bannerPer);
                boldComment = getResults.getComment(boldPer);
                normalComment = getResults.getComment(normalPer);


                aestLabel[i].AutoSize = true;
                aestLabel[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                aestLabel[i].Location = new System.Drawing.Point(posX + 2, posY + 185);
                aestLabel[i].Name = "aestLabel" + i + "";
                aestLabel[i].Size = new System.Drawing.Size(161, 25);
                aestLabel[i].TabIndex = 32;
                aestLabel[i].ForeColor = Color.FromArgb(0, 0, 0);
                aestLabel[i].BackColor = System.Drawing.SystemColors.Control;
                aestLabel[i].Text = "Ban:(CCR=" + bannerResult[0] + ":1)(CD=" + bannerResult[1] + ")(BD=" + bannerResult[2] + ") = " + bannerPer + "% - " + bannerComment + "\nBold:(CCR=" + boldResult[0] + ":1)(CD=" + boldResult[1] + ")(BD=" + boldResult[2] + ") =" + boldPer + "% - " + boldComment + "\nNorm:(CCR=" + normalResult[0] + ":1)(CD=" + normalResult[1] + ")(BD=" + normalResult[2] + ") =" + normalPer + "% - " + normalComment + "";
                //aestLabel[i].Text = "Banner: CCR=4:1,    CD=250,    BD=450. \nBold:     CCR=4:1,    CD=250,    BD=450. \nNormal: CCR=4:1,    CD=250,    BD=450. \n";
                aestLabel[i].BringToFront();

                aestLabel[i].Update();
                this.Controls.Add(aestLabel[i]);
               

                //information panel

                infoPanel[i] = new Panel();

                infoPanel[i].Name = i.ToString();

                infoPanel[i].BackColor = System.Drawing.SystemColors.Control;
                infoPanel[i].Width = 250;
                infoPanel[i].Height = 45;
                infoPanel[i].Location = new System.Drawing.Point(posX, posY + 181);
                infoPanel[i].BorderStyle = BorderStyle.FixedSingle;
                infoPanel[i].SendToBack();

                if (posX >= this.Width - (myWidth + gap) && i >= colNum)
                {
                    posX = -270;
                    row++;
                    posY = infoPanel[i - 1].Location.Y + myHeight + 200;
                }

                this.Controls.Add(infoPanel[i]);



                //this label is to display ranking of each image using Aesthetic measure
                rankingInof[i].AutoSize = true;
                rankingInof[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                rankingInof[i].Location = new System.Drawing.Point(posX + 10, posY + 230);
                rankingInof[i].Name = i.ToString();
                rankingInof[i].Size = new System.Drawing.Size(161, 25);
                rankingInof[i].TabIndex = 32;
                rankingInof[i].ForeColor = System.Drawing.Color.Green;
                rankingInof[i].BackColor = System.Drawing.SystemColors.Control;
                //rankingInof[i].Text = "Rank";
                rankingInof[i].BringToFront();

                rankingInof[i].Update();
                this.Controls.Add(rankingInof[i]);




                //this dynamic checkbox is for allowing user to select the ranking of each images.
                checkboxes[i] = new CheckBox();
                checkboxes[i].Name = i.ToString();
                checkboxes[i].Width = 30;
                checkboxes[i].Location = new System.Drawing.Point(posX + 150, posY + 230);
                checkboxes[i].BringToFront();
                checkboxes[i].Update();
                checkboxes[i].CheckedChanged += new EventHandler(Form1_CheckedChanged);

                if (posX >= this.Width - (myWidth + gap) && i >= colNum)
                {
                    posX = -270;
                    row++;
                    posY = checkboxes[i - 1].Location.Y + myHeight + 200;
                }

                this.Controls.Add(checkboxes[i]);





                //adding button for preview purpose
                //add dynamic button here to preview the website in IE
                preview[i] = new Button();
                preview[i].Name = i.ToString();
                preview[i].Width = 60;
                preview[i].Height = 30;
                preview[i].Text = "Preview";
                preview[i].Location = new System.Drawing.Point(posX + 185, posY + 230);
                preview[i].BringToFront();
                preview[i].Click += new EventHandler(preview_click);

                this.Controls.Add(preview[i]);
                
                

                

                 colorsPanel2[i] = new Panel();

                colorsPanel2[i].Name = i.ToString();

                colorsPanel2[i].BackColor = Color.FromArgb(globals.newMainbackR[i], globals.newMainbackG[i], globals.newMainbackB[i]);
                colorsPanel2[i].Width = 250;
                colorsPanel2[i].Height = 80;
                colorsPanel2[i].Location = new System.Drawing.Point(posX, posY + 99);
                colorsPanel2[i].BorderStyle = BorderStyle.FixedSingle;
                colorsPanel2[i].SendToBack();
             //   colorsPanel2[i].Click += new EventHandler(color_click);

                this.Controls.Add(colorsPanel2[i]);
                
                
                //this panel is displaying all the colors
                
                colorsPanel[i] = new Panel();

                colorsPanel[i].Name = i.ToString();
                //if condition to check the image is selected or not
                if (imageSelected)
                {
                    colorsPanel[i].BackgroundImage = new Bitmap(imagePath + "main_" + filename);
                }
                else
                {
                    colorsPanel[i].BackColor = Color.FromArgb(globals.newBackR[i], globals.newBackG[i], globals.newBackB[i]);
                }
                               
                colorsPanel[i].Width = 250;
                colorsPanel[i].Height = 100;
                colorsPanel[i].Location = new System.Drawing.Point(posX, posY);
                colorsPanel[i].BorderStyle = BorderStyle.FixedSingle;
                colorsPanel[i].SendToBack();
               // colorsPanel[i].Click += new EventHandler(color_click);
                posX += myWidth + gap;

                if (posX >= this.Width - (myWidth + gap) && i >= colNum)
                {
                    posX = 20;
                    row++;
                    posY = colorsPanel[i - 1].Location.Y + myHeight + 200;
                }
                this.Controls.Add(colorsPanel[i]);

                obj.RBackValues = colorsPanel[i].BackColor.R;
                obj.GBackValues = colorsPanel[i].BackColor.G;
                obj.BBackValues = colorsPanel[i].BackColor.B;


                obj.RBannValues = banner[i].ForeColor.R;
                obj.GBannValues = banner[i].ForeColor.G;
                obj.BBannValues = banner[i].ForeColor.B;

                obj.RBoldValues = bold[i].ForeColor.R;
                obj.GBoldValues = bold[i].ForeColor.G;
                obj.BBoldValues = bold[i].ForeColor.B;

                obj.RNormValues = normal[i].ForeColor.R;
                obj.GNormValues = normal[i].ForeColor.G;
                obj.BNormValues = normal[i].ForeColor.B;

                obj.RButtBackValues = homeButt[i].BackColor.R;
                obj.GButtBackValues = homeButt[i].BackColor.G;
                obj.BButtBackValues = homeButt[i].BackColor.B;

                obj.RMainBackValues = colorsPanel2[i].BackColor.R;
                obj.GMainBackValues = colorsPanel2[i].BackColor.G;
                obj.BMainBackValues = colorsPanel2[i].BackColor.B;

                obj.RButtForeValues = homeButt[i].ForeColor.R;
                obj.GButtForeValues = homeButt[i].ForeColor.G;
                obj.BButtForeValues = homeButt[i].ForeColor.B;

                obj.name = colorsPanel[i].Name;

                allColorsArray.Add(obj);

               
               
            }
            //Aesthetic test is done here
            if (autoRun && randomGenPickCount < 12)
            {
                autoPick();
            }
            //Second Aesthetic test is done here if conditon satisfies
            if (runSecondAestheticTest && secondRandomGenPickCount < 12)
            {
                secondAutoPick();
            }
            
    
        }

        void Form1_CheckedChanged(object sender, EventArgs e)
        {
          //implementing checkbox for ranking
            CheckBox tmp = (CheckBox)sender;
            string imgtmp = tmp.Name;
            rankedColors item = new rankedColors();
            allColors colors;


            if (tmp.Checked == false)
            {
                //item.isSelected = false;
                colorSelected.Remove(item);
                manualRankCount = manualRankCount - 1;
                selected_colors = selected_colors - 1;
            }
            else
            {
                //colors = (allColors)allColorsArray[Convert.ToInt32(tmp.Name)];

               

                item.panelName = tmp.Name;


                colors = (allColors)allColorsArray[Convert.ToInt32(tmp.Name)];


                item.RBack = colors.RBackValues;
                item.GBack = colors.GBackValues;
                item.BBack = colors.BBackValues;


                item.RBann = colors.RBannValues;
                item.GBann = colors.GBannValues;
                item.BBann = colors.BBannValues;

                item.RBold = colors.RBoldValues;
                item.GBold = colors.GBoldValues;
                item.BBold = colors.BBoldValues;

                item.RNorm = colors.RNormValues;
                item.GNorm = colors.GNormValues;
                item.BNorm = colors.BNormValues;

                item.RButtBack = colors.RButtBackValues;
                item.GButtBack = colors.GButtBackValues;
                item.BButtBack = colors.BButtBackValues;

                item.RMainBack = colors.RMainBackValues;
                item.GMainBack = colors.GMainBackValues;
                item.BMainBack = colors.BMainBackValues;

                item.RButtFore = colors.RButtForeValues;
                item.GButtFore = colors.GButtForeValues;
                item.BButtFore = colors.BButtForeValues;


                colorSelected.Add(item);
                selected_colors = selected_colors + 1;

            }


        }

        void preview_click(object sender, EventArgs e)
        {
            string bodyColor = "";
            hexColorFormat colorConvert = new hexColorFormat();
            allColors allInOneColors;

            
            Color banner, bold, normal, back, mainBack, butt, buttFore;
            int index = 0;
            Button tmp = (Button)sender;

            index = Convert.ToInt32(tmp.Name);

            allInOneColors = (allColors)allColorsArray[index];

            banner = Color.FromArgb(allInOneColors.RBannValues, allInOneColors.GBannValues, allInOneColors.BBannValues);
            bold = Color.FromArgb(allInOneColors.RBoldValues, allInOneColors.GBoldValues, allInOneColors.BBoldValues);
            normal = Color.FromArgb(allInOneColors.RNormValues, allInOneColors.GNormValues, allInOneColors.BNormValues);
            back = Color.FromArgb(allInOneColors.RBackValues, allInOneColors.GBackValues, allInOneColors.BBackValues);
            mainBack = Color.FromArgb(allInOneColors.RMainBackValues, allInOneColors.GMainBackValues, allInOneColors.BMainBackValues);
            butt = Color.FromArgb(allInOneColors.RButtBackValues, allInOneColors.GButtBackValues, allInOneColors.BButtBackValues);
            buttFore = Color.FromArgb(allInOneColors.RButtForeValues, allInOneColors.GButtForeValues, allInOneColors.BButtForeValues);


            bodyColor = @""""+colorConvert.ColorToHexString(back)+"";
           
            
            //create html file here with all the colors that control panel is holding.
            string path = @"C:\ATGS\ColorContrastIGA\siteDemo\ColorTest\Styles\Site.css";

            // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(@""" body   { background: #"+colorConvert.ColorToHexString(mainBack)+"; font-size: .80em; margin: 0px;  padding: 0px;  color: #"+colorConvert.ColorToHexString(bold)+"; } ");
                    sw.WriteLine(" a:link, a:visited {     color: #034af3; } a:hover {    color: #"+colorConvert.ColorToHexString(mainBack)+";    text-decoration: none; } ");
                    sw.WriteLine(" a:active {    color: #"+ colorConvert.ColorToHexString(mainBack) + ";}p{    margin-bottom: 10px;    line-height: 1.6em;}  ");
                    sw.WriteLine(" h1, h2, h3, h4, h5, h6 {    font-size: 1.5em;    color: #" + colorConvert.ColorToHexString(bold) + ";    font-variant: small-caps;    text-transform: none;    font-weight: 200;    margin-bottom: 0px;}  ");
                    sw.WriteLine(" h1 {    font-size: 1.6em;    padding-bottom: 0px;    margin-bottom: 0px; } h2 {    font-size: 1.5em;    font-weight: 600; }  ");
                    sw.WriteLine(" h3 {    font-size: 1.2em;} h4{    font-size: 1.1em;} h5, h6{    font-size: 1em;} ");
                    sw.WriteLine(" .rightColumn > h1, .rightColumn > h2, .leftColumn > h1, .leftColumn > h2 {    margin-top: 0px;} ");
                    sw.WriteLine(" .page {    width: 960px;    background-color: #"+colorConvert.ColorToHexString(mainBack)+";    margin: 20px auto 0px auto;    border: 1px solid #"+colorConvert.ColorToHexString(mainBack)+";} ");
                    sw.WriteLine(" .header  {    position: relative;    margin: 0px;    padding: 0px;    background: #" + colorConvert.ColorToHexString(back) + ";    width: 100%;} ");
                    sw.WriteLine(" .header h1{    font-weight: 700;    margin: 0px;    padding: 0px 0px 0px 20px;    color: #"+colorConvert.ColorToHexString(banner)+";    border: none;    line-height: 2em;    font-size: 2em;} ");
                    sw.WriteLine(" .main{    padding: 0px 12px;    margin: 12px 8px 8px 8px;    min-height: 420px; color: #" + colorConvert.ColorToHexString(normal) + "} ");
                    sw.WriteLine(" .leftCol {    padding: 6px 0px;    margin: 12px 8px 8px 8px;    width: 200px;    min-height: 200px;} ");
                    sw.WriteLine(" .footer {    color: #4e5766;    padding: 8px 0px 0px 0px;    margin: 0px auto;    text-align: center;    line-height: normal;}  ");
                    sw.WriteLine(" div.hideSkiplink {    background-color:#" + colorConvert.ColorToHexString(back) + ";    width:100%;} ");
                    sw.WriteLine(" div.menu{    padding: 4px 0px 4px 8px;} div.menu ul{    list-style: none;    margin: 0px;    padding: 0px;    width: auto;} ");
                    sw.WriteLine(" div.menu ul li a, div.menu ul li a:visited {    background-color: #" + colorConvert.ColorToHexString(butt) + ";    border: 1px #4e667d solid;    color: #dde4ec;    display: block;    line-height: 1.35em;    padding: 4px 20px;    text-decoration: none;    white-space: nowrap; color: #" + colorConvert.ColorToHexString(buttFore) + "} ");
                    sw.WriteLine(" div.menu ul li a:hover {    background-color: #bfcbd6;    color: #465c71;    text-decoration: none;} ");
                    sw.WriteLine(" div.menu ul li a:active {    background-color: #465c71;    color: #cfdbe6;    text-decoration: none;} ");
                    sw.WriteLine(" fieldset {    margin: 1em 0px;    padding: 1em;    border: 1px solid #ccc;} ");
                    sw.WriteLine(" fieldset p {    margin: 2px 12px 10px 10px;} ");
                    sw.WriteLine(" fieldset.login label, fieldset.register label, fieldset.changePassword label {     display: block;} ");
                    sw.WriteLine(" fieldset label.inline  {     display: inline;} ");
                    sw.WriteLine(" legend {     font-size: 1.1em;    font-weight: 600;    padding: 2px 4px 8px 4px;} ");
                    sw.WriteLine("  input.textEntry  {     width: 320px;    border: 1px solid #ccc;}");
                    sw.WriteLine(" input.passwordEntry {    width: 320px;    border: 1px solid #ccc;}  ");
                    sw.WriteLine("div.accountInfo {    width: 42%;} ");
                    sw.WriteLine(".clear{    clear: both;} ");
                    sw.WriteLine(" .title{   display: block;    float: left;    text-align: left;    width: auto;}");
                    sw.WriteLine(" .loginDisplay{    font-size: 1.1em;    display: block;    text-align: right;    padding: 10px;    color: White;}");
                    sw.WriteLine(" .loginDisplay a:link{    color: white;}.loginDisplay a:visited{    color: white;}");
                    sw.WriteLine(" .loginDisplay a:hover {    color: white;}.failureNotification{    font-size: 1.2em;    color: Red;}");
                    sw.WriteLine(".bold {    font-weight: bold;}.submitButton{    text-align: right;    padding-right: 10px;} ");
                    
                    
                }


            System.Diagnostics.Process.Start("http://localhost:49282/ColorTest/About.aspx");
            
        }          

        private void mutationProb_Scroll(object sender, EventArgs e)
        {
            double inPercent = mutationProb.Value * 12.5;
            globals.MutProb = Convert.ToInt32(inPercent);
            showProb.Text = globals.mutProb.ToString() + "%";
        }

        private void crossoverProb_Scroll(object sender, EventArgs e)
        {
            double inPercent = crossoverProb.Value * 20;
            globals.CrossProb = Convert.ToInt32(inPercent);
            showCrossProb.Text = globals.crossProb.ToString() + "%";
        }

        private void generate_Click(object sender, EventArgs e)
        {
            if (selected_colors == 3)
            {
                engineGA.doCrossMut(colorSelected, allColorsArray);
                presentGeneration = presentGeneration + 1;
                refresh();
            }
            else
            {
                MessageBox.Show("Please Select 3 colors for ranking", "Error");
                refresh();
            }
        }

        private void gen_random_Click(object sender, EventArgs e)
        {
            genRandom = true;

            for (int i = 0; i < globals.newBackR.Length; i++)
            {
                if (!globals.lockButtBack)
                {
                    globals.NewButtbackR[i] = rnd.Next(0, 255);
                    globals.NewButtbackG[i] = rnd.Next(0, 255);
                    globals.NewButtbackB[i] = rnd.Next(0, 255);
                }

                if (!globals.lockBack)
                {
                    globals.NewBackR[i] = rnd.Next(0, 255);
                    globals.NewBackG[i] = rnd.Next(0, 255);
                    globals.NewBackB[i] = rnd.Next(0, 255);

                }

                if (!globals.lockBann)
                {
                    globals.NewBannR[i] = rnd.Next(0, 255);
                    globals.NewBannG[i] = rnd.Next(0, 255);
                    globals.NewBannB[i] = rnd.Next(0, 255);

                }
                if (!globals.lockBold)
                {
                    globals.NewBoldR[i] = rnd.Next(0, 255);
                    globals.NewBoldG[i] = rnd.Next(0, 255);
                    globals.NewBoldB[i] = rnd.Next(0, 255);
               
                }
                if (!globals.lockNorm)
                {
                    globals.NewNormR[i] = rnd.Next(0, 255);
                    globals.NewNormG[i] = rnd.Next(0, 255);
                    globals.NewNormB[i] = rnd.Next(0, 255);

                }

                if (!globals.lockMainBack)
                {
                    globals.NewMainbackR[i] = rnd.Next(0, 255);
                    globals.NewMainbackG[i] = rnd.Next(0, 255);
                    globals.NewMainbackB[i] = rnd.Next(0, 255);

                }

                if (!globals.lockButtFore)
                {
                    globals.NewButtForeR[i] = rnd.Next(0, 255);
                    globals.NewButtForeG[i] = rnd.Next(0, 255);
                    globals.NewButtForeB[i] = rnd.Next(0, 255);

                }
             }
            
            presentGeneration = 0;
            refresh();
        }

        private void refresh()
        {
            // refresh if error occured
            for (int i = 0; i < 12; i++)
            {
                Panel tmp = (Panel)colorsPanel[i];
                Panel tmp2 = (Panel)colorsPanel2[i];
                Panel aes = (Panel)infoPanel[i];
                Button homeB = (Button)homeButt[i];
                Button aboutB = (Button)aboutButt[i];
                Button contB = (Button)contactButt[i];


                Label bantemp = (Label)banner[i];
                Label boldtemp = (Label)bold[i];
                Label nortemp = (Label)normal[i];
                Label aesttemp = (Label)aestLabel[i];
                CheckBox tmpCheck = (CheckBox)checkboxes[i];

                this.Controls.Remove(tmpCheck);
                this.Controls.Remove(aes);
                this.Controls.Remove(tmp);
                this.Controls.Remove(bantemp);
                this.Controls.Remove(nortemp);
                this.Controls.Remove(boldtemp);
                this.Controls.Remove(aesttemp);
                this.Controls.Remove(tmp2);
                this.Controls.Remove(homeB);
                this.Controls.Remove(aboutB);
                this.Controls.Remove(contB);
                

            }

            posX = 20;
            posY = 50;
            selected_colors = 0;
            
            processLogic(presentGeneration);
            Application.DoEvents();
            
        }

        private void crossoverProb_Scroll_1(object sender, EventArgs e)
        {
            double inPercent = crossoverProb.Value * 20;
            globals.CrossProb = Convert.ToInt32(inPercent);
            showCrossProb.Text = globals.crossProb.ToString() + "%";
        }     

        private void updateButt_Click(object sender, EventArgs e)
        {
          refresh();
        }

        private void autoAesthetic_Click(object sender, EventArgs e)
        {
            runSecondAestheticTest = false;
            randomGenPickCount = 0;
                  
            //send user out of this statement, if background color is selected
            if (globals.LockBack || backColorTrigger)
            {
                bestPicked = new ArrayList();
                autoRun = true;
                //this refresh is to randomise 12 times and find the bestpicked values into arrays
                refresh();
               
                // do crossover and mutation for the newly generated arraylist

                //inject best picked banner colors into allColors arraylist
                                              

                inject.injectBannerColors(bestPicked);
                //insert best picked into generations
               
               //injecting best picked main back ground colors
                inject.injectMainBackColors(bestPicked);

                //injecting best picked buttons back ground colors
                inject.injectButtbackColors(bestPicked);

                refresh();


                //perform crossover and muation for banner here 
                
                //load best ranked of banner colors into ranked array list
                

                //ranked and initial array has values now.. just implement the crossover and muation for x times in a loop.
                
                //for banner color evoluation
                if (!globals.LockBann)
                {
                    for (int i = 0; i < 6; i++)
                    {

                        //this.toolStripStatusLabel1.Text = "Applying Crossover + Mutation on (Banner Colors) " + i + "";
                        findBannerRankedColors();
                        aesCrossMutt.doBannerCrossMutt(colorSelected, allColorsArray);
                        refresh();
                    }
                }
                

      
                //for main back color evoluation
                if (!globals.LockMainBack)
                {
                    for (int i = 0; i < 6; i++)
                    {

                        //this.toolStripStatusLabel1.Text = "Applying Crossover + Mutation on (Main Text Area) " + i + "";

                        findMainBackRankedColors();
                        aesCrossMutt.doMainBackCrossMutt(colorSelected, allColorsArray);
                        refresh();

                    }
                }
                


             //for normal buttons color evoluation
                if (!globals.LockButtBack)
                {
                    for (int i = 0; i < 6; i++)
                    {

                       // this.toolStripStatusLabel1.Text = "Applying Crossover + Mutation on (Buttons Colors) " + i + "";


                        findButtbackRankedColors();
                        aesCrossMutt.doButtbackCrossMutt(colorSelected, allColorsArray);
                        refresh();
                    }
                }
                
    
                statusStrip1.Text = "Displayed are the final results.";
                this.toolStripStatusLabel1.Text = "Displayed are the final results.";

                //For loop will be usually as user specifies to run number of loops.
                
                //activate for second process of finsing the best text and bold colors
                secondAestheticTest();


            }
            else
            {
                //display message here
                MessageBox.Show("Please Select 1 Image to lock preffered Background Color before starting Aesthetic Measure search", "Error");
                refresh();
            }
        }

        public void secondAestheticTest()
        {
            secondRandomGenPickCount = 0;
            runSecondAestheticTest = true;
            bestPicked.Clear();
            //get the best mainBackground color and store in variable secondBackColor and find the best ranked text and bold colors over it.


            //IF maintext background area is not locked manually
            if(!globals.LockMainBack)
            {
                secondBackColor = findBestMainBackColor();

                for (int i = 0; i < totalColors; i++)
                {
                    globals.NewMainbackR[i] = secondBackColor.R;
                    globals.NewMainbackG[i] = secondBackColor.G;
                    globals.NewMainbackB[i] = secondBackColor.B;
                }
            }

            if (!globals.LockButtBack)
            {
                buttonBackColor = findBestButtBackColor();

                for (int i = 0; i < totalColors; i++)
                {
                    globals.NewButtbackR[i] = buttonBackColor.R;
                    globals.NewButtbackG[i] = buttonBackColor.G;
                    globals.NewButtbackB[i] = buttonBackColor.B;
                }
            }
            

            //find the best matching colors 
            refresh();

            inject.injectBoldColors(bestPicked);

            inject.injectNormalColors(bestPicked);

            inject.injectForeButtbackColors(bestPicked);

            refresh();

            //apply crossover and muation over bold letters
            if (!globals.LockBold)
            {
                for (int i = 0; i < 6; i++)
                {

                    //this.toolStripStatusLabel1.Text = "Applying Crossover + Mutation on (Bold Colors) " + i + "";

                    findBoldRankedColors();
                    aesCrossMutt.doBoldCrossMutt(colorSelected, allColorsArray);
                    refresh();

                }
            }

            //apply crossover and muation over normal text colors
            if (!globals.LockNorm)
            {
                for (int i = 0; i < 6; i++)
                {

                    //this.toolStripStatusLabel1.Text = "Applying Crossover + Mutation on (Text Colors) " + i + "";

                    findNormalRankedColors();
                    aesCrossMutt.doNormalCrossMutt(colorSelected, allColorsArray);
                    refresh();
                }


            }

            if (!globals.LockButtFore)
            {
                for (int i = 0; i < 6; i++)
                {

                   // this.toolStripStatusLabel1.Text = "Applying Crossover + Mutation on (Button Fore Colors) " + i + "";

                    findButtforeRankedColors();
                    aesCrossMutt.doButtforeCrossMutt(colorSelected, allColorsArray);
                    refresh();

                }
            }

           // this.toolStripStatusLabel1.Text = "Displayed are the final results.";

            //activate for third process of finsing the best text and bold colors
            //  thirdAestheticTest();


        }

        public Color findBestMainBackColor()
        {
            allColors colors;
            Color bestBackColor;

            colors = (allColors)allColorsArray[bestBackMainColor];
            bestBackColor = Color.FromArgb(colors.RMainBackValues, colors.GMainBackValues, colors.BMainBackValues);
                      

            return bestBackColor;
        }

        public Color findBestButtBackColor()
        {
            allColors colors;
            Color bestBackColor;

            colors = (allColors)allColorsArray[bestButtonBackColor];
            bestBackColor = Color.FromArgb(colors.RButtBackValues, colors.GButtBackValues, colors.BButtBackValues);


            return bestBackColor;
        }

        public void autoPick()
        {
            allColors colors, BannerRankedColor, BoldRankedColor, NormRankedColor, ButtonbackColor, MainbackColor;
            int[] bannerRanks = new int[12];
            //int[] boldRanks = new int[12];
           // int[] normalRanks = new int[12];
            int[] buttbackRanks = new int[12];
            int[] mainbackRanks = new int[12];

            //check aesthetic test

            for (int i = 0; i < bannerRanks.Length; i++)
            {
                colors = (allColors)allColorsArray[i];
                bannerRanks[i] = getResults.getPercentage(getResults.checkContrast(backColor, Color.FromArgb(colors.RBannValues, colors.GBannValues, colors.BBannValues)));
                //boldRanks[i] = getResults.getPercentage(getResults.checkContrast(backColor, Color.FromArgb(colors.RBoldValues, colors.GBoldValues, colors.BBoldValues)));
                //normalRanks[i] = getResults.getPercentage(getResults.checkContrast(backColor, Color.FromArgb(colors.RNormValues, colors.GNormValues, colors.BNormValues)));
                buttbackRanks[i] = getResults.getPercentage(getResults.checkContrast(backColor, Color.FromArgb(colors.RButtBackValues, colors.GButtBackValues, colors.BButtBackValues)));
                mainbackRanks[i] = getResults.getPercentage(getResults.checkContrast(backColor, Color.FromArgb(colors.RMainBackValues, colors.GMainBackValues, colors.BMainBackValues)));

            }

            int maxBann = 0, maxBold = 0, maxNor = 0, maxButt = 0, maxMainback = 0;
            Application.DoEvents();

            for (int i = 0; i < bannerRanks.Length; i++)
            {
                //checking the maxvalue index to find out the best banner color match
                if (bannerRanks[i] > bannerRanks[maxBann])
                {
                    maxBann = i;
                }
               
                if (buttbackRanks[i] > buttbackRanks[maxButt])
                {
                    maxButt = i;
                }
                if (mainbackRanks[i] > mainbackRanks[maxMainback])
                {
                    maxMainback = i;
                }

            }

            //this is to find the best main background area which will be used in next aesthetic measure test
            bestBackMainColor = maxMainback;
            bestButtonBackColor = maxButt;

            bestPickedColors item = new bestPickedColors();

            BannerRankedColor = (allColors)allColorsArray[maxBann];
            item.bannerColors = Color.FromArgb(BannerRankedColor.RBannValues, BannerRankedColor.GBannValues, BannerRankedColor.BBannValues);

            ButtonbackColor = (allColors)allColorsArray[maxButt];
            item.buttBackColors = Color.FromArgb(ButtonbackColor.RButtBackValues, ButtonbackColor.GButtBackValues, ButtonbackColor.BButtBackValues);

            MainbackColor = (allColors)allColorsArray[maxMainback];
            item.mainBackColors = Color.FromArgb(MainbackColor.RMainBackValues, MainbackColor.GMainBackValues, MainbackColor.BMainBackValues);

            item.name = randomGenPickCount.ToString();
            bestPicked.Add(item);

            randomGenPickCount = randomGenPickCount + 1;
            //statusStrip1.Text = "Randomly Search applied " + randomGenPickCount + "";
           // this.toolStripStatusLabel1.Text = "Random Search " + randomGenPickCount + "";
            presentGeneration = 0;

            if (randomGenPickCount < 12)
            {
                //randomise all colors
                for (int i = 0; i < globals.newBackR.Length; i++)
                {
                    if (!globals.LockBann)
                    {
                        globals.NewBannR[i] = rnd.Next(0, 255);
                        globals.NewBannG[i] = rnd.Next(0, 255);
                        globals.NewBannB[i] = rnd.Next(0, 255);

                    }

                   if (!globals.LockButtBack)
                    {
                        globals.NewButtbackR[i] = rnd.Next(0, 255);
                        globals.NewButtbackG[i] = rnd.Next(0, 255);
                        globals.NewButtbackB[i] = rnd.Next(0, 255);
                    }

                    if (!globals.LockMainBack)
                    {
                        globals.NewMainbackR[i] = rnd.Next(0, 255);
                        globals.NewMainbackG[i] = rnd.Next(0, 255);
                        globals.NewMainbackB[i] = rnd.Next(0, 255);
                    }
       
                }
            
            }
           refresh();

        }

        public void secondAutoPick()
        {

            allColors colors, BoldRankedColor, NormRankedColor, ForeRankedColor;
            int[] boldRanks = new int[12];
            int[] normalRanks = new int[12];
            int[] foreRanks = new int[12];

            //check aesthetic test

            for (int i = 0; i < boldRanks.Length; i++)
            {
                colors = (allColors)allColorsArray[i];
                boldRanks[i] = getResults.getPercentage(getResults.checkContrast(secondBackColor, Color.FromArgb(colors.RBoldValues, colors.GBoldValues, colors.BBoldValues)));
                normalRanks[i] = getResults.getPercentage(getResults.checkContrast(secondBackColor, Color.FromArgb(colors.RNormValues, colors.GNormValues, colors.BNormValues)));
                foreRanks[i] = getResults.getPercentage(getResults.checkContrast(buttonBackColor, Color.FromArgb(colors.RButtForeValues, colors.GButtForeValues, colors.BButtForeValues)));
            }

            int maxBold = 0, maxNor = 0, maxFore = 0;
            Application.DoEvents();

            for (int i = 0; i < boldRanks.Length; i++)
            {
                //checking the maxvalue index to find out the best banner color match
                if (boldRanks[i] > boldRanks[maxBold])
                {
                    maxBold = i;
                }
                if (normalRanks[i] > normalRanks[maxNor])
                {
                    maxNor = i;
                }
                if (foreRanks[i] > foreRanks[maxFore])
                {
                    maxFore = i;
                }
                
            }

            bestPickedColors item = new bestPickedColors();


            BoldRankedColor = (allColors)allColorsArray[maxBold];
            item.boldColors = Color.FromArgb(BoldRankedColor.RBoldValues, BoldRankedColor.GBoldValues, BoldRankedColor.BBoldValues);

            NormRankedColor = (allColors)allColorsArray[maxNor];
            item.normalColors = Color.FromArgb(NormRankedColor.RNormValues, NormRankedColor.GNormValues, NormRankedColor.BNormValues);

            ForeRankedColor = (allColors)allColorsArray[maxFore];
            item.buttForeColors = Color.FromArgb(ForeRankedColor.RButtForeValues, ForeRankedColor.GButtForeValues, ForeRankedColor.BButtForeValues);
          

            item.name = secondRandomGenPickCount.ToString();
            bestPicked.Add(item);

            secondRandomGenPickCount = secondRandomGenPickCount + 1;
            //statusStrip1.Text = "Randomly Search applied " + secondRandomGenPickCount + "";
           // this.toolStripStatusLabel1.Text = "Random Search " + secondRandomGenPickCount + "";
            presentGeneration = 0;

            if (secondRandomGenPickCount < 12)
            {
                //randomise all colors
                for (int i = 0; i < globals.newBackR.Length; i++)
                {

                    if (!globals.LockBold)
                    {
                        globals.NewBoldR[i] = rnd.Next(0, 255);
                        globals.NewBoldG[i] = rnd.Next(0, 255);
                        globals.NewBoldB[i] = rnd.Next(0, 255);
                    }

                    if (!globals.LockNorm)
                    {
                        globals.NewNormR[i] = rnd.Next(0, 255);
                        globals.NewNormG[i] = rnd.Next(0, 255);
                        globals.NewNormB[i] = rnd.Next(0, 255);
                    }

                    if (!globals.LockButtFore)
                    {
                        globals.NewButtForeR[i] = rnd.Next(0, 255);
                        globals.NewButtForeG[i] = rnd.Next(0, 255);
                        globals.NewButtForeB[i] = rnd.Next(0, 255);
                    }
                    
                }

            }

            refresh();
        }

        private void findBannerRankedColors()
        {
            allColors colors, BannerRankedColor1, BannerRankedColor2, BannerRankedColor3;
            int[] bannerRanks = new int[12];

            for (int i = 0; i < bannerRanks.Length; i++)
            {
                colors = (allColors)allColorsArray[i];
                bannerRanks[i] = getResults.getPercentage(getResults.checkContrast(backColor, Color.FromArgb(colors.RBannValues, colors.GBannValues, colors.BBannValues)));
            }

            int rank1 = 0, rank2 = 0, rank3 = 0;

            for (int i = 0; i < bannerRanks.Length; i++)
            {
                //checking the maxvalue index to find out the best banner color match
                if (bannerRanks[i] > bannerRanks[rank1])
                {
                    rank1 = i;
                }
            }

            for (int i = 0; i < bannerRanks.Length; i++)
            {
                //checking the maxvalue index to find out the best banner color match
                if (bannerRanks[i] > bannerRanks[rank2])
                {
                    if (i != rank1)
                    {
                        rank2 = i;
                    }
                    
                }
            }

            for (int i = 0; i < bannerRanks.Length; i++)
            {
                //checking the maxvalue index to find out the best banner color match
                if (bannerRanks[i] > bannerRanks[rank3])
                {
                    if (i != rank1  && i != rank2)
                    {
                        rank3 = i;
                    }

                }
            }
                        
            rankedColors item1 = new rankedColors();
            rankedColors item2 = new rankedColors();
            rankedColors item3 = new rankedColors();

            BannerRankedColor1 = (allColors)allColorsArray[rank1];
            item1.RBann = BannerRankedColor1.RBannValues;
            item1.GBann = BannerRankedColor1.GBannValues;
            item1.BBann = BannerRankedColor1.BBannValues;        
            item1.panelName = BannerRankedColor1.name;
            colorSelected.Add(item1);

            BannerRankedColor2 = (allColors)allColorsArray[rank2];
            item2.RBann = BannerRankedColor2.RBannValues;
            item2.GBann = BannerRankedColor2.GBannValues;
            item2.BBann = BannerRankedColor2.BBannValues;
            item2.panelName = BannerRankedColor2.name;
            colorSelected.Add(item2);

            BannerRankedColor3 = (allColors)allColorsArray[rank3];
            item3.RBann = BannerRankedColor3.RBannValues;
            item3.GBann = BannerRankedColor3.GBannValues;
            item3.BBann = BannerRankedColor3.BBannValues;
            item3.panelName = BannerRankedColor3.name;
            colorSelected.Add(item3);


        }

        private void findBoldRankedColors()
        {
            allColors colors, BoldRankedColor1, BoldRankedColor2, BoldRankedColor3;
            int[] boldRanks = new int[12];

            for (int i = 0; i < boldRanks.Length; i++)
            {
                colors = (allColors)allColorsArray[i];
                boldRanks[i] = getResults.getPercentage(getResults.checkContrast(secondBackColor, Color.FromArgb(colors.RBoldValues, colors.GBoldValues, colors.BBoldValues)));
            }

            int rank1 = 0, rank2 = 0, rank3 = 0;

            for (int i = 0; i < boldRanks.Length; i++)
            {
                //checking the maxvalue index to find out the best banner color match
                if (boldRanks[i] > boldRanks[rank1])
                {
                    rank1 = i;
                }
            }

            for (int i = 0; i < boldRanks.Length; i++)
            {
                //checking the maxvalue index to find out the best banner color match
                if (boldRanks[i] > boldRanks[rank2])
                {
                    if (i != rank1)
                    {
                        rank2 = i;
                    }

                }
            }

            for (int i = 0; i < boldRanks.Length; i++)
            {
                //checking the maxvalue index to find out the best banner color match
                if (boldRanks[i] > boldRanks[rank3])
                {
                    if (i != rank1 && i != rank2)
                    {
                        rank3 = i;
                    }

                }
            }

            rankedColors item1 = new rankedColors();
            rankedColors item2 = new rankedColors();
            rankedColors item3 = new rankedColors();

            BoldRankedColor1 = (allColors)allColorsArray[rank1];
            item1.RBold = BoldRankedColor1.RBoldValues;
            item1.GBold = BoldRankedColor1.GBoldValues;
            item1.BBold = BoldRankedColor1.BBoldValues;
            item1.panelName = BoldRankedColor1.name;
            colorSelected.Add(item1);

            BoldRankedColor2 = (allColors)allColorsArray[rank2];
            item2.RBold = BoldRankedColor2.RBoldValues;
            item2.GBold = BoldRankedColor2.GBoldValues;
            item2.BBold = BoldRankedColor2.BBoldValues;
            item2.panelName = BoldRankedColor2.name;
            colorSelected.Add(item2);

            BoldRankedColor3 = (allColors)allColorsArray[rank3];
            item3.RBold = BoldRankedColor3.RBoldValues;
            item3.GBold = BoldRankedColor3.GBoldValues;
            item3.BBold = BoldRankedColor3.BBoldValues;
            item3.panelName = BoldRankedColor3.name;
            colorSelected.Add(item3);


        }

        private void findMainBackRankedColors()
        {
            allColors colors, MainbackRankedColor1, MainBackRankedColor2, MainBackRankedColor3;
            int[] mainBackRanks = new int[12];

            for (int i = 0; i < mainBackRanks.Length; i++)
            {
                colors = (allColors)allColorsArray[i];
                mainBackRanks[i] = getResults.getPercentage(getResults.checkContrast(backColor, Color.FromArgb(colors.RMainBackValues, colors.GMainBackValues, colors.BMainBackValues)));
            }

            int rank1 = 0, rank2 = 0, rank3 = 0;

            for (int i = 0; i < mainBackRanks.Length; i++)
            {
                //checking the maxvalue index to find out the best banner color match
                if (mainBackRanks[i] > mainBackRanks[rank1])
                {
                    rank1 = i;
                }
            }

            for (int i = 0; i < mainBackRanks.Length; i++)
            {
                //checking the maxvalue index to find out the best banner color match
                if (mainBackRanks[i] > mainBackRanks[rank2])
                {
                    if (i != rank1)
                    {
                        rank2 = i;
                    }

                }
            }

            for (int i = 0; i < mainBackRanks.Length; i++)
            {
                //checking the maxvalue index to find out the best banner color match
                if (mainBackRanks[i] > mainBackRanks[rank3])
                {
                    if (i != rank1 && i != rank2)
                    {
                        rank3 = i;
                    }

                }
            }

            rankedColors item1 = new rankedColors();
            rankedColors item2 = new rankedColors();
            rankedColors item3 = new rankedColors();

            MainbackRankedColor1 = (allColors)allColorsArray[rank1];
            item1.RMainBack = MainbackRankedColor1.RMainBackValues;
            item1.GMainBack = MainbackRankedColor1.GMainBackValues;
            item1.BMainBack = MainbackRankedColor1.BMainBackValues;
            item1.panelName = MainbackRankedColor1.name;
            colorSelected.Add(item1);

            MainBackRankedColor2 = (allColors)allColorsArray[rank2];
            item2.RMainBack = MainBackRankedColor2.RMainBackValues;
            item2.GMainBack = MainBackRankedColor2.GMainBackValues;
            item2.BMainBack = MainBackRankedColor2.BMainBackValues;
            item2.panelName = MainBackRankedColor2.name;
            colorSelected.Add(item2);

            MainBackRankedColor3 = (allColors)allColorsArray[rank3];
            item3.RMainBack = MainBackRankedColor3.RMainBackValues;
            item3.GMainBack = MainBackRankedColor3.GMainBackValues;
            item3.BMainBack = MainBackRankedColor3.BMainBackValues;
            item3.panelName = MainBackRankedColor3.name;
            colorSelected.Add(item3);


        }

        private void findNormalRankedColors()
        {
            allColors colors, NormalRankedColor1, NormalRankedColor2, NormalRankedColor3;
            int[] normalRanks = new int[12];

            for (int i = 0; i < normalRanks.Length; i++)
            {
                colors = (allColors)allColorsArray[i];
                normalRanks[i] = getResults.getPercentage(getResults.checkContrast(secondBackColor, Color.FromArgb(colors.RNormValues, colors.GNormValues, colors.BNormValues)));
            }

            int rank1 = 0, rank2 = 0, rank3 = 0;

            for (int i = 0; i < normalRanks.Length; i++)
            {
                //checking the maxvalue index to find out the best banner color match
                if (normalRanks[i] > normalRanks[rank1])
                {
                    rank1 = i;
                }
            }

            for (int i = 0; i < normalRanks.Length; i++)
            {
                //checking the maxvalue index to find out the best banner color match
                if (normalRanks[i] > normalRanks[rank2])
                {
                    if (i != rank1)
                    {
                        rank2 = i;
                    }

                }
            }

            for (int i = 0; i < normalRanks.Length; i++)
            {
                //checking the maxvalue index to find out the best banner color match
                if (normalRanks[i] > normalRanks[rank3])
                {
                    if (i != rank1 && i != rank2)
                    {
                        rank3 = i;
                    }

                }
            }

            rankedColors item1 = new rankedColors();
            rankedColors item2 = new rankedColors();
            rankedColors item3 = new rankedColors();

            NormalRankedColor1 = (allColors)allColorsArray[rank1];
            item1.RNorm = NormalRankedColor1.RNormValues;
            item1.GNorm = NormalRankedColor1.GNormValues;
            item1.BNorm = NormalRankedColor1.BNormValues;
            item1.panelName = NormalRankedColor1.name;
            colorSelected.Add(item1);

            NormalRankedColor2 = (allColors)allColorsArray[rank2];
            item2.RNorm = NormalRankedColor2.RNormValues;
            item2.GNorm = NormalRankedColor2.GNormValues;
            item2.BNorm = NormalRankedColor2.BNormValues;
            item2.panelName = NormalRankedColor2.name;
            colorSelected.Add(item2);

            NormalRankedColor3 = (allColors)allColorsArray[rank3];
            item3.RNorm = NormalRankedColor3.RNormValues;
            item3.GNorm = NormalRankedColor3.GNormValues;
            item3.BNorm = NormalRankedColor3.BNormValues;
            item3.panelName = NormalRankedColor3.name;
            colorSelected.Add(item3);


        }

        private void findButtbackRankedColors()
        {
            allColors colors, ButtbackRankedColor1, ButtbackRankedColor2, ButtbackRankedColor3;
            int[] buttBackRanks = new int[12];

            for (int i = 0; i < buttBackRanks.Length; i++)
            {
                colors = (allColors)allColorsArray[i];
                buttBackRanks[i] = getResults.getPercentage(getResults.checkContrast(backColor, Color.FromArgb(colors.RButtBackValues, colors.GButtBackValues, colors.BButtBackValues)));
            }

            int rank1 = 0, rank2 = 0, rank3 = 0;

            for (int i = 0; i < buttBackRanks.Length; i++)
            {
                //checking the maxvalue index to find out the best banner color match
                if (buttBackRanks[i] > buttBackRanks[rank1])
                {
                    rank1 = i;
                }
            }

            for (int i = 0; i < buttBackRanks.Length; i++)
            {
                //checking the maxvalue index to find out the best banner color match
                if (buttBackRanks[i] > buttBackRanks[rank2])
                {
                    if (i != rank1)
                    {
                        rank2 = i;
                    }

                }
            }

            for (int i = 0; i < buttBackRanks.Length; i++)
            {
                //checking the maxvalue index to find out the best banner color match
                if (buttBackRanks[i] > buttBackRanks[rank3])
                {
                    if (i != rank1 && i != rank2)
                    {
                        rank3 = i;
                    }

                }
            }

            rankedColors item1 = new rankedColors();
            rankedColors item2 = new rankedColors();
            rankedColors item3 = new rankedColors();

            ButtbackRankedColor1 = (allColors)allColorsArray[rank1];
            item1.RButtBack = ButtbackRankedColor1.RButtBackValues;
            item1.GButtBack = ButtbackRankedColor1.GButtBackValues;
            item1.BButtBack = ButtbackRankedColor1.BButtBackValues;
            item1.panelName = ButtbackRankedColor1.name;
            colorSelected.Add(item1);

            ButtbackRankedColor2 = (allColors)allColorsArray[rank2];
            item2.RButtBack = ButtbackRankedColor2.RButtBackValues;
            item2.GButtBack = ButtbackRankedColor2.GButtBackValues;
            item2.BButtBack = ButtbackRankedColor2.BButtBackValues;
            item2.panelName = ButtbackRankedColor2.name;
            colorSelected.Add(item2);

            ButtbackRankedColor3 = (allColors)allColorsArray[rank3];
            item3.RButtBack = ButtbackRankedColor3.RButtBackValues;
            item3.GButtBack = ButtbackRankedColor3.GButtBackValues;
            item3.BButtBack = ButtbackRankedColor3.BButtBackValues;
            item3.panelName = ButtbackRankedColor3.name;
            colorSelected.Add(item3);
        }

        private void findButtforeRankedColors()
        {
            allColors colors, ButtforeRankedColor1, ButtforeRankedColor2, ButtforeRankedColor3;
            int[] buttForeRanks = new int[12];

            for (int i = 0; i < buttForeRanks.Length; i++)
            {
                colors = (allColors)allColorsArray[i];
                buttForeRanks[i] = getResults.getPercentage(getResults.checkContrast(buttonBackColor, Color.FromArgb(colors.RButtForeValues, colors.GButtForeValues, colors.BButtForeValues)));
            }

            int rank1 = 0, rank2 = 0, rank3 = 0;

            for (int i = 0; i < buttForeRanks.Length; i++)
            {
                //checking the maxvalue index to find out the best banner color match
                if (buttForeRanks[i] > buttForeRanks[rank1])
                {
                    rank1 = i;
                }
            }

            for (int i = 0; i < buttForeRanks.Length; i++)
            {
                //checking the maxvalue index to find out the best banner color match
                if (buttForeRanks[i] > buttForeRanks[rank2])
                {
                    if (i != rank1)
                    {
                        rank2 = i;
                    }

                }
            }

            for (int i = 0; i < buttForeRanks.Length; i++)
            {
                //checking the maxvalue index to find out the best banner color match
                if (buttForeRanks[i] > buttForeRanks[rank3])
                {
                    if (i != rank1 && i != rank2)
                    {
                        rank3 = i;
                    }

                }
            }

            rankedColors item1 = new rankedColors();
            rankedColors item2 = new rankedColors();
            rankedColors item3 = new rankedColors();

            ButtforeRankedColor1 = (allColors)allColorsArray[rank1];
            item1.RButtFore = ButtforeRankedColor1.RButtForeValues;
            item1.GButtFore = ButtforeRankedColor1.GButtForeValues;
            item1.BButtFore = ButtforeRankedColor1.BButtForeValues;
            item1.panelName = ButtforeRankedColor1.name;
            colorSelected.Add(item1);

            ButtforeRankedColor2 = (allColors)allColorsArray[rank2];
            item2.RButtFore = ButtforeRankedColor2.RButtForeValues;
            item2.GButtFore = ButtforeRankedColor2.GButtForeValues;
            item2.BButtFore = ButtforeRankedColor2.BButtForeValues;
            item2.panelName = ButtforeRankedColor2.name;
            colorSelected.Add(item2);

            ButtforeRankedColor3 = (allColors)allColorsArray[rank3];
            item3.RButtFore = ButtforeRankedColor3.RButtForeValues;
            item3.GButtFore = ButtforeRankedColor3.GButtForeValues;
            item3.BButtFore = ButtforeRankedColor3.BButtForeValues;
            item3.panelName = ButtforeRankedColor3.name;
            colorSelected.Add(item3);
        }

        //all checkbox click functions
     
        private void buttBackCheck_CheckedChanged_1(object sender, EventArgs e)
        {
            if (backButtonTrigger)
            {
                backButtonTrigger = false;
            }
            else
            {
                rankedColors checkedColor;
                CheckBox tmp = (CheckBox)sender;

                if (tmp.Checked == true)
                {
                    if (selected_colors == 1)
                    {
                        checkedColor = (rankedColors)colorSelected[0];
                        globals.lockButtBack = true;
                        for (int i = 0; i < totalColors; i++)
                        {
                            globals.newButtbackR[i] = checkedColor.RButtBack;
                            globals.newButtbackG[i] = checkedColor.GButtBack;
                            globals.newButtbackB[i] = checkedColor.BButtBack;
                        }

                        this.buttBackButton.BackColor = Color.FromArgb(checkedColor.RButtBack, checkedColor.GButtBack, checkedColor.BButtBack);

                        refresh();
                    }
                    else
                    {
                        //display message here
                        MessageBox.Show("Please Select 1 Image to lock Back Color of Buttons", "Error");
                        this.buttBackButton.BackColor = System.Drawing.SystemColors.ButtonFace;
                        tmp.Checked = false;
                    }
                }
                else
                {
                    this.buttBackButton.BackColor = System.Drawing.SystemColors.ButtonFace;
                    buttBackCheck.Checked = false;
                    globals.LockButtBack = false;
                    backButtonTriggerCount = 0;
                    refresh();
                }
            }
            
        }

        private void backCheck_CheckedChanged_1(object sender, EventArgs e)
        {
            if (backColorTrigger)
            {
                backColorTrigger = false;
            }
            else
            {
                rankedColors checkedColor;
                CheckBox tmp = (CheckBox)sender;

                if (tmp.Checked == true)
                {
                    if (selected_colors == 1)
                    {
                        checkedColor = (rankedColors)colorSelected[0];
                        globals.LockBack = true;
                        for (int i = 0; i < totalColors; i++)
                        {
                            globals.NewBackR[i] = checkedColor.RBack;
                            globals.NewBackG[i] = checkedColor.GBack;
                            globals.NewBackB[i] = checkedColor.BBack;
                        }

                        this.BackBut.BackColor = Color.FromArgb(checkedColor.RBack, checkedColor.GBack, checkedColor.BBack);
                        

                        refresh();
                    }
                    else
                    {
                        //display message here
                        MessageBox.Show("Please Select 1 Image to lock Back Color of Buttons", "Error");
                        this.BackBut.BackColor = System.Drawing.SystemColors.ButtonFace;
                        tmp.Checked = false;
                    }
                }
                else
                {
                    this.BackBut.BackColor = System.Drawing.SystemColors.ButtonFace;
                    backCheck.Checked = false;
                    imageSelected = false;
                    globals.LockBack = false;
                    backColorTriggerCount = 0;
                    refresh();
                }
            }
        }

        private void bannCheck_CheckedChanged_1(object sender, EventArgs e)
        {
            if (bannerTrigger)
            {
                bannerTrigger = false;
            }
            else
            {
                rankedColors checkedColor;
                CheckBox tmp = (CheckBox)sender;

                if (tmp.Checked == true)
                {
                    if (selected_colors == 1)
                    {
                        checkedColor = (rankedColors)colorSelected[0];
                        globals.LockBann = true;
                        for (int i = 0; i < totalColors; i++)
                        {
                            globals.NewBannR[i] = checkedColor.RBann;
                            globals.NewBannG[i] = checkedColor.GBann;
                            globals.NewBannB[i] = checkedColor.BBann;
                        }

                        this.banBackButton.BackColor = Color.FromArgb(checkedColor.RBann, checkedColor.GBann, checkedColor.BBann);

                        refresh();
                    }
                    else
                    {
                        //display message here
                        MessageBox.Show("Please Select 1 Image to lock Back Color of Buttons", "Error");
                        this.banBackButton.BackColor = System.Drawing.SystemColors.ButtonFace;
                        tmp.Checked = false;
                    }
                }
                else
                {
                    this.banBackButton.BackColor = System.Drawing.SystemColors.ButtonFace;
                    bannCheck.Checked = false;
                    globals.LockBann = false;
                    bannerTriggerCount = 0;
                    refresh();
                }
            }

        }

        private void boldCheck_CheckedChanged_1(object sender, EventArgs e)
        {
            if (boldTrigger)
            {
                boldTrigger = false;
            }
            else
            {
                rankedColors checkedColor;
                CheckBox tmp = (CheckBox)sender;

                if (tmp.Checked == true)
                {
                    if (selected_colors == 1)
                    {
                        checkedColor = (rankedColors)colorSelected[0];
                        globals.LockBold = true;
                        for (int i = 0; i < totalColors; i++)
                        {
                            globals.newBoldR[i] = checkedColor.RBold;
                            globals.newBoldG[i] = checkedColor.GBold;
                            globals.newBoldB[i] = checkedColor.BBold;
                        }

                        this.boldButton.BackColor = Color.FromArgb(checkedColor.RBold, checkedColor.GBold, checkedColor.BBold);

                        refresh();
                    }
                    else
                    {
                        //display message here
                        MessageBox.Show("Please Select 1 Image to lock Back Color of Buttons", "Error");
                        this.boldButton.BackColor = System.Drawing.SystemColors.ButtonFace;
                        tmp.Checked = false;
                    }
                }
                else
                {
                    this.boldButton.BackColor = System.Drawing.SystemColors.ButtonFace;
                    boldCheck.Checked = false;
                    globals.LockBold = false;
                    boldTriggerCount = 0;
                    refresh();
                }
            }
            
        }

        private void normCheck_CheckedChanged_1(object sender, EventArgs e)
        {
            if (normalTextTrigger)
            {
                normalTextTrigger = false;
            }
            else
            {
                rankedColors checkedColor;
                CheckBox tmp = (CheckBox)sender;

                if (tmp.Checked == true)
                {
                    if (selected_colors == 1)
                    {
                        checkedColor = (rankedColors)colorSelected[0];
                        globals.LockNorm = true;
                        for (int i = 0; i < totalColors; i++)
                        {
                            globals.NewNormR[i] = checkedColor.RNorm;
                            globals.NewNormG[i] = checkedColor.GNorm;
                            globals.NewNormB[i] = checkedColor.BNorm;
                        }

                        this.normalButton.BackColor = Color.FromArgb(checkedColor.RNorm, checkedColor.GNorm, checkedColor.BNorm);

                        refresh();
                    }
                    else
                    {
                        //display message here
                        MessageBox.Show("Please Select 1 Image to lock Back Color of Buttons", "Error");
                        this.normalButton.BackColor = System.Drawing.SystemColors.ButtonFace;
                        tmp.Checked = false;
                    }
                }
                else
                {
                    this.normalButton.BackColor = System.Drawing.SystemColors.ButtonFace;
                    normCheck.Checked = false;
                    globals.LockNorm = false;
                    normalTextTriggerCount = 0;
                    refresh();
                }
            }

        }

        private void mainBackCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (textBackgroundTrigger)
            {
                textBackgroundTrigger = false;
            }
            else
            {
                rankedColors checkedColor;
                CheckBox tmp = (CheckBox)sender;

                if (tmp.Checked == true)
                {
                    if (selected_colors == 1)
                    {
                        checkedColor = (rankedColors)colorSelected[0];
                        globals.LockMainBack = true;
                        for (int i = 0; i < totalColors; i++)
                        {
                            globals.NewMainbackR[i] = checkedColor.RMainBack;
                            globals.NewMainbackG[i] = checkedColor.GMainBack;
                            globals.NewMainbackB[i] = checkedColor.BMainBack;
                        }

                        this.textBackButton.BackColor = Color.FromArgb(checkedColor.RMainBack, checkedColor.GMainBack, checkedColor.BMainBack);

                        refresh();
                    }
                    else
                    {
                        //display message here
                        MessageBox.Show("Please Select 1 Image to lock Back Color of Buttons", "Error");
                        this.textBackButton.BackColor = System.Drawing.SystemColors.ButtonFace;
                        tmp.Checked = false;
                    }
                }
                else
                {
                    this.textBackButton.BackColor = System.Drawing.SystemColors.ButtonFace;
                    mainBackCheck.Checked = false;
                    globals.LockMainBack = false;
                    textBackgroundTriggerCount = 0;
                    refresh();
                }
            }
        }

        private void buttTextCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (buttForeTrigger)
            {
                buttForeTrigger = false;
            }
            else
            {
                rankedColors checkedColor;
                CheckBox tmp = (CheckBox)sender;

                if (tmp.Checked == true)
                {
                    if (selected_colors == 1)
                    {
                        checkedColor = (rankedColors)colorSelected[0];
                        globals.LockButtFore = true;
                        for (int i = 0; i < totalColors; i++)
                        {
                            globals.NewButtForeR[i] = checkedColor.RButtFore;
                            globals.NewButtForeG[i] = checkedColor.GButtFore;
                            globals.NewButtForeB[i] = checkedColor.BButtFore;
                        }

                        this.buttForeButton.BackColor = Color.FromArgb(checkedColor.RButtFore, checkedColor.GButtFore, checkedColor.BButtFore);

                        refresh();
                    }
                    else
                    {
                        //display message here
                        MessageBox.Show("Please Select 1 Image to lock Fore Color of Buttons", "Error");
                        this.buttForeButton.BackColor = System.Drawing.SystemColors.ButtonFace;
                        tmp.Checked = false;
                    }
                }
                else
                {
                    this.buttForeButton.BackColor = System.Drawing.SystemColors.ButtonFace;
                    buttTextCheck.Checked = false;
                    globals.LockButtFore = false;
                    buttForeTriggerCount = 0;
                    refresh();
                }
            }
        }

        //all button clicks functions
                    
        private void applyButt_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void BackBut_Click(object sender, EventArgs e)
        {
            backColorTriggerCount = backColorTriggerCount + 1;
            colorPick.ShowDialog();
            this.BackBut.BackColor = colorPick.Color;
            //manualBackColor = true;
            if (backColorTriggerCount == 1)
            {
                backColorTrigger = true;
            }
            globals.LockBack = true;

            for (int i = 0; i < totalColors; i++)
            {
                globals.NewBackR[i] = colorPick.Color.R;
                globals.NewBackG[i] = colorPick.Color.G;
                globals.NewBackB[i] = colorPick.Color.B;
            }
            imageSelected = false;
            backColor = colorPick.Color;
            backCheck.Checked = true;
            refresh();
        }

        private void buttBackButton_Click(object sender, EventArgs e)
        {
            backButtonTriggerCount = backButtonTriggerCount + 1;
            colorPick.ShowDialog();
            this.buttBackButton.BackColor = colorPick.Color;
            buttonBackColor = colorPick.Color;
            if (backButtonTriggerCount == 1)
            {
                backButtonTrigger = true;
            }
            globals.lockButtBack = true;

            for (int i = 0; i < totalColors; i++)
            {
                globals.NewButtbackR[i] = colorPick.Color.R;
                globals.NewButtbackG[i] = colorPick.Color.G;
                globals.NewButtbackB[i] = colorPick.Color.B;
            }
          
            buttBackCheck.Checked = true;
            refresh();
           
        }

        private void banBackButton_Click(object sender, EventArgs e)
        {
            bannerTriggerCount = bannerTriggerCount + 1;
            colorPick.ShowDialog();
            this.banBackButton.BackColor = colorPick.Color;
            //manualBackColor = true;
            if (bannerTriggerCount == 1)
            {
                bannerTrigger = true;
            }
            globals.LockBann = true;

            for (int i = 0; i < totalColors; i++)
            {
                globals.NewBannR[i] = colorPick.Color.R;
                globals.NewBannG[i] = colorPick.Color.G;
                globals.NewBannB[i] = colorPick.Color.B;
            }

            bannCheck.Checked = true;
            refresh();
        }

        private void boldButton_Click(object sender, EventArgs e)
        {

            boldTriggerCount = boldTriggerCount + 1;
            colorPick.ShowDialog();
            this.boldButton.BackColor = colorPick.Color;
            //manualBackColor = true;
            if (boldTriggerCount == 1)
            {
                boldTrigger = true;
            }
            globals.LockBold = true;

            for (int i = 0; i < totalColors; i++)
            {
                globals.NewBoldR[i] = colorPick.Color.R;
                globals.NewBoldG[i] = colorPick.Color.G;
                globals.NewBoldB[i] = colorPick.Color.B;
            }
            // backColor = colorPick.Color;

            //keep one manual selection trigger to skip the while process when check box is checked.
            boldCheck.Checked = true;
            refresh();
        }

        private void normalButton_Click(object sender, EventArgs e)
        {

            normalTextTriggerCount = normalTextTriggerCount + 1;
            colorPick.ShowDialog();
            this.normalButton.BackColor = colorPick.Color;
            //manualBackColor = true;
            if (normalTextTriggerCount == 1)
            {
                normalTextTrigger = true;
            }
            globals.LockNorm = true;

            for (int i = 0; i < totalColors; i++)
            {
                globals.NewNormR[i] = colorPick.Color.R;
                globals.NewNormG[i] = colorPick.Color.G;
                globals.NewNormB[i] = colorPick.Color.B;
            }
            // backColor = colorPick.Color;

            //keep one manual selection trigger to skip the while process when check box is checked.
            normCheck.Checked = true;
            refresh();
        }

        private void textBackButton_Click(object sender, EventArgs e)
        {
            textBackgroundTriggerCount = textBackgroundTriggerCount + 1;
            colorPick.ShowDialog();
            this.textBackButton.BackColor = colorPick.Color;
            secondBackColor = colorPick.Color;
            //manualBackColor = true;
            if (textBackgroundTriggerCount == 1)
            {
                textBackgroundTrigger = true;
            }
            globals.LockMainBack = true;

            for (int i = 0; i < totalColors; i++)
            {
                globals.NewMainbackR[i] = colorPick.Color.R;
                globals.NewMainbackG[i] = colorPick.Color.G;
                globals.NewMainbackB[i] = colorPick.Color.B;
            }
            // backColor = colorPick.Color;

            //keep one manual selection trigger to skip the while process when check box is checked.
            mainBackCheck.Checked = true;
            refresh();
        }

        private void buttForeButton_Click(object sender, EventArgs e)
        {

            buttForeTriggerCount = buttForeTriggerCount + 1;
            colorPick.ShowDialog();
            this.buttForeButton.BackColor = colorPick.Color;
            //manualBackColor = true;
            if (buttForeTriggerCount == 1)
            {
                buttForeTrigger = true;
            }
            globals.LockButtFore = true;


            for (int i = 0; i < totalColors; i++)
            {
                globals.NewButtForeR[i] = colorPick.Color.R;
                globals.NewButtForeG[i] = colorPick.Color.G;
                globals.NewButtForeB[i] = colorPick.Color.B;
            }
            // backColor = colorPick.Color;

            //keep one manual selection trigger to skip the while process when check box is checked.
            buttTextCheck.Checked = true;
            refresh();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;

            ofd.ShowDialog();

            if (ofd.FileName != "")
                //extract selected file format using string concatination


                formatType = ofd.FileName.Substring((ofd.FileName.Length - 4), 4);

            //check that file format exists in filetypes allowed
            try
            {

                foreach (string x in FileTypes)
                {
                    if (x == formatType)
                        formatFound = true;
                }
                txtFileName.Text = ofd.FileName;

                filepath = ofd.FileName;
                filename = System.IO.Path.GetFileName(filepath);

                getAverageImageRGB(new Bitmap(Image.FromFile(txtFileName.Text)));
                
                if (txtFileName.Text != "" && System.IO.File.Exists(txtFileName.Text))
                {
                   
                    imageSelected = true;

                    //include the code that background button color is applied
                    backColorTriggerCount = backColorTriggerCount + 1;
                    this.BackBut.BackColor = Color.FromArgb(averageRGB[0], averageRGB[1], averageRGB[2]);
                    //manualBackColor = true;
                    if (backColorTriggerCount == 1)
                    {
                        backColorTrigger = true;
                    }
                    globals.LockBack = true;
                                      
                    backColor = Color.FromArgb(0, averageRGB[0], averageRGB[1], averageRGB[2]);
                    backCheck.Checked = true;
                    refresh();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : Please select image format file" +ex.ToString());
            }
        }

        public void getAverageImageRGB(Bitmap picture)
        {
            Bitmap mainBannerImage = new Bitmap(250, 100, PixelFormat.Format24bppRgb);
             Bitmap bannerImage = new Bitmap(206, 63, PixelFormat.Format24bppRgb);
            int count = 0;
            //get pixel luminance from left top  pixel
            long temp1 = 0, temp2 = 0, temp3 = 0;
                       
            //read the pixels and store in new image
            for (int i = 0; i < 250; i++)
            {

                for (int j = 0; j < 100; j++)
                {
                    Color rgb = picture.GetPixel(i, j);

                    if ((i >= 23 && i < 183))
                    {
                        if ((j >= 55 && j < 91))
                        {
                            temp1 += rgb.R;
                            temp2 += rgb.G;
                            temp3 += rgb.B;
                            count = count + 1;
                        }
                    }

                    if((i >= 0 && i < 206))
                    {
                        if((j >= 0 && j < 63))
                        {
                            Color newcol = Color.FromArgb(rgb.R, rgb.G, rgb.B);
                            bannerImage.SetPixel(i, j, newcol);
                            
                        }
                    }

                    //create banner image at the sametime to get opacity for the banner text
                    Color newcol2 = Color.FromArgb(rgb.R, rgb.G, rgb.B);
                    mainBannerImage.SetPixel(i, j, newcol2);

                }
            }

            averageRGB[0] = Convert.ToInt32(temp1 / count);
            averageRGB[1] = Convert.ToInt32(temp2 / count);
            averageRGB[2] = Convert.ToInt32(temp3 / count);

            //calculate average rgb values of the image and store in as banner back color.
            for (int i = 0; i < totalColors; i++)
            {
                globals.NewBackR[i] = averageRGB[0];
                globals.NewBackG[i] = averageRGB[1];
                globals.NewBackB[i] = averageRGB[2];
            }

            bannerImage.Save(imagePath + filename, System.Drawing.Imaging.ImageFormat.Jpeg);
            mainBannerImage.Save(imagePath + "main_"+filename, System.Drawing.Imaging.ImageFormat.Jpeg);
                     
        }

 
    }
}
