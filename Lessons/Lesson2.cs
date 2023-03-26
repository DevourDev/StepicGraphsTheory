using GraphsTheory.Edges;
using GraphsTheory.Helpers;

namespace GraphsTheory.Lessons
{
    internal class Lesson2
    {
        public static void Step8()
        {
            var matrix = GraphsHelpers.ReadMatrixFromConsole();

            int loopsCount = DetectLoopsCountInternal(matrix);

            Console.WriteLine(loopsCount.ToString());
        }

        private static int DetectLoopsCountInternal(int[][] matrix)
        {
            int loopsCount = 0;

            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                if (matrix[rowIndex][rowIndex] == 1)
                    ++loopsCount;
            }

            return loopsCount;
        }


        public static void Step9()
        {
            var matrix = GraphsHelpers.ReadMatrixFromConsole();

            var edgesCount = DetectEdgesCountInternal(matrix);

            Console.WriteLine(edgesCount.ToString());
        }

        private static int DetectEdgesCountInternal(int[][] matrix)
        {
            int edgesCount = 0;

            foreach (var row in matrix)
            {
                foreach (var cell in row)
                {
                    edgesCount += cell;
                }
            }

            return edgesCount;
        }


        public static void Step10()
        {
            var matrix = GraphsHelpers.ReadMatrixFromConsole();

            int[] nodePowers = GraphsHelpers.GetNodePowers(matrix);

            int evensCount = 0;
            int oddsCount = 0;

            foreach (var power in nodePowers)
            {
                if (power % 2 == 0)
                    ++evensCount;
                else
                    ++oddsCount;
            }

            Console.WriteLine($"{evensCount} {oddsCount}");
        }



        public static void Step11()
        {
            var matrix = GraphsHelpers.ReadMatrixFromConsole();

            var nodesWithoutInputs = GetNodesWithoutInputs(matrix);
            var nodesWithoutOutputs = GetNodesWithoutOutputs(matrix);

            Console.WriteLine($"{nodesWithoutInputs.Length} {nodesWithoutOutputs.Length}");
        }


        private static int[] GetNodesWithoutInputs(int[][] matrix)
        {
            if (!GraphsHelpers.IsMatrixValid(matrix))
                return Array.Empty<int>();

            int columnsCount = matrix[0].Length; //assuming matrix is square
            int rowsCount = columnsCount;

            Span<int> nodesWithoutInputs = rowsCount < 500 ? stackalloc int[columnsCount] : new int[columnsCount];
            int nodesWithoutInputsCount = 0;

            for (int columnIndex = 0; columnIndex < columnsCount; columnIndex++)
            {
                if (ColumnContainsOnly(matrix, columnIndex, rowsCount, 0))
                    nodesWithoutInputs[nodesWithoutInputsCount++] = columnIndex;
            }

            return nodesWithoutInputs[..nodesWithoutInputsCount].ToArray();
        }


        private static int[] GetNodesWithoutOutputs(int[][] matrix)
        {
            if (!GraphsHelpers.IsMatrixValid(matrix))
                return Array.Empty<int>();

            int rowsCount = matrix.Length;

            Span<int> nodesWithoutOutputs = rowsCount < 500 ? stackalloc int[rowsCount] : new int[rowsCount];
            int nodesWithoutOutputsCount = 0;

            for (int rowIndex = 0; rowIndex < rowsCount; rowIndex++)
            {
                var row = matrix[rowIndex];

                if (RowContainsOnly(row, 0))
                    nodesWithoutOutputs[nodesWithoutOutputsCount++] = rowIndex;
            }

            return nodesWithoutOutputs[..nodesWithoutOutputsCount].ToArray();
        }


        private static bool ColumnContainsOnly(int[][] matrix, int columnIndex, int rowsCount, int value)
        {
            for (int rowIndex = 0; rowIndex < rowsCount; rowIndex++)
            {
                if (matrix[rowIndex][columnIndex] != value)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool RowContainsAtleastOne(int[] row, int value)
        {
            foreach (var item in row)
            {
                if (item == value)
                    return true;
            }

            return false;
        }

        private static bool RowContainsOnly(int[] row, int value)
        {
            foreach (var item in row)
            {
                if (item != value)
                    return false;
            }

            return true;
        }


        public static void Step12()
        {
            var arr = InputHelpers.ReadIntsArrayFromConsole();
            int nodesCount = arr[0];
            int edgesCount = arr[1];

            UniversalGraphEdge[] edges = new UniversalGraphEdge[edgesCount];

            for (int i = 0; i < edgesCount; i++)
            {
                edges[i] = GraphsHelpers.ReadUniversalGraphEdgeFromConsole();
            }

            //number (1, 2, 3...) to index (0, 1, 2...)
            int targetEdgeIndex = InputHelpers.ReadIntFromConsole() - 1;

            var incidentalEdgesIndices = FindIncidentalEdges(edges, targetEdgeIndex);
            Console.WriteLine(incidentalEdgesIndices.Length);
        }


        private static int[] FindIncidentalEdges(UniversalGraphEdge[] allEdges, int originEdgeIndex)
        {
            int allEdgesCount = allEdges.Length;

            Span<int> incidentalEdgeIndices = allEdgesCount < 500
                ? stackalloc int[allEdgesCount]
                : new int[allEdgesCount];

            int incidentalEdgesCount = 0;

            UniversalGraphEdge originEdge = allEdges[originEdgeIndex];

            for (int i = 0; i < allEdgesCount; i++)
            {
                if (i == originEdgeIndex)
                    continue;


                if (originEdge.EqualAny(allEdges[i]))
                {
                    incidentalEdgeIndices[incidentalEdgesCount++] = i;
                }
            }

            return incidentalEdgeIndices[..incidentalEdgesCount].ToArray();
        }

        public static void Step13()
        {
            var originMatrix = GraphsHelpers.ReadMatrixFromConsole();

            var additionMatrix = ReverseGraphMatrix(originMatrix, true);

            GraphsHelpers.PrintGraphMatrixToConsole(additionMatrix, true);
        }


        private static int[][] ReverseGraphMatrix(int[][] originMatrix, bool ignoreSelfCells)
        {
            var copy = GraphsHelpers.CopyMatrix(originMatrix);

            int size = originMatrix.Length;

            for (int rowIndex = 0; rowIndex < size; rowIndex++)
            {
                var row = copy[rowIndex];

                for (int colIndex = 0; colIndex < size; colIndex++)
                {
                    if (ignoreSelfCells && rowIndex == colIndex)
                        continue;

                    row[colIndex] = ReverseMatrixValue(row[colIndex]);
                }
            }

            return copy;
        }


        private static int ReverseMatrixValue(int source)
        {
            return source == 0 ? 1 : 0;
        }

    }
}
