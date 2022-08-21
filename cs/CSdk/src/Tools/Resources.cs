using System;
using System.IO;
using System.Collections.Generic;

namespace CSDK {
    namespace Tools {
        public static class Resources {
            // QUEUE: for memory and files
            private const int MAX_QUEUE = 40;
            private static Queue<Common.Memory> queue = new Queue<Common.Memory>(MAX_QUEUE);
            private static Common.Memory LastPush;

            public static void Push(Common.Memory item) {
                if (queue.Count == MAX_QUEUE) {
                    Common.Memory _mem = queue.Dequeue();
                }
                LastPush = item;
                queue.Enqueue(item);
            }

            public static Common.Memory Pull () {
                return queue.Dequeue();
            }

            public static Common.Memory GetLast() {
                return LastPush;
            }

            public static int QueueCount() {
                return queue.Count;
            }

            //Common.Memory instanecd for 10 Handlers max, for use with Queue and MemoryStreams
            private const int MAX_MEMORY = 40;
            private static Common.Memory memory = new Common.Memory(MAX_MEMORY);

            public static void Push (Common.Handler handler) {
                if (memory.Size == MAX_MEMORY)
                    memory.Remove(MAX_MEMORY - 1);
                memory.Add(handler);
            }

            public static Common.Handler Pull (int index) {
                if (index <= 10 && index > (-1))
                    return memory[index];
                return null;
            }

            public static int MemoryCount() {
                return memory.Size;
            }
        }
    }
}
