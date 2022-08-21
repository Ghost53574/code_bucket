using System;
using System.Runtime.Serialization;
using CSDK.Common;

namespace CSDK {
	namespace Game {
        [Serializable]
		public class Events {
			private string name;
			private Location location;
			private Handler data;

			public Events() {
                name = "";
                location = new Location();
                data = null;
			}

            public Events(string name) {
                this.name = name;
                location = new Location();
                data = null;
            }

            public Events(string name, Location location) {
                this.name = name;
                this.location = location;
                data = null;
            }

            public Events(Events events) {
                this.name = events.Name;
                this.location = events.Locate;
                this.data = events.Data;
            }

            public string Name {
                get { return name; }
                set { name = value; }
            }

            public Location Locate {
                get { return location; }
                set { location = value; }
            }

            public Handler Data {
                get { return data; }
                set { data = value; }
            }
		}
	}
}
