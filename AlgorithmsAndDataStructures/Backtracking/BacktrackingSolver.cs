namespace AlgorithmsAndDataStructures.Backtracking
{
    public class BacktrackingSolver<StateT, InputT>
    {
        private BacktrackingProblem<StateT, InputT> Problem { get; set; }
        private bool IsFinished { get; set; }

        public void Solve(BacktrackingProblem<StateT, InputT> problem, int solutionMaxSize)
        {
            Problem = problem;
            Problem.OnFinish += () => IsFinished = true;

            IsFinished = false;
            StateT[] a = new StateT[solutionMaxSize];
            int k = 0;
            Backtrack(a, k, problem.Input);
        }

        private void Backtrack(StateT[] a, int k, InputT input)
        {
            if (Problem.IsASolution(a, k))
                Problem.ProcessSolution(a, k);
            else
            {
                k++;
                var candidates = Problem.ConstructCandidates(a, k);
                foreach (var candidate in candidates)
                {
                    a[k] = candidate;
                    Problem.MakeMove(a, k);
                    Backtrack(a, k, input);
                    Problem.UnmakeMove(a, k);
                    if (IsFinished)
                        return;
                }
            }
        }
    }
}