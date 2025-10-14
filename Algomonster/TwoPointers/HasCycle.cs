namespace ProjectDSA2.Algomonster.TwoPointers;

public class HasCycle
{
    public class Node<T>
    {
        public T value;
        public Node<T> next;

        public Node(T value)
        {
            this.value = value;
        }

        public Node(T value, Node<T> next)
        {
            this.value = value;
            this.next = next;
        }
    }

    public static Node<int> NextNode(Node<int> node)
    {
        if (node.next == null)
        {
            return node;
        }
        return node.next;
    }

    public static bool Cycle(Node<int> nodes)
    {
        Node<int> tortoise = NextNode(nodes);
        Node<int> hare = NextNode(NextNode(nodes));

        // while tortoise and hare are not in the same position AND the hare hasn't reached the end
        while (tortoise != hare && hare.next != null)
        {
            tortoise = NextNode(tortoise);
            hare = NextNode(NextNode(hare));
        }

        // if we still have the hare pointing to a node then we definitely have a cycle
        return hare.next != null;
    }

    public static List<Node<int>> GetNodesList(List<int> input)
    {
        List<Node<int>> nodes = new List<Node<int>>();

        for (int i = 0; i < input.Count; i++) 
        {
            nodes.Add(new Node<int>(i));
        }

        for (int i = 0; i < input.Count; i++)
        {
            if (input[i] != -1) // represents empty/null tail cell
            {
                nodes[i].next = nodes[input[i]];
            }
        }

        return nodes;
    }

    public static void Driver()
    {
        List<int> input = new List<int>() { 1, 2, 3, 4, 1 };
        Node<int> nodes = GetNodesList(input)[0];
        bool res = Cycle(nodes);
        Console.WriteLine(res ? "true" : "false");
    }
}
