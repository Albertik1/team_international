using System;
using System.Collections;
using System.Collections.Generic;

namespace TreeCollection
{
    public class Tree<T> : IEnumerable<T>
    {
        private Node<T> root;
        private bool isReversedReading;

        public Tree(bool isReversed = false)
        {
            root = null;
            isReversedReading = isReversed;
        }

        public void Add(T newElement)
        {
            if (root == null)
            {
                root = new Node<T>(newElement);
            }
            else
            {
                AddToNode(root, newElement);
            }
        }

        private void AddToNode(Node<T> node, T newElement)
        {
            IComparable<T> comparer = (IComparable<T>)newElement;
            int comparisonResult = comparer.CompareTo(node.Data);

            if (comparisonResult < 0)
            {
                if (node.Left == null)
                {
                    node.Left = new Node<T>(newElement);
                }
                else
                {
                    AddToNode(node.Left, newElement);
                }
            }
            else if (comparisonResult > 0)
            {
                if (node.Right == null)
                {
                    node.Right = new Node<T>(newElement);
                }
                else
                {
                    AddToNode(node.Right, newElement);
                }
            }
            else
            {
                throw new ArgumentException("An element with the same value already exists in the tree.");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (isReversedReading)
            {
                return InOrderTraversalReverse(root).GetEnumerator();
            }
            else
            {
                return InOrderTraversal(root).GetEnumerator();
            }
        }

        private IEnumerable<T> InOrderTraversal(Node<T> node)
        {
            if (node != null)
            {
                foreach (T data in InOrderTraversal(node.Left))
                {
                    yield return data;
                }

                yield return node.Data;

                foreach (T data in InOrderTraversal(node.Right))
                {
                    yield return data;
                }
            }
        }

        private IEnumerable<T> InOrderTraversalReverse(Node<T> node)
        {
            if (node != null)
            {
                foreach (T data in InOrderTraversalReverse(node.Right))
                {
                    yield return data;
                }

                yield return node.Data;

                foreach (T data in InOrderTraversalReverse(node.Left))
                {
                    yield return data;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    internal class Node<T>
    {
        public T Data { get; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public Node(T data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }
}
