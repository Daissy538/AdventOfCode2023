namespace Day8
{
    public class NodeHistory
    {
        public string StartNode { get; set; }
        public string EndNode { get; set; }
        public string CurrentNode { get; set; }

        public long Steps { get; set; }
    }

    public class Route
    {
        private Dictionary<string, string[]> netwerk = new Dictionary<string, string[]>();
        private Dictionary<string, int> directionMap = new Dictionary<string, int>()
        {
            { "L", 0},
            { "R", 1}
        };

        public List<int> ParseDirections(List<string> list)
        {
            return list.Select(i => directionMap[i]).ToList();
        }


        public Dictionary<string, string[]> CreateNetwork(string[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                var splited = data[i].Replace(" ", "")
                    .Replace("(", "")
                    .Replace(")", "")
                    .Split("=");

                var key = splited[0];
                var value = splited[1].Split(",").ToArray();

                netwerk.Add(key, value);
            }

            return netwerk;
        }

        public long GhostWalk(string[] directions)
        {
            var nodes = this.LoadNodeHistory();


            foreach (var node in nodes)
            {
                Walk(node, directions.Select(d => directionMap[d]).ToList());
            }

            return nodes.Select(n => n.Steps).Aggregate((a, b) => a * b);
        }

        private List<NodeHistory> LoadNodeHistory()
        {
            var list = new List<NodeHistory>();

            var starters = netwerk.Where(n => n.Key.EndsWith("A"));

            foreach(var start in starters) {
                list.Add(new NodeHistory
                {
                    StartNode = start.Key,
                    EndNode = $"{start.Key.Substring(0, start.Key.Length - 1)}Z",
                    Steps = 0                  
                });
            }

            return list;
        }

        public long Walk(NodeHistory node, List<int> directions)
        {           
            node.CurrentNode = node.StartNode;

            var directionIndexer = directions.GetEnumerator();


            while (true)
            {
                if (!directionIndexer.MoveNext())
                {
                    directionIndexer = directions.GetEnumerator();
                    directionIndexer.MoveNext();
                }

                node.Steps = node.Steps + 1;
                node.CurrentNode = netwerk[node.CurrentNode][directionIndexer.Current];

                if (node.CurrentNode.Equals(node.EndNode))
                {
                    return node.Steps;
                }
            }
        }
    }
}
