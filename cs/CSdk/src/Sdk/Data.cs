using System;
using CSDK.Tools;
using CSDK.Common;

namespace CSDK {
    namespace Sdk {
	    public class Segment {
		    private Memory mem;
		    private ObjToMem otm;

		    readonly int INIT_SIZE = 256;

		    public Segment() {
			    mem = new Memory(INIT_SIZE);
		    }

		    //public Add()
	    }
    }
}
