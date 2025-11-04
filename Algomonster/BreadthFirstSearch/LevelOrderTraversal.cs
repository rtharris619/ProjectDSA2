using static ProjectDSA2.Helpers.BinaryTreeHelper;

namespace ProjectDSA2.Algomonster.BreadthFirstSearch;

public class LevelOrderTraversal
{
    public static List<List<int>> LevelOrder(Node<int> root)
    {
        var result = new List<List<int>>();

        Queue<Node<int>> queue = new Queue<Node<int>>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var level = new List<int>();
            var n = queue.Count;
            
            for (int i = 0; i < n; i++)
            {
                var node = queue.Dequeue();
                level.Add(node.val);
                if (node.left != null)
                    queue.Enqueue(node.left);
                if (node.right != null)
                    queue.Enqueue(node.right);
            }
            result.Add(level);
        }

        return result;
    }

    public static void Driver()
    {
        Node<int> root = ExtractTree("1 2 4 x 7 x x 5 x x 3 x 6 x x", int.Parse);
        var result = LevelOrder(root);
        foreach (var item in result)
        {
            Console.WriteLine("[" + string.Join(", ", item) + "]");
        }
    }
}
