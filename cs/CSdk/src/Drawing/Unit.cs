using System;
using CSDK.Objects;

namespace CSDK {
	namespace Drawing {
		public class Unit {
			private Point norm;
			private Point point;

			public Unit(Point point, Normalization norm) {
				this.point = point;
				this.norm = norm.Normalize (point);
			}

			public Point[] GetPoints {
				get { return new Point[] { point, norm }; }
			}
		}
	}
}
