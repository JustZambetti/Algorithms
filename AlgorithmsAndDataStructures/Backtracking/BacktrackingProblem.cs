using AlgorithmsAndDataStructures.DataStructures;

namespace AlgorithmsAndDataStructures.Backtracking
{
    public abstract class BacktrackingProblem<StateT, InputT>
    {
        private (Graph graph, Vertex startVertex, Vertex endVertex) input;

        public event Action OnFinish;
        public InputT Input { get; private set; }
        public BacktrackingProblem(InputT input)
        {
            Input = input;
        }

        protected BacktrackingProblem((Graph graph, Vertex startVertex, Vertex endVertex) input)
        {
            this.input = input;
        }

        public abstract bool IsASolution(StateT[] partialSolution, int k);
        public abstract void ProcessSolution(StateT[] partialSolution, int k);
        public abstract void MakeMove(StateT[] partialSolution, int k);
        public abstract void UnmakeMove(StateT[] partialSolution, int k);
        public abstract StateT[] ConstructCandidates(StateT[] partialSolution, int k);
    }
}