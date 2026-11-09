using System;
using UnityEngine;

public class Tree : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


public class Node
{
    public DateTime data;
    public Node left, right;
    public Node(DateTime x)
    {
        data = x;
        left = null;
        right = null;
    }

}

public class TreeMaker
{
    static Node insert(Node root, DateTime key)
    {
        if (root == null)
            return new Node(key);

        if (key == root.data)
            return root;

        if (key.CompareTo(root.data) <= 0)
        {
            root.left = insert(root.left, key);
        }

        else
            root.right = insert(root.right, key);

        return root;
    }
}