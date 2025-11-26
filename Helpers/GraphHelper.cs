namespace ProjectDSA2.Helpers;

public class GraphHelper
{
    public class WeightedEdge
    {
        public int weight, a, b;

        public WeightedEdge(int weight, int a, int b)
        {
            this.weight = weight;
            this.a = a;
            this.b = b;
        }
    }
}
