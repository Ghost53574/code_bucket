/* * * * * * * * * * * * * * * * * * * * * * * * * *
 * 1) Man file                                     *
 * * * * * * * * * * * * * * * * * * * * * * * * * */

using System;
using CSDK.Sdk;
using CSDK.Game;

class CSdk {
    private static string UsageMenu = String.Format("\n{0}\n{1}\n{2}\n{3}\n{4}","Usage is: ./CSdk.exe [options]","-h : help","-g : gtk","-r : run","-c : compile, -t: test");
	private static string TopMenu = String.Format("\n\t{0}\n\t{1}\n\t{2}","1)...","2)...","3)...");

    private static string HDivider = String.Format("{0}"," ------------------------------------------- ");
    private static string VDivider = String.Format("{0}","|                                           |");

    public static void Main(string[] args) {
        if (args.Length <= 0 || args.Length > 4) {
            Console.WriteLine(UsageMenu);
            Environment.Exit(1);
        }
		for (int i = 0; i < args.Length; ++i) {
			string command = args[i];
			if (command.Substring(0, 1) == "-" && command.Length == 2) {
				switch(command) {
                    case "-h":
                        break;
                    case "-g":
                        break;
                    case "-r":
                        break;
                    case "-c":
                        break;
                    case "-t":
                        Tester.OCSDK_NUnit test = new Tester.OCSDK_NUnit();
                        test.TestCommon();
                        test.TestDebug();
                        test.TestDrawing();
                        test.TestEffects();
                        test.TestGame();
                        test.TestObjects();
                        test.TestSdk();
                        test.TestTools();
                        break;
                    default:
                        break;
                }
			}
			else continue;
		}
	}
}
