using System;

namespace CSDK {
    namespace Tools {
	    public class ParseUnits {
		    public string[] Parse(string filepath) {
			    string data = String.Empty;
			    using (var reader = new System.IO.StreamReader(filepath)) {
				    data = reader.ReadToEnd();
				    reader.Dispose();
			    }
            return data.Split(',');
		    }
	    }
    }
}
