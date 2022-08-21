using System;
using System.Runtime.Serialization;
using CSDK.Common;

namespace CSDK {
	namespace Game {
		[Serializable]
		public class Map {
			private string name;
			private string description;
			private Events[] events;
			private Location[] locations;
			private Handler[] data;	

			public Map() {
				this.name = String.Empty;
				this.description = String.Empty;
			}

			public Map(string name, string description, Events[] events, CSDK.Game.Location[] locations, Handler[] data) {
				this.name = name;
				this.description = description;
				this.events = events;
				this.locations = locations;
				this.data = data;
			}

			public string[] Info {
				get { return new string[] { name, description }; }
				set {
					string[] temp = value;
					if (temp.Length == 2) {
						name = temp[0];
						description = temp[1];
					}
				}
			}

			public Events[] Event {
				get { return events; }
				set { events = value; }
			}

			public Location[] Locations {
				get { return locations; }
				set { locations = value; }
			}

			public Handler[] GetData {
				get { return data; }
				set { data = value; }
			}
		}
	}
}
