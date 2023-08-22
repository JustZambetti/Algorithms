namespace AlgorithmsAndDataStructures.Backtracking
{
    public class GetAllSubsetsProblem : BacktrackingProblem<bool, int>
    {
        private const int MaximumCandidatesCount = 2;

        public GetAllSubsetsProblem(int input) : base(input)
        {
        }

        public override bool[] ConstructCandidates(bool[] partialSolution, int k)
        {
            bool[] candidates = new bool[MaximumCandidatesCount];
            candidates[0] = true;
            candidates[1] = false;
            return candidates;
        }

        public override bool IsASolution(bool[] partialSolution, int k)
        {
            return k == Input;
        }

        public override void MakeMove(bool[] partialSolution, int k)
        {
        }

        public override void ProcessSolution(bool[] solution, int k)
        {
            Console.Write("{ ");
            for (int i = 0; i <= Input; i++)
                if (solution[i])
                    Console.Write($"{i - 1} ");
            Console.WriteLine("}");
        }

        public override void UnmakeMove(bool[] partialSolution, int k)
        {
        }
    }
}