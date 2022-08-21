using System;
using System.Runtime.Serialization;
using CSDK.Objects;

namespace CSDK {
	namespace Drawing {
		[Serializable]
		public class Frame {
			private string name;
			private Mesh[] meshes;
			private Guid guid;

            public Frame(string name, Mesh[] meshes) {
				this.name = name;
				this.meshes = meshes;
				guid = Guid.NewGuid();
			}

            public string Name {
                get { return name; }
                set { name = value; }
            }

            public Mesh[] Meshes {
                get { return meshes; }
                set { meshes = value; }
            }

            public Guid GetGuid {
                get { return guid; }
            }
    	}
	}
}
