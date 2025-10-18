namespace ProjectDSA2.Algomonster.DepthFirstSearch;

public class FindTreeValue
{
    public static BinaryTreeHelper.Node<int>? DFS(BinaryTreeHelper.Node<int> root, int target)
    {
        if (root == null)
            return null;
        if (root.val == target) 
            return root;

        var left = DFS(root.left, target);
        var right = DFS(root.right, target);

        return left ?? right;
    }

    public static bool Find(BinaryTreeHelper.Node<int> root, int target)
    {
        return DFS(root, target) != null;
    }

    public static void Driver()
    {
        string str = "1 2 3 x 5 x x 4 x x 6 x x";
        List<string> strs = [.. str.Split([' '])];
        int pos = 0;
        BinaryTreeHelper.Node<int> root = BinaryTreeHelper.BuildTree(strs, ref pos, int.Parse);
        Console.WriteLine(Find(root, 3));
        //BinaryTreeHelper.PreorderTraversal(root);

        //str = "5 4 3 x x 8 x x 6 x x";
        //strs = [.. str.Split([' '])];
        //pos = 0;
        //root = BinaryTreeHelper.BuildTree(strs, ref pos, int.Parse);
        //BinaryTreeHelper.PreorderTraversal(root);
    }
}
