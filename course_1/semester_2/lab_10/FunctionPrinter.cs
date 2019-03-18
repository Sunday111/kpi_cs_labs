using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab_10
{
    public partial class FunctionPrinter : Form
    {

        public FunctionPrinter()
        {
            InitializeComponent();

            minXTextBox.TextChanged += MinXTextBox_TextChanged;
            minXTextBox.Text = "-2*pi";

            maxXTextBox.TextChanged += MaxXTextBox_TextChanged;
            maxXTextBox.Text = "2*pi";

            minYTextBox.TextChanged += MinYTextBox_TextChanged;
            minYTextBox.Text = "-2";

            maxYTextBox.TextChanged += MaxYTextBox_TextChanged;
            maxYTextBox.Text = "2";

            formulaText.TextChanged += FormulaText_TextChanged;
            formulaText.Text = "sin(x)";
        }

        private void FormulaText_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var Formula = new CompiledExpression(formulaText.Text, "float x");
                var argsCache = new object[1];
                functionPrinterControl.Function = (x) =>
                {
                    argsCache[0] = x;
                    return Formula.Eval(argsCache);
                };
            }
            catch(Exception)
            {
            
            }
        }

        private static bool ParseValueFromControl(ref float value, TextBox control)
        {
            try
            {
                value = CompiledExpression.CompileAndEval(control.Text, "", null);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void MinXTextBox_TextChanged(object sender, EventArgs e)
        {
            float minX = 0;
            if(ParseValueFromControl(ref minX, minXTextBox))
            {
                var range = functionPrinterControl.UserRange;
                float deltaWidth = range.X - minX;
                range.X = minX;
                range.Width += deltaWidth;
                functionPrinterControl.UserRange = range;
            }
        }

        private void MaxXTextBox_TextChanged(object sender, EventArgs e)
        {
            float maxX = 0;
            if (ParseValueFromControl(ref maxX, maxXTextBox))
            {
                var range = functionPrinterControl.UserRange;
                range.Width = maxX - range.X;
                functionPrinterControl.UserRange = range;
            }
        }

        private void MinYTextBox_TextChanged(object sender, EventArgs e)
        {
            float minY = 0;
            if (ParseValueFromControl(ref minY, minYTextBox))
            {
                var range = functionPrinterControl.UserRange;
                float deltaHeight = range.Y - minY;
                range.Y = minY;
                range.Height += deltaHeight;
                functionPrinterControl.UserRange = range;
            }
        }

        private void MaxYTextBox_TextChanged(object sender, EventArgs e)
        {
            float maxY = 0;
            if (ParseValueFromControl(ref maxY, maxYTextBox))
            {
                var range = functionPrinterControl.UserRange;
                range.Height = maxY - range.Y;
                functionPrinterControl.UserRange = range;
            }
        }
    }
}
