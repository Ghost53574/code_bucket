using System;
using System.Runtime.Serialization;
using CSDK.Objects;

namespace CSDK {
	namespace Drawing {
		[Serializable]
		public class Asset {
			private string name, desc;
			private Model[] models;
			private Location location;
            private Metadata data;

			public Asset (string name, string desc, Model[] models, Metadata data) {
				this.name = name;
				this.desc = desc;
				this.models = models;
				this.data = data;
                location = new Location();
			}

            public Asset (string name, string desc, Model[] models, Metadata data, Location location) {
                this.name = name;
                this.desc = desc;
                this.models = models;
                this.data = data;
                this.location = location;
            }

			public string[] Info {
				get { return new string[] { name, desc }; }
			}

			public Model[] Values {
				get { return models; }
				set { models = value; }
			}

			public Location GetLocation {
				get { return location; }
				set { location = value; }
			}

            public Metadata Data {
                get { return data; }
                set { data = value; }
            }
		}
	}
}
