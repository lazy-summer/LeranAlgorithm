using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeranAlgorithms
{
    public class StackToQueue
    {
        private ArrStack<int> stack1=new ArrStack<int>(5);
        private ArrStack<int> stack2=new ArrStack<int>(5);
        public void push(int item)
        {
            stack1.push(item);
        }
        public int pop()
        {
            if (stack2.isEmpty())
            {
                while (!stack1.isEmpty())
                {
                    stack2.push(stack1.pop());
                }
            }
            return stack2.pop();
        }
        public bool IsEmpty()
        {
            return stack2.isEmpty() && stack1.isEmpty();
        }
    }
}
