using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Security.Cryptography;
using System.Collections.Concurrent;

namespace CoPowerScreening
{
    public class Line
    {
        private FixedSizedQueue<int> _position;

        public Line()
        {
            LastMarkedPosition = new FixedSizedQueue<int>();
            LastMarkedPosition.Limit = 1;
        }
        
        public FixedSizedQueue<int> LastMarkedPosition { get; private set; }
    }

    public class FixedSizedQueue<T>
    {
        ConcurrentQueue<T> q = new ConcurrentQueue<T>();
        private object lockObject = new object();

        public T Value { get => q.SingleOrDefault(); }

        public int Limit { get; set; }
        public void Enqueue(T obj)
        {
            q.Enqueue(obj);
            lock (lockObject)
            {
                T overflow;
                while (q.Count > Limit && q.TryDequeue(out overflow)) ;
            }
        }
    }
}
