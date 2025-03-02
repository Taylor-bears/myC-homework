namespace 托普利茨矩阵判断
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入二维矩阵的一维长度");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("请输入二维矩阵的二维长度");
            int b = int.Parse(Console.ReadLine());
            int[][] arr = new int[a][];
            for (int i = 0; i < a; i++)
            {
                Console.WriteLine($"请输入第{i + 1}行的{b}个数据");
                string input = Console.ReadLine();//需要掌握的新的方法，读取一行数据，数据分割
                string[] str = input.Split(' ');//以空格分割数据
                arr[i] = Array.ConvertAll(str, int.Parse);//尝试转换
            }
            if (a == 1)
            {
                Console.WriteLine("该矩阵是托普利茨矩阵");
                return;
            }
            for (int i = 1; i < a; i++)
            {
                for (int j = 1; j < b; j++)
                {
                    if (arr[i][j] != arr[i - 1][j - 1])
                    {
                        Console.WriteLine("该矩阵不是托普利茨矩阵");
                        return;
                    }
                }
            }
            Console.WriteLine("该矩阵是托普利茨矩阵");
        }
    }
}
