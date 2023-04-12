using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Gen_Lists
{
    internal class List_Item<T>
    {
        public T Value;
        public List_Item<T> Next = null;
        public List_Item<T> Previous = null;
        public List<T> List = null;
        public List_Item() { }

        public List_Item(T s)
        {
            Value = s;
        }
    }

}
