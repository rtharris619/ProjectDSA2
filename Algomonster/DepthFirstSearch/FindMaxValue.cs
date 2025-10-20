using static ProjectDSA2.Algomonster.DepthFirstSearch.BinaryTreeHelper;

namespace ProjectDSA2.Algomonster.DepthFirstSearch;

public class FindMaxValue
{
    public static int DFS(Node<int> root)
    {
        if (root == null)
            return 0;

        int leftMax = DFS(root.left);
        int rightMax = DFS(root.right);

        return Math.Max(root.val, Math.Max(leftMax, rightMax));
    }

    public static int FindMax(Node<int> root)
    {
        return DFS(root);
    }

    public static void Driver()
    {
        string str = "5 4 3 x x 8 x x 6 x x";
        List<string> strs = [.. str.Split([' '])];
        int pos = 0;
        Node<int> root = BuildTree(strs, ref pos, int.Parse);
        Console.WriteLine(FindMax(root));
    }
}
