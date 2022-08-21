using System;
using NUnit.Framework;

namespace Tester
{
    [NUnit.Framework.SetUpFixture()]
	public class OCSDK_NUnit
	{
		private void Print (string [] arr)
		{
			foreach (var s in arr)
				Console.WriteLine (s);
		}

		[Test ()]
		public void TestCommon ()
		{
			CSDK.Tools.Environments env = new CSDK.Tools.Environments ();
			CSDK.Tools.Logger log = new CSDK.Tools.Logger (env);

			string test1 = String.Format ("Test Message: {0}", 1);
			string test2 = String.Format ("Test Message: {0} {1}", 2, "Testing...");
			string test3 = String.Format ("Test Message: {0} {1}", 3, String.Format ("Testing inception {0}", 0.000001));

			var arrays = new CSDK.Common.Arrays ();

			Assert.IsNotNull (arrays);

			string [] _arrays_test = { test1, test2, test3 };
			int _arrays_test_length = _arrays_test.Length;

			Assert.AreEqual (_arrays_test [0], test1);
			Assert.AreEqual (_arrays_test [1], test2);
			Assert.AreEqual (_arrays_test [2], test3);

            _arrays_test = CSDK.Common.Arrays.Add (_arrays_test, String.Format ("Test Message: {0}", 4));

			Assert.AreEqual (_arrays_test [3], "Test Message: 4");

			CSDK.Common.Arrays.Remove (_arrays_test, _arrays_test_length);

			Print (_arrays_test);

			CSDK.Common.Arrays.BubbleSort (_arrays_test);

			Print (_arrays_test);

			CSDK.Common.Arrays.MergeSort (_arrays_test);

			Print (_arrays_test);

			CSDK.Common.Arrays.Add (_arrays_test, "\x00");
			CSDK.Common.Arrays.NullSort (_arrays_test);

			Print (_arrays_test);

            _arrays_test = CSDK.Common.Arrays.Remove (_arrays_test, 3);

			Assert.AreEqual (_arrays_test.Length, 3);

			var db = new CSDK.Common.Database (env);

			db.Write ("Some data", true);
			db.Check ();
			db.Remove (1);
			db.Retrive (0);

			CSDK.Common.Debug.Msg (test1);
			CSDK.Common.Debug.Msg (test2);
			CSDK.Common.Debug.Msg (test3);

			var ms = new System.IO.MemoryStream (new byte [] { (byte)'\xDE', (byte)'\xAD' });

			var handler1 = new CSDK.Common.Handler ();
			var handler2 = new CSDK.Common.Handler (ms);
			var handler3 = new CSDK.Common.Handler (ms, new Guid ());

			var memory = new CSDK.Common.Memory (4);

			memory.Add (handler1.Mem);
			memory.Add (handler2.Mem);
			memory.Add (handler3.Mem);
			memory.Add (ms);

			Assert.AreEqual (memory.Size, 4);

			bool result;

			memory.Search (ms, out result);

			Assert.AreEqual (result, true);

			memory.Remove (0);
			memory.Remove (1);
			memory.Remove (2);

			Assert.AreEqual (memory.Size, 1);

			memory.Replace (ms, out result);

			Assert.AreEqual (result, true);

			memory.Clear ();
		}

		[Test ()]
		public void TestDebug ()
		{
			CSDK.Debug.Catcher catcher;
			CSDK.Debug.Config config;
			CSDK.Debug.ReadConfig readconfig;

			CSDK.Tools.Environments env = new CSDK.Tools.Environments ();

			env.DELIM = '\\';
			env.ERROR = false;
			env.GUID = Guid.NewGuid ();
			env.ROOT = "/home/c0z/";
			env.RUNNING = false;
			env.STOPPED = false;

			config = new CSDK.Debug.Config (env);
			catcher = new CSDK.Debug.Catcher (env);
			readconfig = new CSDK.Debug.ReadConfig(env.ROOT);

			Assert.Catch (() => { catcher.Check (); });

			Assert.AreEqual(readconfig.GetPath, env.ROOT);

			Assert.Catch (() => { readconfig.Write (env, false); });
		}

		[Test ()]
		public void TestDrawing ()
		{
			CSDK.Drawing.Asset asset;
			CSDK.Drawing.Blob blob;
			CSDK.Drawing.Camera camera;
			CSDK.Drawing.Frame frame;
			CSDK.Drawing.Location location;
			CSDK.Drawing.Mesh mesh;
			CSDK.Drawing.Model model;
			CSDK.Drawing.Normalization norm;
			CSDK.Drawing.Unit unit;

			System.IO.MemoryStream ms = new System.IO.MemoryStream (new byte [] { (byte)'\xDE', (byte)'\xAD', (byte)'\xBE', (byte)'\xEF' });
			CSDK.Objects.Metadata metadata;
			CSDK.Objects.Point p = new CSDK.Objects.Point ();

			location = new CSDK.Drawing.Location (5, 5, 5);
			metadata = new CSDK.Objects.Metadata ("Metedata: Effect", p, p, p, new CSDK.Common.Handler (ms));
            CSDK.Drawing.Pyrimad _pyrimad = new CSDK.Drawing.Pyrimad(10, 10, 10);
            blob = new CSDK.Drawing.Blob(_pyrimad);
			mesh = new CSDK.Drawing.Mesh (new CSDK.Drawing.Blob [] { blob }, location);
			frame = new CSDK.Drawing.Frame ("frame_bPyrimad", new CSDK.Drawing.Mesh [] { mesh });
			model = new CSDK.Drawing.Model ("model_bPyrimad", new CSDK.Drawing.Frame [] { frame });
			asset = new CSDK.Drawing.Asset ("asset_bPyrimad", "Basic pyrimad asset", new CSDK.Drawing.Model [] { model }, metadata );
			camera = new CSDK.Drawing.Camera ();
			norm = new CSDK.Drawing.Normalization ();
			unit = new CSDK.Drawing.Unit (p, norm);
		}

		[Test ()]
		public void TestEffects ()
		{
			CSDK.Effects.Animations animations;
			CSDK.Effects.Colors colors;
			CSDK.Effects.Light light;
			CSDK.Effects.Shader shader;
			CSDK.Effects.Texture texture;

			CSDK.Objects.Point direction = new CSDK.Objects.Point ();
			CSDK.Objects.Direction.Sides face = CSDK.Objects.Direction.Sides.Top;

			animations = new CSDK.Effects.Animations ();
			colors = new CSDK.Effects.Colors ();
			light = new CSDK.Effects.Light (colors, 0);
			shader = new CSDK.Effects.Shader (light, direction);
			texture = new CSDK.Effects.Texture (colors, 0);
		}

		[Test ()]
		public void TestGame ()
		{
			CSDK.Game.Data<object> data;
			CSDK.Game.Events events;
			CSDK.Game.Game game;
			CSDK.Game.Instance instance;
			CSDK.Game.Level level;
			CSDK.Game.Location location;
			CSDK.Game.Manager manager;
			CSDK.Game.Map map;
			CSDK.Game.Save save;
			CSDK.Game.Watcher watcher;

			byte [] _null = new byte [] { (byte)'\x00' };
			byte [] _magic = new byte [] { (byte)'\xDE', (byte)'\xAD', (byte)'\xBE', (byte)'\xEF' };
			byte [] _data = new byte [] { (byte)'\x0A', (byte)'\x41', (byte)'\x41', (byte)'\x41', (byte)'\x41' };

			byte [] _packet = new byte [] { _null[0], _magic[0], _magic[1], _magic[2], _magic[3],
				_data[0], _data[1], _data[2], _data[3], _data[4], _null[0] };

			System.IO.MemoryStream msg = new System.IO.MemoryStream (_packet);

			CSDK.Objects.Point p = new CSDK.Objects.Point ();

			game = new CSDK.Game.Game ();
			location = new CSDK.Game.Location ("Somewhere", "Description", p, new CSDK.Common.Handler [] { new CSDK.Common.Handler (msg) });
			events = new CSDK.Game.Events ("Some event", location);
			map = new CSDK.Game.Map ("Basic", "Nothing special", new CSDK.Game.Events [] { events }, 
			                         new CSDK.Game.Location [] { location }, new CSDK.Common.Handler [] { new CSDK.Common.Handler (msg) });
			level = new CSDK.Game.Level ("Basic level", "Nothing from map special basic w/e", map);
			instance = new CSDK.Game.Instance (new CSDK.Game.Level [] { level }, new CSDK.Common.Handler (msg));
			manager = new CSDK.Game.Manager ();
			watcher = new CSDK.Game.Watcher (manager);

			save = new CSDK.Game.Save ();

			//Finish
		}

		[Test ()]
		public void TestObjects ()
		{
			CSDK.Objects.Bracket b;
			CSDK.Objects.Circle circle;
			CSDK.Objects.Cone cone;
			CSDK.Objects.Cube cube;
			CSDK.Objects.Direction.Corners corners;
			CSDK.Objects.Direction.Sides sides;
			CSDK.Objects.Line l;
			CSDK.Objects.Metadata metadata;
			CSDK.Objects.Objects objects;
			CSDK.Objects.Point p;
			CSDK.Objects.Position position;
			CSDK.Objects.Pyrimad pyrimad;
			CSDK.Objects.Sphere sphere;
			CSDK.Objects.Square square;
			CSDK.Objects.Triangle triangle;

			b = new CSDK.Objects.Bracket ();
			circle = new CSDK.Objects.Circle (5, 5);
			cone = new CSDK.Objects.Cone (5, 5, 5);
			cube = new CSDK.Objects.Cube (5, 5, 5);
			l = new CSDK.Objects.Line ();
			metadata = new CSDK.Objects.Metadata ("Blank");
			objects = new CSDK.Objects.Objects (0, new CSDK.Objects.Point ());
			p = new CSDK.Objects.Point ();
			//podiyion = new CSDK.Objects.Position(,,,)
			pyrimad = new CSDK.Objects.Pyrimad (5, 5, 5);
			sphere = new CSDK.Objects.Sphere (5, 5, 5);
			square = new CSDK.Objects.Square (5, 5);
			triangle = new CSDK.Objects.Triangle (5, 5);
		}

		[Test ()]
		public void TestSdk ()
		{
			CSDK.Sdk.CSdk csdk;
			CSDK.Sdk.Segment segment;

			csdk = new CSDK.Sdk.CSdk ();
			segment = new CSDK.Sdk.Segment ();
		}

		[Test ()]
		public void TestTools ()
		{
			CSDK.Tools.Environments env;
			CSDK.Tools.FormatData fd;
			CSDK.Tools.Logger log;
			CSDK.Tools.ParseColors pcolors;
			CSDK.Tools.ParseUnits punits;

			env = new CSDK.Tools.Environments ();

			env.ROOT = "\\home\\gh0st\\";
			env.DELIM = '\\';
			env.ERROR = false;
			env.RUNNING = false;
			env.STOPPED = false;
			env.GUID = Guid.NewGuid ();
			env.SaveState ();

			fd = new CSDK.Tools.FormatData ();
			log = new CSDK.Tools.Logger (env);
			pcolors = new CSDK.Tools.ParseColors (env, log);
			punits = new CSDK.Tools.ParseUnits ();
		}
	}
}

