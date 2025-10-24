using static ProjectDSA2.Algomonster.DepthFirstSearch.BinaryTreeHelper;

namespace ProjectDSA2.Algomonster.DepthFirstSearch;

public class LcaOnBinaryTree
{
    public static Node<int>? Find(Node<int> root, int target)
    {
        if (root == null) return null;
        if (root.val == target) return root;

        var left = Find(root.left, target);
        var right = Find(root.right, target);

        return left ?? right;
    }

    public static Node<int>? Lca(Node<int> root, Node<int> node1, Node<int> node2)
    {
        if (root == null) return null;

        if (ReferenceEquals(root, node1) || ReferenceEquals(root, node2)) return root;

        Node<int>? left = Lca(root.left, node1, node2);
        Node<int>? right = Lca(root.right, node1, node2);

        if (left != null && right != null) return root;

        if (left != null) return left;
        if (right != null) return right;

        return null;
    }

    public static void Driver()
    {
        Node<int> tree = ExtractTree("6 4 3 x x 5 x x 8 x x", int.Parse);
        Node<int>? node1 = Find(tree, 4);
        Node<int>? node2 = Find(tree, 8);
        var result = Lca(tree, node1, node2);
        PreorderTraversal(result);
    }
}
