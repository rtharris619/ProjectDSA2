namespace ProjectDSA2.Algomonster.DepthFirstSearch;

public class VisibleTreeNode
{
    public static int DFS(BinaryTreeHelper.Node<int> root, int maxSoFar)
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

    public static int VisibleTree(BinaryTreeHelper.Node<int> root)
    {
        return DFS(root, int.MinValue);
    }

    public static void Driver()
    {
        string str = "5 4 3 x x 8 x x 6 x x";
        List<string> strs = [.. str.Split([' '])];
        int pos = 0;
        BinaryTreeHelper.Node<int> root = BinaryTreeHelper.BuildTree(strs, ref pos, int.Parse);
        Console.WriteLine(VisibleTree(root));

        str = "-100 x -500 x -50 x x";
        strs = [.. str.Split([' '])];
        pos = 0;
        root = BinaryTreeHelper.BuildTree(strs, ref pos, int.Parse);
        Console.WriteLine(VisibleTree(root));
    }
}
