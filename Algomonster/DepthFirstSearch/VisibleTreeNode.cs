namespace ProjectDSA2.Algomonster.DepthFirstSearch;

public class VisibleTreeNode
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

    public static int DFS(Node<int> root, int maxSoFar)
    {
        if (root == null) return 0;

        int total = 0;
        if (root.val >= maxSoFar)
        {
            total++;
        }

        total += DFS(root.left, Math.Max(maxSoFar, root.val));
        total += DFS(root.right, Math.Max(maxSoFar, root.val));

        return total;
    }

    public static int VisibleTree(Node<int> root)
    {
        return DFS(root, int.MinValue);
    }

    public static void Driver()
    {
        string str = "5 4 3 x x 8 x x 6 x x";
        List<string> strs = [.. str.Split([' '])];
        int pos = 0;
        Node<int> root = BuildTree(strs, ref pos, int.Parse);
        Console.WriteLine(VisibleTree(root));

        str = "-100 x -500 x -50 x x";
        strs = [.. str.Split([' '])];
        pos = 0;
        root = BuildTree(strs, ref pos, int.Parse);
        Console.WriteLine(VisibleTree(root));
    }
}
