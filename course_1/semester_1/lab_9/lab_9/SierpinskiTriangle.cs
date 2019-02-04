using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System;

namespace lab_9
{
    public partial class SierpinskiTriangle : Form
    {
        struct Triangle
        {
            public Triangle(PointF p1, PointF p2, PointF p3)
            {
                this.p1 = p1;
                this.p2 = p2;
                this.p3 = p3;
            }

            public PointF p1;
            public PointF p2;
            public PointF p3;
        }

        static readonly bool showRenderTime = true;
        static readonly uint DrawingDepth = 15;
        Pen pen;

        public SierpinskiTriangle()
        {
            InitializeComponent();
            Paint += Form1_Paint;
            pen = Pens.Black;
            //DoubleBuffered = true;
        }

        private void ConvertPoint(ref PointF p)
        {
            p.X = ClientRectangle.X + p.X * ClientRectangle.Width;
            p.Y = ClientRectangle.Y + (1 - p.Y) * ClientRectangle.Height;
        }

        private PointF GetLineCenter(PointF p1, PointF p2)
        {
            PointF p = new PointF(p1.X, p1.Y);
            p.X += (p2.X - p1.X) * 0.5f;
            p.Y += (p2.Y - p1.Y) * 0.5f;
            return p;
        }

        private void DrawTriangle(Graphics g, Triangle t)
        {
            g.DrawLine(pen, t.p1, t.p2);
            g.DrawLine(pen, t.p2, t.p3);
            g.DrawLine(pen, t.p3, t.p1);
        }

        private void DrawSierpinskiTriangle(Graphics g, uint depth, uint maxDepth, Triangle t)
        {
            DrawTriangle(g, t);
            if (depth < maxDepth)
            {
                ++depth;
                var p4 = GetLineCenter(t.p1, t.p2);
                var p5 = GetLineCenter(t.p2, t.p3);
                var p6 = GetLineCenter(t.p3, t.p1);
                DrawSierpinskiTriangle(g, depth, maxDepth, new Triangle(t.p1, p4, p6));
                DrawSierpinskiTriangle(g, depth, maxDepth, new Triangle(p6, p5, t.p3));
                DrawSierpinskiTriangle(g, depth, maxDepth, new Triangle(p4, t.p2, p5));
            }
        }

        private void DrawSierpinskiTriangleTwoQueues(Graphics g, uint maxDepth, Triangle root)
        {
            var queue = new List<Triangle>();
            queue.Add(root);
            var backQueue = new List<Triangle>();

            for(uint i = 0; i < maxDepth; ++i)
            {
                foreach(var t in queue)
                {
                    DrawTriangle(g, t);
                    var p1 = GetLineCenter(t.p1, t.p2);
                    var p2 = GetLineCenter(t.p2, t.p3);
                    var p3 = GetLineCenter(t.p3, t.p1);
                    backQueue.Add(new Triangle(t.p1, p1, p3));
                    backQueue.Add(new Triangle(p3, p2, t.p3));
                    backQueue.Add(new Triangle(p1, t.p2, p2));
                }

                queue.Clear();
                var tmp = queue;
                queue = backQueue;
                backQueue = tmp;
            }
        }

        private void DrawSierpinskiTriangleOneQueue(Graphics g, uint maxDepth, Triangle root)
        {
            var queue = new List<Triangle>();
            queue.Add(root);

            for (uint i = 0; i < maxDepth; ++i)
            {
                var count = queue.Count;
                for(int j = 0; j < count; ++j)
                {
                    var t = queue[j];
                    DrawTriangle(g, t);
                    var p4 = GetLineCenter(t.p1, t.p2);
                    var p5 = GetLineCenter(t.p2, t.p3);
                    var p6 = GetLineCenter(t.p3, t.p1);
                    queue.Add(new Triangle(t.p1, p4, p6));
                    queue.Add(new Triangle(p6, p5, t.p3));
                    queue.Add(new Triangle(p4, t.p2, p5));
                }

                queue.RemoveRange(0, count);
            }
        }

        private void DrawSierpinskiTriangle(Graphics g)
        {
            var t = new Triangle(MakePoint(0.0f, 0.0f), MakePoint(0.5f, 1.0f), MakePoint(1.0f, 0.0f));
            DrawSierpinskiTriangle(g, 0, DrawingDepth, t);
            //DrawSierpinskiTriangleOneQueue(g, DrawingDepth, t);
            //DrawSierpinskiTriangleTwoQueues(g, DrawingDepth, t);
        }

        private PointF MakePoint(float x, float y)
        {
            PointF point = new PointF(x, y);
            ConvertPoint(ref point);
            return point;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            if(showRenderTime)
            {
                var sw = new System.Diagnostics.Stopwatch();
                sw.Start();
                DrawSierpinskiTriangle(e.Graphics);
                sw.Stop();
                MessageBox.Show(sw.ElapsedMilliseconds.ToString());
            }
            else
            {
                DrawSierpinskiTriangle(e.Graphics);
            }
        }
    }
}
