namespace ProjectDSA2.Algomonster.DepthFirstSearch;

public class IsBalanced
{
    public static int TreeHeight(BinaryTreeHelper.Node<int> tree)
    {
        if (tree == null) return 0;

        int leftHeight = TreeHeight(tree.left);
        int rightHeight = TreeHeight(tree.right);

        if (leftHeight == -1 || rightHeight == -1) return -1;
        if (Math.Abs(leftHeight - rightHeight) > 1) return -1;

        return Math.Max(leftHeight, rightHeight) + 1;
    }

    public static bool Balanced(BinaryTreeHelper.Node<int> tree)
    {
        return TreeHeight(tree) != -1;
    }

    public static void Driver()
    {
        string str = "1 2 4 x 7 x x 5 x x 3 x 6 x x";        
        BinaryTreeHelper.Node<int> tree = BinaryTreeHelper.ExtractTree(str, int.Parse);
        Console.WriteLine(Balanced(tree));
        //BinaryTreeHelper.PreorderTraversal(tree);

        str = "1 2 4 x 7 x x 5 x x 3 x 6 8 x x x";
        tree = BinaryTreeHelper.ExtractTree(str, int.Parse);
        Console.WriteLine(Balanced(tree));
    }
}
