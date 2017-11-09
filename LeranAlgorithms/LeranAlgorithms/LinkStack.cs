using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeranAlgorithms
{
    public class LinkStack<Item>
    {
        private Node first = null;
        public class Node
        {
            public Item item;
            public Node next;
        }
        // N is sign
        public bool isEmpty()
        {
            return first == null;
        }
        public void push(Item item)
        {
            Node temp = new Node();
            temp.item = item;
            temp.next = first;
            first = temp;
        }
        public Item pop()
        {
            Item temp = first.item;
            first = first.next;
            return temp;
        }
    }
}
