using System;

namespace 对数组的处理
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入数组的大小：");
            int size=int.Parse(Console.ReadLine());
            int[] number=new int[size];
            for(int i=0;i<size; i++)
            {
                Console.Write("请输入第"+(i+1)+"个元素的值：");
                number[i]=int.Parse(Console.ReadLine());
            }
            //求最大值、最小值、总和
            int MaxValue = 0;
            int MinValue = number[0];
            int sum = 0;
            foreach (int i in number) 
            { 
                if(i > MaxValue)
                    MaxValue = i;
                if (i < MinValue)
                    MinValue = i;
                sum += i;
            }
            float average=(float)sum/(float)size;
            //输出
            Console.WriteLine("数组的统计信息如下：");
            Console.WriteLine("最大值为" + MaxValue);
            Console.WriteLine("最小值为" + MinValue);
            Console.WriteLine("所有元素值的总和为" + sum);
            Console.WriteLine("平均值为" + average);
        }
    }
}
