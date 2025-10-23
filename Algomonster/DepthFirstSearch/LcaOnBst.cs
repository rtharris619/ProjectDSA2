using static ProjectDSA2.Algomonster.DepthFirstSearch.BinaryTreeHelper;

namespace ProjectDSA2.Algomonster.DepthFirstSearch;

public class LcaOnBst
{
    public static int Lca(Node<int> bst, int p, int q)
    {
        if (p < bst.val && q < bst.val)
        {
            return Lca(bst.left, p, q);
        }
        else if (p > bst.val && q > bst.val)
        {
            return Lca(bst.right, p, q);
        }
        else
        {
            return bst.val;
        }
    }

    public static void Driver()
    {
        Node<int> tree = ExtractTree("6 2 0 x x 4 3 x x 5 x x 8 7 x x 9 x x", int.Parse);
        var res = Lca(tree, 2, 8);
        Console.WriteLine(res);

        res = Lca(tree, 2, 4);
        Console.WriteLine(res);
    }
}
