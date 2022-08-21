using System;
using System.Runtime.Serialization;

namespace CSDK {
	namespace Effects {
		[Serializable]
		public class Colors {
			private int[] rgb;
			private string name;

            public Colors() {
                rgb = new int[4];
                rgb[0] = 0;
                rgb[1] = 0;
                rgb[2] = 0;
                rgb[3] = 0;
                this.name = "default";
            }

			public Colors(string name, int red, int blue, int green) {
				rgb = new int[4];
				rgb[0] = red;
				rgb[1] = blue;
				rgb[2] = green;
				rgb[3] = 0;
				this.name = name;
			}

			public Colors(string name, int red, int blue, int green, int opacity) {
				rgb = new int[4];
				rgb[0] = red;
				rgb[1] = blue;
				rgb[2] = green;
				rgb[3] = opacity;
				this.name = name;
			}

            public string Name {
                get { return name; }
            }

			public int[] RGB {
				get { return rgb; }
			}

			public int Red {
				set { rgb[0] = value; }
			}

			public int Blue {
				set { rgb[1] = value; }
			}

			public int Green {
				set { rgb[2] = value; }
			}

			public int Opacity {
				set { rgb[3] = value; }
			}
		}
	}
}
