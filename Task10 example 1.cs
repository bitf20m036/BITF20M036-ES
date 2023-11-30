//Iterator for a Tree Structure
using System;
using System.Collections.Generic;
interface IIterator<T>
{
    bool HasNext();
    T Next();
}

class TreeIterator<T> : IIterator<T>
{
    private Stack<TreeNode<T>> stack;

    public TreeIterator(TreeNode<T> root)
    {
        stack = new Stack<TreeNode<T>>();
        TraverseLeftmostBranch(root);
    }

    private void TraverseLeftmostBranch(TreeNode<T> node)
    {
        while (node != null)
        {
            stack.Push(node);
            node = node.Left;
        }
    }

    public bool HasNext()
    {
        return stack.Count > 0;
    }

    public T Next()
    {
        if (HasNext())
        {
            var current = stack.Pop();
            TraverseLeftmostBranch(current.Right);
            return current.Value;
        }
        else
        {
            throw new InvalidOperationException("No more elements");
        }
    }
}
interface IAggregate<T>
{
    IIterator<T> CreateIterator();
}
class TreeNode<T>
{
    public T Value { get; set; }
    public TreeNode<T> Left { get; set; }
    public TreeNode<T> Right { get; set; }

    public TreeNode(T value)
    {
        Value = value;
    }
}
class BinaryTree<T> : IAggregate<T>
{
    public TreeNode<T> Root { get; set; }

    public IIterator<T> CreateIterator()
    {
        return new TreeIterator<T>(Root);
    }
}

// Client code
class TreeIteratorClient
{
    static void Main()
    {
        var binaryTree = new BinaryTree<int>
        {
            Root = new TreeNode<int>(1)
            {
                Left = new TreeNode<int>(2)
                {
                    Left = new TreeNode<int>(4),
                    Right = new TreeNode<int>(5)
                },
                Right = new TreeNode<int>(3)
                {
                    Left = new TreeNode<int>(6),
                    Right = new TreeNode<int>(7)
                }
            }
        };

        var iterator = binaryTree.CreateIterator();

        while (iterator.HasNext())
        {
            Console.WriteLine(iterator.Next());
        }
    }
}
