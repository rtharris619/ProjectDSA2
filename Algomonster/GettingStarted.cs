namespace ProjectDSA2.Algomonster;

public class GettingStarted
{
    private int Mod(int x, int y)
    {
        while (x >= y)
        {
            x -= y;
        }

        return x;
    }

    public void Driver()
    {
        var x = 32;
        var y = 12;
        var mod = Mod(x, y);
        Console.WriteLine(mod);
    }
}
