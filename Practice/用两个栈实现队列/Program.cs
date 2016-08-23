using System;
using System.Collections.Generic;


//思路：一个栈用于存储数据，另一个栈当作缓冲，push时直接压入stack1，pop时先把数据倒入stack2然后弹出stack2的栈顶；
//在push时判断stack2是否还有没有倒回来来的数据，如果有就倒回来。
namespace 用两个栈实现队列
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> q = new Queue<int>();
            dequeue tQ = new dequeue();
            for (int i = 1; i < 1e5; i++)
            {
                if (0 != i % 3) 
                {
                    q.Enqueue(i);
                    tQ.push(i);
                }
                else
                {
                   int num1 =  q.Dequeue();
                   int num2 =  tQ.pop();
                    if (num1 != num2)
                    {
                        Console.WriteLine("Wrong!");
                    }
                }
            }
        }
    }

    class dequeue
    {
        public dequeue()
        {
            stack1 = new Stack<int>();
            stack2 = new Stack<int>();
        }
        public void push(int node)
        {
            if (0 == stack2.Count) 
            {
                stack1.Push(node);
            }
            else
            {
                while (0 != stack2.Count) 
                {
                    stack1.Push(stack2.Pop());
                }
                stack1.Push(node);
            }
        }
        public int pop()
        {
            if (stack1.Count == 0 && stack2.Count == 0) 
            {
                throw new InvalidOperationException("This Queue is Empty!");
            }

            while (0 != stack1.Count) 
            {
                stack2.Push(stack1.Pop());             
            }
            return stack2.Pop();
        }
        private Stack<int> stack1;//for data
        private Stack<int> stack2;//for buffer
    }
}
