namespace ProjectDSA2.Algomonster.Backtracking;

public class Fibonacci
{
    // Calculates Nth Fibonacci Number
    private static int Fib(int n)
    {
        if (n <= 1) return n;

        return Fib(n - 1) + Fib(n - 2);
    }

    private static int FibMemo(int n, int[] memo)
    {        
        if (n <= 1) return n;
        if (memo[n] != 0) return memo[n];

        int result = FibMemo(n - 1, memo) + FibMemo(n - 2, memo);

        memo[n] = result;
        return result;
    }

    public static void Driver()
    {
        int n = 8;
        int[] memo = new int[n + 1];
        Array.Fill(memo, 0);
        var result = FibMemo(n, memo);
        Console.WriteLine(result);
    }
}
