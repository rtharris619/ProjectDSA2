namespace ProjectDSA2.Algomonster.BinarySearch;

public class SquareRoot
{
    public static int Square(int n)
    {
        if (n == 0) return 0;
        if (n == 1) return 1;

        List<int> arr = [.. Enumerable.Range(0, n)];

        int left = 0, right = arr.Count - 1;
        int searchIndex = -1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int square = arr[mid] * arr[mid];
            if (square == n)
            {
                return arr[mid];
            }
            else if (square > n)
            {
                searchIndex = mid;
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }

        return arr[searchIndex - 1];
    }

    public static int Square2(int n)
    {
        if (n == 0) return 0;

        int left = 1;
        int right = n;
        int result = -1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (mid == n / mid)
            {
                return mid;
            }
            else if (mid * mid > n)
            {
                result = mid;
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }

        return result - 1;
    }

    public static void Driver()
    {
        int n = 9;
        var result = Square2(n);
        Console.WriteLine(result);

        n = 16;
        result = Square2(n);
        Console.WriteLine(result);

        n = 8;
        result = Square2(n);
        Console.WriteLine(result);

        n = 22;
        result = Square2(n);
        Console.WriteLine(result);
    }
}
