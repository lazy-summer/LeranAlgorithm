using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeranAlgorithms
{
    public class BinaryHeap
    {
        private int[] arr;
        private int N;
        public BinaryHeap(int capacity)
        {
            arr = new int[capacity];
        }
        private void swap(int p,int q)
        {
            int temp = arr[p];
            arr[p] = arr[q];
            arr[q] = temp;
        }
        private void swim(int k)
        {
            while (k > 1 && arr[k / 2] > arr[k])
            {
                swap(k, k / 2);
                k = k / 2;
            }
        }
        private void sink(int k)
        {
            while (2 * k <= N)
            {
                int j = 2 * k;
                if (j < N && arr[j] > arr[j + 1]) j++;
                if (arr[k] > arr[j])
                    swap(k, j);
                k = j;
            }
        }
        public bool IsEmpty()
        {
            return N == 0;
        }
        public void Insert(int x)
        {
            arr[++N] = x;
            swim(N);
        }
        public int DelMin()
        {
            int min = arr[1];
            swap(1, N--);
            sink(1);
            arr[N + 1] = 0;
            return min;
        }
    }
    public class HeapSort
    {
        private void sink(int[] arr,int k,int N)
        {
            while (2 * k <= N)
            {
                int j = 2 * k;
                if (j < N && arr[j] > arr[j + 1]) j++;
                if (arr[k] > arr[j])
                    swap(arr,k, j);
                k = j;
            }
        }
        private void swap(int[] arr,int p, int q)
        {
            int temp = arr[p];
            arr[p] = arr[q];
            arr[q] = temp;
        }
        public HeapSort(int[] arr)
        {
            sort(arr);
        }
        public void sort(int[] arr)
        {
            int N = arr.Length-1;
            for (int k = N / 2; k >= 1; k--)
                sink(arr, k, N);
            while (N > 1) 
            {
                swap(arr,1, N);
                sink(arr, 1, --N);
            }
        }
    }
}
