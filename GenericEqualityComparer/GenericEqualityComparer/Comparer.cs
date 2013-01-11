using System;
using System.Collections.Generic;

namespace GenericEqualityComparer
{
    public class Comparer<T> : IEqualityComparer<T>
    {
        public Comparer(Func<T, object> c)
        {
            //_sourceVsTarget = sourceVsTarget;
        }

        public Comparer(Func<T, object> c1, Func<T, object> c2)
        {

        }

        public bool Equals(T x, T y)
        {
            return false;
        }

        public int GetHashCode(T obj)
        {
            return 0;
        }
    }
}