namespace FontToGcode
{
    partial class Help
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Help));
            this.workflow = new System.Windows.Forms.Button();
            this.info = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // workflow
            // 
            this.workflow.Location = new System.Drawing.Point(77, 88);
            this.workflow.Name = "workflow";
            this.workflow.Size = new System.Drawing.Size(140, 55);
            this.workflow.TabIndex = 0;
            this.workflow.Text = "Work-Flow";
            this.workflow.UseVisualStyleBackColor = true;
            this.workflow.Click += new System.EventHandler(this.workflow_Click);
            // 
            // info
            // 
            this.info.Location = new System.Drawing.Point(77, 198);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(140, 55);
            this.info.TabIndex = 1;
            this.info.Text = "Information";
            this.info.UseVisualStyleBackColor = true;
            this.info.Click += new System.EventHandler(this.info_Click);
            // 
            // Help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 450);
            this.Controls.Add(this.info);
            this.Controls.Add(this.workflow);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Help";
            this.Text = "Help";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button workflow;
        private System.Windows.Forms.Button info;
    }
}