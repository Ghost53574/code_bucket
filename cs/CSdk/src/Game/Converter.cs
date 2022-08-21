using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CSDK {
	namespace Game {
		public static class Converter {
			public static List<KeyValuePair<Guid, KeyValuePair<string, CSDK.Common.Memory>>> ConvertMemory(Dictionary<Guid, KeyValuePair<string,	 CSDK.Common.Memory>> memory) {
				List<KeyValuePair<Guid, KeyValuePair<string, CSDK.Common.Memory>>> mem = new List<KeyValuePair<Guid, KeyValuePair<string, CSDK.Common.Memory>>> (128);
				foreach (var segment in memory)
					mem.Add (new KeyValuePair<Guid, KeyValuePair<string, CSDK.Common.Memory>> (segment.Key, new KeyValuePair<string, CSDK.Common.Memory> (segment.Value.Key, segment.Value.Value)));
				return mem;
			}
		}
	}
}
