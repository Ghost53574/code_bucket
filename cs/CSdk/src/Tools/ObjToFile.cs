using System;
using System.IO;

namespace CSDK {
    namespace Tools {
	    public class ObjToFile {
		    public static void Write<T>(string path, T obj, bool append) {
			    if (!File.Exists(path)) File.Create(path).Close();
			    using (Stream stream = File.Open(path, append ? FileMode.Append : FileMode.Create)) {
                    var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            		binaryFormatter.Serialize(stream, obj);
        		}
		    }

		    public static T Read<T>(string path) {
			    if (!File.Exists(path))
				    return (T)new Object();
			    using (Stream stream = File.Open(path, FileMode.Open)) {
            		var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            		return (T)binaryFormatter.Deserialize(stream);
        	    }
		    }
        }
    }
}
