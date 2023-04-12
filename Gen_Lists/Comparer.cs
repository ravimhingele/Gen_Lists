using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gen_Lists
{
    class PriorityComparer<T> : Comparer<T>
        where T : IComparable
    {
        public override int Compare(T x, T y)
        {
            if (object.Equals(x, y)) return 0;
            return x.CompareTo(y);
        }
    }
}
