namespace ProjectDSA2.Helpers;

public class SinglyLinkedListHelper
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

    public static Node<T> BuildList<T>(List<T> ints)
    {
        Node<T> node = null;
        for (int i = ints.Count - 1; i >= 0; i--)
        {
            node = new Node<T>(ints[i], node);
        }
        return node;
    }
}
