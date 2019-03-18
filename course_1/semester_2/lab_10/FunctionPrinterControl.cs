using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab_10
{
    public partial class FunctionPrinterControl : UserControl
    {
        public delegate float PrintedFunction(float arg);

        public FunctionPrinterControl()
        {
            InitializeComponent();
            SizeChanged += (sender, e) => Refresh();
            Paint += FunctionPrinter_Paint;
            DoubleBuffered = true;
        }

        private void FunctionPrinter_Paint(object sender, PaintEventArgs e)
        {
            if (Function == null)
            {
                return;
            }

            var g = new ClientSpaceGraphics(e.Graphics, UserRange, ClientSize);

            // Draw axes
            using (var penOverride = new ClientSpaceGraphics.PenOverride(g, new Pen(Brushes.DeepSkyBlue)))
            {
                // X
                {
                    var pi = (float)Math.PI;
                    g.PrintText(-pi, 0, "-pi  ", SystemFonts.DefaultFont);
                    g.PrintText(-pi / 2, 0, "-pi/2", SystemFonts.DefaultFont);
                    g.PrintText(pi / 2, 0, "pi/2", SystemFonts.DefaultFont);
                    g.PrintText(pi, 0, "pi  ", SystemFonts.DefaultFont);
                    g.DrawLine(UserRange.Left, 0.0f, UserRange.Right, 0.0f);
                }

                // Y
                {

                    float dy = 0.5f;
                    float y = ((int)UserRange.Y) - 1;
                    while (y < UserRange.Y + UserRange.Height)
                    {
                        g.PrintText(0, y, y.ToString(), SystemFonts.DefaultFont);
                        y += dy;
                    }
                    g.DrawLine(0, UserRange.Bottom, 0.0f, UserRange.Top);
                }
            }

            // Draw function curve
            using (var penOverride = new ClientSpaceGraphics.PenOverride(g, new Pen(Color.FromArgb(127, Color.Black))))
            {
                var cachedArgsArray = new object[1];
                float dx = 1.0f / SegmentsCount;
                g.DrawFunctionLine(dx, x => Function(x));
            }
        }

        public PrintedFunction Function
        {
            get { return _Function; }
            set { _Function = value; Refresh(); }
        }

        public RectangleF UserRange
        {
            get { return _UserRange; }
            set { _UserRange = value; Refresh(); }
        }

        public uint SegmentsCount
        {
            get { return _SegmentsCount; }
            set { _SegmentsCount = value; Refresh(); }
        }

        private PrintedFunction _Function;
        private RectangleF _UserRange;
        private uint _SegmentsCount = 1000;
    }
}
