using System;
using System.Runtime.Serialization;

namespace CSDK {
	namespace Objects {
		[Serializable]
		public class Point {
			private double x = 0.0, y = 0.0, z = 0.0;

			public Point() {
				x = 0.0;
				y = 0.0;
				z = 0.0;
			}

			public Point(Point point) {
				double[] points = point.Values;
				x = points[0];
				y = points[1];
				z = points[2];
			}

            public Point(double x) {
                this.x = x;
                y = 0.0;
                z = 0.0;
            }

			public Point(double x, double y) {
				this.x = x;
				this.y = y;
				z = 0.0;
			}

			public Point(double x, double y, double z) {
				this.x = x;
				this.y = y;
				this.z = z;
			}

            public static Point operator +(Point p1, Point p2) {
                return new Point(p1.x + p2.x, p1.y + p2.y, p1.z + p2.z);
            }

            public static Point operator -(Point p1, Point p2) {
                return new Point(p1.x - p2.x, p1.y - p2.y, p1.z - p2.z);
            }

            public static Point operator *(Point p1, Point p2) {
                return new Point(p1.x * p2.x, p1.y * p2.y, p1.z * p2.z);
            }

            public static Point operator /(Point p1, Point p2) {
                return new Point(p1.x / p2.x, p1.y / p2.y, p1.z / p2.z);
            }

            public static Point operator %(Point p1, Point p2) {
                return new Point(p1.x % p2.x, p1.y % p2.y, p1.z % p2.z);
            }

            public static bool operator >(Point p1, Point p2) {
                return ((p1.x + p1.y + p1.z) > (p2.x + p2.y + p2.z)) ? true : false;
            }

            public static bool operator >=(Point p1, Point p2) {
                return ((p1.x + p1.y + p1.z) >= (p2.x + p2.y + p2.z)) ? true : false;
            }

            public static bool operator <=(Point p1, Point p2) {
                return ((p1.x + p1.y + p1.z) <= (p2.x + p2.y + p2.z)) ? true : false;
            }

            public static bool operator <(Point p1, Point p2) {
                return ((p1.x + p1.y + p1.z) < (p2.x + p2.y + p2.z)) ? true : false;
            }

            public static bool operator ==(Point p1, Point p2) {
                return ((p1.x + p1.y + p1.z) == (p2.x + p2.y + p2.z)) ? true : false;
            }

            public static bool operator !=(Point p1, Point p2) {
                return ((p1.x + p1.y + p1.z) != (p2.x + p2.y + p2.z)) ? true : false;
            }

            public override bool Equals(object obj)
            {
                return base.Equals(obj);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public static explicit operator Point(double[] v) {
                if (v.Length != 3)
                    throw new Exception("Array length does not equal 3");
                return new Point(v[0], v[1], v[2]);
            }

            public static explicit operator double[](Point p) {
                return new double[] { p.x, p.y, p.z };
            }

            public Point GetPoint {
				get { return this; }
			}

            public double this[int index] {
                get {
                    double temp = 0;
                    switch(index) {
                        case 0:
                            temp = x;
                            break;
                        case 1:
                            temp = y;
                            break;
                        case 2:
                            temp = z;
                            break;
                    }
                    return temp;
                }
                set {
                    switch(value) {
                        case 0:
                            x = value;
                            break;
                        case 1:
                            y = value;
                            break;
                        case 2:
                            z = value;
                            break;

                    }
                }
            }

			public double[] Values
            {
                get
                {
                    return new double[] { x, y, z };
                }
            }
		}
	}
}
