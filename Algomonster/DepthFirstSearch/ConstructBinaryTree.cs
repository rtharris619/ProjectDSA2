using static ProjectDSA2.Algomonster.DepthFirstSearch.BinaryTreeHelper;

namespace ProjectDSA2.Algomonster.DepthFirstSearch;

public class ConstructBinaryTree
{
    public static Node<int>? BuildTreeRecursive(
        List<int> preorder, 
        Dictionary<int, int> inorderIndexMap, 
        int preorderStartIndex, 
        int inorderStartIndex, 
        int size)
    {
        if (size <= 0) return null;

        int rootValue = preorder[preorderStartIndex];
        int inorderIndex = inorderIndexMap.FirstOrDefault(x => x.Value == rootValue).Key;
        int leftSize = inorderIndex - inorderStartIndex;

        var left = BuildTreeRecursive(
            preorder, 
            inorderIndexMap, 
            preorderStartIndex + 1, 
            inorderStartIndex, 
            leftSize);

        var right = BuildTreeRecursive
            (preorder, 
            inorderIndexMap, 
            preorderStartIndex + 1 + leftSize, 
            inorderIndex + 1, 
            size - 1 - leftSize);

        return new Node<int>(rootValue, left, right);
    }

    public static Node<int>? Construct(List<int> preorder, List<int> inorder)
    {
        var inorderIndexMap = new Dictionary<int, int>();
        for (int i = 0; i < inorder.Count; i++)
        {
            inorderIndexMap[i] = inorder[i];
        }

        return BuildTreeRecursive(preorder, inorderIndexMap, 0, 0, preorder.Count);
    }

    public static void Driver()
    {
        List<int> preorder = new List<int>() { 3, 9, 20, 15, 7 };
        List<int> inorder = new List<int>()  { 9, 3, 15, 20, 7 };
        var res = Construct(preorder, inorder);
        PreorderTraversal(res);
    }
}
