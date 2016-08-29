using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
//此题教训，注意基本类型int、long的实际范围和程序中可能出现的最大值的比较！！
namespace rectCover
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int n = 0; n < 90; n++)
            {
                Console.WriteLine("Fib {0}:{1}",n,Solution.rectangelCover(n));
                Console.WriteLine("Combination:{0}\n",Solution.rectCover(n));

            }
           // BigInteger k = Solution.factorial(40);
           // Console.WriteLine("Combination:{0}\n", k);
        }

    }

    class Solution
    {
       /* public static long factorial(int n)
        {
            long result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }*/

        public static BigInteger factorial(int n)
        {
            BigInteger result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }


        public static int rectCover(int target)
        {
            int tempNum = 1;
            int result = 2;

            if (target == 0)
            {
                return 0;
            }

            if (target == 1 || target == 2)
            {
                return target;
            }

            int count = 2;
            while (count < target)
            {
                result += tempNum;
                tempNum = result - tempNum;
                count++;
            }
            return result;
        }

        public static BigInteger rectangelCover(int n)
        {
            if (n == 1) 
            {
                return 1;
            }
            BigInteger sum = 1;
            for (int i = 1; i < n; i++)
            {
                if ( (n-i) % 2 !=0 )
                {
                    continue;
                }
                //int temp = factorial((n + i) / 2) / factorial(i) / factorial((n - i) / 2);
                sum += factorial((n + i)/ 2)/factorial(i)/factorial((n - i) / 2);
            }
            if (n % 2 == 0) 
            {
                return sum + 1;
            }
            return sum;
        }
    }
}
