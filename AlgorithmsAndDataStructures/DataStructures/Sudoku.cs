namespace AlgorithmsAndDataStructures.DataStructures
{
    public class Sudoku
    {
        private const int SetSize = 9;
        private int[] Values { get; } = new int[SetSize * SetSize];
        private SubGrid[] Rows { get; } = new SubGrid[SetSize].Select(n => new SubGrid()).ToArray();
        private SubGrid[] Columns { get; } = new SubGrid[SetSize].Select(n => new SubGrid()).ToArray();
        private SubGrid[] Squares { get; } = new SubGrid[SetSize].Select(n => new SubGrid()).ToArray();
        private Cell[] Cells { get; } = new Cell[SetSize * SetSize].Select(n => new Cell() { PossibleValuesCount = 9 }).ToArray();

        public Sudoku()
        {
            int index = 0;
            foreach (var row in Rows)
                for (int i = 0; i < SetSize; i++)
                {
                    row.Cells[i] = Cells[index];
                    index++;
                }
            index = 0;
            foreach (var column in Columns)
            {
                for (int i = 0; i < SetSize; i++)
                {
                    column.Cells[i] = Cells[SetSize * i + index];
                }
                index++;
            }
            index = 0;
            int squareIndex = 0;
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            Squares[squareIndex].Cells[3 * j + i] = Cells[index];
                            index++;
                        }
                        index += 6;
                    }
                    squareIndex++;
                    index -= 24;
                }
                index += 18;
            }
        }

        public int Get(int index)
            => Values[index];
        public int[] GetPossibleValues(int index)
        {
             for (int i = index; i < 81; i++)
          if(Cells[i].PossibleValuesCount == 0)
                     return Array.Empty<int>();

            int[] values = new int[Cells[index].PossibleValuesCount];
            int valueIndex = 0;
            for (int i = 1; valueIndex < values.Length; i++)
                if (!Cells[index].Contains(i))
                {
                    values[valueIndex] = i;
                    valueIndex++;
                }

            return values.ToArray();
        }

        private int ColumnIndex { get; set; } = 0;
        private int RowIndex { get; set; } = 0;
        private int SquareIndex { get; set; } = 0;

        public void Set(int index, int value)
        {
            RowIndex = index / 9;
            ColumnIndex = index % 9;
            SquareIndex = GetSquareIndex(RowIndex, ColumnIndex);

            Rows[RowIndex].Set(value);
            Columns[ColumnIndex].Set(value);
            Squares[SquareIndex].Set(value);
            Values[index] = value;
        }
        public void Reset(int index)
        {
            int value = Get(index);
            RowIndex = index / 9;
            ColumnIndex = index % 9;
            SquareIndex = GetSquareIndex(RowIndex, ColumnIndex);

            Rows[RowIndex].Reset(value);
            Columns[ColumnIndex].Reset(value);
            Squares[SquareIndex].Reset(value);
            Values[index] = 0;
        }

        private static int GetSquareIndex(int rowIndex, int columnIndex)
            => rowIndex / 3 * 3 + columnIndex / 3;

        public class SubGrid
        {
            public Cell[] Cells { get; } = new Cell[SetSize];
            public void Set(int value)
            {
                for (int i = 0; i < SetSize; i++)
                    Cells[i].Set(value);
            }
            public void Reset(int value)
            {
                for (int i = 0; i < SetSize; i++)
                    Cells[i].Reset(value);
            }
        }

        public class Cell
        {
            private int[] Mask { get; set; } = new int[SetSize];
            public int PossibleValuesCount { get; set; }
            public void Set(int value)
            {
                if (Mask[value - 1] == 0)
                    PossibleValuesCount--;
                Mask[value - 1]++;
            }

            public void Reset(int value)
            {
                if (Mask[value - 1] == 1)
                    PossibleValuesCount++;
                Mask[value - 1]--;
            }

            public bool Contains(int value)
                => Mask[value - 1] > 0;
        }
    }
}