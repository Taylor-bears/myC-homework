using System;

namespace 埃氏筛法求素数
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int MaxSize=100;
            bool[] isPrime = new bool[MaxSize+1];
            //先初始化每一个元素均为素数
            for (int i = 0; i < isPrime.Length; i++) 
            {
                isPrime[i] = true;
            }
            //利用素数倍数标记合数
            for(int i=2;i*i<= MaxSize; i++)
            {
                if (isPrime[i])
                {
                    for(int j=i*i; j<=MaxSize; j+=i)//素数的倍数均不是素数
                        isPrime[j] = false;
                }
            }
            Console.WriteLine("2到100之间的素数有");
            for(int i = 2; i <= MaxSize; i++)
            {
                if (isPrime[i])
                    Console.Write(i + " ");
            }
        }
    }
}
