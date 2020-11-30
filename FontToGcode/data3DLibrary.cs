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
    public partial class data3DLibrary : Form
    {
        // link Form1 form with dataLibbrary form
        Form1 form1 = new Form1();
        // link prepare form with dataLibbrary form
        //prepare PreP = new prepare();


        // reference data for each scope 
        // triangle
        String Template3D_1 = "G21,G90,G92 E0,M82," +
            "G1 Z2 F100,G4 P500," +
            "G4 P500," +
            "M106," +
            "G1 F1900 X115.4375 Y23.8125," +
            "G1 X123.3125 Y24.5625," +
            "G1 X130.4375 Y26.4375," +
            "G1 X136.625 Y29.8125," +
            "G1 X142.0625 Y34.3125," +
            "G1 X146.375 Y40.125," +
            "G1 X149.5625 Y47.0625," +
            "G1 X151.4375 Y55.125," +
            "G1 X152 Y64.125," +
            "G1 X151.4375 Y73.125," +
            "G1 X149.5625 Y81.1875," +
            "G1 X146.375 Y88.125," +
            "G1 X142.0625 Y93.9375," +
            "G1 X136.625 Y98.625," +
            "G1 X130.4375 Y102," +
            "G1 X123.3125 Y103.875," +
            "G1 X115.4375 Y104.625," +
            "G1 X107.75 Y103.875,"+
            "G1 X100.625 Y102," +
            "G1 X94.4375 Y98.625," +
            "G1 X89 Y93.9375," +
            "G1 X84.6875 Y88.125," +
            "G1 X81.5 Y81.1875," +
            "G1 X79.625 Y73.125," +
            "G1 X79.0625 Y64.125," +
            "G1 X79.625 Y55.125," +
            "G1 X81.5 Y47.0625," +
            "G1 X84.6875 Y40.125," +
            "G1 X89 Y34.3125," +
            "G1 X94.4375 Y29.625," +
            "G1 X100.625 Y26.4375," +
            "G1 X107.75 Y24.375," +
            "G1 X115.4375 Y23.8125," +
            "G1 X115.4375 Y23.8125," +
            "M107," +
            "G4 P500," +
            "G1 Z4 F100," +
            "G1 F1900 X115.4375 Y91.3125," +
            "G4 P500," +
            "M106," +
            "G1 X123.5 Y89.625," +
            "G1 X129.875 Y84.5625," +
            "G1 X134 Y76.125," +
            "G1 X135.3125 Y64.125," +
            "G1 X134 Y62.125," +
            "G1 X129.875 Y43.6875," +
            "G1 X123.5 Y38.625," +
            "G1 X115.4375 Y36.9375," +
            "G1 X107.5625 Y38.625," +
            "G1 X101.1875 Y43.6875," +
            "G1 X97.0625 Y52.125," +
            "G1 X95.5625 Y64.125," +
            "G1 X97.0625 Y76.125," +
            "G1 X101.1875 Y84.5625," +
            "G1 X107.5625 Y89.625," +
            "G1 X115.4375 Y91.3125," +
            "G1 X115.4375 Y91.3125," +
            "M107,G4 P500,G1 F100 Z5,G1 F1900 X120 Y55, G4 P500, M106, G4 P4500, M107," +
            "G1 F100 Z7, G1 F1900 X120 Y55, G1 F200 E15, G1 F100 Z5.5, M106, G4 P10000, M107," +
            "G1 F100 Z7, G1 F1900 X145 Y75, G1 F200 E30, G1 F100 Z5.5, M106, G4 P10000, M107," +
            "G1 F100 Z7, G1 F1900 X95 Y75, G1 F200 E46, G1 F100 Z5.5, M106, G4 P10000, M107," +
            "G1 F100 Z10,G1 F1500 X120 Y45, G1 F200 X120 Y45 E0," +
            "M84,G90,M82";
        // heart
        String Template3D_2 = "G28 X0 Y0, M84";
        // square
        String Template3D_3 = "G28 X0 Y0, M84";
        // circle
        String Template3D_4 = "G28 X0 Y0, M84";

        //for checking connection
        bool isConnected4;

        //port serial
        SerialPort port4;

        // link port and isConnected
        public data3DLibrary(SerialPort port, bool isConnected)
        {
            InitializeComponent();
            port4 = port;
            isConnected4 = isConnected;
        }
        //
        private void template3D_1_Click(object sender, EventArgs e)
        {
            if (isConnected4)
            {
                // triangle
                MessageBox.Show("Drawing, Please Wait!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                drawing3DLatte(Template3D_1);
                MessageBox.Show("Done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //
        private void template3D_2_Click(object sender, EventArgs e)
        {
            if (isConnected4)
            {
                // triangle
                MessageBox.Show("Drawing, Please Wait!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                drawing3DLatte(Template3D_2);
                MessageBox.Show("Done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //
        private void template3D_3_Click(object sender, EventArgs e)
        {
            if (isConnected4)
            {
                // triangle
                MessageBox.Show("Drawing, Please Wait!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                drawing3DLatte(Template3D_3);
                MessageBox.Show("Done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //
        private void template3D_4_Click(object sender, EventArgs e)
        {
            if (isConnected4)
            {
                // triangle
                MessageBox.Show("Drawing, Please Wait!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                drawing3DLatte(Template3D_4);
                MessageBox.Show("Done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // processing G-code
        private void drawing3DLatte(String drawingGcode)
        {
            int milliseconds_4 = 50;
            String getValueDrawing_4 = drawingGcode;
            String getData_4;
            String[] spearator_4 = { "," };
            Int32 count_4 = 100;
            String[] strlist_4 = getValueDrawing_4.Split(spearator_4, count_4,
                       StringSplitOptions.RemoveEmptyEntries);
            foreach (String s in strlist_4)
            {
                //generate format substrings from substring
                String s_sub_4 = s + "\n";
                //convert to char array
                Char[] character_4 = s_sub_4.ToCharArray();
                //send g-code string
                port4.Write(character_4, 0, s_sub_4.Length);
                //get data
                getData_4 = port4.ReadLine(); // just one line
                //wait for receiving data
                while (getData_4 != "ok") ;
                //delay for clear buffer
                Thread.Sleep(milliseconds_4);
            }
        }
        //
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
