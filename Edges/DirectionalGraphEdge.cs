namespace GraphsTheory.Edges
{
    public readonly struct DirectionalGraphEdge : IGraphEdge, IEquatable<DirectionalGraphEdge>, IComparable<DirectionalGraphEdge>
    {
        private readonly int _from;
        private readonly int _to;


        public DirectionalGraphEdge(int from, int to)
        {
            _from = from;
            _to = to;
        }


        public int From => _from;
        public int To => _to;


        public override bool Equals(object? obj)
        {
            return obj is DirectionalGraphEdge other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_from, _to);
        }

        public bool Equals(DirectionalGraphEdge other)
        {
            return other._from == _from && other._to == _to;
        }

        public static bool operator ==(DirectionalGraphEdge left, DirectionalGraphEdge right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(DirectionalGraphEdge left, DirectionalGraphEdge right)
        {
            return !(left == right);
        }

        public static bool operator <(DirectionalGraphEdge left, DirectionalGraphEdge right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(DirectionalGraphEdge left, DirectionalGraphEdge right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(DirectionalGraphEdge left, DirectionalGraphEdge right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(DirectionalGraphEdge left, DirectionalGraphEdge right)
        {
            return left.CompareTo(right) >= 0;
        }

        public int CompareTo(DirectionalGraphEdge other)
        {
            if (_from < other._from)
                return -1;

            if (_from > other._from)
                return 1;

            if (_to < other._to)
                return -1;

            if (_to > other._to)
                return 1;

            return 0;
        }

        public override string ToString()
        {
            return $"[{_from}, {_to}]";
        }

        public string ToStringSimple(bool indexToHumanOrder = false)
        {
            if (indexToHumanOrder)
                return $"{_from + 1} {_to + 1}";

            return $"{_from} {_to}";
        }
    }
}
