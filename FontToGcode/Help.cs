using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FontToGcode
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }

        private void workflow_Click(object sender, EventArgs e)
        {

            WorkFlow WorkFlow  = new WorkFlow();
            WorkFlow.Show();
        }

        private void info_Click(object sender, EventArgs e)
        {
            Information Information = new Information();
            Information.Show();
        }
    }
}
