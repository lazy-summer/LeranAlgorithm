using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeranAlgorithms
{
    public class QuickUnionUF
    {
        private int[] id;
        private int[] weights;
        public QuickUnionUF(int N)
        {
            id = new int[N];                   //第一次的数组并没有规定的大小，是不对的
            weights = new int[N];                   //第一次的数组并没有规定的大小，是不对的
            for (int i = 0; i < N; i++)
            {
                id[i] = i;
                weights[i] = 1;
            }
        }
        public int root(int p)
        {
            while (id[p] != p)
            {
                id[p] = id[id[p]];            //这一句话完成了路径压缩的所有内容！！！！！
                p = id[p];
            }
            return p;
        }
        public bool connected(int p, int q)
        {
            return root(p) == root(q);
        }
        public void union(int p, int q)
        {
            int i = root(p);
            int j = root(q);
            if (i == j) return;              //如果相等就不要搞事情了
            if (weights[i] < weights[j])
            {
                id[i] = j;
                weights[j] += weights[i];
            }
            else
            {
                id[j] = i;
                weights[i] += weights[j];
            }

        }
        public void show()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(id[i]);
            }
        }
    }
    public class QucikFindUF
    {
        private int[] id;
        public QucikFindUF(int N)
        {
            id = new int[N];
            for(var i = 0; i < N; i++)
            {
                id[i] = i;
            } 
        }
        public bool connected(int p,int q)
        {
            return id[p] == id[q];
        }
        public int root(int p)
        {
            return id[p];
        }
        public void union(int p,int q)
        {
            int pId = id[p];
            int qId = id[q];
            for(int i = 0; i < id.Length; i++)
            {
                if (id[i] == pId)
                {
                    id[i] = qId;
                }
            }
        }
        public void show()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(id[i]);
            }
        }
        
        
    }
}
