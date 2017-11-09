using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeranAlgorithms
{
    public class SortApplication
    {
        
    }
    public class PokerSort
    {
        private int[] arr = new int[52];
        public void swap(int p,int q)
        {
            int temp = arr[p];
            arr[p] = arr[q];
            arr[q] = temp;
        }
        public void iinitialize()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i;
            }
        }
        public void shellsort()
        {
            int[] sedgewick = new int[] { 1, 5, 19, 41 };
            foreach(int increment in sedgewick)
                for(int i = 0; i < arr.Length; i+=increment)
                {
                    int min = i;
                    for (int j=i+increment; j < arr.Length; j+=increment)
                    {
                        if (arr[j] < arr[min]) min = j;
                    }
                    swap(min, i);
                }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);
            }
        }
        public void sortAndShow()
        {
            var rd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                int j = rd.Next(i+1);
                swap(i, j);
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
    }
}
