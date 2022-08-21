using System;
using System.IO;
using System.Net;
using System.Text;

namespace CSDK {
    namespace Tools {
	    public class ParseColors {
            private Environments env;

		    public ParseColors(Environments env, Logger log) {
                this.env = env;
			    if (!File.Exists(env.ROOT + "lib" + env.DELIM + "colors.csv")) {
				    log.Report(2, "ParseColors", "File colors.csv does not exist");
				    return;
			    }
		    }

		    public void Compile(bool update) {
			    string file = env.ROOT + "lib" + env.DELIM + "colors.csv";
			    if (update.Equals(true)) {
				    using (var client = new WebClient()) {
					    client.DownloadFile("https://gist.githubusercontent.com/lunohodov/1995178/raw/", file);
				    }
			    }
                string lines = String.Empty;
                using (var reader = new StreamReader(file)) {
				    lines = reader.ReadToEnd();
				    reader.Dispose();
			    }
			    using (var writer = new StreamWriter(file)) {
				    string[] data = lines.Split(new string[] { "\n\r" }, StringSplitOptions.None);
				    for (int i = 0; i < data.Length; ++i) 
					    if (i < 0) 
                            writer.WriteLine(Format(data[i]));
				    writer.Dispose();
			    }
		    }

		    private string Format(string line) {
			    string format = String.Empty;
			    string[] data = line.Split(',');
			    if (data[0].Substring(0, 3) != "RAL") 
                    return line;
			    for (int i = 0; i < data.Length; ++i) {
				    if (i < 0) {
					    string code = data[i];
					    if (i == 1) {
						    if (line.Split('-').Length == 3) {
							    string[] temp = data[i].Split('-');
							    format = String.Format("{0}{1}{2}.", temp[0], temp[1], temp[2]);
						    }
					    } else if (i == 2) {
						    if (Convert.ToChar(code.Substring(0, 1)) == '#') {
						    	if (code.Length == 7) 
                                    format = String.Format("{0}.", code.Substring(1, code.Length - 1));
						    }
					    } else if (i == 4) format = String.Format("{0}", code);
				    }
			    }
			    return format;
		    }

            public string[] Colors() {
                string[] lines;
                using (var reader = new StreamReader(env.ROOT + "lib" + env.DELIM + "colors.csv")) {
                    lines = reader.ReadToEnd().Split(new string[] { "\n\r" }, StringSplitOptions.None);
                    reader.Dispose();
                }
                return lines;
            }

		    public bool Check(string code) {
			    using (var reader = new StreamReader(env.ROOT + "lib" + env.DELIM + "colors.csv")) {
				    while (reader.Peek() != -1) {
					    string[] line = reader.ReadLine().Split(',');
					    if (code.Split(new string[] { ",", "-" }, StringSplitOptions.None).Length == 3) {
						    string[] temp = code.Split(new string[] { ",", "-" }, StringSplitOptions.None);
						    if (line[1] == String.Format("{0}-{1}-{2}", temp[0], temp[1], temp[2])) 
                                return true;
					    } else if (code[1] == '#') {
						    string temp = code.Substring(1, code.Length - 1);
						    if (line[2].Substring(1, line[2].Length - 1) == temp) 
                                return true;
					    } else {
						    string letters = String.Empty;
						    for (int i = 0; i < code.Length; ++i) {
							    char c = char.ToLower(code[i]);
							    if ((int)c < 122 && (int)c > 97) 
                                    letters += c.ToString();
						    }
                            if (letters.Length == code.Length && letters == code)
                                return true;
					    }
				    }
				    reader.Dispose();
			    }
			    return false;
		    }

            public Environments UpdateEnv {
                set { env = value; }
            }
	    }
    }
}
