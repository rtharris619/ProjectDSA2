namespace ProjectDSA2.Algomonster.TwoPointers;

public class MiddleOfLinkedList
{
    public class Node<T>
    {
        public T val;
        public Node<T> next;

        public Node(T val)
        {
            this.val = val;
        }

        public Node(T val, Node<T> next)
        {
            this.val = val;
            this.next = next;
        }
    }

    public static int Middle(Node<int> head)
    {
        Node<int> left = head, right = head;

        while (right != null && right.next != null)
        {
            left = left.next;
            right = right.next.next;
        }

        return left.val;
    }

    public static Node<int> BuildList(List<int> ints)
    {
        Node<int> node = null;
        for (int i = ints.Count - 1; i >= 0; i--)
        {
            node = new Node<int>(ints[i], node);
        }
        return node;
    }

    public static void Driver()
    {
        List<int> arr = new List<int> { 0, 1, 2, 3, 4 };
        Node<int> head = BuildList(arr);
        int result = Middle(head);
        Console.WriteLine(result);

        arr = new List<int> { 0, 1, 2, 3, 4, 5 };
        head = BuildList(arr);
        result = Middle(head);
        Console.WriteLine(result);
    }
}
