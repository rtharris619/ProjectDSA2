using static ProjectDSA2.Helpers.BinaryTreeHelper;

namespace ProjectDSA2.Algomonster.BreadthFirstSearch;

public class BinaryTreeRightSideView
{
    public static List<int> RightSideView(Node<int> root)
    {
        if (root == null)
            return new List<int>();

        var result = new List<int>();
        var q = new Queue<Node<int>>();
        q.Enqueue(root);

        while (q.Count > 0)
        {
            int n = q.Count;
            int last = 0; // Uses additional memory

            for (int i = 0; i < n; i++)
            {
                Node<int> node = q.Dequeue();
                last = node.val;
                if (node.left != null)
                    q.Enqueue(node.left);
                if (node.right != null)
                    q.Enqueue(node.right);
            }

            result.Add(last);
        }

        return result;
    }

    public static List<int> RightSideView2(Node<int> root)
    {
        if (root == null)
            return new List<int>();

        var result = new List<int>();
        var q = new Queue<Node<int>>();
        q.Enqueue(root);

        while (q.Count > 0)
        {
            int n = q.Count;

            result.Add(q.Peek().val);
            for (int i = 0; i < n; i++)
            {
                Node<int> node = q.Dequeue();
                if (node.right != null)
                    q.Enqueue(node.right);
                if (node.left != null)
                    q.Enqueue(node.left);
            }
        }

        return result;
    }

    public static void Driver()
    {
        Node<int> root = ExtractTree("1 2 4 x 7 x x 5 x x 3 x 6 x x", int.Parse);
        var result = RightSideView2(root);
        Console.WriteLine("[" + string.Join(", ", result) + "]");
    }
}
