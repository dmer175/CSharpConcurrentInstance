using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpConcurrentInstance._03
{
    /*
     * Q:并行任务的结构和数量要在运行时才能确定
     * A:Parallel类和并行LINQ只是对Task的封装，复杂任务还是直接使用Task
     */
    public class _0304_Dynamic_Parallel
    {
        /*
         * 例子对二叉树的每个节点进行处理，并且该处理是很耗资源的。二叉树的结构在运行时才能确定，因此非常适合采用动态并行。Traverse方法处理当前节点，然后创建两个子任务，每个子任务对应一个子节点（本例中，假定必须先处理父节点，然后才能处理子节点）。ProcessTree方法启动处理过程，创建一个最高层的父任务，并等待任务完成
         */
        public static void Traverse(Node current)
        {
            DoExpensiveActionOnNode(current);
            ProcessTree(current.left);
            ProcessTree(current.right);
        }

        private static void ProcessTree(Node root)
        {
            if (root != null)
            {
                Task.Factory.StartNew(() => Traverse(root), CancellationToken.None, TaskCreationOptions.AttachedToParent, TaskScheduler.Default);
            }
        }

        private static void DoExpensiveActionOnNode(Node current)
        {
            //some Intensive processing
        }
    }

    public class Node
    {
        public int val;
        public Node left;
        public Node right;

        public Node(int val, Node left, Node right)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
