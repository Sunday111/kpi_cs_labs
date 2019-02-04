using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void InputTextBox_TextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = string.Empty;
            OutpuTextBox.Text = string.Empty;

            try
            {
                var x = double.Parse(InputTextBox.Text);
                var z = Compute(x);
                OutpuTextBox.Text = z.ToString();
            }
            catch(Exception ex)
            {
                toolStripStatusLabel1.Text = ex.Message;
            }
        }

        private double Compute(double x)
        {
            return
                Math.Abs(6 * Math.Log(Math.Sqrt(Math.Exp(Math.Sin(x)) + Math.Exp(x)))) +
                Math.Abs(6 * x + Math.Pow(Math.Pow(Math.E + 4 * x, 3 * x) , 1.0 / 3.0));
        }
    }
}
