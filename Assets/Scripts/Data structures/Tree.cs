using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics.SymbolStore;
using UnityEngine;

public class Tree : MonoBehaviour
{

}


public class Node
{
    public Employees data;
    public Node left, right;
    public Node(Employees x)
    {
        data = x;
        left = null;
        right = null;

    }
}

public class TreeNode
{
    Node root;
    public Node GetList(List<Employees> empList)
    {
        int mid = empList.Count / 2;
        for (int i = mid; i >= 0; i--)
        {
            Insert(empList[i]);
        }
        for (int i = mid + 1; i < empList.Count; i++)
        {
            Insert(empList[i]);
        }
        return root;
    }
    int leftCount = 0;
    int rightCount = 0;
    public void Insert(Employees key)
    {
        if (root == null)
        { root = new(key); return;}
        Node currentNode = root;

        while (currentNode != null)
        {
            if (key.parsedExit.CompareTo(currentNode.data.parsedExit) < 0)
            {
                if (currentNode.left == null)
                { currentNode.left = new Node(key); leftCount++; break; }
                else currentNode = currentNode.left;
            }
            else 
            {
                if (currentNode.right == null)
                { currentNode.right = new Node(key); rightCount++;  break; }
                else currentNode = currentNode.right;
            }
        }

    }

    public void DFSBoi()
    {
        Node currentNode = root;
        Stack<Node> nodeStack = new Stack<Node>();
        int i = 0;
        while ( i < 1600)
        { 
            while (currentNode != null)
            {
                nodeStack.Push(currentNode);
                currentNode = currentNode.left;
            }
            if (nodeStack.Count > 0)
            { currentNode = nodeStack.Pop(); }
            else if (nodeStack.Count == 0)
            { break; }
            if (currentNode != null)
            {
                //Debug.Log(currentNode.data.Name + " " + currentNode.data.parsedExit.ToString());
            }
            currentNode = currentNode.right;
            i++;  
            
        }
    }
    #region lavaFlow
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
            Employees b =  eQueue.Dequeue();
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
    
       //    https://www.geeksforgeeks.org/dsa/depth-first-search-or-dfs-for-a-graph/
       //    https://github.com/gt4dev/yet-another-tree-structure/blob/master/csharp/CSharpTree/TreeNode.cs
    
}
#endregion

