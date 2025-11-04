using static ProjectDSA2.Helpers.BinaryTreeHelper;

namespace ProjectDSA2.Algomonster.BreadthFirstSearch;

public class ZigZagTraversal
{
    public static List<List<int>> ZigZag(Node<int> root)
    {
        var result = new List<List<int>>();

        Queue<Node<int>> queue = new Queue<Node<int>>();
        queue.Enqueue(root);
        var leftFirst = true;

        while (queue.Count > 0)
        {
            var level = new LinkedList<int>();            
            var n = queue.Count;

            for (int i = 0; i < n; i++)
            {
                var node = queue.Dequeue();
                if (leftFirst)
                {
                    level.AddLast(node.val);
                }
                else
                {
                    level.AddFirst(node.val);
                }

                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);                        
            }

            leftFirst = !leftFirst;
            result.Add(level.ToList());
        }

        return result;
    }

    public static List<List<int>> ZigZag2(Node<int> root)
    {
        if (root == null) return new List<List<int>>();

        var result = new List<List<int>>();

        Queue<Node<int>> q = new Queue<Node<int>>();
        q.Enqueue(root);
        var left = true;

        while (q.Count > 0)
        {
            var level = new List<int>();
            var n = q.Count;

            for (int i = 0; i < n; i++)
            {
                var node = q.Dequeue();
                level.Add(node.val);
                if (node.left != null)
                    q.Enqueue(node.left);
                if (node.right != null)
                    q.Enqueue(node.right);
            }

            if (!left) level.Reverse();
            result.Add(level);
            left = !left;
        }

        return result;
    }

    public static void Driver()
    {
        Node<int> root = ExtractTree("1 2 4 x 7 x x 5 x 8 x x 3 x 6 x x", int.Parse);
        var result = ZigZag2(root);
        foreach (var item in result)
        {
            Console.WriteLine("[" + string.Join(", ", item) + "]");
        }
    }
}
