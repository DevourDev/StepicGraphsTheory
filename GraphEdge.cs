namespace GraphsTheory
{
    internal readonly struct GraphEdge
    {
        public readonly int From;
        public readonly int To;


        public GraphEdge(int from, int to)
        {
            From = from;
            To = to;
        }


        public bool EqualFrom(GraphEdge other) => other.From == From;

        public bool EqualTo(GraphEdge other) => other.To == To;

        public bool EqualAny(GraphEdge other)
            => other.From == From || other.To == To
            || other.From == To || other.To == From;



        public static implicit operator (int a, int b)(GraphEdge value)
        {
            return (value.From, value.To);
        }

        public static implicit operator GraphEdge((int a, int b) value)
        {
            return new GraphEdge(value.a, value.b);
        }
    }
}
