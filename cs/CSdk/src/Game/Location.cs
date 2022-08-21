using System;
using System.Runtime.Serialization;
using CSDK.Common;
using CSDK.Objects;

namespace CSDK {
	namespace Game {
        [Serializable]
		public class Location {
			private string name;
			private string desc;
			private Point location;
			private Handler[] data;

			public Location() {
				name = String.Empty;
				desc = String.Empty;
				location = new Point();
			}

			public Location(string name, string desc, Point location, Handler[] data) {
				this.name = name;
				this.desc = desc;
				this.location = location;
				this.data = data;
			}

			public string[] GetInfo {
				get { return new string[] { name, desc }; }
				set {
					string[] temp = value;
					name = temp[0];
					desc = temp[1];
				}
			}

			public double[] GetLocation {
				get { return new double[] { location.Values[0], location.Values[1], location.Values[2] }; }
				set { location = new Point(value[0], value[1], value[2]); }
			}

			public Handler[] GetData {
				get { return data; }
				set { data = value; }
			}
		}
	}
}
