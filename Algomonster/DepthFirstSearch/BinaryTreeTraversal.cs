using System.Text;

namespace ProjectDSA2.Algomonster.DepthFirstSearch;

public class BinaryTreeTraversal
{
    public class Node<T>
    {
        public T value;
        public Node<T> left;
        public Node<T> right;

        public Node(T value)
        {
            this.value = value;
        }

        public Node(T value, Node<T> left, Node<T> right)
        {
            this.value = value;
            this.left = left;
            this.right = right;
        }
    }

    public static void InOrderTraversal(Node<int> root)
    {
        if (root != null)
        {
            InOrderTraversal(root.left);
            Console.WriteLine(root.value);
            InOrderTraversal(root.right);
        }
    }

    public static void PreOrderTraversal(Node<int> root)
    {
        if (root != null)
        {
            Console.WriteLine(root.value);
            PreOrderTraversal(root.left);
            PreOrderTraversal(root.right);
        }
    }

    public static void PostOrderTraversal(Node<int> root)
    {
        if (root != null)
        {
            PostOrderTraversal(root.left);
            PostOrderTraversal(root.right);
            Console.WriteLine(root.value);
        }
    }

    public static Node<T> BuildTree<T>(List<string> strs, ref int pos, Func<string, T> f)
    {
        string val = strs[pos];
        pos++;
        if (val == "x") return null;
        Node<T> left = BuildTree(strs, ref pos, f);
        Node<T> right = BuildTree(strs, ref pos, f);
        return new Node<T>(f(val), left, right);
    }

    public static string InOrderAsciiTree<T>(Node<T> root)
    {        
        var sb = new StringBuilder();
        BuildAscii(root, "", true, sb);
        return sb.ToString();

        static void BuildAscii<T>(Node<T> node, string prefix, bool isTail, StringBuilder sb)
        {
            if (node == null) return;

            if (node.right != null)
            {
                BuildAscii(node.right, prefix + (isTail ? "│   " : "    "), false, sb);
            }

            sb.Append(prefix)
                .Append(isTail ? "└── " : "┌── ")
                .AppendLine(node.value?.ToString());

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
        Node<int> root = BuildTree(strs, ref pos, int.Parse);
        //InOrderTraversal(root);
        Console.WriteLine(InOrderAsciiTree(root));
    }
}
