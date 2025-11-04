using ProjectDSA2.Helpers;
using System.Text;

namespace ProjectDSA2.Algomonster.DepthFirstSearch;

public class BinaryTreeTraversal
{
    public static void InOrderTraversal(BinaryTreeHelper.Node<int> root)
    {
        if (root != null)
        {
            InOrderTraversal(root.left);
            Console.WriteLine(root.val);
            InOrderTraversal(root.right);
        }
    }

    public static void PreOrderTraversal(BinaryTreeHelper.Node<int> root)
    {
        if (root != null)
        {
            Console.WriteLine(root.val);
            PreOrderTraversal(root.left);
            PreOrderTraversal(root.right);
        }
    }

    public static void PostOrderTraversal(BinaryTreeHelper.Node<int> root)
    {
        if (root != null)
        {
            PostOrderTraversal(root.left);
            PostOrderTraversal(root.right);
            Console.WriteLine(root.val);
        }
    }

    public static string InOrderAsciiTree<T>(BinaryTreeHelper.Node<T> root)
    {        
        var sb = new StringBuilder();
        BuildAscii(root, "", true, sb);
        return sb.ToString();

        static void BuildAscii<T>(BinaryTreeHelper.Node<T> node, string prefix, bool isTail, StringBuilder sb)
        {
            if (node == null) return;

            if (node.right != null)
            {
                BuildAscii(node.right, prefix + (isTail ? "│   " : "    "), false, sb);
            }

            sb.Append(prefix)
                .Append(isTail ? "└── " : "┌── ")
                .AppendLine(node.val?.ToString());

            if (node.left != null)
            {
                BuildAscii(node.left, prefix + (isTail ? "    " : "│   "), true, sb);
            }
        }
    }

    public static void Driver()
    {
        string str = "5 4 3 x x 8 x x 6 x x";
        List<string> strs = [.. str.Split([' '])];
        int pos = 0;
        BinaryTreeHelper.Node<int> root = BinaryTreeHelper.BuildTree(strs, ref pos, int.Parse);
        //InOrderTraversal(root);
        Console.WriteLine(InOrderAsciiTree(root));
    }
}
