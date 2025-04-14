using System;
using static System.Net.Mime.MediaTypeNames;

namespace Assignment3.Utility
{
    [Serializable]
    public class Node
    {
        //gets or sets data stored in node
        public object Data { get; set; }
        //gets or sets reference to the next node in list
        public Node Next { get; set; }
        //creates new node with specified data
        public Node(object data)
        {
            Data = data;
            Next = null;
        }
    }
}

