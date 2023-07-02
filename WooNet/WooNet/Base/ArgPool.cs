using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;

namespace WooNet
{
    class ArgPool
    {
        private Queue<SocketAsyncEventArgs> collection = null;
        private LockParam lockParam = new LockParam();
        private int capacity = 4;

        public int Count
        {
            get { return collection.Count; }
        }


        public int Capacity { get { return capacity; } }

        public ArgPool(int capacity = 32)
        {
            this.capacity = capacity;
            collection = new Queue<SocketAsyncEventArgs>(capacity);
        }


        private SocketAsyncEventArgs Get()
        {
            using (LockWait lwait = new LockWait(ref lockParam))
            {
                if (collection.Count > 0)
                    return collection.Dequeue();
                else return default(SocketAsyncEventArgs);
            }
        }


        public void Set(SocketAsyncEventArgs item)
        {
            using (LockWait lwait = new LockWait(ref lockParam))
            {
                collection.Enqueue(item);
            }
        }


        public void Clear()
        {
            using (LockWait lwait = new LockWait(ref lockParam))
            {
                collection.Clear();
            }
        }


        public void ClearToCloseArgs()
        {
            using (LockWait lwait = new LockWait(ref lockParam))
            {
                while (collection.Count > 0)
                {
                    var token = collection.Dequeue();
                    if (token != null)
                    {
                        token.Dispose();
                    }
                }
            }
        }

        public SocketAsyncEventArgs GetEmptyWait(Func<int, bool> fun, bool isWaitingFor = false)
        {
            int retry = 1;

            while (true)
            {
                var tArgs = Get();
                if (tArgs != null) return tArgs;
                if (isWaitingFor == false)
                {
                    if (retry > 16) break;
                    ++retry;
                }

                var isContinue = fun(retry);
                if (isContinue == false) break;

                Thread.Sleep(1000 * retry);
            }
            return default(SocketAsyncEventArgs);
        }
    }
}