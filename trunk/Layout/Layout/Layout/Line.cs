using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Layout
{
[Serializable()]
    public class Line
    {

        private Point point1, point2;

        public Point Point2
        {
            get { return point2; }
            set { point2 = value; }
        }

        public Point Point1
        {
            get { return point1; }
            set { point1 = value; }
        }

        public Line(Point point1, Point point2)
        {
            this.point1 = point1;
            this.point2 = point2;
        
        
        }


        public Line(int x1, int y1, int x2, int y2)
        {
            this.point1 = new Point(x1, y1);
            this.point2 = new Point(x2, y2);


        }

        public override string ToString()
        {
            return String.Format("Line ({0},{1};{2},{3}) ",point1.X,point1.Y,point2.X,point2.Y);
        }

        public string ToString(int scale)
        {
            return String.Format("Line ({0},{1};{2},{3}) Length ={4:0.00} km  ", point1.X, point1.Y, point2.X, point2.Y, GetLength(point1.X, point1.Y, point2.X, point2.Y));
        }

        private double GetLength(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt(Math.Pow((y2 - y1), 2) + Math.Pow((x2 - x1), 2)); 
        }

    


    }
}
