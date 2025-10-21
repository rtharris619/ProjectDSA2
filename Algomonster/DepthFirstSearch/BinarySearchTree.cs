using static ProjectDSA2.Algomonster.DepthFirstSearch.BinaryTreeHelper;

namespace ProjectDSA2.Algomonster.DepthFirstSearch;

public class BinarySearchTree
{
    public static bool Find(Node<int> tree, int target)
    {
        if (tree == null) return false;

        int valueComparision = tree.val.CompareTo(target);
        if (valueComparision == 0)
        {
            return true;
        }
        else if (valueComparision < 0)
        {
            return Find(tree.right, target);
        }
        else
        {
            return Find(tree.left, target);
        }
    }

    public static Node<int> Insert(Node<int> tree, int value)
    {
        if (tree == null)
        {
            return new Node<int>(value);
        }

        int valueComparison = tree.val.CompareTo(value);
        if (valueComparison < 0)
        {
            tree.right = Insert(tree.right, value);
        }
        else if (valueComparison > 0)
        {
            tree.left = Insert(tree.left, value);
        }

        return tree;
    }

    public static void Driver()
    {
        Node<int> tree = ExtractTree("8 3 1 x x 6 x 4 x x 10 x x", int.Parse);
        //PreorderTraversal(tree);
        var res = Find(tree, 6);
        Console.WriteLine(res);

        tree = Insert(tree, 7);
        PreorderTraversal(tree);
    }
}
