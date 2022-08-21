using System;
using System.Runtime.Serialization;
using CSDK.Objects;

namespace CSDK {
	namespace Drawing {
		[Serializable]
		public class Model {
			private string name;
			private Frame[] frames;
			private Position[] pos;
			private Location location;
    		private Guid guid;

			private void Assign(Frame[] frames) {
				int positions = 0, t = 0;
				int _index = frames.Length;
				for (int i = 0; i < frames.Length; ++i) {
					for (int k = 0; k < frames[i].Meshes.Length; ++k) {
                        for (int h = 0; h < frames[i].Meshes[k].Blobs.Length; ++h) {
						    ++positions;
                        }
                    }
				}
				pos = new Position[positions];
				for (int i = 0; i < frames.Length; ++i) {
					for (int k = 0; k < frames[i].Meshes.Length; ++k) {
                        for (int h = 0; h < frames[i].Meshes[k].Blobs.Length; ++h) {
    						pos[t++] = new Position(frames[i].Meshes[k].Blobs[h].GetBlob);
					    }
				    }
			    }
            }

            public Model(string name, Frame[] frames) {
                this.name = name;
                this.frames = frames;
                guid = Guid.NewGuid();
                Assign(frames);
            }

			public Model(string name, Frame[] frames, Location location) {
				this.name = name;
				this.frames = frames;
                this.location = location;
				guid = Guid.NewGuid();
				Assign(frames);
			}

			public string Name {
				get { return name; }
			}

            public Frame this[int index] {
                get { return frames[index]; }
            }

			public Frame[] Frames {
				get { return frames; }
				set { frames = value; }
			}

            public Location GetLocation {
                get { return location; }
                set { location = value; }
            }

			public Position[] Positions {
				get { return pos; }
				set { pos = value; }
			}

			public Guid GetGuid {
				get { return guid; }
			}
		}
	}
}
