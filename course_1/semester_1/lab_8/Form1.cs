using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab_8
{
    public partial class Form1 : Form
    {
        Pen pen;
        readonly bool LocalFlipX = false;
        readonly bool LocalFlipY = true;
        readonly uint SquaresCount = 50;
        readonly float P = 0.08f;

        public Form1()
        {
            InitializeComponent();
            Paint += Form1_Paint;
            pen = new Pen(Color.Black);
            DoubleBuffered = true;
        }

        unsafe void PointToGlobalSpace(PointF p, PointF* outPoint)
        {
            float px = LocalFlipX ? (1 - p.X) : p.X;
            float py = LocalFlipY ? (1 - p.Y) : p.Y;
            outPoint->X = ClientRectangle.X + px * ClientRectangle.Width;
            outPoint->Y = ClientRectangle.Y + py * ClientRectangle.Height;
        }

        unsafe void DrawLine(PaintEventArgs e, PointF p1, PointF p2)
        {
            var points = stackalloc PointF[2];
            PointToGlobalSpace(p1, points + 0);
            PointToGlobalSpace(p2, points + 1);
            e.Graphics.DrawLine(pen, points[0], points[1]);
        }

        unsafe void DrawPolyline(PaintEventArgs e, PointF* points, int pointsCount, bool closed)
        {
            if(pointsCount > 1)
            {
                for (int i = 1; i < pointsCount; ++i)
                {
                    DrawLine(e, points[i - 1], points[i]);
                }

                if (closed && pointsCount > 2)
                {
                    DrawLine(e, points[pointsCount - 1], points[0]);
                }
            }
        }

        unsafe void InitalizeFirstSquare(PointF* points)
        {
            var globalSide = (float)Math.Min(Width, Height);
            var localSideX = globalSide / Width;
            var localSideY = globalSide / Height;

            float x1 = (1.0f - localSideX) / 2;
            float x2 = x1 + localSideX;
            float y1 = (1.0f - localSideY) / 2;
            float y2 = y1 + localSideY;

            points[0] = new PointF(x1, y1);
            points[1] = new PointF(x2, y1);
            points[2] = new PointF(x2, y2);
            points[3] = new PointF(x1, y2);
        }

        unsafe void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (SquaresCount > 0)
            {
                int pointsCount = 4;
                var outerSquare = stackalloc PointF[pointsCount];
                var innerSquare = stackalloc PointF[pointsCount];
                InitalizeFirstSquare(outerSquare);
                DrawPolyline(e, outerSquare, pointsCount, true);

                for (int i = 0; i < (int)SquaresCount - 1; ++i)
                {
                    // Compute inner square
                    for (int j = 0; j < 4; ++j)
                    {
                        var p1 = outerSquare[j];
                        var p2 = outerSquare[(j + 1) % pointsCount];
                        innerSquare[j].X = p1.X + (p2.X - p1.X) * P;
                        innerSquare[j].Y = p1.Y + (p2.Y - p1.Y) * P;
                    }

                    DrawPolyline(e, innerSquare, pointsCount, true);
                    var tmp = outerSquare;
                    outerSquare = innerSquare;
                    innerSquare = tmp;
                }
            }
        }
    }
}
