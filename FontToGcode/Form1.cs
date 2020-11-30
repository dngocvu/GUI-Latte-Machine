/*
    This code is based on Project's Yazan Mohammad and following
    website:https://www.c-sharpcorner.com
    (best.NETTRAINING)https://www.youtube.com/channel/UCzWd8lsefYoh42OCrg6FzuQ
    Author: Dang Ngoc Vu
    Ho Chi Minh City, 27/10/2019
    Part of mechatronics project 
*/
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
    public partial class Form1 : Form
    {
        // link dataLibrary Form with Form1
        // dataLibrary dataForm = new dataLibrary();
        // link prepare Form with Form1
        // prepare PreP = new prepare();

        // public for sharing 
        public bool isConnected = false; // sign for connect 
        bool isHandMode = false;  // sign for connect
        public SerialPort port;
        String[] ports;
        //String[] getValueQuickly;
        //String[] getValueDrawing;
        PointF StartPoint = new PointF(0.0f, 0.0f), SubStartPoint = new PointF(0.0f, 0.0f), EndPoint = new PointF(0.0f, 0.0f);
        GraphicsPath Path;
        GraphicsPath hPath;
        GraphicsPath h_Path;
        Graphics f;
        Graphics g;
        Font font;
        PathData data;
        //PathData hdata;
        //Array myArray;
        //Char[] character;
        Pen RemoveMaterial = new Pen(Color.White, 1), Transition = new Pen(Color.Red, 0.1f);
        Pen p = new Pen(Color.White, 4);
        //PointF current = new Point();
        //PointF old = new Point();
        //PointF mid = new Point();
        int x1 = -1;
        int y1 = -1;
        int x2 = -1;
        int y2 = -1;
        int x3 = -1;
        int y3 = -1;
        int x4 = -1;
        int y4 = -1;
        bool moving = false;
        //Point[] myArray;
        // main form
        public Form1() 
        {
            InitializeComponent();
            disableControls();
            getAvailableComPort();
            panel2.Enabled = false;
            foreach (string port in ports)
            {
                comboBox1.Items.Add(port);
                Console.WriteLine(port);
                if (ports[0] != null)
                {
                    comboBox1.SelectedItem = ports[0];
                }
                else
                {
                    DialogResult messageNoPort = MessageBox.Show("No Compatitive Port Connected !", "Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                }
            }
            p.SetLineCap(LineCap.Round, LineCap.Round, DashCap.Round); // set line capture

        }
        // get available com port
        void getAvailableComPort()
        {
            try
            {
                ports = SerialPort.GetPortNames();
                if (ports == null)
                    throw new Exception("You're not connecting!");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error opening my port: {0}", ex.Message);
            }
        }
        // font to code
        private string FontToGcode(string Text, PointF origin, float FeedRate, float Depth, float RetractDistance)
        {
            String GCode = "";
            Path = new GraphicsPath();
            StringFormat stringformat = StringFormat.GenericDefault; //format
            FontFamily family = new FontFamily(font.Name); // font
            int style = (int)FontStyle.Bold; // style
            Path.AddString(Text, family, style, font.Size, origin, stringformat);
            data = new PathData();
            Path.Flatten();

            Path.FillMode = FillMode.Winding;

            return GCode;
        }
        // drawing to code
        private string DrawingToGcode(PointF origin, float FeedRate, float Depth, float RetractDistance)
        {
            String hGCode = "";
            hPath = new GraphicsPath();
            hPath.StartFigure();
            hPath.AddPath(h_Path,true);
            data = new PathData();
            hPath.Flatten();
            hPath.FillMode = FillMode.Winding;
            hPath.CloseFigure();
            g.DrawPath(p, hPath);
            g.Save();

            return hGCode;
        }
        // generate Text contents 
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // A FontDialog control in WinForms is used to  
            // select a font from available fonts installed on a system.
        
            fontDialog1.ShowDialog(); // Call the ShowDialog method
            if (fontDialog1.Font != null)
                font = fontDialog1.Font;
        }
        // Initial
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            // richTextBox1 get value
            this.richTextBox1.Text = "";
            // ready to drawing text
            FontToGcode(toolStripTextBox1.Text, new PointF(0.0f, 0.0f), 10.0f, 3.0f, 1.0f);
        }
        // Draw text
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            f = this.panel1.CreateGraphics();  // initial and create graphics in panel1
            f.DrawPath(RemoveMaterial, Path);
            f.Save();
        }
        // Draw on panel and generate G-code
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            f = this.panel1.CreateGraphics(); // initial and create graphics in panel1
            f.ScaleTransform(5.0f, 5.0f);     // scale and transform graphics

            String GCode = "";
            GCode += "G21,G90,M82,M117 Processing...,\n";
            GCode += "G1 Z1 F100,G4 P500, G1 F2000 X120 Y45,\n";
            GCode += "G1 F2000 X120 Y105,\n";
            GCode += "G1 Z0.1 F100,\n";
            GCode += "G4 P500,\n";
            GCode += "M106,\n";
            GCode += "G4 P3000,\n";
            GCode += "M107,\n";
            GCode += "G1 Z2.5 F100,\n";
            GCode += "M106,\n";
            GCode += "G4 P3000,\n";
            GCode += "M107,\n";
            GCode += "G1 Z4.2 F100,\n";
            GCode += "G1 F1500 X120.375 Y90.75,\n";
            GCode += "M106,\n";
            GCode += "G4 P500,\n";
            // move small sketch
            //float YOffset = Path.GetBounds().Height*3.0f;

            for (int i = 0; i < Path.PointCount; i++)
            {
                
                switch ((PathPointType)Path.PathData.Types[i])
                {
                    case PathPointType.Start:

                        EndPoint.X = Path.PathPoints[i].X;
                        EndPoint.Y = Path.PathPoints[i].Y;

                        //if (i != 0)
                        //{
                        f.DrawLine(RemoveMaterial, StartPoint, SubStartPoint);

                        //    GCode += "\nG01 Z -2 F 5\n";
                        if (i != 0)
                            //GCode += "G1 F400 X" + SubStartPoint.X.ToString() + " Y" + (-SubStartPoint.Y + YOffset).ToString() + ",\n";
                            GCode += "G1 F1500 X" + (SubStartPoint.X*3 + 40).ToString() + " Y" + (SubStartPoint.Y*3 - 20).ToString() + ",\n";
                        StartPoint.X = SubStartPoint.X;
                        StartPoint.Y = SubStartPoint.Y;
                        //}

                        f.DrawLine(Transition, StartPoint, EndPoint);

                        if (i != 0)
                            GCode += ",\n";

                        GCode += "G1 F100 Z5,\n";
                        //GCode += "G1 F400 X" + EndPoint.X.ToString() + " Y" + (-EndPoint.Y + YOffset).ToString() + ",\n";
                        GCode += "G1 F1500 X" + (EndPoint.X*3 + 40).ToString() + " Y" + (EndPoint.Y*3 - 20).ToString() + ",\n";
                        //GCode += "G1 F100 Z6,\n";

                        SubStartPoint.X = EndPoint.X;
                        SubStartPoint.Y = EndPoint.Y;
                        StartPoint.X = EndPoint.X;
                        StartPoint.Y = EndPoint.Y;

                        break;

                    default:

                        EndPoint.X = Path.PathPoints[i].X;
                        EndPoint.Y = Path.PathPoints[i].Y;


                        // Delay to see the paths while being drawn. Use it wisely, be careful not to use long intervals! be warned.
                        //for (int h = 0; h < 20000000; h++) ;

                        f.DrawLine(RemoveMaterial, StartPoint, EndPoint);

                        //GCode += "G1 F400 X" + EndPoint.X.ToString() + " Y" + (-EndPoint.Y + YOffset).ToString() + ",\n";
                        GCode += "G1 F1500 X" + (EndPoint.X*3 + 40).ToString() + " Y" + (EndPoint.Y*3 - 20).ToString() + ",\n";
                        StartPoint.X = EndPoint.X;
                        StartPoint.Y = EndPoint.Y;

                        break;
                }
            }

            EndPoint = Path.GetLastPoint();
            f.DrawLine(RemoveMaterial, EndPoint, SubStartPoint);

            //GCode += "G1 F400 X" + SubStartPoint.X.ToString() + " Y" + (-SubStartPoint.Y + YOffset).ToString() + ",\n";
            GCode += "G1 F1500 X" + (SubStartPoint.X*3 + 40).ToString() + " Y" + (SubStartPoint.Y*3 - 20).ToString() + ",\n";
            GCode += "M107,\n";
            GCode += "G4 P500,\n";
            GCode += "G1 F100 Z10,G1 F1500 X120 Y45,\n";
            GCode += "M84,G90,M82\n";
            this.richTextBox1.Text = GCode;

            Path.Reset();  
        }

        // clearButton's option
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Path.Reset();
            richTextBox1.Text = "";
            f.Clear(Color.SaddleBrown);
            StartPoint.X = 0;






            StartPoint.Y = 0;
           SubStartPoint.X = 0;
            SubStartPoint.Y = 0;
            EndPoint.X = 0;
            EndPoint.Y = 0;
        }
        // send g-code
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                // time for delay (clear buffer of serial communication)
                int milliseconds = 50;
                //String getValueDrawing = "#TEXT" + richTextBox1.Text + "\n" + "M84" + "#\n";
                //Char[] character = getValueDrawing.ToCharArray();
                //int length = getValueDrawing.Length;
                //get string
                String getValueDrawing = richTextBox1.Text;
                //receive string from serial
                String getData;
                //string seperator
                String[] spearator = {","};
                //maximun number of substring
                Int32 count = 100;
                //using the method 
                String[] strlist = getValueDrawing.Split(spearator, count,
                       StringSplitOptions.RemoveEmptyEntries);
                //send g-code string 
                foreach (String s in strlist)
                {
                    //generate format substrings from substring
                    //String s_sub = "#" + s + "\n";
                    String s_sub = s + "\n";
                    //convert to char array
                    Char[] character = s_sub.ToCharArray();
                    //send g-code string
                    port.Write(character, 0, s_sub.Length);
                    //get data
                    getData = port.ReadLine(); // just one line
                    //read all data in buffer
                    //getData = port.ReadExisting();
                    //wait for receiving data
                    while (getData != "ok");
                    //delay for clear buffer
                    Thread.Sleep(milliseconds);
                }
                //Thread.Sleep(milliseconds);
                //port.Write("#TEXT" + "M84" + "\n" + "G90" + "\n" + "G82" + "#\n");
                /*
                int length = getValueDrawing.Length;
                int countExcept = length%250;
                int count = 250;
                
                for (int i = 0; i < length; i = i + 250)
                {
                    if (i + 250 > length)
                    {
                        port.Write(character, i, countExcept);
                        Thread.Sleep(milliseconds);
                    }
                    else
                    {
                        port.Write(character, i, count);
                        Thread.Sleep(milliseconds);
                    }
                }
                */
            }
        }
        // 2D data library
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            dataLibrary datalibrary = new dataLibrary(port, isConnected); // get two parameters of form1
            datalibrary.Show();
        }
        // 3D data library
        private void toolStripButton7_Click_1(object sender, EventArgs e)
        {
            data3DLibrary data3Dlibrary = new data3DLibrary(port, isConnected); // get two parameters of form1
            data3Dlibrary.Show();
        }
        // Help
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            Help Help = new Help();
            Help.Show();
        }

        //prepare materials click
        private void prePump_Click(object sender, EventArgs e)
        {
            prepare Prepare = new prepare(port, isConnected); // get two parameters of form1
            Prepare.Show();
        }
        // click to control
        private void button1_Click(object sender, EventArgs e)
        {
            //String checkData;
            if (!isConnected)
            {
                checkPort();
                if (port != null)
                {
                    port.Write("#" + "G28 X0 Y0 Z0 \n" + "M84" + "\n");
                    //checkData = port.ReadExisting();
                    connectToArduino();
                }
            }
            else
            {
                //Char[] character = getValue.ToCharArray();
                port.Write("#" + "G28 X0 Y0 Z0 \n" + "M84" + "\n");
                disconnectFromArduino();
            }
        }
        // send data Quick access
        private void button2_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                String getValueQuickly = "#" + richTextBox2.Text + "\n" + "M84" + "\n";
                Char[] character = getValueQuickly.ToCharArray();
                port.Write(character, 0, getValueQuickly.Length);
                //port.Write(character, 0, 9999);
            }
        }
        // Clear data Quick access
        private void button3_Click(object sender, EventArgs e) 
        {
            richTextBox2.Text = "";
        }
        // hand drawing
        private void button4_Click(object sender, EventArgs e) 
        {
            if (!isHandMode)
            {
                panel2.Enabled = true;
                g = panel2.CreateGraphics();
                button4.Text = "Text Mode";
                toolStripLabel1.Enabled = false;
                toolStripLabel2.Enabled = false;
                toolStripTextBox1.Enabled = false;
                toolStripButton1.Enabled = false;
                toolStripButton2.Enabled = false;
                toolStripButton3.Enabled = false;
                toolStripButton4.Enabled = false;
                toolStripButton5.Enabled = false;
                toolStripButton6.Enabled = false;
                isHandMode = true;
            }
            else
            {
                button4.Text = "Hand-Writing";
                toolStripLabel1.Enabled = true;
                toolStripLabel2.Enabled = true;
                toolStripTextBox1.Enabled = true;
                toolStripButton1.Enabled = true;
                toolStripButton2.Enabled = true;
                toolStripButton3.Enabled = true;
                toolStripButton4.Enabled = true;
                toolStripButton5.Enabled = true;
                toolStripButton6.Enabled = true;
                panel2.Enabled = false;
                isHandMode = false;
                
            }

        }
        // Clear Hand-Writing
        private void button5_Click(object sender, EventArgs e) 
        {
            clearHandDrawing();
        }
        // Create G-code
        private void button6_Click(object sender, EventArgs e) 
        {

            //
            g = this.panel2.CreateGraphics();
            String hGCode = "";
            float YOffset = hPath.GetBounds().Height * 3.0f;
            for (int j = 0; j < hPath.PointCount; j++)
            {

                switch ((PathPointType)hPath.PathData.Types[j])
                {
                    case PathPointType.Start:

                        EndPoint.X = hPath.PathPoints[j].X;
                        EndPoint.Y = hPath.PathPoints[j].Y;

                        //if (i != 0)
                        //{
                        g.DrawLine(p, StartPoint, SubStartPoint);

                        //    GCode += "\nG01 Z -2 F 5\n";
                        if (j != 0)
                            hGCode += "G1 X" + SubStartPoint.X.ToString() + " Y" + (-SubStartPoint.Y + YOffset).ToString() + "\n";

                        StartPoint.X = SubStartPoint.X;
                        StartPoint.Y = SubStartPoint.Y;
                        //}

                        g.DrawLine(Transition, StartPoint, EndPoint);

                        if (j != 0)
                            //hGCode += "\n";

                        hGCode += "G0 Z1\n";
                        hGCode += "G0 X" + EndPoint.X.ToString() + " Y" + (-EndPoint.Y + YOffset).ToString() + "\n";
                        hGCode += "G1 Z1\n";

                        SubStartPoint.X = EndPoint.X;
                        SubStartPoint.Y = EndPoint.Y;
                        StartPoint.X = EndPoint.X;
                        StartPoint.Y = EndPoint.Y;

                        break;

                    default:

                        EndPoint.X = hPath.PathPoints[j].X;
                        EndPoint.Y = hPath.PathPoints[j].Y;


                        // Delay to see the paths while being drawn. Use it wisely, be careful not to use long intervals! be warned.
                        //for (int h = 0; h < 20000000; h++) ;

                        g.DrawLine(p, StartPoint, EndPoint);

                        hGCode += "G1 X" + EndPoint.X.ToString() + " Y" + (-EndPoint.Y + YOffset).ToString() + "\n";

                        StartPoint.X = EndPoint.X;
                        StartPoint.Y = EndPoint.Y;

                        break;
                }
            }

            EndPoint = hPath.GetLastPoint();
            g.DrawLine(p, EndPoint, SubStartPoint);
            hGCode += "G0 X" + SubStartPoint.X.ToString() + " Y" + (-SubStartPoint.Y + YOffset).ToString() + "\n";
            hGCode += "G0 Z1\n";
            
            this.richTextBox1.Text = hGCode;

            hPath.Reset();
        }
        // mouse drawing
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            x1 = e.X;
            y1 = e.Y;
        }
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving && x1 != -1 && y1 != -1)
            { 
                g.DrawLine(p, new Point(x1,y1), e.Location);
                x1 = e.X;
                y1 = e.Y;
                
            }
            x4 = x3;
            y4 = y3;
            x3 = x2;
            y3 = y2;
            x2 = x1;
            y2 = y1;
            Point[] myArray = { new Point(x4, y4), new Point(x3, y3), new Point(x2, y2), new Point(x1, y1)};
            h_Path = new GraphicsPath();
            h_Path.AddLines(myArray);
        }
        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            /*
            moving = false;
            
            x1 = -1;
            y1 = -1;
            x2 = -1;
            y2 = -1;
            x3 = -1;
            y3 = -1;
            x4 = -1;
            y4 = -1;
            */
            panel2.Cursor = Cursors.Default;
        }

        // Save handWriting graphics
        private void button7_Click(object sender, EventArgs e) 
        {
            // richTextBox1 get value
            this.richTextBox1.Text = "";
            g = this.panel2.CreateGraphics();  // initial and create graphics in panel2
            DrawingToGcode(new PointF(0.0f, 0.0f), 10.0f, 3.0f, 1.0f);
            g.Save();         
        }
        // connect control
        private void checkPort()
        {
            //isConnected = true;
            string selectedPort = comboBox1.GetItemText(comboBox1.SelectedItem);
            String getFirstData;
            String getRedundantData1;
            String getRedundantData2;

            try
            {
                port = new SerialPort(selectedPort, 115200, Parity.None, 8, StopBits.One);
                port.Open();
                port.Write("");
                DialogResult messageNoPort = MessageBox.Show("You're Connecting! \n Please Reset Your Machine To Controll!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Thread.Sleep(100);
                getFirstData = port.ReadLine();
                // has sd card
                getRedundantData1 = port.ReadTo("SD card ok");
                // has not sd card
                //getRedundantData1 = port.ReadTo("SD init fail");
                getRedundantData2 = port.ReadLine();
                while (getFirstData != "start");
                DialogResult dialogResult = MessageBox.Show("You're Connecting Completely! \nHave Fun!!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //throw new ArgumentException("You're not connecting!");
            }
            catch (Exception)
            {
                //Console.WriteLine("Error opening my port: {0}", ex.Message);
                DialogResult messageNoPort = MessageBox.Show("You're Not Connecting! \nCan't find serial port \nPlease Check Your Connection!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        // connect control
        private void connectToArduino()
        {
            isConnected = true;
            button1.Text = "Disconnect";
            enableControls();
        }
        // disconnect control 
        private void disconnectFromArduino()
        {
            isConnected = false;
            port.Write("");
            port.Close();
            button1.Text = "Connect";
            disableControls();
            resetDefaults();
        }
        // enable controls
        private void enableControls()
        {
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            toolStripButton6.Enabled = true;
            toolStripButton7.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            AvalubleTemplates.Enabled = true;
            prePump.Enabled = true;
        }
        // disenable controls
        private void disableControls()
        {
            //groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            toolStripButton6.Enabled = false;
            toolStripButton7.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            AvalubleTemplates.Enabled = false;
            prePump.Enabled = false;
        }
        // default mode
        private void resetDefaults()
        {
            richTextBox2.Text = "";
        }
        private void clearHandDrawing()
        {
            g.Clear(Color.SaddleBrown);
            richTextBox1.Text = "";
        }
        //
        // richTextBox's option
        //
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
            richTextBox2.Copy();

        }
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
            richTextBox2.SelectAll();
        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
            richTextBox2.Paste();
        }
        // make sure Exit application
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult messageExit = MessageBox.Show("Do you want to EXIT ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (messageExit == DialogResult.Yes)
            {
                //Application.Exit();
                //Application.ExitThread(); //work well
                e.Cancel = false;
            }
            else if (messageExit == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        /// not use
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
    }

}