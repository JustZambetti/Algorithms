using AlgorithmsAndDataStructures.DataStructures;

namespace AlgorithmsAndDataStructures.Backtracking
{
    public class GetAllSimplePathsInGraphProblem : BacktrackingProblem<Vertex, (Graph graph, Vertex startVertex, Vertex endVertex)>
    {
        private Dictionary<Vertex, bool> IsVisited { get; } = new();
        public Graph Graph { get; }
        public Vertex StartVertex { get; }
        public Vertex EndVertex { get; }

        public GetAllSimplePathsInGraphProblem((Graph graph, Vertex startVertex, Vertex endVertex) input) : base(input)
        {
            Graph = input.graph;
            StartVertex = input.startVertex;
            foreach (var vertex in Graph.Vertices)
                IsVisited[vertex] = false;

            EndVertex = input.endVertex;
            IsVisited[StartVertex] = true;
        }

        public override Vertex[] ConstructCandidates(Vertex[] partialSolution, int k)
        {
            var lastVertex = partialSolution[k - 1];
            var vertex = lastVertex ?? StartVertex;
            return vertex.LinkedVertices.Where(v => !IsVisited[v]).ToArray();
        }

        public override bool IsASolution(Vertex[] partialSolution, int k)
        {
            return partialSolution[k] == EndVertex;
        }

        public override void MakeMove(Vertex[] partialSolution, int k)
        {
            var lastVertex = partialSolution[k];
            IsVisited[lastVertex] = true;
        }

        public override void ProcessSolution(Vertex[] solution, int k)
        {
            Console.Write("< ");
            Console.Write(StartVertex.Value + " - ");
            for (int i = 1; i <= k; i++)
                if (solution[i] == null)
                    break;
                else
                    Console.Write($"{solution[i].Value} - ");
            Console.WriteLine("\b\b>  ");
        }

        public override void UnmakeMove(Vertex[] partialSolution, int k)
        {
            var lastVertex = partialSolution[k];
            IsVisited[lastVertex] = false;
        }
    }
}