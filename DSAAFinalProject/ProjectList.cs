using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAAFinalProject
{
    public class ProjectList<T>
    {
        class Node // Node class created.
        {
            public T data;
            public Node Next = null;

            public Node(T data)
            {
                this.data = data;
            }
        }

        private Node Head = null;  // The first node is assigned null by default.
        public int Count = 0; // Size variable is set to 0 by default.

        public void Add(T data) // Method to add an element to the list
        {
            Node node = new Node(data);

            if (Count == 0) // If this is the first time an element is added to the list, it will be added at the beginning.
            {
                Head = node;
            }

            else // If a new element is added to the list, the elements will be shifted and added at the beginning.
            {
                node.Next = Head;
                Head = node;
            }

            Count++; // Increases the number by one as an element is added to the list.
        }

        public void Remove(T data) // Created a method to delete an element from the list.
        {
            if (Equals(Head.data, data)) // If the data to be deleted is the last data added, delete it and reduce the list size by one.
            {
                Head = Head.Next;
                Count--;
            }

            else // If the data to be deleted is not the last one in the list 
            {
                Node nodeToRemove = Head; // Create node for the data to be deleted and assign the last node added to the list.
                Node previousNode = Head; // Create a node for the data that holds the address of the data to be deleted and assign it to the last node added to the list.

                while (!(Equals(nodeToRemove.data, data)) && nodeToRemove.Next != null) // The data to be deleted is searched in the list.
                {
                    previousNode = nodeToRemove; // The node that holds the address of the data to be deleted is assigned the node that holds the data to be deleted.
                    nodeToRemove = nodeToRemove.Next; // The node that holds the data to be deleted is assigned the address of the next node (to navigate through the list)
                }

                if (Equals(nodeToRemove.data, data)) // If the data to be deleted as a result of the scan is present in the list
                {
                    previousNode.Next = nodeToRemove.Next; // The address of the previous node holding the data to be deleted is assigned the next address held by the node holding the data to be deleted.
                    nodeToRemove.Next = null; // Delete operation
                    Count--; // Reduced the size of the list.
                }

                else
                    Console.WriteLine("Silmek istenen değer liste içerisinde bulunamadı .");
            }
        }

        public IEnumerable<T> GetEnumerator() // Method created to perform iteration in the created data structure
        {
            for (Node node = Head; node != null; node = node.Next) // Returns all the data returned from the elements in the list.
            {
                yield return node.data;
            }
        }
    }
}
