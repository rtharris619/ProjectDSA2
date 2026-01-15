using static ProjectDSA2.Helpers.SinglyLinkedListHelper;

namespace ProjectDSA2.Algomonster.TwoPointers;

public class MiddleOfLinkedList
{

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
