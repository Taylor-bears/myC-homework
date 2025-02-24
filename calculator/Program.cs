using System;

namespace calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //数字1
            Console.WriteLine("请输入第一个数字");
            string str1 = Console.ReadLine();
            float firstNum;
            //判断是否有效
            while(!float.TryParse(str1, out firstNum))
            {
                Console.WriteLine("输入的数字无效，请重新输入");
                str1 = Console.ReadLine();
            }
            
            //运算符
            Console.WriteLine("请输入运算符");
            char operate= Console.ReadKey().KeyChar;//这里是读入单个字符
            //判断是否有效
            while (!(operate == '+' || operate == '-' || operate == '*' || operate == '/'))
            {
                Console.WriteLine("输入的运算符无效，请重新输入");
                operate = Console.ReadKey().KeyChar;
            }
            Console.WriteLine();

            //数字2
            Console.WriteLine("请输入第二个数字");
            string str2 = Console.ReadLine();
            float doubleNum;
            //判断是否有效
            while (!float.TryParse(str2, out doubleNum))
            {
                Console.WriteLine("输入的数字无效，请重新输入");
                str2 = Console.ReadLine();
            }

            //数字2作为除数不合法
            if (doubleNum == 0 && operate == '/')
            {
                Console.WriteLine("除数不能为0");
                Console.WriteLine();
                Console.WriteLine("请按任意键退出");
                Console.ReadKey();
                return;
            }

            //计算结果
            float result = 0;
            switch (operate)
            {
                case '+':
                    result = firstNum+doubleNum; 
                    break;
                case '-':
                    result = firstNum - doubleNum;
                    break;
                case '*':
                    result = firstNum * doubleNum;
                    break;
                case '/':
                    result = firstNum / doubleNum;
                    break;
            }

            Console.Write($"计算的结果为：{firstNum}{operate}{doubleNum}={result}");
            Console.WriteLine();
            Console.WriteLine("请按任意键退出");
            Console.ReadKey();
            return;
        }
    }
}
