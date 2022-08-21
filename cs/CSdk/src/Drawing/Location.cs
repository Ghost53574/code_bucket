using System;
using System.Runtime.Serialization;
using CSDK.Objects;

namespace CSDK {
	namespace Drawing {
		[Serializable]
		public class Location {
			private Point current;

            public Location() {
                current = new Point();
            }

			public Location(double x, double y) {
				current = new Point (x, y);
			}

			public Location(double x, double y, double z) {
				current = new Point (x, y, z);
			}

			public Point CurrentLocation {
				get { return current; }
				set { current = value; }
			}
		}
	}
}
