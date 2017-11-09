using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeranAlgorithms
{
    class Program
    {
        static void show(int x)
        {
            Console.WriteLine(x);
        }
        static void Main(string[] args)
        {
            //Test UF
            /*StreamReader sr = File.OpenText(@"C:\Users\wsj\Desktop\2.txt");
            int N = Convert.ToInt32(sr.ReadLine());
            int[] arr=new int[22];
            for(int i =0; i < 22; i++)  arr[i]=Convert.ToInt32(sr.ReadLine());
            sr.Close();
            //var uf = new QucikFindUF(N);
            var uf = new QuickUnionUF(N);
            for (int i = 0; i < 22; i++)
            {
                int p = arr[i++];
                int q = arr[i];
                if (uf.connected(p, q) == false)
                {
                    uf.union(p, q);
                    Console.WriteLine(p + "  " + q);
                }
            }
            uf.show();*/

            //Test Stack
            /*// var strStack = new ArrStack<int>(2);   //只有确定类型后才可以放入
            var strStack = new LinkStack<int>();  
            //var strStack = new LinkStackOfString();
            strStack.push(4);
            strStack.push(2);
            strStack.push(3);
            while (!strStack.isEmpty())
            {
                Console.WriteLine(strStack.pop());
            }*/

            //Test Queue
            /*LinkQueueOfString linkQ = new LinkQueueOfString();
            linkQ.enQueue("1");
            linkQ.enQueue("2");
            linkQ.enQueue("3");
            while (!linkQ.IsEmpty())
            {
                Console.WriteLine(linkQ.deQueue());
            }*/

            //Test Stack to Queue
            /*StackToQueue stq = new StackToQueue();
            stq.push(1);
            stq.push(2);
            stq.push(3);
            while (!stq.IsEmpty())
            {
                show(stq.pop());
            }*/

            //Test Sort
            /*Sort sort = new Sort();
            sort.showOrder();
            sort.shellSort();
            sort.showOrder();
            var psort = new PokerSort();
            psort.iinitialize();
            psort.sortAndShow();
            psort.shellsort();
            //var prsort = new PracticalSort();
            //var quSort = new Quick();
            var threeSort = new ThreeWaySort();
            int[] arr = new int[6];
            Random rd = new Random();
            for(int i=0;i<arr.Length;i++)
            {
                arr[i] = rd.Next(5*arr.Length);
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            threeSort.sort(arr,0,arr.Length -1);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]+" ");
            }
            //Console.Write(quSort.selectIndex(arr,5));*/

            //Test HeapSort
            var bsort = new BinaryHeap(100);

            int[] arr = new int[10];
            Random rd = new Random();


            for (int i = 1; i < 80; i++)
            {
                var x = rd.Next(200);
                bsort.Insert(x);
                Console.WriteLine(x);
            }
            Console.WriteLine("");
            while (!bsort.IsEmpty())
            {
                Console.WriteLine(bsort.DelMin());
            }

            for (int i = 1; i < 10; i++)
                arr[i] = rd.Next(105);

            var hsort = new HeapSort(arr);
            //foreach (int item in arr)
              //  Console.WriteLine(item);

        }
    }
}
