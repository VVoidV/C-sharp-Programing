using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace printListfromTail
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            ListNode list = s.CreateList(10);
            List<int> result = s.reverseList(list);
            foreach (var val in result)
            {
                Console.Write("{0} ",val);
            }
        }
    }
    class Solution
    {
        //public List<int> reverseList(ListNode listNode)
        //{
        //    Stack<int> stack = new Stack<int>();
        //    for (ListNode i = listNode; i != null; i = i.next)
        //    {
        //        stack.Push(i.val);
        //    }

        //    return stack.ToList();
        //}

        public List<int> reverseList(ListNode listNode)
        {
            Stack<int> stack = new Stack<int>();
            for (ListNode i = listNode; i != null; i = i.next)
            {
                stack.Push(i.val);
            }
            List<int> result = new List<int>();
            while (stack.Count > 0)
            {
                result.Add(stack.Pop());
            }
            return result;
        }



        public ListNode CreateList(int n)
        {
            ListNode head = new ListNode();
            head = new ListNode();
            for (int i = 0; i < n; i++)
            {
                ListNode tmp = new ListNode(i);
                tmp.next = head.next;
                head.next = tmp;              
            }
            return head.next;
        }
    }

    class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x)
        {
            val = x;
        }
        public ListNode()
        {
            next = null;
        }
    }
}
