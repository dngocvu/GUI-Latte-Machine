namespace FontToGcode
{
    partial class prepare
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(prepare));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pumpup = new System.Windows.Forms.Label();
            this.pumpdown = new System.Windows.Forms.Label();
            this.configPump = new System.Windows.Forms.GroupBox();
            this.moveAxis = new System.Windows.Forms.GroupBox();
            this.warning = new System.Windows.Forms.Label();
            this.home = new System.Windows.Forms.Button();
            this.distancetext = new System.Windows.Forms.TextBox();
            this.distance = new System.Windows.Forms.Label();
            this.P = new System.Windows.Forms.Label();
            this.Z = new System.Windows.Forms.Label();
            this.Y = new System.Windows.Forms.Label();
            this.X = new System.Windows.Forms.Label();
            this.Pump = new System.Windows.Forms.Button();
            this.moveZ = new System.Windows.Forms.Button();
            this.moveY = new System.Windows.Forms.Button();
            this.moveX = new System.Windows.Forms.Button();
            this.invert = new System.Windows.Forms.RadioButton();
            this.forward = new System.Windows.Forms.RadioButton();
            this.clearMachine = new System.Windows.Forms.GroupBox();
            this.clear = new System.Windows.Forms.Label();
            this.checkClearing = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.OffVan = new System.Windows.Forms.Button();
            this.OnVan = new System.Windows.Forms.Button();
            this.turnVan = new System.Windows.Forms.Label();
            this.configPump.SuspendLayout();
            this.moveAxis.SuspendLayout();
            this.clearMachine.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(150, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 48);
            this.button1.TabIndex = 0;
            this.button1.Text = "UP";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(150, 87);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 48);
            this.button2.TabIndex = 1;
            this.button2.Text = "DOWN";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pumpup
            // 
            this.pumpup.AutoSize = true;
            this.pumpup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pumpup.Location = new System.Drawing.Point(16, 35);
            this.pumpup.Name = "pumpup";
            this.pumpup.Size = new System.Drawing.Size(71, 17);
            this.pumpup.TabIndex = 2;
            this.pumpup.Text = "Pump UP:";
            // 
            // pumpdown
            // 
            this.pumpdown.AutoSize = true;
            this.pumpdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pumpdown.Location = new System.Drawing.Point(16, 103);
            this.pumpdown.Name = "pumpdown";
            this.pumpdown.Size = new System.Drawing.Size(96, 17);
            this.pumpdown.TabIndex = 3;
            this.pumpdown.Text = "Pump DOWN:";
            // 
            // configPump
            // 
            this.configPump.Controls.Add(this.pumpdown);
            this.configPump.Controls.Add(this.pumpup);
            this.configPump.Controls.Add(this.button2);
            this.configPump.Controls.Add(this.button1);
            this.configPump.Location = new System.Drawing.Point(12, 294);
            this.configPump.Name = "configPump";
            this.configPump.Size = new System.Drawing.Size(366, 152);
            this.configPump.TabIndex = 4;
            this.configPump.TabStop = false;
            this.configPump.Text = "configPump";
            // 
            // moveAxis
            // 
            this.moveAxis.Controls.Add(this.warning);
            this.moveAxis.Controls.Add(this.home);
            this.moveAxis.Controls.Add(this.distancetext);
            this.moveAxis.Controls.Add(this.distance);
            this.moveAxis.Controls.Add(this.P);
            this.moveAxis.Controls.Add(this.Z);
            this.moveAxis.Controls.Add(this.Y);
            this.moveAxis.Controls.Add(this.X);
            this.moveAxis.Controls.Add(this.Pump);
            this.moveAxis.Controls.Add(this.moveZ);
            this.moveAxis.Controls.Add(this.moveY);
            this.moveAxis.Controls.Add(this.moveX);
            this.moveAxis.Controls.Add(this.invert);
            this.moveAxis.Controls.Add(this.forward);
            this.moveAxis.Location = new System.Drawing.Point(12, 9);
            this.moveAxis.Name = "moveAxis";
            this.moveAxis.Size = new System.Drawing.Size(365, 285);
            this.moveAxis.TabIndex = 5;
            this.moveAxis.TabStop = false;
            this.moveAxis.Text = "moveAxis";
            this.moveAxis.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // warning
            // 
            this.warning.AutoSize = true;
            this.warning.Location = new System.Drawing.Point(243, 26);
            this.warning.Name = "warning";
            this.warning.Size = new System.Drawing.Size(65, 13);
            this.warning.TabIndex = 14;
            this.warning.Text = "(1 to 10 mm)";
            // 
            // home
            // 
            this.home.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.home.Location = new System.Drawing.Point(16, 21);
            this.home.Name = "home";
            this.home.Size = new System.Drawing.Size(101, 55);
            this.home.TabIndex = 13;
            this.home.Text = "Origin";
            this.home.UseVisualStyleBackColor = true;
            this.home.Click += new System.EventHandler(this.estop_Click);
            // 
            // distancetext
            // 
            this.distancetext.Location = new System.Drawing.Point(196, 23);
            this.distancetext.Name = "distancetext";
            this.distancetext.Size = new System.Drawing.Size(41, 20);
            this.distancetext.TabIndex = 12;
            // 
            // distance
            // 
            this.distance.AutoSize = true;
            this.distance.Location = new System.Drawing.Point(135, 26);
            this.distance.Name = "distance";
            this.distance.Size = new System.Drawing.Size(55, 13);
            this.distance.TabIndex = 11;
            this.distance.Text = "Distance :";
            // 
            // P
            // 
            this.P.AutoSize = true;
            this.P.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P.Location = new System.Drawing.Point(16, 242);
            this.P.Name = "P";
            this.P.Size = new System.Drawing.Size(48, 17);
            this.P.TabIndex = 10;
            this.P.Text = "Pump:";
            // 
            // Z
            // 
            this.Z.AutoSize = true;
            this.Z.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Z.Location = new System.Drawing.Point(16, 193);
            this.Z.Name = "Z";
            this.Z.Size = new System.Drawing.Size(50, 17);
            this.Z.TabIndex = 9;
            this.Z.Text = "Z Axis:";
            // 
            // Y
            // 
            this.Y.AutoSize = true;
            this.Y.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Y.Location = new System.Drawing.Point(16, 138);
            this.Y.Name = "Y";
            this.Y.Size = new System.Drawing.Size(50, 17);
            this.Y.TabIndex = 8;
            this.Y.Text = "Y Axis:";
            // 
            // X
            // 
            this.X.AutoSize = true;
            this.X.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.X.Location = new System.Drawing.Point(16, 86);
            this.X.Name = "X";
            this.X.Size = new System.Drawing.Size(50, 17);
            this.X.TabIndex = 7;
            this.X.Text = "X Axis:";
            // 
            // Pump
            // 
            this.Pump.Location = new System.Drawing.Point(150, 242);
            this.Pump.Name = "Pump";
            this.Pump.Size = new System.Drawing.Size(128, 37);
            this.Pump.TabIndex = 6;
            this.Pump.Text = "P";
            this.Pump.UseVisualStyleBackColor = true;
            this.Pump.Click += new System.EventHandler(this.Pump_Click);
            // 
            // moveZ
            // 
            this.moveZ.Location = new System.Drawing.Point(150, 183);
            this.moveZ.Name = "moveZ";
            this.moveZ.Size = new System.Drawing.Size(128, 37);
            this.moveZ.TabIndex = 5;
            this.moveZ.Text = "Z";
            this.moveZ.UseVisualStyleBackColor = true;
            this.moveZ.Click += new System.EventHandler(this.moveZ_Click);
            // 
            // moveY
            // 
            this.moveY.Location = new System.Drawing.Point(150, 128);
            this.moveY.Name = "moveY";
            this.moveY.Size = new System.Drawing.Size(128, 37);
            this.moveY.TabIndex = 4;
            this.moveY.Text = "Y";
            this.moveY.UseVisualStyleBackColor = true;
            this.moveY.Click += new System.EventHandler(this.moveY_Click);
            // 
            // moveX
            // 
            this.moveX.Location = new System.Drawing.Point(150, 76);
            this.moveX.Name = "moveX";
            this.moveX.Size = new System.Drawing.Size(128, 37);
            this.moveX.TabIndex = 3;
            this.moveX.Text = "X";
            this.moveX.UseVisualStyleBackColor = true;
            this.moveX.Click += new System.EventHandler(this.moveX_Click);
            // 
            // invert
            // 
            this.invert.AutoSize = true;
            this.invert.Location = new System.Drawing.Point(226, 53);
            this.invert.Name = "invert";
            this.invert.Size = new System.Drawing.Size(52, 17);
            this.invert.TabIndex = 1;
            this.invert.TabStop = true;
            this.invert.Text = "Invert";
            this.invert.UseVisualStyleBackColor = true;
            this.invert.CheckedChanged += new System.EventHandler(this.invert_CheckedChanged);
            // 
            // forward
            // 
            this.forward.AutoSize = true;
            this.forward.Location = new System.Drawing.Point(148, 53);
            this.forward.Name = "forward";
            this.forward.Size = new System.Drawing.Size(63, 17);
            this.forward.TabIndex = 0;
            this.forward.TabStop = true;
            this.forward.Text = "Forward";
            this.forward.UseVisualStyleBackColor = true;
            this.forward.CheckedChanged += new System.EventHandler(this.forward_CheckedChanged);
            // 
            // clearMachine
            // 
            this.clearMachine.Controls.Add(this.clear);
            this.clearMachine.Controls.Add(this.checkClearing);
            this.clearMachine.Location = new System.Drawing.Point(12, 468);
            this.clearMachine.Name = "clearMachine";
            this.clearMachine.Size = new System.Drawing.Size(364, 75);
            this.clearMachine.TabIndex = 6;
            this.clearMachine.TabStop = false;
            this.clearMachine.Text = "clearMachine";
            // 
            // clear
            // 
            this.clear.AutoSize = true;
            this.clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clear.Location = new System.Drawing.Point(16, 34);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(102, 17);
            this.clear.TabIndex = 4;
            this.clear.Text = "Clear Machine:";
            // 
            // checkClearing
            // 
            this.checkClearing.Location = new System.Drawing.Point(150, 22);
            this.checkClearing.Name = "checkClearing";
            this.checkClearing.Size = new System.Drawing.Size(127, 40);
            this.checkClearing.TabIndex = 1;
            this.checkClearing.Text = "Clear";
            this.checkClearing.UseVisualStyleBackColor = true;
            this.checkClearing.Click += new System.EventHandler(this.checkClearing_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.OffVan);
            this.groupBox1.Controls.Add(this.OnVan);
            this.groupBox1.Controls.Add(this.turnVan);
            this.groupBox1.Location = new System.Drawing.Point(12, 561);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(365, 71);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "configVan";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // OffVan
            // 
            this.OffVan.Location = new System.Drawing.Point(246, 21);
            this.OffVan.Name = "OffVan";
            this.OffVan.Size = new System.Drawing.Size(90, 40);
            this.OffVan.TabIndex = 6;
            this.OffVan.Text = "OFF";
            this.OffVan.UseVisualStyleBackColor = true;
            this.OffVan.Click += new System.EventHandler(this.OffVan_Click);
            // 
            // OnVan
            // 
            this.OnVan.Location = new System.Drawing.Point(100, 21);
            this.OnVan.Name = "OnVan";
            this.OnVan.Size = new System.Drawing.Size(90, 40);
            this.OnVan.TabIndex = 5;
            this.OnVan.Text = "ON";
            this.OnVan.UseVisualStyleBackColor = true;
            this.OnVan.Click += new System.EventHandler(this.OnVan_Click);
            // 
            // turnVan
            // 
            this.turnVan.AutoSize = true;
            this.turnVan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.turnVan.Location = new System.Drawing.Point(13, 33);
            this.turnVan.Name = "turnVan";
            this.turnVan.Size = new System.Drawing.Size(41, 17);
            this.turnVan.TabIndex = 5;
            this.turnVan.Text = "Van :";
            // 
            // prepare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 644);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.clearMachine);
            this.Controls.Add(this.moveAxis);
            this.Controls.Add(this.configPump);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "prepare";
            this.Text = "Prepare Material";
            this.configPump.ResumeLayout(false);
            this.configPump.PerformLayout();
            this.moveAxis.ResumeLayout(false);
            this.moveAxis.PerformLayout();
            this.clearMachine.ResumeLayout(false);
            this.clearMachine.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label pumpup;
        private System.Windows.Forms.Label pumpdown;
        private System.Windows.Forms.GroupBox configPump;
        private System.Windows.Forms.GroupBox moveAxis;
        private System.Windows.Forms.Label P;
        private System.Windows.Forms.Label Z;
        private System.Windows.Forms.Label Y;
        private System.Windows.Forms.Label X;
        private System.Windows.Forms.Button Pump;
        private System.Windows.Forms.Button moveZ;
        private System.Windows.Forms.Button moveY;
        private System.Windows.Forms.Button moveX;
        private System.Windows.Forms.RadioButton invert;
        private System.Windows.Forms.RadioButton forward;
        private System.Windows.Forms.TextBox distancetext;
        private System.Windows.Forms.Label distance;
        private System.Windows.Forms.GroupBox clearMachine;
        private System.Windows.Forms.Label clear;
        private System.Windows.Forms.Button checkClearing;
        private System.Windows.Forms.Button home;
        private System.Windows.Forms.Label warning;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button OffVan;
        private System.Windows.Forms.Button OnVan;
        private System.Windows.Forms.Label turnVan;
    }
}