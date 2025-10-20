using static ProjectDSA2.Algomonster.DepthFirstSearch.BinaryTreeHelper;

namespace ProjectDSA2.Algomonster.DepthFirstSearch;

public class SubtreeOfAnotherTree
{
    public static bool IsSameTree(Node<int> root, Node<int> subRoot)
    {
        if (root == null && subRoot == null) return true;
        if (root == null || subRoot == null) return false;

        return root.val == subRoot.val && IsSameTree(root.left, subRoot.left) && IsSameTree(root.right, subRoot.right);
    }

    public static bool Subtree(Node<int> root, Node<int> subRoot)
    {
        if (root == null) return false;

        return IsSameTree(root, subRoot) || Subtree(root.left, subRoot) || Subtree(root.right, subRoot);
    }

    public static void Driver()
    {
        Node<int> root = ExtractTree("3 4 1 x x 2 x x 5 x x", int.Parse);
        Node<int> subRoot = ExtractTree("4 1 x x 2 x x", int.Parse);

        var res = Subtree(root, subRoot);
        Console.WriteLine(res);
    }
}