using System.Drawing;
using System.Timers;
using System.Windows.Forms;

namespace lab_11
{
    public partial class Form1 : Form
    {
        // Relative image size
        static readonly float ImageFactor = 1 / 3.0f;
        static readonly float Dt = 0.30f;
        static readonly System.TimeSpan Tick = System.TimeSpan.FromMilliseconds(16.0);

        public Form1()
        {
            InitializeComponent();
            Paint += Form1_Paint;
            DoubleBuffered = true;
            Image = image_provider.ImageProvider.Image;
            Timer = new System.Timers.Timer(Tick.Milliseconds);
            Timer.Elapsed += Timer_Elapsed;
            Timer.AutoReset = true;
            Timer.Enabled = true;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if(!IsDisposed)
            {
                Invoke((MethodInvoker)delegate
                {
                    t += Dt * Tick.Milliseconds / 1000.0f;
                    Refresh();
                });
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var maxX = ClientRectangle.Width * (1 - ImageFactor);
            var maxY = ClientRectangle.Height * (1 - ImageFactor);
            var maxLocation = new PointF(maxX, maxY);
            var location = new PointF(t * maxX, t * maxY);
            var size = new SizeF(ClientRectangle.Width * ImageFactor, ClientRectangle.Height * ImageFactor);
            var region = new RectangleF(location, size);
            e.Graphics.DrawImage(Image, region);
        }

        float t = 0.0f;
        Bitmap Image;
        System.Timers.Timer Timer;
    }
}
