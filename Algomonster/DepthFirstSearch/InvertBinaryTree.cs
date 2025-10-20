using static ProjectDSA2.Algomonster.DepthFirstSearch.BinaryTreeHelper;

namespace ProjectDSA2.Algomonster.DepthFirstSearch;

public class InvertBinaryTree
{
    public static Node<int> Invert(Node<int> tree)
    {
        if (tree == null) return null;

        return new Node<int>(tree.val, Invert(tree.right), Invert(tree.left));
    }

    public static void Driver()
    {
        Node<int> tree = ExtractTree("1 2 4 x 7 x x 5 x x 3 x 6 x x", int.Parse);
        Node<int> res = Invert(tree);
        PreorderTraversal(res);
    }
}
 