using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace CSDK {
	namespace Objects {
		[Serializable]
		public class Position {
			private Bracket line;
			private List<KeyValuePair<Direction.Sides, Point>> sides;
			private List<KeyValuePair<Direction.Corners, Point>> corners;
			private double x, y, z;

			public Position(KeyValuePair<int, Object> blob) {
				object o = blob;
				Cube cube;
				Sphere sphere;
				Cone cone;
				Pyrimad pyrimad;
				if (o != null) {
					if (o.GetType() == typeof(Cube)) {
						cube = (Cube)o;
						x = cube.Length;
						y = cube.Height;
						z = cube.Depth;
						line = cube.Values.GetBracket;
						sides = cube.GetSides;
						corners = cube.GetCorners;
					}
					else if (o.GetType() == typeof(Sphere)) {
						sphere = (Sphere)o;
						x = sphere.Length;
						y = sphere.Height;
						z = sphere.Depth;
						line = sphere.Values.GetBracket;
						sides = sphere.GetSides;
						corners = sphere.GetCorners;
					}
					else if (o.GetType() == typeof(Pyrimad)) {
						pyrimad = (Pyrimad)o;
						x = pyrimad.Length;
						y = pyrimad.Height;
						z = pyrimad.Depth;
						line = pyrimad.Values.GetBracket;
						sides = pyrimad.GetSides;
						corners = pyrimad.GetCorners;
					}
					else if (o.GetType() == typeof(Cone)) {
						cone = (Cone)o;
						x = cone.Length;
						y = cone.Height;
						z = cone.Depth;
						line = cone.Values.GetBracket;
						sides = cone.GetSides;
						corners = cone.GetCorners;
					}
				} else {
					x = 0.0;
					y = 0.0;
					z = 0.0;
				}
			}

			public double X {
				get { return x; }
			}

			public double Y {
				get { return y; }
			}

			public double Z {
				get { return z; }
			}

			public Bracket Line {
				get { return line; }
			}

			public List<KeyValuePair<Direction.Sides, Point>> Sides {
				get { return sides; }
			}

			public List<KeyValuePair<Direction.Corners, Point>> Corners {
				get { return corners; }
			}
		}
	}
}
