using System;
using System.IO;
using MongoDB.Driver;
using MongoDB.Bson;
using CSDK.Tools;

namespace CSDK {
    namespace Common {
	    public class Database {
            private Environments db_env;
            private Common.Memory memory;
            private MongoClient client;
            private MongoClientSettings client_settings;

            private System.Threading.CancellationToken cancel_token;
            private IClientSessionHandle session;

            public Database() {
                db_env = new Environments();
                memory = new Common.Memory();
                cancel_token = new System.Threading.CancellationToken();
                client_settings.ApplicationName = "OSCDK-MongoDB";
                client = new MongoClient(client_settings);
                session = client.StartSession(null, cancel_token);
                db_env.RUNNING = true;
                db_env.ROOT = client.Settings.Server.Host;
                db_env.GUID = memory.GetGuid;
            }

            public void Add (BsonDocument doc) {
                
            }

            public void Remove (int index) {
                
            }

            public void Retrive (int index) {
                
            }
		    /*private int t = 0;
		    private string db;
            private Logger log;
            private Environments env;

		    private void Create() {
			    Write("DB INIT", false);
		    }

		    public Database(Environments env) {
                log = new Logger(env);
                this.env = env;
                db = String.Format("{0}dat{1}store",env.ROOT,env.DELIM);
			    log.Report(0, "Database", "Creating DB");
			    Create();
			    Check();
		    }

		    public void Write(string data, bool append) {
			    if (data != null) {
				    using (var writer = new StreamWriter(db, append)) {
					    string[] temp = data.Split(' ');
					    if (temp.Length == 2) {
						    writer.WriteLine(String.Format("{0} {1} {2}", t, temp[0], temp[1]));
						    log.Report(0, "Database", String.Format("Wrote object:{0} and data:{1} to the DB", temp[0], temp[1]));
					    }
					    ++t;
					    writer.Dispose();
				    }
			    }
		    }

		    public string Retrive(int value) {
			    if (value > 0) {
				    string[] temp = new string[1];
				    using (var reader = new StreamReader(db)) {
					    while (reader.Peek() != -1) {
						    if (temp[0] != null) 
                                temp = Arrays.Add(temp, reader.ReadLine());
						    else 
                                temp[0] = reader.ReadLine();
					    }
					    reader.Dispose();
				    }
				    for (int i = 0; i < temp.Length; ++i) { 
					    if (i == value) {
						    log.Report(0, "Database", String.Format("Fetched:{0} from the DB", temp[i]));
						    return temp[i];
					    }
				    }
			    }
			    return "";
		    }

		    public int Retrive(string value) {
			    if (value != null) {
				    using (var reader = new StreamReader(db)) {
					    int i = 0;
					    while (reader.Peek() != -1) {
						    string[] temp = reader.ReadLine().Split(' ');
						    if (temp.Length == 3) {
							    if (temp[2] == value) {
								    log.Report(0, "Database", String.Format("Fetched:{0} from the DB", 
                                                              String.Format("{0} {1} {2}", temp[0], temp[1], temp[2])));
								    return Convert.ToInt32(temp[0]);
							    }
							    ++i;
						    }
						    else Remove(i);
					    }
					    reader.Dispose();
				    }
			    }
			    return 0;
		    }

		    public void Remove(int value) {
			    if (value > 0) {
					string[] temp = new string[1];
					using (var reader = new StreamReader(db))
					{
						while (reader.Peek() != -1)
						{
							string[] _temp = reader.ReadLine().Split(' ');
							if (_temp.Length == 3)
							{
								if (temp[0] != null)
								{
									if (!_temp[0].Equals(value.ToString()))
										temp = Arrays.Add(temp, reader.ReadLine());
								}
								else
									temp[0] = reader.ReadLine();
							}
							else
								temp = Arrays.Add(temp, null);
						}
						reader.Dispose();
					}
				    using (var writer = new StreamWriter(db)) {
					    for (int i = 0; i < temp.Length; ++i) {
						    string[] _temp = temp[i].Split(' ');
						    writer.WriteLine(String.Format("{0} {1} {2}", i, _temp[1], _temp[2]));
					    }
					    --t;
					    writer.Dispose();
				    }
				    log.Report(0, "Database", String.Format("Removed line {0} from the DB", value));
			    }
		    }

		    public void Check() {
			    if (!File.Exists(db)) {
				    t = 0;
				    Create();
			    }
			    string[] temp = new string[1];
			    using (var reader = new StreamReader(db)) {
				    while (reader.Peek() != -1) {
					    if (temp[0] != null) 
                            temp = Arrays.Add(temp, reader.ReadLine());
					    else 
                            temp[0] = reader.ReadLine();
				    }
				    reader.Dispose();
			    }
			    string[] errs = new string[1];
			    for (int i = 0; i < temp.Length; ++i) {
				    string[] _temp = temp[i].Split(' ');
				    if (!_temp[0].Equals(i.ToString())) {
					    log.Report(1, "Database", String.Format("Error at line {0}", i));
					    if (errs[0] != null) 
                            errs = Arrays.Add(errs, i.ToString());
					    else 
                            errs[0] = i.ToString();
				    }
			    }
			    for (int i = 0; i < errs.Length; ++i) 
                    Remove(Convert.ToInt32(errs[i]));
		    }*/
	    }
    }
}
