using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeranAlgorithms
{
    public class ArrStack<Item>
    {
        private Item[] str;
        // N is sign
        private int N = 0;            
        public ArrStack(int capacity)
        {
            str = new Item[capacity];
        }
        public bool isEmpty()
        {
            return N==0;
        }
        public void push(Item item)
        {
            if (N == str.Length)
            {
                resize(2 * N);
            }
            str[N++] = item;
        }
        public Item pop()
        {
            if (N>0&&N == str.Length / 4)             //N>0是为了保证在没有元素的时候不Pop
            {
                resize(str.Length/2);
            }
            return str[--N];
        }
        public void resize(int capacity)                //实现动态堆栈数组的关键（同时满翻倍，少于1/4缩减一半的思想十分了得！！）
        {
            var tempstr = new Item[capacity];
            for(int i = 0; i < N; i++)
            {
                tempstr[i] = str[i];
            }
            str = tempstr;
        }

    }
}
