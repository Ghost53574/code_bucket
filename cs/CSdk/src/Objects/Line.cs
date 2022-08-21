using System;
using System.Runtime.Serialization;

namespace CSDK {
    namespace Objects {
        [Serializable]
        public class Line {
            private Point x, y;

            public Line () {
                x = new Point();
                y = new Point();
            }

            public Line(Line line) {
                Point[] points = line.Values;
                x = new Point(points[0]);
                y = new Point(points[1]);
            }

            public Line (Point x, Point y) {
                this.x = x;
                this.y = y;
            }

            public Line GetLine {
                get { return this; }
            }

            public static Line operator +(Line x, Line y) {
                return new Line((x.x + y.x), (y.x + y.y));
            }

            public static Line operator -(Line x, Line y) {
                return new Line((x.x - y.x), (x.y - y.y));
            }

            public static Line operator *(Line x, Line y) {
                return new Line((x.x * x.y), (y.x * y.y));
            }

            public static Line operator /(Line x, Line y) {
                return new Line((x.x / y.x), (y.x / y.y));
            }

            public static Line operator %(Line x, Line y) {
                return new Line(x.x % y.x, x.y % y.y); 
            }

            public static bool operator <(Line x, Line y) {
                return ((x.x + y.x) < (x.y + y.y)) ? true : false; 
            }

            public static bool operator >(Line x, Line y) {
                return ((x.x + y.x) > (x.y + y.y)) ? true : false;
            }

            public static bool operator <=(Line x, Line y) {
                return ((x.x + y.x) <= (x.y + y.y)) ? true : false;
            }

            public static bool operator >=(Line x, Line y) {
                return ((x.x + y.x) >= (x.y + y.y)) ? true : false;
            }

            public static bool operator ==(Line x, Line y) {
                return ((x.x + y.x) == (x.y + y.y)) ? true : false;
            }

            public static bool operator !=(Line x, Line y) {
                return ((x.x + y.x) != (x.y + y.y)) ? true : false;
            }

            public override bool Equals(object obj)
            {
                return base.Equals(obj);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public static explicit operator Line(Point[] p) {
                if (p.Length != 2)
                    throw new Exception("Array length is not two");
                return new Line(p[0], p[1]);
            }

            public static explicit operator Point[](Line l) {
                return new Point[2] { l.x, l.y };
            }

            public Point this[int index] {
                get {
                    Point t = null;
                    if (index == 0)
                        t = x;
                    if (index == 1)
                        t = y;
                    return t;
                }
                set {
                    if (index == 0)
                        x = value;
                    if (index == 1)
                        y = value;
                }
            }

            public Point[] Values {
                get { return new Point[] { x, y }; }
            }
        }
    }
}
