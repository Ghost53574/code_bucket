using System;
using CSDK.Objects;

namespace CSDK {
	namespace Effects {
		public class Shader {
			private Light light;
			private Point direction;

			public Shader(Light light, Point direction) {
				this.light = light;
				this.direction = direction;
			}

			public Light GetLight {
				get { return light; }
			}

			public Point GetDirection {
				get { return direction; }
			}
		}
	}
}
