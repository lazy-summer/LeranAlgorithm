using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeranAlgorithms
{
    public class EasySort
    {
        private int[] arr = new int[] { 9, 11, 5, 4, 7, 6, 19, 11, 50, 15 };
        public void swap(int p, int q)
        {
            int temp = arr[p];
            arr[p] = arr[q];
            arr[q] = temp;
        }
        public void showOrder()
        {
            foreach (int item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("");

        }
        public void selectSort()
        {
            int min;
            for (int i = 0; i < arr.Length; i++)
            {
                min = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min]) min = j;
                }
                swap(i, min);
            }
        }
        public void insertSort()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i ; j > 0; j--)
                {
                    if (arr[j] < arr[j - 1]) swap(j, j - 1);    //小于不加等于便是稳定的排序，也就是相同的情况下不变
                    else break;
                }
            }
        }
        public void shellSort()
        {
            int[] sedgewick = { 1, 5, 19, 41, 109, 209, 505, 929 };
            foreach(int increment in sedgewick)
            for (int i = 0; i < arr.Length; i+=increment)
            {
               int min = i;
               for(int j = i + increment; j < arr.Length; j += increment)
               {
                   if (arr[j] < arr[min]) min = j;
               }
               swap(i, min);
            }
        }
    }
}
