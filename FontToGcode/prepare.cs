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
    public partial class prepare : Form
    {
        // link Form1 form with prepare form
         Form1 form1 = new Form1();
        // link dataLibrary form with prepare form
        // dataLibrary dataForm = new dataLibrary();

        // data down 
        String dataDown = "G21, G90, M82, G92 E0, G1 F200 E0, G1 F200 E46, M84, G90, M82";
        // data up
        String dataUp = "G21, G90, M82, G92 E0, G1 F200 E0, G1 F200 E-46, M84, G90, M82";
        // data clear
        String dataClear = "G21, M106, G4 P25000, M107,  M84, G90, M82";
        // data move
        String dataMove = "";
        // data home
        String dataOrigin = "G21, G90,  M82, G92, G1 Z8.8 F100, G1 F2000 X120 Y45, M84, G90, M82,";
        // data van on
        String dataVanOn = "G21, M106,  M84, G90, M82";
        // data van off
        String dataVanOff = "G21, M107,  M84, G90, M82";
        // for checking connection
        bool isConnected3;
        // check up
        //bool isUP;
        // check down
        //bool isDOWN;
        // port serial
        SerialPort port3;
        // link port and isConnected
        public prepare(SerialPort port, bool isConnected)
        {
            InitializeComponent();
            port3 = port;
            isConnected3 = isConnected;
        }
        // up pump
        private void button1_Click(object sender, EventArgs e)
        {
            if (isConnected3)
            {
				//
				MessageBox.Show("Processing, Please Wait!","Information", MessageBoxButtons.OK,MessageBoxIcon.Information);
                movePump(dataUp);
                MessageBox.Show("UP Done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // down pump
        private void button2_Click(object sender, EventArgs e)
        {
            if (isConnected3)
            {
				//
				MessageBox.Show("Processing, Please Wait!","Information", MessageBoxButtons.OK,MessageBoxIcon.Information);
                movePump(dataDown);
                MessageBox.Show("DOWN Done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // move X
        private void moveX_Click(object sender, EventArgs e)
        {
            if (isConnected3)
            {
                if (distancetext.Text=="")
                {
                    MessageBox.Show("Have no distance!", "Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                }
                else
                {
                    if (forward.Checked == false && invert.Checked == false)
                    {
                        MessageBox.Show("Have no direction!", "Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (forward.Checked == true)
                        {
                            dataMove = "G90 X0, M82, G92 X0, G1 F800 X0, G1 F800 X" + distancetext.Text + ",G91, M84, G90, M82";
                            movePump(dataMove);
                        }
                        if (invert.Checked == true)
                        {
                            dataMove = "G90 X0, M82, G92 X" + distancetext.Text + ", G1 F800 X0, G1 F800 X-" + distancetext.Text + ",G91, M84, G90, M82";
                            movePump(dataMove);
                        }
                    }
                }
            }
        }
        // move Y
        private void moveY_Click(object sender, EventArgs e)
        {
            if (isConnected3)
            {
                if (distancetext.Text == "")
                {
                    MessageBox.Show("Have no distance!", "Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                }
                else
                {
                    if (forward.Checked == false && invert.Checked == false)
                    {
                        MessageBox.Show("Have no direction!", "Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (forward.Checked == true)
                        {
                            dataMove = "G90 Y0, M82, G92 Y0, G1 F800 Y0, G1 F800 Y" + distancetext.Text + ",G91, M84, G90, M82";
                            movePump(dataMove);
                        }
                        if (invert.Checked == true)
                        {
                            dataMove = "G90 Y0, M82, G92 Y" + distancetext.Text + ", G1 F800 Y0, G1 F800 Y-" + distancetext.Text + ",G91, M84, G90, M82";
                            movePump(dataMove);
                        }
                    }
                }
            }
        }
        // move Z
        private void moveZ_Click(object sender, EventArgs e)
        {
            if (isConnected3)
            {
                if (distancetext.Text == "")
                {
                    MessageBox.Show("Have no distance!", "Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                }
                else
                {
                    if (forward.Checked == false && invert.Checked == false)
                    {
                        MessageBox.Show("Have no direction!", "Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (forward.Checked == true)
                        {
                            dataMove = "G90 Z0, M82, G92 Z0, G1 F800 Z0, G1 F800 Z" + distancetext.Text + ",G91, M84, G90, M82";
                            movePump(dataMove);
                        }
                        if (invert.Checked == true)
                        {
                            dataMove = "G90 Z0, M82, G92 Z" + distancetext.Text + ", G1 F800 Z0, G1 F800 Z-" + distancetext.Text + ",G91, M84, G90, M82";
                            movePump(dataMove);
                        }
                    }
                }
            }
        }
        // move pump
        private void Pump_Click(object sender, EventArgs e)
        {
            if (isConnected3)
            {
                if (distancetext.Text == "")
                {
                    MessageBox.Show("Have no distance!", "Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                }
                else
                {
                    if (forward.Checked == false && invert.Checked == false)
                    {
                        MessageBox.Show("Have no direction!", "Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (forward.Checked == true)
                        {
                            dataMove = "G90 E0, M82, G92 E0, G1 F200 E0, G1 F200 E" + distancetext.Text + ",G91, M84, G90, M82";
                            movePump(dataMove);
                        }
                        if (invert.Checked == true)
                        {
                            dataMove = "G90 E0, M82, G92 E" + distancetext.Text + ", G1 F200 E0, G1 F200 E-" + distancetext.Text + ",G91, M84, G90, M82";
                            movePump(dataMove);
                        }
                    }
                }
            }
        }
        // clear machine
        private void checkClearing_Click(object sender, EventArgs e)
        {
            if (isConnected3)
            {
                MessageBox.Show("Processing. Please wait!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                movePump(dataClear);
                MessageBox.Show("Done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // turn Van
        // turn van on
        private void OnVan_Click(object sender, EventArgs e)
        {
            if (isConnected3)
            {
                MessageBox.Show("Begin.Please wait!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                movePump(dataVanOn);
                MessageBox.Show("Done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // turn van off
        private void OffVan_Click(object sender, EventArgs e)
        {
            if (isConnected3)
            {
                MessageBox.Show("Begin.Please wait!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                movePump(dataVanOff);
                MessageBox.Show("Done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // Origin(original position)
        private void estop_Click(object sender, EventArgs e)
        {
            if (isConnected3)
            {
                MessageBox.Show("Processing. Please wait!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                movePump(dataOrigin);
                MessageBox.Show("Done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // processing G-code
        private void movePump(String movePumpGcode)
        {
            int milliseconds_3 = 50;
            String getValueDrawing_3 = movePumpGcode;
            String getData_3;
            String[] spearator_3 = {","};
            Int32 count_3 = 100;
            String[] strlist_3 = getValueDrawing_3.Split(spearator_3, count_3,
                       StringSplitOptions.RemoveEmptyEntries);
     
            foreach (String s in strlist_3)
            {
                //generate format substrings from substring
                String s_sub_3 = s + "\n";
                //convert to char array
                Char[] character_3 = s_sub_3.ToCharArray();
                //send g-code string
                port3.Write(character_3, 0, s_sub_3.Length);
                //get data
                getData_3 = port3.ReadLine(); // just one line
                //wait for receiving data
                while (getData_3 != "ok");
                //delay for clear buffer
                Thread.Sleep(milliseconds_3);
            }
        }
        // not using
        private void forward_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void invert_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

    }
}
