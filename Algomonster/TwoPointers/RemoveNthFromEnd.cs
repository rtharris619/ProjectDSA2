using static ProjectDSA2.Helpers.SinglyLinkedListHelper;

namespace ProjectDSA2.Algomonster.TwoPointers;

public class RemoveNthFromEnd
{

    public static Node<int> RemoveNth(Node<int> head, int n)
    {
        Node<int> dummy = new Node<int>(default) { next = head };
        Node<int> slow = dummy;
        Node<int> fast = dummy;

        while (n > 0)
        {
            fast = fast.next;
            n--;
        }

        while (fast.next != null)
        {
            slow = slow.next;
            fast = fast.next;
        }

        slow.next = slow.next.next;

        return dummy.next;
    }

    public static void Driver()
    {
        var arr = new List<int> { 1, 2, 3, 4 };
        Node<int> head = BuildList(arr);
        int n = 2;
        var result = RemoveNth(head, n);
        Console.WriteLine(result.val);
    }
}
