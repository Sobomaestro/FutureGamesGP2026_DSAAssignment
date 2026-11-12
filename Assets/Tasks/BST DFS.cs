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
            
            Node currentNode = root;
            Node previousNode = currentNode;
            Stack<Node> nodeStack = new Stack<Node>();            
            int i = 0;
            while (i < 802)
            {
                while (currentNode != null)
                {
                    if (currentNode.data.parsedExit.CompareTo(low) >= 0)
                    { 
                        nodeStack.Push(currentNode);
                        currentNode = currentNode.left;
                    }                    
                    else { break; }
                }
                

                //if (currentNode.data.parsedExit.CompareTo(low) >= 0 && currentNode.data.parsedExit.CompareTo(high) < 0)

                if (nodeStack.Count > 0)
                { 
                    currentNode = nodeStack.Pop(); 
                }
                if (currentNode.data.parsedExit.CompareTo(low) >= 0 && currentNode.data.parsedExit.CompareTo(high) < 0)
                {
                    Debug.Log(currentNode.data.Name + " " + currentNode.data.parsedExit.ToString());
                }
                if (currentNode != null)
                {
                    if (currentNode.right == null)
                        break;
                    if (currentNode.right.data.parsedExit.CompareTo(high) < 0)
                    {
                        currentNode = currentNode.right;
                    }
                    else break;
                }
                else { currentNode = null; }
            }

            //while (currentNode!= null)
            //{
            //    nodeStack.Push(currentNode);
            //    if (currentNode.data.parsedExit.CompareTo(low) >= 0)
            //    { currentNode.left = currentNode; }
            //}

            //    Queue<Employees> eQueue = new Queue<Employees>();
            //    eQueue.Enqueue(DFSPreOrder(root, low));
            //    Stack<Employees> hiStack = new Stack<Employees>();
            //    hiStack.Push(DFSPreOrderHigh(root, high));
            //    //foreach (Employees e in hiStack)
            //    //{
            //    //    eQueue.Enqueue(hiStack.Pop());
            //    //}
            //    while ( hiStack.Count > 0)
            //    {
            //        eQueue.Enqueue(hiStack.Pop());
            //    }
            //    foreach (Employees e in eQueue)
            //    {
            //        Employees b = eQueue.Dequeue();
            //        Debug.Log($"Employee name: {b.Name}, employees last exit from engine room: {b.parsedExit} ");
            //    }
            //}

            //public Employees DFSPreOrder(Node node, DateTime date)
            //{
            //    if (node.data.parsedExit.CompareTo(date) <= 0)
            //    {
            //        if (node.left.data.parsedExit.CompareTo(date) <= 0)
            //        { DFSPreOrder(node.left, date); }
            //        else if (node.right.data.parsedExit.CompareTo(date) <= 0)
            //        { DFSPreOrder(node.right, date); }
            //        else { return node.data; }
            //    }
            //    return null;
            //}

            //public Employees DFSPreOrderHigh(Node node, DateTime date)
            //{
            //    if (node.left != null && node.left.data.parsedExit.CompareTo(date) < 0)
            //    { DFSPreOrderHigh(node.left, date); }
            //    else if (node.right != null && node.right.data.parsedExit.CompareTo(date) < 0)
            //    { DFSPreOrderHigh(node.right, date); }
            //    else { return node.data; }
            //    return null;
            //}


        }
    }
}