using System.Drawing;
using System.Windows.Forms;

namespace lab_12
{
    public partial class Form1 : Form
    {
        static readonly float ImageFactor = 1 / 3.0f;
        static readonly float dx = 1 / 100.0f;
        static readonly float dy = 1 / 100.0f;

        public Form1()
        {
            InitializeComponent();
            Paint += Form1_Paint;
            DoubleBuffered = true;
            Image = image_provider.ImageProvider.Image;
            ImagePoint = new PointF(0.0f, 0.0f);
        }

        protected override bool IsInputKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Right:
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                    return true;

                case Keys.Shift | Keys.Right:
                case Keys.Shift | Keys.Left:
                case Keys.Shift | Keys.Up:
                case Keys.Shift | Keys.Down:
                    return true;
            }
            return base.IsInputKey(keyData);
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            switch (e.KeyCode)
            {
                case Keys.Left:
                    ImagePoint.X -= dx;
                    Refresh();
                    break;

                case Keys.Right:
                    ImagePoint.X += dx;
                    Refresh();
                    break;

                case Keys.Up:
                    ImagePoint.Y -= dy;
                    Refresh();
                    break;

                case Keys.Down:
                    ImagePoint.Y += dy;
                    Refresh();
                    break;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var maxX = ClientRectangle.Width * (1 - ImageFactor);
            var maxY = ClientRectangle.Height * (1 - ImageFactor);
            var maxLocation = new PointF(maxX, maxY);
            var location = new PointF(ImagePoint.X * maxX, ImagePoint.Y * maxY);
            var size = new SizeF(ClientRectangle.Width * ImageFactor, ClientRectangle.Height * ImageFactor);
            var region = new RectangleF(location, size);
            e.Graphics.DrawImage(Image, region);
        }

        PointF ImagePoint;
        Bitmap Image;
    }
}
