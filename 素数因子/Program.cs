using System;


namespace 素数因子
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一个整数：");
            int number=int.Parse(Console.ReadLine());
            List<int> list = GetPrimeFactor(number);
            Console.WriteLine($"{number}的所有素数因子是：");
            foreach (int i in list) {
                Console.Write("{0} ",i);
            }
            Console.WriteLine();
            List<int> list2=list.Distinct().ToList();//去除重复的因子
            Console.WriteLine($"{number}的所有素数因子(已去重)是：");
            foreach (int i in list2)
            {
                Console.Write("{0} ", i);
            }
        }

        static List<int> GetPrimeFactor(int number) { 
            List<int> result = new List<int>();
            while (number % 2 == 0)//先一直除2
            {
                result.Add(2);
                number /= 2;
            }
            for(int i = 3; i < number; i+=2)//再除奇数因子
            {
                while (number % i == 0)
                {
                    result.Add(i);
                    number /= i;
                }
            }
            if(number>2)
                result.Add(number);
            return result;
        }
    }
}
