using System.Drawing;
using System.Windows.Forms;

namespace lab_13
{
    public partial class Form1 : Form
    {
        static readonly float ImageFactor = 1 / 3.0f;
        public Form1()
        {
            InitializeComponent();
            Paint += Form1_Paint;
            Image = image_provider.ImageProvider.Image;
            MouseDown += Form1_MouseDown;
            MouseMove += Form1_MouseMove;
            MouseUp += Form1_MouseUp;
            DoubleBuffered = true;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (Pressed)
            {
                ImagePoint.X += e.X - PressedLocation.X;
                ImagePoint.Y += e.Y - PressedLocation.Y;
                Pressed = false;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Pressed)
            {
                Refresh();
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                Pressed = true;
                PressedLocation = e.Location;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var p = ImagePoint;

            if(Pressed)
            {
                var cursor = PointToClient(Cursor.Position);
                p.X += cursor.X - PressedLocation.X;
                p.Y += cursor.Y - PressedLocation.Y;
            }

            var maxX = ClientRectangle.Width * (1 - ImageFactor);
            var maxY = ClientRectangle.Height * (1 - ImageFactor);
            var maxLocation = new PointF(maxX, maxY);
            var location = new PointF(p.X, p.Y);
            var size = new SizeF(ClientRectangle.Width * ImageFactor, ClientRectangle.Height * ImageFactor);
            var region = new RectangleF(location, size);
            e.Graphics.DrawImage(Image, region);
        }

        bool Pressed = false;
        Point PressedLocation;
        PointF ImagePoint;
        Bitmap Image;
    }
}
