using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO.Ports;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace FontToGcode
{
    public partial class dataLibrary : Form
    {
        // link Form1 form with dataLibbrary form
         Form1 form1 = new Form1();
        // link prepare form with dataLibbrary form
        //prepare PreP = new prepare();


        // reference data for each scope 
        // Heart Cappuccino
        String template_1 = "G21,G90,M82,G92 E0,M117 Processing...," +
            "G1 Z1 F100,G4 P500, M106, G1 F200 X120 Y45 E1," +
            "G1 F200 X120 Y45 E1.25,G1 F200 X120 Y45 E1.5," +
            "G1 F200 X120 Y45 E1.75,G1 F200 X120 Y45 E2," +
            "G1 F200 X120 Y45 E2.25,G1 F200 X120 Y45 E2.5," +
            "G1 F200 X120 Y45 E2.75,G1 F200 X120 Y45 E3," +
            "G1 F200 X120 Y45 E3.25,G1 F200 X120 Y45 E3.5," +
            "G1 F200 X120 Y45 E4,G1 F200 X120 Y45 E4.5," +
            "G1 F200 X120 Y45 E5,G1 F200 X120 Y45 E5.5," +
            "G1 F200 X120 Y45 E6,G1 F200 X120 Y45 E6.5," +
            "G1 F200 X120 Y45 E7,G1 F200 X120 Y45 E8," +
            "G1 F200 X120 Y45 E9,G1 F200 X120 Y45 E10," +
            "G1 F200 X120 Y45 E11,G1 F200 X120 Y45 E12," +
            "G1 F200 X120 Y45 E13,G1 F200 X120 Y45 E14," +
            "G1 F200 X120 Y45 E15,G1 F200 X120 Y45 E17,G4 P500," +
            "G1 F200 X120 Y45 E20, M107, G1 Z5 F100, M106, G1 F200 X120 Y45 E22," +
            "G1 F200 X120 Y45 E25,G1 F200 X120 Y45 E30," +
            "G1 F200 X120 Y45 E31,G1 F200 X120 Y45 E35," +
            "G1 F200 X120 Y45 E40,G1 F200 X120 Y45 E41," +
            "G1 F200 X120 Y45 E43,G1 F200 X120 Y45 E46, G4 P2000, M107" +
            "G4 P2000, G1 F600 X120 Y55, G1 Z4.6 F100,G1 F600 X120 Y75,G1 Z5 F100, G1 F600 X120 Y95," +
            "G4 P1000,M107,G1 F100 Z10,G1 F1500 X120 Y45," +
            "G1 F200 X120 Y45 E20,G1 F200 X120 Y45 E0," +
            "M84,G90,M82,";
        // Heart Path
        String template_2 = "G21,G90,M82,M117 Processing...," +
            "G1 Z1 F100,G4 P500, G1 F2000 X120 Y45," +
            "G1 F2000 X120 Y105," +
            "G1 Z0.1 F100" +
            "G4 P500," +
            "M106," +
            "G4 P3000," +
            "M107," +
            "G1 Z2.5 F100," +
            "M106," +
            "G4 P3000," +
            "M107," +
            "G1 Z4.2 F100," +
            "G1 F1500 X120.375 Y90.75," +
            "M106," +
            "G4 P500," +
            "G1 F1300 X110.625 Y70.4375," +
            "G1 F1300 X102.375 Y59.9375," +
            "G1 F1300 X96.5625 Y50," +
            "G1 F1300 X93 Y41," +
            "G1 F1300 X91.875 Y32.5625," +
            "G1 F1300 X93 Y26.375," +
            "G1 F1300 X96.1875 Y21.0625," +
            "G1 F1300 X100.875 Y18.0625," +
            "G1 F1300 X107.25 Y17," +
            "G1 F1300 X112.875 Y18.0625," +
            "G1 F1300 X117.1875 Y21.0625," +
            "G1 F1300 X120.375 Y26.375," +
            "G1 F1300 X123.1875 Y21.0625," +
            "G1 F1300 X127.875 Y18.0625," +
            "G1 F1300 X133.3125 Y17," +
            "G1 F1300 X139.5 Y19.875," +
            "G1 F1300 X144.1875 Y22.875," +
            "G1 F1300 X147.5625 Y26.375," +
            "G1 F1300 X148.6875 Y32.5625," +
            "G1 F1300 X147.5625 Y41," +
            "G1 F1300 X144 Y50," +
            "G1 F1300 X138 Y59.9375," +
            "G1 F1300 X129.75 Y70.4375," +
            "G1 F1300 X120.375 Y80.75," +
            "M107," +
            "G4 P500," +
            "G1 F100 Z10,G1 F1500 X120 Y45," +
            "M84,G90,M82";                     
        // square
        String template_3 = "";
        // circle
        String template_4 = "";
        //for checking connection
        bool isConnected2;

        //port serial
        SerialPort port2;
        // link port and isConnected
        public dataLibrary(SerialPort port, bool isConnected)
        {
            InitializeComponent();
            port2 = port;
            isConnected2 = isConnected;
        }
        // draw heart
        private void template1_Click(object sender, EventArgs e)
        {
            if (isConnected2)
            {
                // heart
                MessageBox.Show("Drawing, Please Wait!","Information", MessageBoxButtons.OK,MessageBoxIcon.Information);
                drawingLatte(template_1);
                MessageBox.Show("Done!","Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // draw triangle heart
        private void template2_Click(object sender, EventArgs e)
        {
            if (isConnected2)
            {
                // triangle 
                MessageBox.Show("Drawing, Please Wait!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                drawingLatte(template_2);
                MessageBox.Show("Done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // draw square
        private void template3_Click(object sender, EventArgs e)
        {
            if (isConnected2)
            {
                // square
                MessageBox.Show("Drawing, Please Wait!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                drawingLatte(template_3);
                MessageBox.Show("Done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // draw circle
        private void template4_Click(object sender, EventArgs e)
        {
            if (isConnected2)
            {
                // circle
                MessageBox.Show("Drawing, Please Wait!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                drawingLatte(template_4);
                MessageBox.Show("Done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // processing G-code
        private void drawingLatte(String drawingGcode)
        {
            int milliseconds_2 = 50;
            String getValueDrawing_2 = drawingGcode;
            String getData_2;
            String[] spearator_2 = {","};
            Int32 count_2 = 100;
            String[] strlist_2 = getValueDrawing_2.Split(spearator_2, count_2,
                       StringSplitOptions.RemoveEmptyEntries);
            foreach (String s in strlist_2)
            {
                //generate format substrings from substring
                String s_sub_2 = s + "\n";
                //convert to char array
                Char[] character_2 = s_sub_2.ToCharArray();
                //send g-code string
                port2.Write(character_2, 0, s_sub_2.Length);
                //get data
                getData_2 = port2.ReadLine(); // just one line
                //wait for receiving data
                while (getData_2 != "ok");
                //delay for clear buffer
                Thread.Sleep(milliseconds_2);
            }
        }
        // not using
        private void dataLibrary_Load(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
