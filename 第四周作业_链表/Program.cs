using System;

namespace 第四周作业_链表
{
    public class Node<T> 
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }

        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }

    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        public GenericList()
        {
            tail = head = null;
        }
        public Node<T> Head
        {
            get => head;
        }
        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }

        //我根据题目要求新添的
        public void ForEach(Action<T> action)
        {
            for (Node<T> node = head; node != null; node = node.Next)
            {
                action(node.Data);
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> list = new GenericList<int>();
            list.Add(2); //将我的学号添加进去
            list.Add(0);
            list.Add(2);
            list.Add(3);
            list.Add(3);
            list.Add(0);
            list.Add(2);
            list.Add(0);
            list.Add(6);
            list.Add(1);
            list.Add(0);
            list.Add(7);
            list.Add(1);
            //打印
            Console.WriteLine("链表的元素如下：");
            list.ForEach(x => Console.Write(x + " "));
            Console.WriteLine();
            //求最大
            int max = int.MinValue;
            list.ForEach(x =>
            {
                if (x > max)
                {
                    max = x;
                }
            });
            Console.WriteLine("最大元素为：" + max);            
            //求最小
            int min = int.MaxValue;
            list.ForEach(x =>
            {
                if (x < min)
                {
                    min = x;
                }
            });
            Console.WriteLine("最小元素为：" + min);           
            //求和
            int sum = 0;
            list.ForEach(x => sum += x);
            Console.WriteLine("元素之和为：" + sum);           
        }
    }
}
