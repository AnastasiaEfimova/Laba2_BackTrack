using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace EmilGraph.Graphs
{
    class Graph
    {
        private int maxX;
        private int maxY;
        protected List<Point> topList;
        protected List<Tuple<int, int, double>> edgeList;

        public int Count
        {
            get
            {
                return topList.Count;
            }
        }

        public Graph(int maxX, int maxY)
        {
            this.maxX = maxX;
            this.maxY = maxY;
            topList = new List<Point>();
            edgeList = new List<Tuple<int, int, double>>();
        }

        protected bool EpsTop(ref Point point, int eps)
        {
            foreach (Point topPoint in topList)
            {
                if (Math.Abs(topPoint.X - point.X) <= eps && Math.Abs(topPoint.Y - point.Y) <= eps)
                {
                    point = topPoint;
                    return true;
                }
            }
            return false;
        }
        protected void ChangeIndexes(int index)
        {
            for (int i = 0; i < edgeList.Count; i++)
            {
                if (edgeList[i].Item1 > index)
                {
                    int k = edgeList[i].Item1 - 1;
                    edgeList[i] = new Tuple<int, int, double>(k, edgeList[i].Item2, edgeList[i].Item3);
                }
                if (edgeList[i].Item2 > index)
                {
                    int k = edgeList[i].Item2 - 1;
                    edgeList[i] = new Tuple<int, int, double>(edgeList[i].Item1, k, edgeList[i].Item3);
                }
            }
        }

        public virtual bool Add(Point point)
        {
            if (topList.Contains(point) || point.X > maxX || point.Y > maxY)
            {
                return false;
            }
            topList.Add(point);
            return true;
        }

        public virtual bool Delete(Point point)
        {
            int index = topList.FindIndex(x => x == point);
            if (index != -1)
            {
                topList.RemoveAt(index);
                edgeList.RemoveAll(x => x.Item1 == index || x.Item2 == index);
                ChangeIndexes(index);
                return true;
            }
            return false;
        }
        public virtual bool Delete(int top)
        {
            return Delete(topList[top]);
        }
        public virtual bool Connect(Point top1, Point top2, double distance)
        {
            int num1 = topList.FindIndex(x => x == top1);
            int num2 = topList.FindIndex(x => x == top2);
            Tuple<int, int, double> edge1 = new Tuple<int, int, double>(num1, num2, distance);
            Tuple<int, int, double> edge2 = new Tuple<int, int, double>(num2, num1, distance);
            if (edgeList.Contains(edge1) || edgeList.Contains(edge2))
            {
                return false;
            }
            edgeList.Add(edge1);
            return true;
        }
        public virtual bool Connect(int top1, int top2, double distance)
        {
            return Connect(topList[top1], topList[top2], distance);
        }
        public virtual bool Disconnect(Point top1, Point top2)
        {
            int num1 = topList.FindIndex(x => x == top1);
            int num2 = topList.FindIndex(x => x == top2);
            Tuple<int, int, double> edge1 = new Tuple<int, int, double>(num1, num2, 0);
            Tuple<int, int, double> edge2 = new Tuple<int, int, double>(num2, num1, 0);
            int index = edgeList.FindIndex(p => p.Item1 == edge1.Item1 && p.Item2 == edge1.Item2);
            if (index != -1)
            {
                edgeList.RemoveAt(index);
                return true;
            }
            index = edgeList.FindIndex(p => p.Item1 == edge2.Item1 && p.Item2 == edge2.Item2);
            if (index != -1)
            {
                edgeList.RemoveAt(index);
                return true;
            }
            return false;
        }
        public virtual bool Disconnect(int top1, int top2)
        {
            return Disconnect(topList[top1], topList[top2]);
        }
        public virtual bool Load(string filename)
        {
            StreamReader sr = new StreamReader(filename);
            string tempStr = sr.ReadLine();
            int num;
            if (!(Int32.TryParse(tempStr, out num) && num > 0))
            {
                Clear();
                return false;
            }
            for (int i = 0; i < num; i++)
            {
                tempStr = sr.ReadLine().Trim();
                string[] strings = tempStr.Split(' ');
                int x;
                int y;
                if (!(strings.Length > 1 && Int32.TryParse(strings[0], out x) && Int32.TryParse(strings[1], out y)))
                {
                    continue;
                }
                Add(new Point(x, y));
            }
            tempStr = sr.ReadLine();
            if (!(Int32.TryParse(tempStr, out num) && num >= 0))
            {
                Clear();
                return false;
            }
            for (int i = 0; i < num; i++)
            {
                tempStr = sr.ReadLine().Trim();
                string[] strings = tempStr.Split(' ');
                int top1;
                int top2;
                if (!(strings.Length > 0 && Int32.TryParse(strings[0], out top1) && Int32.TryParse(strings[1], out top2) &&
                    top1 <= topList.Count && top2 <= topList.Count && top1 >= 0 && top2 >= 0))
                {
                    continue;
                }
                Connect(top1, top2, 0);
            }
            sr.Dispose();
            return true;
        }
        public virtual void Clear()
        {
            edgeList.Clear();
            topList.Clear();
        }

        public virtual void Save(string filename)
        {
            StreamWriter sw = new StreamWriter(filename);
            sw.WriteLine(topList.Count);
            foreach (Point p in topList)
            {
                sw.WriteLine(p.X + " " + p.Y);
            }
            sw.WriteLine(edgeList.Count);
            foreach(Tuple<int, int, double> tuple in edgeList)
            {
                sw.WriteLine(tuple.Item1 + " " + tuple.Item2 + " " + tuple.Item3);
            }
            sw.Dispose();
        }
    }
}
