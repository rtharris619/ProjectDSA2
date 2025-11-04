using static ProjectDSA2.Helpers.BinaryTreeHelper;

namespace ProjectDSA2.Algomonster.DepthFirstSearch;

public class ValidBst
{
    public static bool DFS(Node<int> root, int min, int max)
    {
        if (root == null) return true;

        if (root.val < min || root.val > max)
        {
            return false;
        }

        return DFS(root.left, min, root.val) && DFS(root.right, root.val, max);
    }

    public static bool Valid(Node<int> root)
    {
        return DFS(root, int.MinValue, int.MaxValue);
    }

    public static void Driver()
    {
        Node<int> tree = ExtractTree("6 4 3 x x 5 x x 8 x x", int.Parse);
        Console.WriteLine(Valid(tree));

        tree = ExtractTree("6 4 3 x x 9 x x 8 x x", int.Parse);
        Console.WriteLine(Valid(tree));
    }
}
