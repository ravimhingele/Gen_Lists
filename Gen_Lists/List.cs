using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.MobileControls;
using System.Xml.Linq;


namespace Gen_Lists
{
    internal class List<T> : IEnumerable<T>, IComparable<List<T>>, ICloneable, ICollection<T>
        where T : IComparable
    {
        public List_Item<T> Head { get; set; }
        public List_Item<T> Tail { get; set; }

        public List(T[] arr)
        {
            foreach (T i in arr)
            {
                this.AddLast(i);
            }
        }
        
        int ICollection<T>.Count => this.Count();

        public bool IsReadOnly => false;

        public int count = 0;
        public List()
        {
           
        }
        public List(T s)
        {
            List_Item<T> item = new List_Item<T>(s);
        }

        public bool Contains(T s)
        {
            if (Find(s).Value != null)
                return true;
            return false;
        }

        public void RemoveFirst()
        {
            if (this.count == 1)
            {
                Tail = null;
                Head = null;
                count--;
            }
            if (count > 1)
            {
                List_Item<T> item = Head;
                Head = item.Next;
                item.Next = null;
                Head.Previous = null;
                count--;
            }
        }

        public void AddFirst(T s)
        {
            List_Item<T> newHead = new List_Item<T>(s);
            if (this.count == 0)
            {
                Tail = null;
                Head = null;
            }
            newHead.Next = Head;
            newHead.List = this;
            Head.Previous = newHead;
            Head = newHead; 
            count++;
        }

        public void RemoveLast()
        {
            if (count == 1)
            {
                Head = Tail = null;
                count--;
            }
            if (count > 1)
            {
                List_Item<T> item = Tail;
                Tail = item.Previous;
                Tail.Next = null;
                item.Previous = null;
                item.List = null;
                count--;
            }
        }

        public void AddLast(T s)
        {
            List_Item<T> item = new List_Item<T>(s);
            if (Head == null)
            {
                Head = item;
                Tail = item;
                count++;
                return;
            }
            Tail.Next = item;
            item.Previous = Tail;
            Tail = item;
            item.List = this;
            count++;
        }

        public List_Item<T> Find(T s)
        {
            List_Item<T> item = Head;
            if (Head == null)
            {
                item = new List_Item<T>();
                return item;
            }
            
            while (item.Next != null && !item.Value.Equals(s))
                item = item.Next;
            if (Equals(item.Value, s))
                return item;
            item = new List_Item<T>();
            return item;
        }

        public List_Item<T> FindLast(T s)
        {
            List_Item<T> item = Tail;
            while (item.Previous != null)
            {
                if (Equals(item.Value, s))
                    return item;
                item = item.Previous;
            }
            return null;
        }

        public void AddBefore(List_Item<T> node, T s)
        {
            List_Item<T> result = new List_Item<T>(s);
            if (Find(result.Value).List == this)
            {
                throw new InvalidOperationException("The LinkedList node belongs a LinkedList");
            }
            result.List = this;
            //List_Item<T> result = new List_Item<T>(s);
            InsertBefore(node, result);
        }

        public void AddBefore(List_Item<T> node, List_Item<T> newNode)
        {
            InsertBefore(node, newNode);
            newNode.List = this;
            if (node == Head)
            {
                Head = newNode;
            }
        }

        public void AddAfter(List_Item<T> node, T s)
        {
            List_Item<T> result = new List_Item<T>(s);
            if (Find(result.Value).List == this)
            {
                throw new InvalidOperationException("The LinkedList node belongs a LinkedList");
            }
            result.List = this;
            InsertBefore(node.Next, result);
        }

        public void AddAfter(List_Item<T> node, List_Item<T> newNode)
        {
            InsertBefore(node.Next, newNode);
            newNode.List = this;
        }

        public override string ToString()
        {
            if (count == 0) return "";
            StringBuilder str = new StringBuilder();
            List_Item<T> temp = Head;
            //string c = "";
            //c = c + temp.Value + " ";
            if (this.count == 0)
            {
                return "";
            }
            while (temp.Next != null)
            {
                str.Append(temp.Value.ToString() + " ");
                temp = temp.Next;
                //c = c + temp.Value + " ";
            }
            str.Append(temp.Value.ToString() + " ");
            return str.ToString();
        }


        public void IsPalindrome()
        {
            List_Item<T> temp = Head;
            List<T> second = Reverse();
            List_Item<T> temp2 = second.Head;
            while (temp != null)
            {
                if (!temp.Value.Equals(temp2.Value))
                {
                    Console.WriteLine("Не палиндром");
                    return;
                }
                temp = temp.Next;
                temp2 = temp2.Next;
            }
            Console.WriteLine("Палиндром");
        }

        public List<T> Reverse()
        {
            List<T> newList = new List<T>();
            var temp = Tail;
            while (temp != null)
            {
                newList.AddLast(temp.Value);
                temp = temp.Previous;
            }
            return newList;
        }

        public bool Remove(List_Item<T> item)
        {
            
            bool result = false;
            List_Item<T> temp = Head;
            if (item.Next == null)
            {
                Tail = Tail.Previous;
                Tail.Next = null;
                item.Previous = null;
                result = true;
                count--;
                return result;
            }
            if (item.Previous == null)
            {
                Head = Head.Next;
                Head.Previous = null;
                item.Next = null;
                result = true;
                count--;
                return result;
            }
            while (temp.Next != null)
            {
                if (temp.Equals(item))
                {
                    temp.Previous.Next = temp.Next;
                    temp.Next.Previous = temp.Previous;
                    temp.List = null;
                    count--;
                    result = true;
                    return result;
                }
                temp = temp.Next;
            }
            if (temp.Equals(item))
            {
                temp.Previous.Next = temp.Next;
                temp.List = null;
                count--;
                result = true;
                return result;
            }
            return result;
        }
        public bool Remove(T value)
        {
            bool result = false;
            List_Item<T> temp = Head;
            while (temp.Next != null)
            {
                if (temp.Value.Equals(value))
                {
                    temp.Previous.Next = temp.Next;
                    temp.Next.Previous = temp.Previous;
                    temp.List = null;
                    count--;
                    result = true;
                    return result;
                }
                temp = temp.Next;
            }
            if (temp.Value.Equals(value))
            {
                temp.Previous.Next = null;
                temp.List = null;
                count--;
                result = true;
                return result;
            }
            return result;
        }

        public int Count()
        {
            return count;
        }

        public void CopyTo(T[] s, int index)
        {
            List_Item<T> item = Head;
            for (int i = index; i < s.Length - 1; i++)
            {
                s[i] = item.Value;
                item = item.Next;
            }
        }

        public void Clear()
        {
            Head = Tail = null;
            count = 0;
        }

        private void InsertBefore(List_Item<T> node, List_Item<T> newNode)
        {
            if (node == null)
            {
                newNode.Next = null;
                newNode.Previous = Tail;
                count++;
            }
            else
            {
                newNode.Next = node;
                newNode.Previous = node.Previous;
                node.Previous.Next = newNode;
                node.Previous = newNode;
                count++;
            }
        }


        // Получаем перечисление всех элементов списка
        public IEnumerator<T> GetEnumerator()
        {
            List_Item<T> current = Head;
            while(current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        // Сравниваем списки по числу элементов
        public int CompareTo(List<T> list)
        {
            return Count().CompareTo(list.Count());
            /*
            if (list.Count() > Count() ) return -1;
            if (list.Count() < Count()) return 1;
            return 0;*/
        }

        public List<T> Clone()
        {
            List<T> clone = new List<T>();
            foreach (var t in this)
            {
                clone.AddLast(t);
            }
            return clone;
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public void Add(T item)
        {
            AddLast(item);
        }

        bool ICollection<T>.Remove(T item)
        {
            return Remove(item);
        }

        public void Sort(IComparer<T> comparator)
        {
            List_Item<T> temp1 = Head;
            List_Item<T> temp2;
            for (int i = 0; i < count; i++)
            {
                if (i > 0) { temp1 = temp1.Next; } // пропуск первого элемента
                temp2 = temp1;
                for (int j = i; j > 0; j--)
                {
                    if (j < i) { temp2 = temp2.Previous; }
                    if (comparator.Compare(temp2.Value, temp2.Previous.Value) < 0)
                    {
                        T tempValue = temp2.Value;
                        temp2.Value = temp2.Previous.Value;
                        temp2.Previous.Value = tempValue;
                    }
                }
            }
        }

        
    }
}
