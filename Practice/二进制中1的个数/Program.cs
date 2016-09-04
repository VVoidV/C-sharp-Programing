using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace 二进制中1的个数
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = -1;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 0X7ffffff; i++)
            {
                Solution.NumberOf1(255);
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            for (int i = 0; i < 0X7ffffff; i++)
            {
                Solution.NumberOf1_2(255);
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }
    }

    class Solution
    {
        public static int NumberOf1(int n)
        {
            int count = 0;
            // write code here
            if (n >= 0) 
            {
                while (n != 0)
                {
                    if (0 != (n & 1)) 
                    {
                        count++;
                    }
                    n = n >> 1;
                }
            }
            else
            {
                n = n & 0x7fffffff;
                count++;
                while (n != 0)
                {
                    if (0 != (n & 1))
                    {
                        count++;
                    }
                    n = n >> 1;
                }

            }
            return count;
        }

        public static int NumberOf1_2(int n)
        {
            n = (n & 0x55555555) + ((n >> 1) & 0x55555555);//相邻两位相加，得将n的二进制表示划分为 2 bit 一块，每块中 1 的个数

            n = (n & 0x33333333) + ((n >> 2) & 0x33333333); // 再统计相邻 2 bit 块中 1 的个数

            n = (n & 0x0f0f0f0f) + ((n >> 4) & 0x0f0f0f0f);

            n = (n & 0x00ff00ff) + ((n >> 8) & 0x00ff00ff);

            n = (n & 0x0000ffff) + ((n >> 16) & 0x0000ffff);
            return n;
        }
    }
}
