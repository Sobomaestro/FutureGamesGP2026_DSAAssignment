using System;
using System.Collections.Generic;
using UnityEngine;

namespace Environment.Tasks
{
    [CreateAssetMenu(fileName = "BSTDFS", menuName = "Scriptable Objects/BSTDFS")]
    public class BSTDFS : Task
    {
        public override void Execute()
        {
            
        }


        public void TreeSearchSpan(Node root, DateTime low, DateTime high)
        {
            Queue<Employees> eQueue = new Queue<Employees>();
            eQueue.Enqueue(DFSPreOrder(root, low));
            Stack<Employees> hiStack = new Stack<Employees>();
            hiStack.Push(DFSPreOrderHigh(root, high));
            foreach (Employees e in hiStack)
            {
                eQueue.Enqueue(hiStack.Pop());
            }
            foreach (Employees e in eQueue)
            {
                Employees b = eQueue.Dequeue();
                Debug.Log($"Employee name: {b.Name}, employees last exit from engine room: {b.parsedExit} ");
            }
        }

        public Employees DFSPreOrder(Node node, DateTime date)
        {
            if (node.data.parsedExit.CompareTo(date) <= 0)
            {
                if (node.left.data.parsedExit.CompareTo(date) <= 0)
                { DFSPreOrder(node.left, date); }
                else if (node.right.data.parsedExit.CompareTo(date) <= 0)
                { DFSPreOrder(node.right, date); }
                else { return node.data; }
            }
            return null;
        }

        public Employees DFSPreOrderHigh(Node node, DateTime date)
        {
            if (node.left.data.parsedExit.CompareTo(date) < 0)
            { DFSPreOrderHigh(node.left, date); }
            else if (node.right.data.parsedExit.CompareTo(date) < 0)
            { DFSPreOrderHigh(node.right, date); }
            else { return node.data; }
            return null;
        }


    }
}