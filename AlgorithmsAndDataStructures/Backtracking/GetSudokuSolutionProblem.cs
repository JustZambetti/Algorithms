using AlgorithmsAndDataStructures.DataStructures;

namespace AlgorithmsAndDataStructures.Backtracking
{
    public class GetSudokuSolutionProblem : BacktrackingProblem<int, Sudoku>
    {
        int count = 0;
        int failCount = 0;
        int failDelta = 0;
        int[] moves;

        public GetSudokuSolutionProblem(Sudoku input) : base(input)
        {
            List<int> m = new();
            for (int i = 0; i < 81; i++)
                if (input.Get(i) == 0)
                    m.Add(i);
            moves = m.ToArray();
        }

        public override int[] ConstructCandidates(int[] partialSolution, int k)
        {
            int value = Input.Get(moves[k - 1]);
            if (value != 0)
                return new int[] { value };
            else
            {
                var v = Input.GetPossibleValues(moves[k - 1]);
                if (v.Length == 0)
                {
                    failDelta++;
                    failCount++;
                    if (failDelta == 1000000)
                    {
                        failDelta = 0;
                        Console.WriteLine("FAIL: " + failCount);
                    }
                }
                return v;
            }
        }

        public override bool IsASolution(int[] partialSolution, int k)
        {
            /*
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    int i = x + y * 9;
                    if (i <= k)
                        Console.Write(partialSolution[i + 1] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            */
            return k == moves.Length;
        }

        public override void MakeMove(int[] partialSolution, int k)
        {
            Input.Set(moves[k - 1], partialSolution[k]);
        }
        int difference = 0;
        public override void ProcessSolution(int[] partialSolution, int k)
        {
         //   Console.WriteLine("Solution!");

            
            count++;
            difference++;
            if (difference == 1000000)
            {
                Console.WriteLine("SOLUTION: " + count);
                difference = 0;
            }
            
            /*
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    int i = x + y * 9;
                    Console.Write(Input.Get(i) + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            */
        }

        public override void UnmakeMove(int[] partialSolution, int k)
        {
            Input.Reset(moves[k - 1]);
        }
    }
}