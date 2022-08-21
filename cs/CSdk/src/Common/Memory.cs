using System;
using System.IO;
using System.Runtime.Serialization;

namespace CSDK {
	namespace Common {
        [Serializable]
        public class Memory
        {
            private Handler[] handlers;
            private Guid[] memory;
            private Guid guid;
            private int k;

            private void Increment() {
                k = handlers.Length;
            }

            private void Decrement() {
                --k;
            }

            public Memory()
            {
                int size = 3;
                guid = Guid.NewGuid();
                memory = new Guid[size];
                handlers = new Handler[size];
                for (int i = 0; i < size; ++i)
                {
                    handlers[i] = new Handler();
                    memory[i] = Guid.NewGuid();
                }
                k = 0;
            }

            public Memory(int size)
            {
                guid = Guid.NewGuid();
                memory = new Guid[size];
                handlers = new Handler[size];
                for (int i = 0; i < size; ++i)
                {
                    handlers[i] = new Handler();
                    memory[i] = Guid.NewGuid();
                }
                k = 0;
            }

            private void Check()
            {
                if (handlers.Length == memory.Length && (handlers.Length != 0 && memory.Length != 0 && k != 0))
                    return;
                if (k == 0 && (handlers.Length > 0 || memory.Length > 0))
                    k = (handlers.Length > memory.Length) ? handlers.Length - memory.Length : memory.Length - handlers.Length;
                if ((handlers.Length == 0 || memory.Length == 0) && k > 0)
                {
                    Memory _memory = new Memory(k);
                    handlers = _memory.handlers;
                    memory = _memory.memory;
                }
                if (handlers.Length > memory.Length)
                    //Handler size is larger
                    Resize((handlers.Length - memory.Length), true);
                else//Handler size is smaller
                    Resize((memory.Length - handlers.Length), false);
            }

            public void Resize(int offset, bool isHandle)
            {
                int size = (isHandle) ? (handlers.Length - k > 0) ? handlers.Length : k : (memory.Length - k > 0) ? memory.Length : k;
                int i = 0;
                Handler[] _handlers = new Handler[size + offset];
                Guid[] _guids = new Guid[size + offset];
                k = 0;
                for (; i < size; i++)
                {
                    _handlers[i] = handlers[i];
                    _guids[i] = memory[i];
                    Increment();
                }
                for (i = 0; i < offset; i++)
                {
                    switch (isHandle)
                    {
                        case true:
                            //Create new GUIDs
                            _handlers[i] = handlers[i];
                            _guids[i] = Guid.NewGuid();
                            break;
                        case false:
                            //Create new Handles
                            _handlers[i] = new Handler();
                            _guids[i] = _handlers[i].Id;
                            break;
                    }
                }
                handlers = _handlers;
                memory = _guids;
            }

            public void Replace(MemoryStream ms, out bool result)
            {
                Check();
                result = false;
                int s = Search(ms, out result);
                if (s == -1 || s > k)
                    return;
                result = true;
                Add(ms, s);
            }

            public Guid Add(MemoryStream ms)
            {
                Check();
                Increment();
                memory[k] = handlers[k].Id;
                handlers[k].Mem = ms;
                return handlers[k].Id;
            }

            public Guid Add(MemoryStream ms, int index)
            {
                Check();
                if (index < 0)
                    return Guid.Empty;
                Increment();
                if (index > k)
                    Add(ms);
                else if (handlers[index].Mem != null)
                    handlers[index].Mem = ms;
                return handlers[index].Id;
            }

            public Guid Add(Handler handler) {
                Check();
                Increment();
                memory[k] = handlers[k].Id;
                handlers[k] = handler;
                return handlers[k].Id;
            }

            public void Remove(int index)
            {
                Check();
                if ((index >= 0 && index < handlers.Length) == false)
                    return;
                Decrement();
                int offset = 0, i = 0, j;
                for (i = 0; i < handlers.Length; ++i)
                {
                    if (i == index)
                    {
                        //Remove and shift shorter legnth to realign, or fill with nulls
                        offset = handlers.Length - i;
                        for (j = offset; handlers.Length > j; j++)
                        {
                            handlers[j] = handlers[(j == handlers.Length) ? j : j + 1];
                            memory[j] = memory[(j == handlers.Length) ? j : j + 1];
                        }
                        handlers[j] = null;
                        memory[j] = Guid.Empty;
                        break;
                    }
                }
            }

            public int Search(MemoryStream ms, out bool result)
            {
                result = false;
                for (int i = 0; i < handlers.Length; ++i)
                {
                    if (handlers[i] == null || handlers[i].Mem == null)
                        continue;
                    string[] temp, temp2;
                    temp = new string[ms.Length];
                    for (int k = 0; k < temp.Length; ++k)
                    {
                        ms.Position = k;
                        temp[k] = ms.ReadByte().ToString();
                    }
                    temp2 = new string[handlers[i].Mem.Length];
                    for (int k = 0; k < temp2.Length; ++k)
                    {
                        handlers[i].Mem.Position = k;
                        temp2[k] = handlers[i].Mem.ReadByte().ToString();
                    }
                    Array.Sort(temp);
                    Array.Sort(temp2);
                    int diff = temp.Length - temp2.Length;
                    for (int k = 0; (diff < 0) ? k < (temp.Length + diff) : k < temp.Length; ++k)
                    {
                        if (temp[k] != temp2[k])
                            break;
                        if (temp.Length - 1 == k)
                        {
                            result = true;
                            return i;
                        }
                    }
                }
                return 0;
            }

            public int Search(Guid guid, out bool result)
            {
                result = false;
                for (int i = 0; i < memory.Length; ++i)
                {
                    if (memory[i] == guid && handlers[i].Id == guid)
                    {
                        result = true;
                        return i;
                    }
                }
                return 0;
            }

            public void Clear()
            {
                handlers = new Handler[3];
                memory = new Guid[3];
                k = 0;
            }

            public Guid GetGuid
            {
                get { return guid; }
            }

            public Handler this[int index]
            {
                get { return handlers[index]; }
                set { handlers[index] = value; }
            }

            public int Size
            {
                get { return handlers.Length; }
            }
        }
	}
}
