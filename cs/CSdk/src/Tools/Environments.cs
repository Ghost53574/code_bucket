using System;
using System.Runtime.Serialization;

namespace CSDK {
	namespace Tools {
		[Serializable]
		public class Environments {
			public bool RUNNING;
			public bool STOPPED;
			public bool ERROR;
			public char DELIM;
			public string ROOT;
			public Guid GUID;

			public Environments() {
				RUNNING = false;
				STOPPED = false;
				ERROR = false;
				DELIM = ' ';
				ROOT = String.Empty;
				GUID = Guid.Empty;
			}

			public void SaveState() {
                Resources.Push(new Common.Handler(ObjToMem.Write(this), GUID));
			}

			public Environments RestoreState() {
                Common.Handler handler = null;
                for (int i = 0; i < Resources.MemoryCount(); ++i) {
                    handler = Resources.Pull(i);
                    if (handler.Id == GUID)
                        break;
                }
                return ObjToMem.Read<Environments>(handler.Mem);
			}
		}
	}
}
