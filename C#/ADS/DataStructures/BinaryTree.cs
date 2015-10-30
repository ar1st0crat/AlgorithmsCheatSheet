using System;

namespace ADS.DataStructures
{
    public class BinaryTreeNode
    {
        public int data;
        public BinaryTreeNode left = null;
        public BinaryTreeNode right = null;
    }


    public class BinaryTree
    {
        public BinaryTreeNode root = null;

        public void InsertNode(ref BinaryTreeNode node, int elem)
        {
            if (node == null)
            {
                node = new BinaryTreeNode();
                node.data = elem;
            }
            else if (elem > node.data)
            {
                InsertNode(ref node.right, elem);
            }
            else
            {
                InsertNode(ref node.left, elem);
            }
        }


        public BinaryTreeNode Find(int elem)
        {
            BinaryTreeNode node = root;

            while (node != null)
            {
                if (node.data == elem)
                    return node;
                else if (node.data < elem)
                    node = node.right;
                else
                    node = node.left;
            }
            return null;
        }


        public void InOrder(BinaryTreeNode node /*, int nLevel*/)
        {
            // UNCOMMENT THIS FOR A NICE OUTPUT LIKE:
            //  Root
            //  |_First
            //  |_Second
            //  ||_Second1
            //  ||_Second2
            //
            //if (node != null)
            //{
            //    for (int i = 0; i < nLevel; i++)
            //        Console.Write("|");
            //    Console.WriteLine("_" + node.name);

            //    PrintNodes(node.left, nLevel + 1);
            //    PrintNodes(node.right, nLevel + 1);
            //}
            //else
            //{
            //    for (int i = 0; i < nLevel; i++)
            //        Console.Write("|");
            //    Console.WriteLine("_ *");
            //}
            

            if (node != null)
            {
                InOrder(node.left);
                Console.Write(node.data + " ");
                InOrder(node.right);
            }
        }

        public void InOrderPrint()
        {
            InOrder( root );
        }

        public void Insert(int elem)
        {
            InsertNode(ref root, elem);
        }

        public void Print()
        {
            InOrder(root);
        }

        public void PrintSorted()
        {
            InOrderPrint();
        }

        public void PreOrder(BinaryTreeNode node)
        {
            if (node != null)
            {
                Console.Write( node.data + " " );
                PreOrder( node.left );
                PreOrder( node.right );
            }
        }

        public void PreOrderPrint()
        {
            PreOrder( root );
        }


        public void PostOrder(BinaryTreeNode node)
        {
            if (node != null)
            {
                PostOrder(node.left);
                PostOrder(node.right);
                Console.Write(node.data + " ");
            }
        }

        public void PostOrderPrint()
        {
            PostOrder(root);
        }

        public int Depth(BinaryTreeNode node)
        {
            if (node == null)
                return -1;
            else
                return Math.Max(Depth(node.left), Depth(node.right)) + 1;
        }

        public int getDepth()
        {
            return Depth( root );
            // here we can put the code for searching the node with particular element
        }

        public int getHeight(BinaryTreeNode node = null)
        {
            if (node == null)
                return 0;
            else
                return Math.Max( getHeight(node.left), getHeight(node.right) );
        }


        /// <summary>
        /// Iterative version of node removal in BST
        /// </summary>
        public void Remove(int elem)
        {
            // ------------------------------------------------ CASE 0 : EMPTY TREE
            if (root == null)
                return;

            BinaryTreeNode node = root;
            BinaryTreeNode prevnode = null;// root;

            // -------------------------------------------- find the necessary node
            while (node != null)
            {
                if (node.data == elem)
                {
                    break;
                }
                else if (node.data < elem)
                {
                    prevnode = node;
                    node = node.right;
                }
                else
                {
                    prevnode = node;
                    node = node.left;
                }
            }

            // ----------------------------------------- if there's no such element
            if (node == null)
                return;

            // ------------------------------------------------------ CASE 1 : LEAF
            if (node.left == null && node.right == null)
            {
                if (node == root)                           // perhaps this is root!
                {
                    root = null;
                    return;
                }

                if (prevnode.left == node)                  // otherwise
                    prevnode.left = null;
                else
                    prevnode.right = null;
                return;
            }

            // ------------------------------------------ CASE 2 : ONLY ONE SUBTREE
            else if (node.left == null || node.right == null)
            {
                if (node == root)
                {
                    root = (root.left != null) ? root.left : root.right;
                    return;
                }

                if (prevnode.left == node)
                {
                    prevnode.left = (node.left != null) ? node.left : node.right;
                }
                else
                {
                    prevnode.right = (node.right != null) ? node.right : node.left;
                }
            }
            else
                // --------------------------------------------- CASE 3 : BOTH CHILDREN
                if (node.left != null && node.right != null)
                {
                    BinaryTreeNode prev = null;
                    BinaryTreeNode t = node.left;

                    while (t.right != null)             // traverse to the top-right node
                    {
                        prev = t;
                        t = t.right;
                    }

                    int tmp = node.data;
                    node.data = t.data;
                    t.data = tmp;

                    if (prev == null)                   // if a left node was the only one
                    {
                        node.left = t.left;             // recombine pointers in this manner
                    }
                    else
                    {
                        prev.right = t.left;            // recombine pointers in this manner
                    }
                }
        }


        /// <summary>
        /// Recursive version of node removal
        /// </summary>
        public void Remove(ref BinaryTreeNode node, int elem)
        {
            if (node == null)
                return;
            if (node.data == elem)
            {
                if (node.left == null)
                    node = node.right;
                else if (node.right == null)
                    node = node.left;
                else
                {
                    BinaryTreeNode newLeft = node.left;
                    BinaryTreeNode newRight = node.right;
                    BinaryTreeNode newNode = getMax(node.left);
                    Remove(ref node, newNode.data);
                    node = newNode;
                    if (newLeft != newNode)
                        node.left = newLeft;
                    node.right = newRight;
                }
            }
            else if (elem < node.data)
            {
                Remove(ref node.left, elem);
            }
            else
            {
                Remove(ref node.right, elem);
            }
        }


        /// <summary>
        /// Reverse BST: flip left and right subtrees
        /// </summary>
        public void Reverse(BinaryTreeNode root)
        {
            if (root == null)
                return;

            // swap left and right children
            var tmp = root.left;
            root.left = root.right;
            root.right = tmp;

            Reverse(root.left);
            Reverse(root.right);
        }

        public void ReverseTree()
        {
            Reverse(root);
        }
        

        /// <summary>
        /// Get the maximum value stored in BST
        /// </summary>
        public BinaryTreeNode getMax(BinaryTreeNode node) 
        {
            if (node.right == null)
                return node;

            return getMax(node.right);
        }
    }
}
