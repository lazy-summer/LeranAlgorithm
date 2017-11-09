using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeranAlgorithms
{
    public class PracticalSort                        //MergeSort
    {
        private static void merge(int[] arr,int[] temparr,int lo,int mid,int hi)
        {
            for(int i = lo; i <= hi; i++)
            {
                temparr[i] = arr[i];                                                 //改进三：如果想节约复制的时间（在sort的函数里sort(temparr,arr....)）互换
            }
            int p = lo, q = mid + 1;
            for (int i = lo; i <= hi; i++)
            {
                if      (p > mid) arr[i] = temparr[q++];
                else if (q > hi)  arr[i] = temparr[p++];
                else if (temparr[p] < temparr[q])   arr[i] = temparr[p++];            //千万注意 此时这里是temparr 
                else              arr[i] = temparr[q++];
            }
        }
        private static void sort(int[] arr,int[] temparr,int lo,int hi)
        {
            /*if (hi - lo <= 4)
            {
                //insertSort(arr, lo, hi);                                           //改进一：在比较短时的时候用insertSort 节约时间
                return;
            }*/
            if (lo < hi)
            {
                int mid = lo + (hi - lo) / 2;
                sort(arr, temparr, lo, mid);
                sort(arr, temparr, mid + 1, hi);
                if (arr[mid] < arr[mid + 1]) return;                                  //改进二：如果左边最大的已经小于右边最大，不用修改
                merge(arr, temparr, lo, mid, hi);
            }
            else return;
        }
        public void mergeSort(int[] arr)                                              //只提供一个public！！！
        {
            var temparr = new int[arr.Length];
            sort(arr, temparr, 0, arr.Length - 1);    
        }

        //自下而上的mergeSort
        public void mergeSort2(int[] arr)
        {
            int N = arr.Length;
            var temparr = new int[N];
            for (int increment = 1; increment < N; increment *= 2)
            {
                for (int lo = 0; lo < N - increment; lo += 2*increment)                 //加2*increment
                {
                    merge(arr, temparr,lo, lo + increment-1, Math.Min(lo + 2 * increment - 1, N - 1));
                }
            }
        }
    }
    public class Quick
    {
        private void swap(int[] arr,int i,int j)
        {
            int tem = arr[i];
            arr[i] = arr[j];
            arr[j] = tem;
        }
        private int medianOf3(int[] arr,int lo,int mid,int hi)
        {
            if ((arr[lo] - arr[mid]) * (arr[lo] - arr[hi]) <= 0) return lo;
            else if ((arr[mid] - arr[lo]) * (arr[mid] - arr[hi]) <= 0) return mid;
            else return hi;
        }
        private int partition(int[] arr,int lo,int hi)
        {
            int temp = arr[lo];
            int i = lo, j = hi+1;
            while (true)
            {
                while (arr[++i] < arr[lo]) if (i == hi) break;            //一：解决了一直小的问题
                while (arr[--j] > arr[lo]) if (j == lo) break;            //二：解决了一直大的问题
                if (i >= j) break;                                        //三：如果i>=j，为跳出条件，此时arr[j]<arr[i]
                swap(arr,i, j);
            }
            swap(arr, lo, j);
            return j;
        }
        private void sort(int[] arr,int lo,int hi)
        {
            /*if(hi-lo<4)
            {
                insertSort(arr, lo, hi);                                    //改进一：当比较小的时候，直接排序
                return;                
            }*/
            if (lo < hi)
            {
                int m = medianOf3(arr, lo, lo + (hi - lo) / 2, hi);
                swap(arr, lo, m);
                int mid=partition(arr, lo, hi);
                sort(arr, lo, mid-1);                                    //sort lo->mid-1    AND  mid+1->hi
                sort(arr, mid + 1, hi);
            }   
        }
        public void quickSort(int[] arr)
        {
            sort(arr, 0, arr.Length - 1);
        }
        public int selectIndex(int[] arr,int k)
        {
            int lo = 0, hi = arr.Length-1;
            while (hi>lo)
            {
                int j = partition(arr, lo, hi);
                if (j > k) lo = j + 1;
                else if (j < k) hi = j - 1;
                else return arr[k];
            }
            return arr[k];
        }
    }
    public class ThreeWaySort
    {
        private void swap(int[] arr, int i, int j)
        {
            int tem = arr[i];
            arr[i] = arr[j];
            arr[j] = tem;
        }
        public  void sort(int[] arr,int lo,int hi)
       {
            if (lo < hi)
            {
                int lt = lo, gt = hi;
                int mid = arr[lo];
                int i = lo;
                while (i <= gt)
                {
                    if (arr[i] < mid) swap(arr, i++, lt++);
                    else if (arr[i] > mid) swap(arr, i, gt--);
                    else i++;
                }
                sort(arr, lo, lt-1);
                sort(arr, gt+1, hi);
            }
       }
    }
}
