namespace GraphsTheory
{
    internal static class GraphsHelpers
    {
        public static int[][] ReadMatrixFromConsole()
        {
            var rowsCount = InputHelpers.ReadIntFromConsole();
            int[][] matrix = new int[rowsCount][];

            for (int i = 0; i < rowsCount; i++)
            {
                matrix[i] = InputHelpers.ReadIntsArrayFromConsole();
            }

            return matrix;
        }

        public static bool IsMatrixValid(int[][] matrix)
        {
            return matrix != null && matrix.Length != 0 && matrix[0].Length == matrix.Length;
        }


        public static GraphEdge ReadGraphEdgeFromConsole()
        {
            string input = Console.ReadLine()!;
            string[] splitted = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int count = splitted.Length;

            if (count == 0 || count > 2)
                throw new Exception($"Graph edge can only have 2 points (from and to) " +
                    $"or 1 if looped. Attempt to create with {count} points");

            int from = int.Parse(splitted[0]);
            int to = count == 1 ? from : int.Parse(splitted[1]);

            return new(from, to);
        }


        public static void PrintGraphMatrixToConsole(int[][] matrix, bool addTrailingSpaces)
        {
            if (!IsMatrixValid(matrix))
                return;

            int columnsCount = matrix[0].Length;

            foreach (var row in matrix)
            {
                for (int i = 0; i < columnsCount; i++)
                {
                    if (i > 0)
                        Console.Write(' ');

                    Console.Write(row[i]);
                }

                if (addTrailingSpaces)
                    Console.WriteLine(' ');
            }
        }


        public static int[][] CopyMatrix(int[][] origin)
        {
            var rowsCount = origin.Length;

            int[][] copy = new int[rowsCount][];

            for (int i = 0; i < rowsCount; i++)
            {
                var row = origin[i];
                var colsCount = row.Length;

                var copyRow = new int[colsCount];
                copy[i] = copyRow;

                for (int j = 0; j < colsCount; j++)
                {
                    copyRow[j] = row[j];
                }
            }

            return copy;
        }
    }
}
