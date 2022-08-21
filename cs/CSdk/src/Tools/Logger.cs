using System;
using System.Collections.Generic;

namespace CSDK {
    namespace Tools {
        public class Logger {
            private List<string> queue;
            private Environments env;

            private void Queue(string msg) {
                queue.Add(msg);
            }

            public Logger(Environments env) {
                queue = new List<string>();
                this.env = env;
            }

    	    public string Report(int c, string title, string msg) {
			    string temp  = String.Empty;
                string date = DateTime.UtcNow.ToString("yyymmdd HHmmss");
			    if (c >= 0 && c <= 2) {
				    if (c == 0) 
					    temp = String.Format("{0}[INFO]::{1}",date,String.Format("{0}-{1}", title, msg));
				    else if (c == 1) 
					    temp = String.Format("{0}[WARN]::{1}",date,String.Format("{0}-{1}", title, msg));
				    else if (c == 2) 
					    temp = String.Format("{0}[ERR]::{1}",date,String.Format("{0}-{1}", title, msg));
			    }
			    Console.WriteLine(temp);
                if (queue.Count < 100)
                    Queue(temp);
                else
                    Write();
                return temp;
		    }

            public void Write() {
                using (var writer = new System.IO.StreamWriter(env.ROOT + "log", true)) {
                    for (int i = 0; i < queue.Count; ++i)
                        writer.Write(queue[i]);
                    writer.Dispose();
                }
                queue.Clear();
            }
	    }
    }
}
