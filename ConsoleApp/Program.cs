
using AlgorithmsAndDataStructures;
using AlgorithmsAndDataStructures.Backtracking;
using AlgorithmsAndDataStructures.DataStructures;
/*
int n = 10;

GetAllSubsetsProblem getAllSubsetsProblem = new(n);
GetAllPermutationsProblem getAllPermutationsProblem = new(n);
var solver = new BacktrackingSolver<bool, int>();
solver.Solve(getAllSubsetsProblem, n + 1);
Console.WriteLine();
var permutationSolver = new BacktrackingSolver<int, int>();
permutationSolver.Solve(getAllPermutationsProblem, n + 1);
*/

/*
Graph g = new(
    (1,2),
    (2,6),
    (1,3),
    (1,4),
    (3,4),
    (3,6),
    (4,6),
    (1,5),
    (5,6)
);

GetAllSimplePathsInGraphProblem getAllSimplePathsInGraph = new((g, g.Vertices[g.ValueToIndex[1]], g.Vertices[g.ValueToIndex[3]]));

var solver = new BacktrackingSolver<Vertex, (Graph graph, Vertex startVertex, Vertex endVertex)>();
solver.Solve(getAllSimplePathsInGraph, g.Vertices.Count+1);

*/

Sudoku sudoku = new();
/*
sudoku.Set(1,9);
sudoku.Set(3,4);
sudoku.Set(12,6);
sudoku.Set(16,5);
sudoku.Set(18,2);
sudoku.Set(20,4);
sudoku.Set(23,7);
sudoku.Set(24,8);
sudoku.Set(28,8);
sudoku.Set(32,9);
sudoku.Set(36,3);
sudoku.Set(38,9);
sudoku.Set(39,7);
sudoku.Set(44,6);
sudoku.Set(46,1);
sudoku.Set(51,3);
sudoku.Set(54,1);
sudoku.Set(67,2);
sudoku.Set(71,8);
sudoku.Set(72,7);
sudoku.Set(74,3);
sudoku.Set(77,4);
sudoku.Set(78,2);
*/

for (int y = 0; y < 9; y++)
{
    for (int x = 0; x < 9; x++)
    {
        int i = x + y * 9;
        Console.Write(sudoku.Get(i) + " ");
    }
    Console.WriteLine();
}
Console.WriteLine();



GetSudokuSolutionProblem sudokuProblem = new(sudoku);

var solver = new BacktrackingSolver<int, Sudoku>();
solver.Solve(sudokuProblem, 82);