using NUnit.Framework;
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

    static List<int> DFS(List<List<int>> adj)
    {
        bool[] visited = new bool[adj.Count];
        List<int> res = new List<int>();
        DfsRec(adj, visited, 0, res);
        return res;
    }

    static void DfsRec(List<List<int>> adj, bool[] visited, int s, List<int> res)
    {
        visited[s] = true;
        res.Add(s);

        foreach(int i in adj[s])
        {
            if (!visited[i])
                DfsRec(adj, visited, i, res);
        }
    }
    
       //    https://www.geeksforgeeks.org/dsa/depth-first-search-or-dfs-for-a-graph/
       //    https://github.com/gt4dev/yet-another-tree-structure/blob/master/csharp/CSharpTree/TreeNode.cs
    
}


