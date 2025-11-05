using static ProjectDSA2.Helpers.BinaryTreeHelper;

namespace ProjectDSA2.Algomonster.BreadthFirstSearch;

public class BinaryTreeMinDepth
{
    public static int MinDepth(Node<int> root)
    {
        if (root == null)
            return 0;

        int depth = 0;
        var q = new Queue<Node<int>>();
        q.Enqueue(root);

        while (q.Count > 0)
        {
            int n = q.Count;
            for (int i = 0; i < n; i++)
            {
                var node = q.Dequeue();
                if (node.left == null && node.right == null)
                    return depth;
                if (node.left != null)
                    q.Enqueue(node.left);
                if (node.right != null)
                    q.Enqueue(node.right);
            }
            depth++;
        }

        return depth;
    }

    public static void Driver()
    {
        Node<int> root = ExtractTree("1 2 4 x 7 x x 5 x x 3 x 6 x x", int.Parse);
        var result = MinDepth(root);
        Console.WriteLine(result);
    }
}
