namespace ProjectDSA2.Algomonster.DepthFirstSearch;

public class TreeMaxDepth
{
    public static string INDENT_LEVEL = "  ";
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

    public static Node<T> BuildTree<T>(List<string> strs, ref int pos, Func<string, T> f)
    {
        string val = strs[pos];
        pos++;
        if (val == "x") return null;
        Node<T> left = BuildTree(strs, ref pos, f);
        Node<T> right = BuildTree(strs, ref pos, f);
        return new Node<T>(f(val), left, right);
    }

    public static void PreorderTraversal(Node<int> node, string indent)
    {
        if (node != null)
        {
            var current_indent = indent + INDENT_LEVEL;
            Console.WriteLine(current_indent + node.value);
            PreorderTraversal(node.left, current_indent);
            PreorderTraversal(node.right, current_indent);
        }
    }

    public static int DFS(Node<int> node)
    {
        if (node == null)
            return 0;

        return 1 + Math.Max(DFS(node.left), DFS(node.right));
    }
    
    public static int MaxDepth(Node<int> root)
    {
        return root != null ? DFS(root) - 1 : 0;
    }

    public static void Driver()
    {
        string str = "5 4 3 x x 8 x x 6 x x";
        List<string> strs = [.. str.Split([' '])];
        int pos = 0;
        Node<int> root = BuildTree(strs, ref pos, int.Parse);
        PreorderTraversal(root, "");

        Console.WriteLine(MaxDepth(root));
    }
}
