using System;

namespace CSDK {
	namespace Effects {
		public class Light {
			private Colors color;
			private int opacity;

			public Light(Colors color, int opacity) {
				this.color = color;
				this.opacity = opacity;
			}

			public Colors GetColor {
				get { return color; }
			}

			public int Opactity {
				get { return opacity; }
				set { opacity = value; }
			}
		}
	}
}
