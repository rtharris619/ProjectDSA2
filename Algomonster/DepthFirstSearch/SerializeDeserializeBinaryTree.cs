using static ProjectDSA2.Algomonster.DepthFirstSearch.BinaryTreeHelper;

namespace ProjectDSA2.Algomonster.DepthFirstSearch;

public class SerializeDeserializeBinaryTree
{
    public static void SerializeDFS(Node<int> tree, List<string> result)
    {
        if (tree == null)
        {
            result.Add("x");
            return;
        }

        result.Add(tree.val.ToString());
        SerializeDFS(tree.left, result);
        SerializeDFS(tree.right, result);
    }

    public static string Serialize(Node<int> root)
    {
        var result = new List<string>();
        SerializeDFS(root, result);
        return string.Join(" ", result);
    }

    public static Node<int>? DeserializeDFS(List<string> nodes, ref int pos)
    {
        var val = nodes[pos];
        pos++;
        if (val == "x")
        {
            return null;
        }
        var current = new Node<int>(int.Parse(val));
        current.left = DeserializeDFS(nodes, ref pos);
        current.right = DeserializeDFS(nodes, ref pos);
        return current;
    }

    public static Node<int> Deserialize(string root)
    {
        int pos = 0;
        return DeserializeDFS(root.Split(" ").ToList(), ref pos);
    }

    public static void Driver()
    {
        Node<int> tree = ExtractTree("1 2 3 x x x 6 x x", int.Parse);
        var serialized = Serialize(tree);
        Node<int> tree2 = Deserialize(serialized);

        PreorderTraversal(tree);

        Console.WriteLine("\n\n\n");

        PreorderTraversal(tree2);
    }
}
