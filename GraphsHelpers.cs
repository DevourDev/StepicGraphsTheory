﻿namespace GraphsTheory
{
    internal static class GraphsHelpers
    {
        private const int _bufferSize = 1024;

        private static readonly UniversalGraphEdge[] _universalEdgesBuffer = new UniversalGraphEdge[_bufferSize];
        private static readonly DirectionalGraphEdge[] _dirEdgesBuffer = new DirectionalGraphEdge[_bufferSize];
        private static readonly NonDirectionalGraphEdge[] _nonDirEdgesBuffer = new NonDirectionalGraphEdge[_bufferSize];

        private static readonly HashSet<NonDirectionalGraphEdge> _nonDirEdgesHashBuffer = new(_bufferSize);


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


        public static NonDirectionalGraphEdge[] MatrixToNonDirEdges(int[][] matrix)
        {
            if (!IsMatrixValid(matrix))
                return Array.Empty<NonDirectionalGraphEdge>();

            int size = matrix[0].Length;
            var bufferHS = _nonDirEdgesHashBuffer;

            for (int rowIndex = 0; rowIndex < size; rowIndex++)
            {
                var row = matrix[rowIndex];

                for (int colIndex = 0; colIndex < size; colIndex++)
                {
                    var col = row[colIndex];

                    if (col == 1)
                        _ = bufferHS.Add(new NonDirectionalGraphEdge(rowIndex, colIndex));
                }
            }

            var arr = bufferHS.ToArray();
            bufferHS.Clear();
            return arr;
        }


        public static UniversalGraphEdge ReadGraphEdgeFromConsole(bool toIndex = false)
        {
            string input = Console.ReadLine()!;
            string[] splitted = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int count = splitted.Length;

            if (count == 0 || count > 2)
                throw new Exception($"Graph edge can only have 2 points (from and to) " +
                    $"or 1 if looped. Attempt to create with {count} points");

            int from = int.Parse(splitted[0]);
            int to = count == 1 ? from : int.Parse(splitted[1]);

            if (toIndex)
            {
                --from;
                --to;
            }

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
