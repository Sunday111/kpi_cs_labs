using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace lab_3
{
    public partial class Form1 : Form
    {
        delegate string ConvertDelegate(long input);

        enum TargetType
        {
            Int16,
            Int32,
            Int64,
            UInt16,
            UInt32,
            UInt64,
            Double
        }

        Dictionary<TargetType, ConvertDelegate> Converters;

        public Form1()
        {
            InitializeComponent();

            Converters = new Dictionary<TargetType, ConvertDelegate>();
            Converters.Add(TargetType.Int16, (x) => Convert.ToInt16(x).ToString());
            Converters.Add(TargetType.Int32, (x) => Convert.ToInt32(x).ToString());
            Converters.Add(TargetType.Int64, (x) => Convert.ToInt64(x).ToString());
            Converters.Add(TargetType.UInt16, (x) => Convert.ToUInt16(x).ToString());
            Converters.Add(TargetType.UInt32, (x) => Convert.ToUInt32(x).ToString());
            Converters.Add(TargetType.UInt64, (x) => Convert.ToUInt64(x).ToString());
            Converters.Add(TargetType.Double, (x) => Convert.ToDouble(x).ToString());

            foreach (var val in (TargetType[])Enum.GetValues(typeof(TargetType)))
            {
                TargetTypeComboBox.Items.Add(val);
            }
        }

        private void InputTextBox_TextChanged(object sender, EventArgs e)
        {
            DoConversion();
        }

        private void TargetTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DoConversion();
        }

        private void DoConversion()
        {
            statusLabel.Text = string.Empty;
            OutputTextBox.Text = string.Empty;

            if (TargetTypeComboBox.SelectedItem == null ||
                TargetTypeComboBox.SelectedItem.GetType() != typeof(TargetType))
            {
                statusLabel.Text = "Invalid target type";
                return;
            }

            ConvertDelegate converter;
            if(!Converters.TryGetValue((TargetType)TargetTypeComboBox.SelectedItem, out converter))
            {
                statusLabel.Text = "Unknown target type";
                return;
            }

            try
            {
                var parsed = long.Parse(InputTextBox.Text);
                string converted = converter(parsed);
                OutputTextBox.Text = converted;
            }
            catch(Exception ex)
            {
                statusLabel.Text = ex.Message;
            }
        }
    }
}
