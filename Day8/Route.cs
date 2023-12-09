

namespace Day8
{
    public class NodeHistory
    {
        public string StartNode { get; set; }
        public string EndNode { get; set; }
        public string CurrentNode { get; set; }

        public bool Finished { get; set; }
    }

    public class Route
    {
        private Dictionary<string, string[]> netwerk = new Dictionary<string, string[]>();
        private Dictionary<string, int> directionMap = new Dictionary<string, int>()
        {
            { "L", 0},
            { "R", 1}
        };


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

        public int GhostWalk(string[] directions)
        {
            var steps = 0;
            var nodes = this.LoadNodeHistory();

            while (nodes.Any(n => !n.Finished))
            {
                foreach (var direction in directions)
                {                    
                    var index = directionMap[direction];
                    steps++;

                    foreach (var node in nodes)
                    {                     

                        node.CurrentNode = netwerk[node.CurrentNode][index];
                        node.Finished = node.CurrentNode.Equals(node.EndNode);
                    }

                    if (nodes.All(n => n.Finished))
                    {
                        break;
                    }

                   
                }
            }

            return steps;
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
                    CurrentNode = start.Key,
                    Finished = false,
                });
            }

            return list;
        }

        public int Walk(string[] directions)
        {
            var steps = 0;
            var end = true;
            var currentLocation = "AAA";
            while (end)
            {
                foreach( var direction in directions)
                {
                    steps = steps + 1;
                    var index = directionMap[direction];
                    currentLocation = netwerk[currentLocation][index];

                    if (currentLocation.Equals("ZZZ"))
                    {
                        end = false;
                        break;
                    }
                }
            }

            return steps;
        }
    }
}
