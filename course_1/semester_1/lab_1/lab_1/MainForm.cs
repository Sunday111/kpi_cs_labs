using System;
using System.Windows.Forms;

namespace lab_1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
