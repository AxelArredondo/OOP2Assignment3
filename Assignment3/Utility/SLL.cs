using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Assignment3.Utility
{
    [DataContract]  // Ensure the class is serializable
    [KnownType(typeof(Node))]  // Mark Node as a known type
    [KnownType(typeof(User))]  // Mark User as a known type
    //implements singly linked list using Node and User
    public class SLL : ILinkedListADT
    {
        private Node head;
        private int count;
        //creates empty linked list
        public SLL()
        {
            head = null;
            count = 0;
        }

        //adds user to the end of list
        public void AddLast(User value)
        {
            Node newNode = new Node(value);
            if (IsEmpty())
            {
                head = newNode;
            }
            else
            {
                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
            count++;
        }
        //adds user to the beginning of list
        public void AddFirst(User value)
        {
            Node newNode = new Node(value);
            newNode.Next = head;
            head = newNode;
            count++;
        }

        //adds user at a specific index in list
        public void Add(User value, int index)
        {
            if (index < 0 || index > count)
                throw new IndexOutOfRangeException();
            if (index == 0)
            {
                AddFirst(value);
                return;
            }
            Node newNode = new Node(value);
            Node current = head;

            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }
            newNode.Next = current.Next;
            current.Next = newNode;
            count++;
        }

        //replaces value at a specific index
        public void Replace(User value, int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();
            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            current.Data = value;
        }

        //returns number of elements in ist
        public int Count()
        {
            return count;
        }

        //removes first element in list
        public void RemoveFirst()
        {
            if (IsEmpty())
                throw new Exception("cannot remove from empty list");
            head = head.Next;
            count--;
        }

        //removes last element in list
        public void RemoveLast()
        {
            if (IsEmpty())
                throw new Exception("cannot remove from empty list");
            if (count == 1)
            {
                head = null;
            }
            else
            {
                Node current = head;
                while (current.Next.Next != null)
                {
                    current = current.Next;
                }
                current.Next = null;
            }
            count--;
        }

        //removes element at a specific index
        public void Remove(int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();
            if (index == 0)
            {
                RemoveFirst();
                return;
            }
            Node current = head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }
            current.Next = current.Next.Next;
            count--;
        }

        //gets value at the specified index
        public User GetValue(int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();
            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            return (User)current.Data;
        }
        //returns index of user in list or -1 if isnt found
        public int IndexOf(User value)
        {
            Node current = head;
            int index = 0;
            while (current != null)
            {
                if (current.Data.Equals(value))
                    return index;
                current = current.Next;
                index++;
            }
            return -1;
        }

        //checks if list contains user
        public bool Contains(User value)
        {
            return IndexOf(value) != -1;
        }

        //returns true if list is empty
        public bool IsEmpty()
        {
            return count == 0;
        }

        //clears list
        public void Clear()
        {
            head = null;
            count = 0;
        }

        //additional feature: reverses the list
        public void Reverse()
        {
            Node prev = null;
            Node current = head;
            while (current != null)
            {
                Node next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }
            head = prev;
        }
    }
}