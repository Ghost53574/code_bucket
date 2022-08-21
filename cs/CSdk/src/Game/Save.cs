using System;
using System.IO;
using CSDK.Game;
using CSDK.Tools;

namespace CSDK {
	namespace Game {
		public class Save {
			public void SaveObject (string path, MemoryStream[] obj) {
				if (File.Exists(path))
					;
				ObjToFile.Write<MemoryStream[]>(path, obj, false);				
			}

			public MemoryStream[] LoadObject (string path) {
				return ObjToFile.Read<MemoryStream[]>(path);	
			}
		}
	}
}
