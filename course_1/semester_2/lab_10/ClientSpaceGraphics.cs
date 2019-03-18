using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace lab_10
{
    class ClientSpaceGraphics
    {
        public class PenOverride : IDisposable
        {
            public PenOverride(ClientSpaceGraphics g, Pen pen)
            {
                Graphics = g;
                PrevPen = g.Pen;
                g.Pen = pen;
            }

            public void Dispose()
            {
                Graphics.Pen = PrevPen;
            }

            ClientSpaceGraphics Graphics;
            Pen PrevPen;
        }

        public delegate float UserFunction(float arg);

        Size ClientSize;
        RectangleF UserRange;
        Graphics Graphics;
        bool FlipX = false;
        bool FlipY = true;
        Pen Pen = new Pen(Brushes.Black);

        public ClientSpaceGraphics(Graphics graphics, RectangleF userRange, Size windowClientSize)
        {
            Graphics = graphics;
            UserRange = userRange;
            ClientSize = windowClientSize;
        }

        public void DrawLine(float x1, float y1, float x2, float y2)
        {
            var points = new PointF[2];
            points[0] = new PointF(x1, y1);
            points[1] = new PointF(x2, y2);
            TransformToClientSpace(points, UserRange, ClientSize, FlipX, FlipY);
            Graphics.DrawLine(Pen, points[0], points[1]);
        }

        public void PrintText(float x, float y, string text, Font font)
        {
            var points = new PointF[1];
            points[0] = new PointF(x, y);
            TransformToClientSpace(points, UserRange, ClientSize, FlipX, FlipY);
            Graphics.DrawString(text, font, Pen.Brush, points[0]);
        }

        private static Matrix MakeWindowTransform(RectangleF userRange, Size clientSize)
        {
            var mtx = new Matrix();
            mtx.Translate(-(userRange.X / userRange.Width) * clientSize.Width, -(userRange.Y / userRange.Height) * clientSize.Height);
            mtx.Scale(clientSize.Width / userRange.Width, clientSize.Height / userRange.Height);
            return mtx;
        }

        private static float FlipCoord(float val, float max, bool cond)
        {
            return cond ? max - val : val;
        }

        private static void TransformToClientSpace(PointF[] points, RectangleF userRange, Size windowClientSize, bool flipX, bool flipY)
        {
            var mtx = MakeWindowTransform(userRange, windowClientSize);
            mtx.TransformPoints(points);

            if (flipX || flipY)
            {
                for (int i = 0; i < points.Length; ++i)
                {
                    points[i].X = FlipCoord(points[i].X, windowClientSize.Width, flipX);
                    points[i].Y = FlipCoord(points[i].Y, windowClientSize.Height, flipY);
                }
            }
        }

        public void DrawFunctionLine(float dx, UserFunction fn)
        {
            float x = UserRange.Left;
            float prevX = x;
            float prevY = fn(x);

            while (x < UserRange.Right)
            {
                var y = fn(x);
                DrawLine(prevX, prevY, x, y);

                prevX = x;
                prevY = y;
                x += dx;
            }
        }
    }
}
