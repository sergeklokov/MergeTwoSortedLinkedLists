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
        /// </summary>
        static void Main(string[] args)
        {
            var array1 = new int[] { 4, 8, 15, 19 };
            var array2 = new int[] { 7, 9, 10, 16 };

            // let's convert arrays above to linked lists
            // Note:
            // Linked List class in c# is in fact Double Linked List, so we will not use one (second) pointer, to imitate real Linked List. 
            var llist1 = new LinkedList<int>(array1);
            var llist2 = new LinkedList<int>(array2);

            PrintLinkedList(llist1);
            PrintLinkedList(llist2);

        }

        private static void PrintLinkedList(LinkedList<int> linkedList)
        {
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
