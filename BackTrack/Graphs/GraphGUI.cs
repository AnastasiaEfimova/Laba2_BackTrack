using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace EmilGraph.Graphs
{
    class GraphGUI : Graph
    {
        private PictureBox picture;
        private Image image;
        private Graphics graphics;
        private Pen pen;
        private StringFormat stringFormat;

        private const int eps = 2;
        private int topRadius;
        private int edgeWidth;
        public GraphGUI(PictureBox picture, int topRadius, int edgeWidth) : base(picture.Width, picture.Height)
        {
            this.picture = picture;
            this.image = new Bitmap(picture.Width, picture.Height);
            this.topRadius = topRadius;
            this.edgeWidth = edgeWidth;
            graphics = Graphics.FromImage(image);
            pen = Pens.Black;
            stringFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            View();
        }
        private Brush[] brushesColors =
        {
            Brushes.Red, Brushes.Green, Brushes.Blue,
            Brushes.BlueViolet, Brushes.Purple, Brushes.Yellow,
            Brushes.Orange, Brushes.Pink, Brushes.RoyalBlue,
            Brushes.Honeydew, Brushes.Gray, Brushes.Brown,
        };
        private void DrawTop(Point point, int i = 0)
        {
            graphics.FillEllipse(Brushes.White, point.X - topRadius, point.Y - topRadius, topRadius * 2, topRadius * 2);
            graphics.DrawEllipse(pen, point.X - topRadius, point.Y - topRadius, topRadius * 2, topRadius * 2);
        }
        private void DrawEdge(Point p1, Point p2, double distance)
        {
            Pen pen = new Pen(Color.Black, edgeWidth);
            graphics.DrawLine(pen, p1, p2);
            graphics.DrawString(distance.ToString(), SystemFonts.DefaultFont, Brushes.Black, new Point((p2.X + p1.X) / 2,(p2.Y + p1.Y) / 2));
            pen.Dispose();
        }
        public void View()
        {
            graphics.Clear(Color.White);
            foreach (Tuple<int, int, double> tuple in edgeList)
            {
                DrawEdge(topList[tuple.Item1], topList[tuple.Item2], tuple.Item3);
            }
            int k = 0;
            foreach (Point point in topList)
            {
                DrawTop(point, k);
                Font font = new Font(FontFamily.GenericSansSerif, 15F, FontStyle.Regular); 
                graphics.DrawString(k++.ToString(), font, Brushes.Black, point, stringFormat);
                font.Dispose();
            }
            picture.Image = image;
        }
        public void Task(int topIndex, double distance)
        {
            Solve(topIndex, distance);
        }
        public override bool Add(Point point)
        {
            if (EpsTop(ref point, topRadius * eps))
            {
                return false;
            }
            bool res = base.Add(point);
            if (res)
            {
                View();
            }
            return res;
        }
        public override bool Load(string filename)
        {
            bool res = base.Load(filename);
            if (res)
            {
                View();
            }
            return res;
        }
        public override void Clear()
        {
            base.Clear();
            View();
        }
        public override bool Delete(Point point)
        {
            bool res = base.Delete(point);
            if (!res && EpsTop(ref point, topRadius * eps))
            {
                base.Delete(point);
            }
            View();
            return res;
        }
        public override bool Delete(int top)
        {
            bool res = base.Delete(top);
            if (res)
            {
                View();
            }
            return res;
        }
        public override bool Connect(Point top1, Point top2, double distance)
        {
            bool res = base.Connect(top1, top2, distance);
            if (res)
            {
                View();
            }
            return res;
        }
        public override bool Connect(int top1, int top2, double distance)
        {
            bool res = base.Connect(top1, top2, distance);
            if (res)
            {
                View();
            }
            return res;
        }
        public override bool Disconnect(Point top1, Point top2)
        {
            bool res = base.Disconnect(top1, top2);
            if (res)
            {
                View();
            }
            return res;
        }
        public override bool Disconnect(int top1, int top2)
        {
            bool res = base.Disconnect(top1, top2);
            if (res)
            {
                View();
            }
            return res;
        }
        public bool CheckSolve(int[] colors)
        {
            for (int i = 0; i < topList.Count; i++)
            {
                if (colors[i] == 0)
                {
                    break;
                }
                int index = -1;
                do
                {
                    if (index == edgeList.Count)
                    {
                        break;
                    }
                    index = edgeList.FindIndex(++index, x => x.Item1 == i || x.Item2 == i);
                    if (index != -1)
                    {
                        int top = i == edgeList[index].Item1 ? edgeList[index].Item2 : edgeList[index].Item1;
                        if (colors[i] == colors[top])
                        {
                            return false;
                        }
                    }
                } while (index != -1);
            }
            return true;
        }
        
        public void Solve(int topIndex, double distance)
        {
            topSet = new HashSet<int>();
            visitedSet = new HashSet<int>();
            TrySolve(topIndex, distance);
            topSet.Remove(topIndex);
            string text = "Веришны, входящие в периферию " + topIndex.ToString() + " города: ";
            foreach (int i in topSet)
            {
                text += i.ToString() + " ";
            }
            MessageBox.Show(text);
        }
        HashSet<int> topSet;
        HashSet<int> visitedSet;
        private void TrySolve(int topIndex, double distance)
        {
            if (distance < 0 && !visitedSet.Contains(topIndex))
            {
                topSet.Add(topIndex);
            }
            visitedSet.Add(topIndex);
            foreach (Tuple<int, int, double> tuple in edgeList.FindAll(t => t.Item1 == topIndex || t.Item2 == topIndex))
            {
                if (tuple.Item1 != topIndex && !visitedSet.Contains(tuple.Item1))
                {
                    TrySolve(tuple.Item1, distance - tuple.Item3);
                }
                else if (!visitedSet.Contains(tuple.Item2))
                {
                    TrySolve(tuple.Item2, distance - tuple.Item3);
                }
            }
        }
    }
}
