using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using CSDK.Common;
using CSDK.Tools;

namespace CSDK {
	namespace Game {
		[Serializable]
		public class Manager {
			private Guid guid;
			private bool result;
			private Dictionary<Guid, KeyValuePair<string, Memory>> memory;

			private Dictionary<Guid, KeyValuePair<string, Memory>> GetMemory {
				get { return memory; }
				set { memory = value; }
			}

			public void Add(string name) {
				memory.Add(Guid.NewGuid(), new KeyValuePair<string, Memory>(name, new Memory()));
			}

			public void Add(string name, Memory memory) {
				this.memory.Add (Guid.NewGuid (), new KeyValuePair<string, Memory> (name, memory));
			}

			public void Remove(int index) {
				int i = 0;
				var list = new Dictionary<Guid, KeyValuePair<string, Memory>> (memory);
				var enumerator = list.GetEnumerator ();
				while (enumerator.MoveNext()) {
					if (i != index) {
						++i;
						break;
					}
					var segment = enumerator.Current;
					Guid guid = segment.Key;
					memory.Remove (guid);
				}
			}

			public enum Command {
				Add, Remove, Replace, Retrieve
			}

			public Manager() {
				guid = Guid.NewGuid();
				result = false;
				memory = new Dictionary<Guid, KeyValuePair<string, Memory>>();
				memory.Add(Guid.NewGuid(), new KeyValuePair<string, Memory>("Main", new Memory()));
			}

			public async Task ModifyHandler(Command cmd, string name, Handler data = null) {
				var list = CSDK.Game.Converter.ConvertMemory (memory);
				await Task.Delay (1);
				for (int i = 0; i < list.Count; ++i) {
					if (cmd != Command.Retrieve && data == null)
						break;
					if (list [i].Value.Key != name)
						continue;
					Guid guid = list [i].Key;
					Memory _memory = list [i].Value.Value;
					int index = _memory.Search (guid, out result);
					switch (cmd) {
					case Command.Add:
						_memory.Add (data.Mem);
						break;
					case Command.Remove:
						if (index >= 0 && result)
							_memory.Remove (index);
						break;
					case Command.Replace:
						_memory.Replace (data.Mem, out result);
						break;
					case Command.Retrieve:
						data = _memory [index];
						break;
					default:
						break;
					}
				}
			}

			public async Task ModifyMemory(Command cmd, string name, Memory data = null) {
				var list = CSDK.Game.Converter.ConvertMemory(memory);
				await Task.Delay (1);
				for (int i = 0; i < list.Count; ++i) {
					if (cmd != Command.Retrieve && data == null)
						break;
					if (list [i].Value.Key != name)
						continue;
					Guid guid = list [i].Key;
					switch (cmd) {
					case Command.Add:
						memory.Add (Guid.NewGuid(), new KeyValuePair<string, Memory> (name, data));
						break;
					case Command.Remove:
						memory.Remove(guid);
						break;
					case Command.Replace:
						memory[guid] = new KeyValuePair<string, Memory> (name, data);
						break;
					case Command.Retrieve:
						data = memory [guid].Value;
						break;
					default:
						break;
					}
				}
			}
		}
	}
}
