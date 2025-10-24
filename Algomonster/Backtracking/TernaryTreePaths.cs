namespace ProjectDSA2.Algomonster.Backtracking;

public class TernaryTreePaths
{
    private class Node<T>
    {
        public T val;
        public List<Node<T>> children;

        public Node(T val)
        {
            this.val = val;
        }

        public Node(T val, List<Node<T>> children)
        {
            this.val = val;
            this.children = children;
        }
    }

    private static Node<T> BuildTree<T>(List<string> strs, ref int pos, Func<string, T> f)
    {
        string val = strs[pos];
        pos++;
        int num = int.Parse(strs[pos]);
        pos++;
        List<Node<T>> children = new List<Node<T>>();
        for (int i = 0; i < num; i++)
        {
            children.Add(BuildTree(strs, ref pos, f));
        }
        return new Node<T>(f(val), children);
    }

    private static List<string> SplitWords(string s)
    {
        return string.IsNullOrEmpty(s) ? new List<string>() : s.Trim().Split(' ').ToList();
    }

    private static void DFS(Node<int> root, List<string> path, List<string> result)
    {
        if (root.children.Count == 0)
        {
            path.Add(root.val.ToString());
            result.Add(string.Join("->", path));
            return;
        }

        foreach (Node<int> child in root.children)
        {
            if (child != null)
            {
                List<string> pathCopy = new List<string>(path);
                pathCopy.Add(root.val.ToString());
                DFS(child, pathCopy, result);
            }
        }
    }

    private static void DFSImproved(Node<int> root, List<string> path, List<string> result)
    {
        if (root.children.Count == 0)
        {
            path.Add(root.val.ToString()); // Push on the stack
            result.Add(string.Join("->", path));
            path.RemoveAt(path.Count - 1); // Pop off the stack
            return;
        }

        foreach (Node<int> child in root.children)
        {
            if (child != null)
            {
                path.Add(root.val.ToString()); // Add to the stack
                DFSImproved(child, path, result);
                path.RemoveAt(path.Count - 1); // Pop off the stack
            }
        }
    }

    private static List<string> Paths(Node<int> root)
    {
        List<string> result = new List<string>();
        if (root != null) DFSImproved(root, new List<string>(), result);
        return result;
    }

    public static void Driver()
    {
        int pos = 0;
        string input = "1 3 2 1 5 0 3 0 4 0";
        Node<int> root = BuildTree(SplitWords(input), ref pos, int.Parse);
        List<string> result = Paths(root);
        foreach (var line in result)
        {
            Console.WriteLine(line);
        }
    }
}
