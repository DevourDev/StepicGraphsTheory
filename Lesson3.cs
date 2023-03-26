using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsTheory
{
    internal class Lesson3
    {
        public static void Step1()
        {
            int[] buffer = new int[128];

            int count = InputHelpers.ReadIntsArrayFromConsoleNonAlloc(buffer);

            if (count != 2)
                throw new Exception($"{nameof(count)}: {count}");

            int n = buffer[0]; //nodes count
            int m = buffer[1]; //edges count

            UniversalGraphEdge[] edges = new UniversalGraphEdge[m];

            for (int i = 0; i < m; i++)
            {
                edges[i] = GraphsHelpers.ReadGraphEdgeFromConsole(true);
            }

            for (int i = 0; i < m; i++)
            {
                Console.WriteLine(edges[i]);
            }

            Array.Sort(edges);

            Console.WriteLine("==========");

            for (int i = 0; i < m; i++)
            {
                Console.WriteLine(edges[i]);
            }

            int[] indices = new int[n];
            Array.Fill(indices, -1);

            for (int i = 0; i < m; i++)
            {
                int v = edges[i].From;

                if (indices[v] < 0)
                    indices[v] = i;
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"[{indices[i]}]: {edges[i]}");
            }
        }


        public static void Step4()
        {
            var matrix = GraphsHelpers.ReadMatrixFromConsole();
            var edges = GraphsHelpers.MatrixToNonDirEdges(matrix);

            foreach (var edge in edges)
            {
                Console.WriteLine(edge.ToStringSimple(true));
            }
        }
    }
}
