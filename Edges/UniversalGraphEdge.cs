namespace GraphsTheory.Edges
{
    public readonly struct UniversalGraphEdge : IGraphEdge, IEquatable<UniversalGraphEdge>, IComparable<UniversalGraphEdge>
    {
        private readonly int _from;
        private readonly int _to;


        public UniversalGraphEdge(int from, int to)
        {
            _from = from;
            _to = to;
        }


        public int From => _from;
        public int To => _to;


        public bool EqualFrom(UniversalGraphEdge other) => other._from == _from;

        public bool EqualTo(UniversalGraphEdge other) => other._to == _to;

        public bool EqualAny(UniversalGraphEdge other)
            => other._from == _from || other._to == _to
            || other._from == _to || other._to == _from;

        public bool EqualNonDirectional(UniversalGraphEdge other)
            => other._from == _from && other._to == _to
            || other._from == _to && other._to == _from;


        public static implicit operator (int a, int b)(UniversalGraphEdge value)
        {
            return (value._from, value._to);
        }

        public static implicit operator UniversalGraphEdge((int a, int b) value)
        {
            return new UniversalGraphEdge(value.a, value.b);
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

        public bool Equals(UniversalGraphEdge other)
        {
            return other._from == _from && other._to == _to;
        }

        public override bool Equals(object? obj)
        {
            return obj is UniversalGraphEdge edge && Equals(edge);
        }

        public int CompareTo(UniversalGraphEdge other)
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

        public override int GetHashCode()
        {
            return HashCode.Combine(_from, _to);
        }

        public int GetNonDirHashCode()
        {
            if (_from > _to)
                return HashCode.Combine(_to, _from);

            return HashCode.Combine(_from, _to); //to prevent GetHashCode() sealing
        }

        public DirectionalGraphEdge ToDirectional()
        {
            return new DirectionalGraphEdge(_from, _to);
        }

        public NonDirectionalGraphEdge ToNonDirectional()
        {
            return new NonDirectionalGraphEdge(_from, _to);
        }

        public static bool operator ==(UniversalGraphEdge left, UniversalGraphEdge right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(UniversalGraphEdge left, UniversalGraphEdge right)
        {
            return !(left == right);
        }

        public static bool operator <(UniversalGraphEdge left, UniversalGraphEdge right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(UniversalGraphEdge left, UniversalGraphEdge right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(UniversalGraphEdge left, UniversalGraphEdge right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(UniversalGraphEdge left, UniversalGraphEdge right)
        {
            return left.CompareTo(right) >= 0;
        }
    }
}
