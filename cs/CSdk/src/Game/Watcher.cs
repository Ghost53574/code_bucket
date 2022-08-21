using System;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using CSDK.Common;

namespace CSDK {
	namespace Game {
		[Serializable]
		public class Watcher {
			private Manager manager;

			public enum Functions {
				Add, Remove, Replace, Get
			};

			public enum MemTypes {
				Handler, Memory
			};

			private async Task<Manager> Modify(Functions func, string name, Handler handle) {
				Object data;
				switch (func) {
				case Functions.Add:
					await manager.ModifyHandler (Manager.Command.Add, name, handle);
					break;
				case Functions.Remove:
					await manager.ModifyHandler (Manager.Command.Remove, name, handle);
					break;
				case Functions.Replace:
					await manager.ModifyHandler (Manager.Command.Replace, name, handle);
					break;
				case Functions.Get:
					await manager.ModifyHandler (Manager.Command.Retrieve, name, handle);
					break;
				}
				return null;
			}

			private async Task<Manager> Modify(Functions func, string name, Memory memory) {
				Object data;
				switch (func) {
				case Functions.Add:
					await manager.ModifyMemory (Manager.Command.Add, name, memory);
					break;
				case Functions.Remove:
					await manager.ModifyMemory (Manager.Command.Remove, name, memory);
					break;
				case Functions.Replace:
					await manager.ModifyMemory (Manager.Command.Replace, name, memory);
					break;
				case Functions.Get:
					await manager.ModifyMemory (Manager.Command.Retrieve, name, memory);
					break;
				}
				return null;
			}

			public Watcher(Manager manager) {
				if (manager == null)
					this.manager = new Manager ();
				this.manager = manager;
			}
			/// <summary>
			/// Asnyc Manager for handling CSDK memory objects
			/// </summary>
			/// <param name="func">Type of function provoked</param>
			/// <param name="memtypes">Memory type provoking</param>
			/// <param name="data">Handler or Memory assigned</param>
			/// <param name="name">Name of memory accessing</param>
			public async void Manage(Functions func, MemTypes memtypes, Object data, string name = null) {
				if (name == null)
					return;
				if (memtypes == MemTypes.Handler)
					await Modify (func, name, (Handler)data);
				else 
					await Modify (func, name, (Memory)data);
			}
		}
	}
}
