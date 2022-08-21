using System;
using System.Runtime.Serialization;

namespace CSDK {
	namespace Game {
		[Serializable]
		public class Data<T> {
			public T DataConvert(T data) {
				return (T)Convert.ChangeType(data, typeof(T));
			}
		}	
	}
}
