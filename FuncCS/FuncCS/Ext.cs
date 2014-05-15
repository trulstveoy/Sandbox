using System;

namespace FuncCS
{
    public static class Ext
    {
        public static void Pipe<T>(this T obj, Action<T> action)
        {
            action(obj);
        }

        public static R Pipe<T,R>(this T obj, Func<T, R> func)
        {
            return func(obj);
        }
    }
}
