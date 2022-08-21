using System;
using System.Runtime.Serialization;

namespace CSDK {
	namespace Objects {
		[Serializable]
		public static class Direction {
			public enum Faces {
				Left, 
				Right, 
				Top, 
				Bottom, 
				Front, 
				Back
			}

			public enum Edges {
				TopLeft,
				TopRight,
				BotLeft,
				BotRight,
                TopMiddle,
                BotMiddle,
                SideTop,
                SideMiddle,
                SideBot,
			}
		}
	}
}
