using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reConstructBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] pre = { 1, 2, 4, 7, 3, 5, 6, 8 };
            int[] tin = { 4, 7, 2, 1, 5, 3, 8, 6 };
            TreeNode t = bTreeConstructor.reBuild(pre, tin);
            bTreeConstructor.inordertraverse(t);
            Console.ReadLine();
        }
    }

    class bTreeConstructor
    {
        public static TreeNode reBuild(int[] pre,int[] tin)
        {
            if (pre.Length != tin.Length) 
            {
                throw new ArgumentException("输入的数组长度有误");
            }

            if (0 == pre.Length || 0 == tin.Length) 
            {
                return null;
            }

            if (1 == pre.Length) 
            {
                return new TreeNode(pre[0]);
            }

            TreeNode root = new TreeNode(pre[0]);
            int rootIndex = -1;
            for (int i = 0; i < tin.Length; i++)
            {
                if (tin[i] == pre[0]) 
                {
                    rootIndex = i;
                    break;
                }
            }

            if (-1 == rootIndex) 
            {
                throw new ArgumentException("输入的序列有误");
            }
            int[] leftPre = new int[rootIndex];
            int[] leftTin = new int[rootIndex];
            int[] rightPre = new int[tin.Length - rootIndex - 1];
            int[] rightTin = new int[tin.Length - rootIndex - 1];

            Array.Copy(tin, leftTin, rootIndex );
            Array.Copy(tin, rootIndex + 1,rightTin,0,tin.Length - rootIndex - 1);
            Array.Copy(pre, 1, leftPre, 0, rootIndex);
            Array.Copy(pre, rootIndex + 1, rightPre, 0, tin.Length - rootIndex - 1);
            root.left = reBuild(leftPre, leftTin);
            root.right = reBuild(rightPre, rightTin);

            return root;
        }

        public static void inordertraverse(TreeNode t)
        {
            if (t != null)
            {
                Console.Write("{0}", t.val);
                inordertraverse(t.left);
                
                inordertraverse(t.right);
                
            }
            return;
        }
    }
}
