using static ProjectDSA2.Helpers.BinaryTreeHelper;

namespace ProjectDSA2.Algomonster.DepthFirstSearch;

public class TreeMaxDepth
{    
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
