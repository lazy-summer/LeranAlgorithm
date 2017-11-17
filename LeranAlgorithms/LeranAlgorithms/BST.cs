using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeranAlgorithms
{
    public class BST<Key,Value>where Key:IComparable
    {
        private Node root;
        public BST()
        {
        }
        private class Node: IComparable      //？？？private？？？
        {
            public Key key;
            public Value val;
            public Node left=null, right=null;
            public int count=1;
            public Node(Key key,Value val)
            {
                this.key = key;
                this.val = val;
            }
            public int CompareTo(object obj)
            {
                Node otherNode = obj as Node;
                return this.key.CompareTo(otherNode.key);
            }
        }
        public int size()
        {
            return size(root);
        }
        private int size(Node x)
        {
            if (x == null) return 0;
            return x.count;
        }

        //To serach
        public Value get(Key key)
        {
            Node x = root;
            while (x != null)
            {
                int cmp = key.CompareTo(x.key);
                if (cmp > 0) x = x.right;
                else if (cmp < 0) x = x.left;
                else return x.val;
            }
            return default(Value);
        }

        //To insert
        public void put(Key key,Value val)
        {
            root = put(root, key, val);
        }
        private Node put(Node x,Key key,Value val)                //private之间的对应关系
        {
            if (x == null) return new Node(key, val);
            int cmp  = key.CompareTo(x.key);
            if (cmp < 0) x.left=put(x.left, key, val);
            else if (cmp > 0) x.right=put(x.right, key, val);         //给自己一个提示 不要随便粘贴复制代码 发生的小错误很难找啊！！
            else x.val = val;
            x.count = 1 + size(x.left) + size(x.right);
            return x;
        }
       
        //To Find Floor and Ceiling
        public Key floor(Key key)
        {
            Node x = floor(root, key);
            if(x==null) return default(Key);
            return x.key;
        }                           
        private Node floor(Node x,Key key)
        {
            if (x == null) return null;
            int cmp = key.CompareTo(x.key);
            if (cmp == 0) return x;

            if (cmp < 0) return floor(x.left, key);
            Node t = floor(x.right, key);
            if (t != null) return t;                                           //如果比key小 可以返回
            else return x;                                                     //如果没有的话 返回之前的
        }
        public Key ceiling(Key key)
        {
            Node x=ceiling(root, key);
            if (x == null) return default(Key);
            return x.key;
        }
        private Node ceiling(Node x,Key key)
        {
            if (x == null) return null;
            int cmp = key.CompareTo(x.key);
            if (cmp == 0) return x;
            if (cmp > 0) return ceiling(x.right, key);
            Node t = ceiling(x.left, key);
            if (t != null) return t;
            else return x;
        }
        
        //return count(*) of keys<k!!!
        public int rank(Key key)
        {
            return rank(key,root);
        }
        private int rank(Key key,Node x)
        {
            if (x == null) return 0;
            int cmp = key.CompareTo(x.key);
            if (cmp < 0) return rank(key, x.left);
            else if (cmp > 0) return 1 + size(x.left) + rank(key, x.right);
            else return size(x.left);
        }
       
        //To Sort
        public ArrStack<Key> keys()
        {
            ArrStack<Key> q = new ArrStack<Key>(100);
            inorder(root, q);
            return q;
        }
        private void inorder(Node x,ArrStack<Key> q)
        {
            if (x == null) return;
            inorder(x.left, q);
            q.push(x.key);
            inorder(x.right, q);
        }

        //To Delete
        private Node min(Node x)
        {
            if (x == null) return null;
            while (x.left != null)
            {
                x = x.left;
            }
            return x;
        }
        public void deleteMin()
        {
            root = deleteMin(root);
        }
        private Node deleteMin(Node x)
        {
            if(x.left==null) return x.right;
            x.left = deleteMin(x.left);
            x.count = 1 + size(x.left) + size(x.right);
            return x;
        }
        public void delete(Key key)
        {
            root = delete(root, key);
        }
        private Node delete(Node x,Key key)
        {
            if (x == null) return null;
            int cmp = key.CompareTo(x.key);
            if (cmp < 0)  x.left=delete(x.left, key);
            else if (cmp > 0) x.right=delete(x.right, key);
            else
            {
                if (x.left == null) return x.right;
                if (x.right == null) return x.left;
                Node t = x;
                x=min(t.right);
                x.right = deleteMin(t.right);
                x.left = t.left;
            }
            x.count = 1 + size(x.right) + size(x.left);
            return x;
        }
    }
}
