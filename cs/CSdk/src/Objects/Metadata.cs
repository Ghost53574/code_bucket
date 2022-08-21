using System;
using CSDK.Common;
using System.Runtime.Serialization;

namespace CSDK {
	namespace Objects {
		[Serializable]
		public class Metadata {
			private string name;
			private Point x, y, z;
			private Handler data;

			public Metadata (string name) {
				this.name = name;
				x = new Point();
				y = new Point();
				z = new Point();
				data = new Handler();
			}

			public Metadata(string name, Point x, Point y, Point z, Handler data) {
				this.name = name;
				this.x = x;
				this.y = y;
				this.z = z;
				this.data = data;
			}

			public string Name  { 
				get { return name; }
			}

			public Point[] Points {
				get { return new Point[] { x, y, z }; }
			}

			public Handler Data {
				get { return data; }
			}
		}
	}
}
