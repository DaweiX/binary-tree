using System;
using System.Collections.Generic;

namespace 二叉树
{
    class Program
    {
        static void Main(string[] args)
        {
            Node<int> n_10 = new Node<int>(10);
            Node<int> n_30 = new Node<int>(30);
            Node<int> n_40 = new Node<int>(40);
            Node<int> n_70 = new Node<int>(70);
            Node<int> n_60 = new Node<int>(60, n_70);
            Node<int> n_45 = new Node<int>(45, null, n_60);
            Node<int> n_20 = new Node<int>(20, n_30, n_40);
            Node<int> n_98 = new Node<int>(98, n_20, n_10);
            Node<int> n_6 = new Node<int>(6, n_45, null);
            Node<int> n_15 = new Node<int>(15, n_98, n_6);
            Console.WriteLine("叶子结点:");
            Methods.PrintLast(n_15);
            Console.WriteLine("按层次输出:");
            Methods.Printall(n_15);
            Methods.Exchange(n_15);
            Console.WriteLine("互换后按层次输出:");
            Methods.Printall(n_15);
            Console.ReadLine();
        }
    }
    public static class Methods
    {
        /// <summary>
        /// 按层次输出
        /// </summary>
        /// <param name="n">二叉树根结点</param>
        static public void Printall(Node<int> n)
        {
            List<Node<int>> list = new List<Node<int>>();
            list.Add(n);
            do
            {
                for (int i = 0; i < list.Count; i++)
                {
                    Node<int> item = list[i];
                    if (item != null)
                    {
                        list.Remove(item);
                        list.Add(item.Left);
                        list.Add(item.Right);
                        Console.WriteLine(item.Data);
                    }
                    else
                    {
                        list.Remove(item);
                    }
                    i = -1;
                }
            } while (list.Count > 0);          
        }

        /// <summary>
        /// 输出叶子结点
        /// </summary>
        /// <param name="n">二叉树根结点</param>
        static public void PrintLast(Node<int> n)
        {
            if (n != null) 
            {
                if ((n.Left == null && n.Right == null))
                {
                    Console.WriteLine(n.Data);
                }
                PrintLast(n.Left);
                PrintLast(n.Right);
            }
        }

        /// <summary>
        /// 将所有左右子树值交换
        /// </summary>
        /// <param name="n">二叉树根结点</param>
        public static void Exchange(Node<int> n)
        {
            if (n != null)
            {
                if (!(n.Left == null && n.Right == null))
                {
                    var a = n.Left;
                    n.Left = n.Right;
                    n.Right = a;
                }
                Exchange(n.Left);
                Exchange(n.Right);
            }
        }
    }
    /// <summary>
    /// 结点
    /// </summary>
    public class Node<T>
    {
        private int data;
        private Node<int> left;
        private Node<int> right;
        public int Data
        {
            set { data = value; }
            get { return data; }
        }
        public Node<int> Left
        {
            set { left = value; }
            get { return left; }
        }
        public Node<int> Right
        {
            set { right = value; }
            get { return right; }
        }
        /// <param name="value">值</param>
        /// <param name="n1">左侧结点</param>
        /// <param name="n2">右侧结点</param>
        public Node(int value, Node<int> n1 = null, Node<int> n2 = null)
        {
            data = value;
            left = n1;
            right = n2;
        }
        public Node(Node<int> n)
        {
            data = n.Data;
            left = n.Left;
            right = n.Right;
        }

        public Node()
        {
            data = default(int);
            left = right = null;
        }

        /// <summary>
        /// 添加子结点
        /// </summary>
        public void Add(Node<int> node_left = null, Node<int> node_right = null)
        {
            left = node_left;
            right = node_right;
        }
    }
}
