using System;
using CSDK.Tools;
using CSDK.Common;
using CSDK.Debug;

class Debugger {
	public static void Main(string[] args) {
	    Console.WriteLine("Press 'q' to exit at anytime...\n\n");
        Environments env = new Environments();
        Config conf = new Config(env);
        env = conf.Env;
        Logger log = new Logger(env);
		Catcher catcher = new Catcher(env);
		Database db = new Database();
		do {
			while (!Console.KeyAvailable) {
				//Do something
				catcher.Check();
				if (env.ERROR) {
					log.Report(2, "Debugger", "An unknown exception has occured");
					Environment.Exit(1);
				}
			}
		} while (Console.ReadKey(true).Key != ConsoleKey.Q);
		Environment.Exit(0);
	}
}

