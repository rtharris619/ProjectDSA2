namespace ProjectDSA2.Misc;

public class Primes
{
    public static List<int> GetPrimesUpTo(int max)
    { 
        var result = new List<int>();
        bool[] isPrimes = new bool[max + 1];
        Array.Fill(isPrimes, true);
        isPrimes[0] = isPrimes[1] = false;

        for (int i = 2; i * i <= max; i++)
        {
            if (isPrimes[i])
            {
                // Mark all multiples of i as not prime
                for (int j = i * i; j <= max; j += i)
                {
                    isPrimes[j] = false;
                }
            }
        }

        for (int i = 2; i < max; i++)
        {
            if (isPrimes[i])
                result.Add(i);
        }

        return result;
    }

    public static void Driver()
    {
        int max = 30;
        List<int> result = GetPrimesUpTo(max);
        Console.WriteLine("[" + string.Join(", ", result) + "]");
    }
}
