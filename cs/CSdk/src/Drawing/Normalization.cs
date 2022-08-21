using System;
using CSDK.Objects;

namespace CSDK {
	namespace Drawing {
		public class Normalization {
			private double length;
			private double height;

			private void GetLength(double ax, double ay, double az) {
				length = Math.Sqrt((ax * ax) + (ay * ay) + (az * az));
			}

			public Normalization() {
			}

			public Point Normalize(Point point) {
				double[] temp = point.Values;
				GetLength(temp[0], temp[1], temp[2]);
				//GetHeight(temp[0], temp[1], temp[2]);
				return new Point(temp[0] / length, temp[1] / length, temp[2] / length);
			}

			public double Length {
				get { return length; }
			}
		}
	}
}
