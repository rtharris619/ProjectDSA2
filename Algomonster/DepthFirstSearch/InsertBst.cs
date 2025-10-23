using static ProjectDSA2.Algomonster.DepthFirstSearch.BinaryTreeHelper;

namespace ProjectDSA2.Algomonster.DepthFirstSearch;

public class InsertBst
{
    public static Node<int> Insert(Node<int> bst, int val)
    {
        if (bst == null) return new Node<int>(val);

        int valueToCompare = bst.val.CompareTo(val);

        if (valueToCompare == 0)
        {
            return bst;
        }
        else if (valueToCompare < 0)
        {
            bst.right = Insert(bst.right, val);
        }
        else
        {
            bst.left = Insert(bst.left, val);
        }
        return bst;
    }

    public static void Driver()
    {
        Node<int> tree = ExtractTree("8 5 2 x 3 x x 6 x x 10 x 14 x x", int.Parse);
        tree = Insert(tree, 7);
        PreorderTraversal(tree);
    }
}
