using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphsTheory.Edges;
using GraphsTheory.Helpers;

namespace GraphsTheory.Lessons
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
                edges[i] = GraphsHelpers.ReadUniversalGraphEdgeFromConsole(true);
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


        public static void Step5()
        {
            var nmSpan = InputHelpers.ReadIntsFromConsole().Span;
            int nodesCount = nmSpan[0];
            int edgesCount = nmSpan[1];

            IGraphEdge[] edges = new IGraphEdge[edgesCount];

            for (int i = 0; i < edgesCount; i++)
            {
                edges[i] = GraphsHelpers.ReadUniversalGraphEdgeFromConsole();
            }

            var powers = GraphsHelpers.GetNodePowers(edges, nodesCount, true);
            HashSet<int> differentPowersHs = new(nodesCount);

            foreach (var power in powers)
            {
                _ = differentPowersHs.Add(power);
            }

            Console.WriteLine(differentPowersHs.Count);
        }
    }
}
