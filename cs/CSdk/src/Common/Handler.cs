using System;
using System.IO;
using System.Runtime.Serialization;

namespace CSDK {
	namespace Common {
		[Serializable]
		public class Handler {
			private MemoryStream ms;
			private Guid guid;

			public Handler() {
				guid = Guid.NewGuid();
			}

            public Handler(Guid guid) {
                this.guid = guid;
            }

			public Handler(MemoryStream ms) {
				this.ms = ms;
				this.guid = Guid.NewGuid();
			}

			public Handler(MemoryStream ms, Guid guid) {
				this.ms = ms;
				this.guid = guid;
			}

			public MemoryStream Mem {
				get { return ms; }
				set { ms = value; }
			}

			public Guid Id {
				get { return guid; }
				set { guid = value; }
			}
		}
	}
}
