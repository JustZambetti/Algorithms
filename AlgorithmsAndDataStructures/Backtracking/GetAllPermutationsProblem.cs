namespace AlgorithmsAndDataStructures.Backtracking
{
    public class GetAllPermutationsProblem : BacktrackingProblem<int, int>
    {
        private readonly List<int> unusedElements = new();

        public GetAllPermutationsProblem(int input) : base(input)
        {
            unusedElements.AddRange(Enumerable.Range(0, input));
        }

        public override int[] ConstructCandidates(int[] partialSolution, int k)
        {
            return unusedElements.ToArray();
        }

        public override bool IsASolution(int[] partialSolution, int k)
        {
            return k == Input;
        }

        public override void MakeMove(int[] partialSolution, int k)
        {
            unusedElements.Remove(partialSolution[k]);
        }

        public override void ProcessSolution(int[] solution, int k)
        {
            Console.Write("[ ");
            for (int i = 1; i <= Input; i++)
                Console.Write($"{solution[i]} ");
            Console.WriteLine("]");
        }

        public override void UnmakeMove(int[] partialSolution, int k)
        {
            unusedElements.Add(partialSolution[k]);
        }
    }
}