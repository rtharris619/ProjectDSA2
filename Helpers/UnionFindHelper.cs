namespace ProjectDSA2.Helpers;

public class UnionFindHelper
{
    public class UnionFind()
    {
        private readonly Dictionary<int, int> parent = new Dictionary<int, int>();
        private readonly Dictionary<int, int> rank = new Dictionary<int, int>();

        public int Find(int x)
        {
            if (!parent.ContainsKey(x))
            {
                parent[x] = x;
                rank[x] = 0;
            }

            if (parent[x] != x)
            {
                parent[x] = Find(parent[x]); // path compression
            }
            return parent[x];
        }

        public void Union(int x, int y)
        {
            int rx = Find(x);
            int ry = Find(y);
            if (rx == ry)
                return;

            // union by rank
            if (rank[rx] < rank[ry])
            {
                parent[rx] = ry;
            }
            else if (rank[rx] > rank[ry])
            {
                parent[ry] = rx;
            }
            else
            {
                parent[ry] = rx;
                rank[rx]++;
            }
        }
    }
}
