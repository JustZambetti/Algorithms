namespace AlgorithmsAndDataStructures.DataStructures
{
    public class Graph
    {
        public Dictionary<int, int> ValueToIndex { get; } = new();
        public List<Vertex> Vertices { get; } = new();
        public Graph(params (int v1, int v2)[] edges)
        {
            foreach(var (v1, v2) in edges)
            {
                if (!ValueToIndex.ContainsKey(v1))
                {
                    ValueToIndex[v1] = Vertices.Count;
                    Vertices.Add(new(v1));
                }
                if (!ValueToIndex.ContainsKey(v2))
                {
                    ValueToIndex[v2] = Vertices.Count;
                    Vertices.Add(new(v2));
                }

                Vertex vertexV1 = Vertices[ValueToIndex[v1]];
                Vertex vertexV2 = Vertices[ValueToIndex[v2]];
                vertexV1.LinkedVertices.Add(vertexV2);
                vertexV2.LinkedVertices.Add(vertexV1);
            }
        }
    }

    public class Vertex
    {
        public Vertex(int value)
        {
            Value = value;
        }
        public int Value { get; }
        public List<Vertex> LinkedVertices { get; set; } = new();
    }
}