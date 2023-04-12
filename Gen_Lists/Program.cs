﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gen_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<T> list = new List<T>;
            list.AddAfter("s");
            list.AddAfter("a");
            List.AddAfter("b");

            
            //TestInterface();

            //TestList();
            //TestMyList();

            void TestInterface()
            {
                List<int> first = new List<int>();
                List<int> second = new List<int>();

                first.AddLast(1);
                first.AddLast(3);

                second = first.Clone();

                second.AddLast(2);
                //Console.WriteLine(first.CompareTo(second));
                Console.WriteLine(second);
                Console.WriteLine(first);

                Console.ReadKey();
            }

            void TestList()
            {
                // Create the link list.
                string[] words =
                    { "the", "fox", "jumps", "over", "the", "dog" };
                LinkedList<string> sentence = new LinkedList<string>(words);
                Display(sentence, "The linked list values:");
                Console.WriteLine("sentence.Contains(\"jumps\") = {0}",
                    sentence.Contains("jumps"));

                // Add the word 'today' to the beginning of the linked list.
                sentence.AddFirst("today");
                Display(sentence, "Test 1: Add 'today' to beginning of the list:");

                // Move the first node to be the last node.
                LinkedListNode<string> mark1 = sentence.First;
                sentence.RemoveFirst();
                sentence.AddLast(mark1);
                Display(sentence, "Test 2: Move first node to be last node:");

                // Change the last node to 'yesterday'.
                sentence.RemoveLast();
                sentence.AddLast("yesterday");
                Display(sentence, "Test 3: Change the last node to 'yesterday':");

                // Move the last node to be the first node.
                mark1 = sentence.Last;
                sentence.RemoveLast();
                sentence.AddFirst(mark1);
                Display(sentence, "Test 4: Move last node to be first node:");

                // Indicate the last occurence of 'the'.
                sentence.RemoveFirst();
                LinkedListNode<string> current = sentence.FindLast("the");
                IndicateNode(current, "Test 5: Indicate last occurence of 'the':");

                // Add 'lazy' and 'old' after 'the' (the LinkedListNode named current).
                sentence.AddAfter(current, "old");
                sentence.AddAfter(current, "lazy");
                IndicateNode(current, "Test 6: Add 'lazy' and 'old' after 'the':");

                // Indicate 'fox' node.
                current = sentence.Find("fox");
                IndicateNode(current, "Test 7: Indicate the 'fox' node:");

                // Add 'quick' and 'brown' before 'fox':
                sentence.AddBefore(current, "quick");
                sentence.AddBefore(current, "brown");
                IndicateNode(current, "Test 8: Add 'quick' and 'brown' before 'fox':");

                // Keep a reference to the current node, 'fox',
                // and to the previous node in the list. Indicate the 'dog' node.
                mark1 = current;
                LinkedListNode<string> mark2 = current.Previous;
                current = sentence.Find("dog");
                IndicateNode(current, "Test 9: Indicate the 'dog' node:");

                // The AddBefore method throws an InvalidOperationException
                // if you try to add a node that already belongs to a list.
                Console.WriteLine("Test 10: Throw exception by adding node (fox) already in the list:");
                try
                {
                    sentence.AddBefore(current, mark1);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("Exception message: {0}", ex.Message);
                }
                Console.WriteLine();

                // Remove the node referred to by mark1, and then add it
                // before the node referred to by current.
                // Indicate the node referred to by current.
                sentence.Remove(mark1);
                sentence.AddBefore(current, mark1);
                IndicateNode(current, "Test 11: Move a referenced node (fox) before the current node (dog):");

                // Remove the node referred to by current.
                sentence.Remove(current);
                IndicateNode(current, "Test 12: Remove current node (dog) and attempt to indicate it:");

                // Add the node after the node referred to by mark2.
                sentence.AddAfter(mark2, current);
                IndicateNode(current, "Test 13: Add node removed in test 11 after a referenced node (brown):");

                // The Remove method finds and removes the
                // first node that that has the specified value.
                sentence.Remove("old");
                Display(sentence, "Test 14: Remove node that has the value 'old':");

                // When the linked list is cast to ICollection(Of String),
                // the Add method adds a node to the end of the list.
                sentence.RemoveLast();
                ICollection<string> icoll = sentence;
                icoll.Add("rhinoceros");
                Display(sentence, "Test 15: Remove last node, cast to ICollection, and add 'rhinoceros':");

                Console.WriteLine("Test 16: Copy the list to an array:");
                // Create an array with the same number of
                // elements as the linked list.
                string[] sArray = new string[sentence.Count];
                sentence.CopyTo(sArray, 0);

                foreach (string s in sArray)
                {
                    Console.WriteLine(s);
                }

                // Release all the nodes.
                sentence.Clear();

                Console.WriteLine();
                Console.WriteLine("Test 17: Clear linked list. Contains 'jumps' = {0}",
                    sentence.Contains("jumps"));

                Console.ReadLine();
            }

            void TestMyList()
            {
                // Create the link list.
                string[] words =
                    { "the", "fox", "jumps", "over", "the", "dog" };
                List<string> sentence = new List<string>();
                foreach (string word in words)
                {
                    sentence.AddLast(word);
                }

                Display(sentence, "The linked list values:");
                Console.WriteLine("sentence.Contains(\"jumps\") = {0}",
                    sentence.Contains("jumps"));

                // Add the word 'today' to the beginning of the linked list.
                sentence.AddFirst("today");
                Display(sentence, "Test 1: Add 'today' to beginning of the list:");

                // Move the first node to be the last node.
                List_Item<string> mark1 = sentence.Head;
                sentence.RemoveFirst();
                sentence.AddLast(mark1.Value);
                Display(sentence, "Test 2: Move first node to be last node:");

                // Change the last node to 'yesterday'.
                sentence.RemoveLast();
                sentence.AddLast("yesterday");
                Display(sentence, "Test 3: Change the last node to 'yesterday':");

                // Move the last node to be the first node.
                mark1 = sentence.Tail;
                sentence.RemoveLast();
                sentence.AddFirst(mark1.Value);
                Display(sentence, "Test 4: Move last node to be first node:");

                // Indicate the last occurence of 'the'.
                sentence.RemoveFirst();
                List_Item<string> current = sentence.FindLast("the");
                IndicateNode(current, "Test 5: Indicate last occurence of 'the':");

                // Add 'lazy' and 'old' after 'the' (the LinkedListNode named current).
                sentence.AddAfter(current, "old");
                sentence.AddAfter(current, "lazy");
                IndicateNode(current, "Test 6: Add 'lazy' and 'old' after 'the':");

                // Indicate 'fox' node.
                current = sentence.Find("fox");
                IndicateNode(current, "Test 7: Indicate the 'fox' node:");

                // Add 'quick' and 'brown' before 'fox':
                sentence.AddBefore(current, "quick");
                sentence.AddBefore(current, "brown");
                IndicateNode(current, "Test 8: Add 'quick' and 'brown' before 'fox':");

                // Keep a reference to the current node, 'fox',
                // and to the previous node in the list. Indicate the 'dog' node.
                mark1 = current;
                List_Item<string> mark2 = current.Previous;
                current = sentence.Find("dog");
                IndicateNode(current, "Test 9: Indicate the 'dog' node:");


                // The AddBefore method throws an InvalidOperationException
                // if you try to add a node that already belongs to a list.
                Console.WriteLine("Test 10: Throw exception by adding node (fox) already in the list:");
                try
                {
                    sentence.AddBefore(current, mark1.Value);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception message: {0}", ex.Message);
                }
                Console.WriteLine();

                // Remove the node referred to by mark1, and then add it
                // before the node referred to by current.
                // Indicate the node referred to by current.
                sentence.Remove(mark1.Value);
                sentence.AddBefore(current, mark1.Value);
                IndicateNode(current, "Test 11: Move a referenced node (fox) before the current node (dog):");

                // Remove the node referred to by current.
                sentence.Remove(current);
                IndicateNode(current, "Test 12: Remove current node (dog) and attempt to indicate it:");

                // Add the node after the node referred to by mark2.
                sentence.AddAfter(mark2, current);
                IndicateNode(current, "Test 13: Add node removed in test 12 after a referenced node (brown):");

                // The Remove method finds and removes the
                // first node that that has the specified value.
                sentence.Remove("old");
                Display(sentence, "Test 14: Remove node that has the value 'old':");



                
                // When the linked list is cast to ICollection(Of String),
                // the Add method adds a node to the end of the list.
                sentence.RemoveLast();
                ICollection<string> icoll = sentence;
                icoll.Add("rhinoceros");
                Display(sentence, "Test 15: Remove last node, cast to ICollection, and add 'rhinoceros':");
                


                Console.WriteLine("Test 16: Copy the list to an array:");
                // Create an array with the same number of
                // elements as the linked list.
                string[] sArray = new string[sentence.count - 1];
                sentence.CopyTo(sArray, 0);

                foreach (string s in sArray)
                {
                    Console.WriteLine(s);
                }



                // Release all the nodes.
                sentence.Clear();

                Console.WriteLine();
                Console.WriteLine("Test 17: Clear linked list. Contains 'jumps' = {0}",
                    sentence.Contains("jumps"));

                Console.ReadLine();
            }
        }

        private static void Display(List<string> words, string test)
        {
            Console.WriteLine(test);
            foreach (string word in words)
            {
                Console.Write(word + " ");
            }
            //Console.WriteLine(words);
            Console.WriteLine();
            Console.WriteLine();
        }

        private static void IndicateNode(List_Item<string> node, string test)
        {
            Console.WriteLine(test);
            if (node.List == null)
            {
                Console.WriteLine("Node '{0}' is not in the list.\n",
                    node.Value);
                return;
            }

            StringBuilder result = new StringBuilder("(" + node.Value + ")");
            List_Item<string> nodeP = node.Previous;

            while (nodeP != null)
            {
                result.Insert(0, nodeP.Value + " ");
                nodeP = nodeP.Previous;
            }

            node = node.Next;
            while (node != null)
            {
                result.Append(" " + node.Value);
                node = node.Next;
            }

            Console.WriteLine(result);
            Console.WriteLine();
        }

        private static void Display(LinkedList<string> words, string test)
        {
            Console.WriteLine(test);
            foreach (string word in words)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        private static void IndicateNode(LinkedListNode<string> node, string test)
        {
            Console.WriteLine(test);
            if (node.List == null)
            {
                Console.WriteLine("Node '{0}' is not in the list.\n",
                    node.Value);
                return;
            }

            StringBuilder result = new StringBuilder("(" + node.Value + ")");
            LinkedListNode<string> nodeP = node.Previous;

            while (nodeP != null)
            {
                result.Insert(0, nodeP.Value + " ");
                nodeP = nodeP.Previous;
            }

            node = node.Next;
            while (node != null)
            {
                result.Append(" " + node.Value);
                node = node.Next;
            }

            Console.WriteLine(result);
            Console.WriteLine();
        }
    }
}
