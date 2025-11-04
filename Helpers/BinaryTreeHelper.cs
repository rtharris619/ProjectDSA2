namespace ProjectDSA2.Helpers;

public class BinaryTreeHelper
{
    public class Node<T>
    {
        public T val;
        public Node<T> left;
        public Node<T> right;

        public Node(T val)
        {
            this.val = val;
        }

        public Node(T val, Node<T> left, Node<T> right)
        {
            this.val = val;
            this.left = left;
            this.right = right;
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

    public static Node<T> ExtractTree<T>(string str, Func<string, T> f)
    {
        List<string> strs = [.. str.Split([' '])];
        int pos = 0;
        return BuildTree(strs, ref pos, f);
    }

    public static void PreorderTraversal(Node<int> node, string indent = "")
    {
        if (node != null)
        {
            var current_indent = indent + "  ";
            Console.WriteLine(current_indent + node.val);
            PreorderTraversal(node.left, current_indent);
            PreorderTraversal(node.right, current_indent);
        }
    }
}
