using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CSDK.Common;

namespace CSDK {
	namespace Game {
		[Serializable]
		public class Instance {
			private Level[] levels;
			private Handler data;

			public Instance() {
				levels = new Level[1];
				data = new Handler();
			}

			public Instance(Instance instance) {
				this.levels = instance.Data.Key;
				this.data = instance.Data.Value;
			}
		
			public Instance(Level[] levels, Handler data) {
				this.levels = levels;
				this.data = data;
			}

			public KeyValuePair<Level[], Handler> Data {
				get { 
					return new KeyValuePair<Level[], Handler>(levels, data); 
				}
				set { 
					this.levels = value.Key;
					this.data = value.Value;
				}
			}
		}
	}
}
