using System;

namespace CSDK {
	namespace Effects {
		public class Texture {
			private Colors color;

			public Texture(Colors color, int opacity) {
				this.color = color;
				this.color.Opacity = opacity;
			}

			public Colors GetColor {
				get { return color; }
			}

			public int Opacity {
				get { return color.RGB[3]; }
				set { color.RGB[3] = value; }
			}
		}
	}
}
