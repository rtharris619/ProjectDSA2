namespace ProjectDSA2.Algomonster.DynamicProgramming;

public class NthTribonacciNumber
{

    public static int NthTribonacci(int n)
    {
        if (n == 0) return 0;
        if (n <= 2) return 1;

        int first = 0;
        int second = 1;
        int third = 1;

        for (int i = 3; i <= n; i++)
        {
            int fourth = first + second + third;
            first = second;
            second = third;
            third = fourth;
        }

        return third;
    }

    public static void Driver()
    {
        int n = 25;
        int result = NthTribonacci(n);
        Console.WriteLine(result);
    }
}
