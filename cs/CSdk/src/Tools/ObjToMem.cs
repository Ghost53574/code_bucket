using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization;

namespace CSDK {
    namespace Tools {
	    public class ObjToMem {
		    public static MemoryStream Write(Object obj) {
			    MemoryStream ms = new MemoryStream();
			    if (obj == null) 
                    return ms;
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                return ms;
		    }

		    public static T Read<T>(MemoryStream ms) {
			    if (ms.Length == 0 || ms == null)
                    return (T)new Object();
			    IFormatter formatter = new BinaryFormatter();
                ms.Seek(0, SeekOrigin.Begin);
                T obj = (T)formatter.Deserialize(ms);
			    return obj;
		    }
	    }
    }
}
