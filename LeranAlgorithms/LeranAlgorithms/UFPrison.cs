using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeranAlgorithms
{
    
    public  class UFPrison
    {
        static List<tree> arr = new List<tree>();
        public struct tree
        {
            public int p;
            public int q;
            public int weight;
        }
        static void qsort(int l,int r)
        {
            int i = l, j = r, mid = arr[(i + j) / 2].weight;
            while (i <= j)
            {
                while (arr[i].weight > mid) i++;
                while (arr[j].weight < mid) j--;
                if (i <= j)
                {
                    var temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    i++;
                    j--;
                }
            }
            if (i < r) qsort(i, r);
            if (j > l) qsort(l, j);
        }
        static void Main(string[] args)
        {
            StreamReader sr = File.OpenText(@"C:\Users\wsj\Desktop\4.txt");
            int N = Convert.ToInt32(sr.ReadLine());
            int len = Convert.ToInt32(sr.ReadLine());
            for (int i = 0; i < len; i++)
            {
                tree  tr= new tree();
                tr.p = Convert.ToInt32(sr.ReadLine())-1;
                tr.q = Convert.ToInt32(sr.ReadLine())-1;
                tr.weight = Convert.ToInt32(sr.ReadLine());
                arr.Add(tr);
            }
            qsort(0, len - 1);
            sr.Close();

            /*for (int i = 0; i < len; i++)
            {
                Console.WriteLine(arr[i].weight);
            }*/
            var uf = new QucikFindUF(N);
            int a = arr[0].p;
            int b = arr[0].q;
            int max=0;
            for (int i = 1; i < len; i++)
            {
                int p = arr[i].p;
                int q = arr[i].q;
                if(uf.connected(p,q))
                {
                    max = arr[i].weight;
                    break;
                }//如果两个在不同的集合中 无需操作
                else if (uf.connected(a, p)) uf.union(b, q);
                else if (uf.connected(a, q)) uf.union(b, p);
                else if (uf.connected(b, p)) uf.union(a, q);
                else if (uf.connected(b, q)) uf.union(a, p);//操作一个在里面的情况
                else if(!uf.connected(a,p)&& !uf.connected(b, p) && !uf.connected(a, q) && !uf.connected(b, q))
                {
                    for(int j = 1; j < N; i++)
                    {
                        if (uf.connected(a, j) || uf.connected(b, j))
                        {

                        }
                    }
                }

            }
            Console.WriteLine(max);

        }

    }
}
