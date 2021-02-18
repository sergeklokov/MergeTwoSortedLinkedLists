using System;
using System.Collections.Generic;

namespace MergeTwoSortedLinkedLists
{
    class Program
    {
        /// <summary>
        /// Merge two sorted linked lists
        /// Given two sorted linked lists, merge them so that the resulting linked list is also sorted.
        /// Consider two sorted linked lists and the merged list below them as an example.
        /// ///
        /// https://www.educative.io/blog/crack—amazon-coding-interview-questions
        ///
        ///
        /// </summary>
        static void Main(string[] args)
        {
            var al = new int[] { 4, 8, 15, 19, 20 };
            //var al = new int[] { };
            var a2 = new int[] { 7, 9, 16, 16 };
            //var a2 = new int[] { };

            // let's convert arrays above to linked lists
            // Note:
            // Linked List class in c# is in fact Double Linked List, so we will not use one (second) pointer, to imitate real Linked List. 
            var ll1 = new LinkedList<int>(al);
            var ll2 = new LinkedList<int>(a2);
            PrintLinkedList("Linked list 1     ", ll1);
            PrintLinkedList("Linked list 2     ", ll2);
            var ll3 = MergeTwoSortedLinkedLists(ll1, ll2);
            PrintLinkedList("Merged in a loop  ", ll3);
            var ll4 = MergeTwoSortedLinkedListsRecursive(ll1, ll2);
            PrintLinkedList("Merged recursively", ll4);
            Console.WriteLine("Press any key..");
            Console.ReadKey();
        }

        private static LinkedList<int> MergeTwoSortedLinkedListsRecursive(LinkedList<int> ll1, LinkedList<int> ll2)
        {
            void SortedMergeRecursive(LinkedList<int> r, LinkedListNode<int> n1, LinkedListNode<int> n2)
            {
                if (n1 != null || n2 != null)
                {
                    if (n1 == null)
                    {
                        r.AddLast(n2.Value);
                        n2 = n2.Next;
                    }
                    else if (n2 == null)
                    {
                        r.AddLast(n1.Value);
                        n1 = n1.Next;
                    }
                    else if (n1.Value < n2.Value)
                    {
                        r.AddLast(n1.Value);
                        n1 = n1.Next;
                    }
                    else
                    {
                        r.AddLast(n2.Value);
                        n2 = n2.Next;

                    }
                    SortedMergeRecursive(r, n1, n2); // recursive call
                }
            }

            var llResult = new LinkedList<int>();
            SortedMergeRecursive(llResult, ll1.First, ll2.First);
            return llResult;
        }

        private static LinkedList<int> MergeTwoSortedLinkedLists(LinkedList<int> ll1, LinkedList<int> ll2)
        {
            var n1 = ll1.First;
            var n2 = ll2.First;
            var llResult = new LinkedList<int>();

            // now iterate and merge both
            while (n1 != null || n2 != null)
            {
                if (n1 == null)
                {
                    llResult.AddLast(n2.Value);
                    n2 = n2.Next;
                }
                else if (n2 == null)
                {
                    llResult.AddLast(n1.Value);
                    n1 = n1.Next;
                }
                else if (n1.Value < n2.Value)
                {
                    llResult.AddLast(n1.Value);
                    n1 = n1.Next;
                }
                else
                {
                    llResult.AddLast(n2.Value);
                    n2 = n2.Next;
                }
            }

            return llResult;
        }

        private static void PrintLinkedList(string version, LinkedList<int> linkedList)
        {
            if (String.IsNullOrWhiteSpace(version))
                Console.Write(version + ": ");

            var node = linkedList.First;
            while (node != null)
            {
                Console.Write(node.Value + " ");
                node = node.Next;
            }

            Console.WriteLine();
        }
    }
}