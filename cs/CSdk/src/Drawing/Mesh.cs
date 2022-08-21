using System;
using System.Runtime.Serialization;
using CSDK.Objects;
using CSDK.Effects;

namespace CSDK {
	namespace Drawing {
		[Serializable]
		public class Mesh {
			private Blob[] blobs;
			private Location location;
			private Shader shader;
			private Texture texture;

			public Mesh(Blob[] blobs, Location location) {
				this.blobs = blobs;
				this.location = location;
			}

			public Mesh(Blob[] blobs, Shader shader, Location location) {
				this.blobs = blobs;
				this.shader = shader;
				this.location = location;
			}

			public Mesh(Blob[] blobs, Shader shader, Texture texture, Location location) {
				this.blobs = blobs;
				this.shader = shader;
				this.texture = texture;
				this.location = location;
			}

			public Location GetLocation {
				get { return location; }
				set { location = value; }
			}

			public Shader GetShader {
				get { return shader; }
				set { shader = value; }
			}

			public Texture GetTexture {
				get { return texture; }
				set { texture = value; }
			}

			public Blob[] Blobs {
				get { return blobs; }
				set { blobs = value; }
			}
		}
	}
}
