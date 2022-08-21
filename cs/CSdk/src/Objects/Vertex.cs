using System;
using System.Collections.Generic;
using CSDK.Objects;

namespace CSDK
{
    namespace Objects
    {
        public class Vertex
        {
            private Point slope;
            private Line points;
            private double angle, distance;

            private void SetupVertex(Point x, Point y) {
                slope = new Point(y[0] - x[0], y[1] - x[1], y[2] - x[2]);
                distance = slope[1] / slope[0];
                angle = 0;//fix
            }

            public Vertex() {
                this.points = new Line(new Point(), new Point());
                SetupVertex(points[0], points[1]);
            }

            public Vertex(Point x, Point y) {
                this.points = new Line(x, y);
                SetupVertex(x, y);
            }

            public Vertex(Point x, Point y, int angle)
            {
                this.points = new Line(x, y);
                SetupVertex(x, y);
                this.angle = angle;
            }

            public Point Slope {
                get { return slope; }
                set { slope = value; }
            }

            public Line Value {
                get { return points; }
                set { points = value; }
            }

            public static Vertex operator +(Vertex x, Vertex y)
            {
                Point _xx = x.Value.Values[0];
                Point _xy = x.Value.Values[1];
                Point _yx = y.Value.Values[0];
                Point _yy = y.Value.Values[1];
                return new Vertex((_xx + _yx), (_xy + _yy));
            }

            public static Vertex operator -(Vertex x, Vertex y)
            {
                Point _xx = x.Value.Values[0];
                Point _xy = x.Value.Values[1];
                Point _yx = y.Value.Values[0];
                Point _yy = y.Value.Values[1];
                return new Vertex((_xx - _yx), (_xy - _yy));
            }

            public static Vertex operator *(Vertex x, Vertex y)
            {
                Point _xx = x.Value.Values[0];
                Point _xy = x.Value.Values[1];
                Point _yx = y.Value.Values[0];
                Point _yy = y.Value.Values[1];
                return new Vertex((_xx * _yx), (_xy * _yy));
            }

            public static Vertex operator /(Vertex x, Vertex y)
            {
                Point _xx = x.Value.Values[0];
                Point _xy = x.Value.Values[1];
                Point _yx = y.Value.Values[0];
                Point _yy = y.Value.Values[1];
                return new Vertex((_xx / _yx), (_xy / _yy));
            }

            public static Vertex operator %(Vertex x, Vertex y)
            {
                Point _xx = x.Value.Values[0];
                Point _xy = x.Value.Values[1];
                Point _yx = y.Value.Values[0];
                Point _yy = y.Value.Values[1];
                return new Vertex((_xx % _yx), (_xy % _yy));
            }

            public static bool operator <(Vertex x, Vertex y)
            {
                Point _xx = x.Value.Values[0];
                Point _xy = x.Value.Values[1];
                Point _yx = y.Value.Values[0];
                Point _yy = y.Value.Values[1];
                return ((_xx + _yx) < (_xy + _yy)) ? true : false;
            }

            public static bool operator >(Vertex x, Vertex y)
            {
                Point _xx = x.Value.Values[0];
                Point _xy = x.Value.Values[1];
                Point _yx = y.Value.Values[0];
                Point _yy = y.Value.Values[1];
                return ((_xx + _yx) > (_xy + _yy)) ? true : false;
            }

            public static bool operator <=(Vertex x, Vertex y)
            {
                Point _xx = x.Value.Values[0];
                Point _xy = x.Value.Values[1];
                Point _yx = y.Value.Values[0];
                Point _yy = y.Value.Values[1];
                return ((_xx + _yx) <= (_xy + _yy)) ? true : false;
            }

            public static bool operator >=(Vertex x, Vertex y)
            {
                Point _xx = x.Value.Values[0];
                Point _xy = x.Value.Values[1];
                Point _yx = y.Value.Values[0];
                Point _yy = y.Value.Values[1];
                return ((_xx + _yx) >= (_xy + _yy)) ? true : false;
            }

            public static bool operator ==(Vertex x, Vertex y)
            {
                Point _xx = x.Value.Values[0];
                Point _xy = x.Value.Values[1];
                Point _yx = y.Value.Values[0];
                Point _yy = y.Value.Values[1];
                return ((_xx + _yx) == (_xy + _yy)) ? true : false;
            }

            public static bool operator !=(Vertex x, Vertex y)
            {
                Point _xx = x.Value.Values[0];
                Point _xy = x.Value.Values[1];
                Point _yx = y.Value.Values[0];
                Point _yy = y.Value.Values[1];
                return ((_xx + _yx) != (_xy + _yy)) ? true : false;
            }

            public override bool Equals(object obj)
            {
                return base.Equals(obj);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public static explicit operator Vertex(Point[] p) {
                return new Vertex(p[0], p[1]);
            }

            public static explicit operator Point[](Vertex v) {
                return new Point[] { new Point(v.points[0]), new Point(v.points[1]) };
            }

            public Point this[int index]
            {
                get { return points[index]; }
                set { points[index] = value; }
            }
        }
	}
}
