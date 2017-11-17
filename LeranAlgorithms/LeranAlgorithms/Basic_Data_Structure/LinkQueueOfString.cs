using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeranAlgorithms
{
    public class Node
    {
        public string item;
        public Node next;
    }
    public class LinkQueueOfString
    {
        private Node first, last;
        public bool IsEmpty()
        {
            return first==null;
        }
        public void enQueue(string item)
        {
            Node oldLast = last;
            last = new Node();
            last.item = item;
            last.next = null;
            if (IsEmpty())    first = last;
            else            oldLast.next = last;
        }
        public string deQueue()
        {
            var temp = first.item;   
            first = first.next;
            if (IsEmpty()) last = null;
            return temp;
        }
    }
}
