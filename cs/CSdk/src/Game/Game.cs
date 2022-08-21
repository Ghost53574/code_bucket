using System;
using System.Runtime.Serialization;
using CSDK.Tools;

namespace CSDK {
	namespace Game {
		[Serializable]
		public class Game {
			private Watcher watcher;
			private Manager manager;
			private Instance instance;
			private Save save;
			private Environments env;

			public Game() {
				manager = new Manager();
				watcher = new Watcher(manager);
				instance = new Instance();
				save = new Save();
				env = new Environments();
				env.GUID = Guid.NewGuid();
			}

			public void Start() {
				env.RUNNING = true;
				env.STOPPED = false;
			}

			public void Stop() {
				env.RUNNING = false;
				env.STOPPED = true;
			}

			public Environments GetEnv {
				get { return env; }
			}

			public Save GetSave {
				get { return save; }
			}

			public Instance CurrentInstance {
				get { return instance; }
			}
		}
	}
}
