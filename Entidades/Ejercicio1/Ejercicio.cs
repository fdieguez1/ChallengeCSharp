using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Entidades.Ejercicio1
{
    public static class Ejercicio
    {
        public static readonly Random Rnd = new();

        #region Ejercicio 1
        public static Lazy<IEnumerable<T>> FilterCollection<T>(this IEnumerable<T> originalCollection, Func<T, bool> evaluate)
        {
            if (originalCollection == null)
            {
                throw new ArgumentNullException(nameof(originalCollection));
            }
            if (evaluate == null)
            {
                throw new ArgumentNullException(nameof(evaluate));
            }
            var filtered = MyWhere(originalCollection, evaluate);
            Lazy<IEnumerable<T>> lazyCollection = new (filtered);
            return lazyCollection;
        }
        private static Collection<T> MyWhere<T>(this IEnumerable<T> originalCollection, Func<T, bool> evaluate)
        {
            Collection<T> col = new();
            foreach (T item in originalCollection)
            {
                if (evaluate(item))
                {
                    col.Add(item);
                }
            }
            return col;
        }

        public static T[] MyToArray<T>(this IEnumerable<T> originalCollection)
        {
            if (originalCollection is ICollection<T> collection)
            {
                T[] tmp = new T[collection.Count];
                collection.CopyTo(tmp, 0);
                return tmp;
            }

            T[] ret = Array.Empty<T>();
            int count = 0;
            foreach (T item in originalCollection)
            {
                if (count == ret.Length)
                {
                    Array.Resize(ref ret, ret.Length * 2);
                }
                ret[count++] = item;
            }

            if (count != ret.Length)
            {
                Array.Resize(ref ret, count);
            }
            return ret;
        }

        #endregion

        #region MetodosHardcodeoDePrueba

        public static List<TestClass> HardcodeTestClassList()
        {
            List<TestClass> list = new()
            {
                new TestClass() { IsActive = true, Name = "TestName List A", Number = 5 },
                new TestClass() { IsActive = true, Name = "TestName List B", Number = 6 },
                new TestClass() { IsActive = false, Name = "TestName List C", Number = 7 },
                new TestClass() { IsActive = false, Name = "TestName List D", Number = 2 },
                new TestClass() { IsActive = true, Name = "TestName List E", Number = 3 },
            };
            return list;
        }
        public static Stack<TestClass> HardcodeTestClassStack()
        {
            return new Stack<TestClass>(HardcodeTestClassList());
        }

        public static Queue<int> HardcodeIntQueue()
        {
            Queue<int> queue = new();
            for (int i = 0; i < 5; i++)
            {
                queue.Enqueue(Rnd.Next(0, 101));
            }
            return queue;
        }
        public static Stack<string> HardcodeStringStack()
        {
            Stack<string> stack = new();
            for (int i = 0; i < 5; i++)
            {
                stack.Push("TestString" + i);
            }
            return stack;
        }
        #endregion
    }
}
