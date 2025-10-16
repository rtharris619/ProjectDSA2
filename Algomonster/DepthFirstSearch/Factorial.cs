namespace ProjectDSA2.Algomonster.DepthFirstSearch;

public class Factorial
{
    public static int CalculateFactorial(int n)
    {
        if (n <= 1)
        {
            return 1;
        }
        return n * CalculateFactorial(n - 1);
    }

    public static int CalculateFactorialStack(int n)
    {
        int res = 1;
        Stack<int> stack = new Stack<int>();

        while (n > 0)
        {
            stack.Push(n);
            n--;
        }

        while (stack.Count > 0)
        {
            res *= stack.Pop();
        }

        return res;
    }

    public static void Driver()
    {
        int n = 5;
        int res = CalculateFactorialStack(n);
        Console.WriteLine(res);
    }
}
