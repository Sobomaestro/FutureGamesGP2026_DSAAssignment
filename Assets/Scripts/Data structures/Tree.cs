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
    public static void Insert(Node root, Employees key)
    {        

        if (root == null)
            root = new(key);

        if (key.parsedExit.CompareTo(root.data.parsedExit) <= 0)
        {
            if (root.left == null)
            {
                root.left = new Node(key);
            }
            else
            {
                Insert(root.left, key);
            }
        }
        else
            if (root.right == null)
            {
                root.right = new Node(key);
            }
            else
            {
                Insert(root.right, key);
            }
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


