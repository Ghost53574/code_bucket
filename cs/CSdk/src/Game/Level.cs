using System;
using System.Runtime.Serialization;

namespace CSDK {
    namespace Game {
		[Serializable]
	    public class Level {
		    private Map[] maps;
		    private string name;
		    private string desc;

		    private Map[] Resize (Map[] maps, int size) {
			    if (size < 0) return maps;
			    int index = maps.Length;
			    Map[] _maps = new Map[((index + size) / 2) + 1];
			    for (int i = 0; i < _maps.Length; ++i) {
				    if (i < _maps.Length)
					    _maps[i] = maps[i];
			    }
			    return _maps;
		    }

			public Level() {
				maps = new Map[5];
				name = "";
				desc = "";
			}

		    public Level(string name, string description, Map map) {
			    maps = new Map[5];
			    maps[0] = map;
			    this.name = name;
			    desc = description;
		    }

		    public void Add(Map map) {
                Map[] _maps;
                int size = Size;
			    if (size == 0)
				    _maps = Resize(new Map[] { map }, 3);
                else if (Capacity == 0 || (size < Capacity)) {
                    //Sort(maps, false, false);
                    _maps = Resize(maps, size + 3);
                }
                else {
                    _maps = Resize(maps, size);
                    _maps[size - Capacity] = map;
                }
                maps = _maps;
            }

		    public Map[] Maps {
			    get { return maps; }
		    }

		    public string Name {
			    get { return name; }
		    }

		    public string Description {
			    get { return desc; }
		    }

            public int Size {
                get { return maps.Length; }
            }

            public int Capacity {
                get {
                    int size = maps.Length, empty = 0;
                    for (int i = 0; i < size; ++i) {
                        if (maps[i] == null)
                            empty++;
                    }
                    return maps.Length - empty;
                }
            }
	    }
    }
}
