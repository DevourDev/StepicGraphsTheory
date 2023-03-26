namespace GraphsTheory
{
    public readonly struct UniversalGraphEdge : IEquatable<UniversalGraphEdge>, IComparable<UniversalGraphEdge>
    {
        public readonly int From;
        public readonly int To;


        public UniversalGraphEdge(int from, int to)
        {
            From = from;
            To = to;
        }


        public bool EqualFrom(UniversalGraphEdge other) => other.From == From;

        public bool EqualTo(UniversalGraphEdge other) => other.To == To;

        public bool EqualAny(UniversalGraphEdge other)
            => other.From == From || other.To == To
            || other.From == To || other.To == From;

        public bool EqualNonDirectional(UniversalGraphEdge other)
            => (other.From == From && other.To == To)
            || (other.From == To && other.To == From);


        public static implicit operator (int a, int b)(UniversalGraphEdge value)
        {
            return (value.From, value.To);
        }

        public static implicit operator UniversalGraphEdge((int a, int b) value)
        {
            return new UniversalGraphEdge(value.a, value.b);
        }


        public override string ToString()
        {
            return $"[{From}, {To}]";
        }

        public string ToStringSimple(bool indexToHumanOrder = false)
        {
            if (indexToHumanOrder)
                return $"{From + 1} {To + 1}";

            return $"{From} {To}";
        }

        public bool Equals(UniversalGraphEdge other)
        {
            return other.From == From && other.To == To;
        }

        public override bool Equals(object? obj)
        {
            return obj is UniversalGraphEdge edge && Equals(edge);
        }

        public int CompareTo(UniversalGraphEdge other)
        {
            if (From < other.From)
                return -1;

            if (From > other.From)
                return 1;

            if (To < other.To)
                return -1;

            if (To > other.To)
                return 1;

            return 0;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(From, To);
        }

        public int GetNonDirHashCode()
        {
            if (From > To)
                return HashCode.Combine(To, From);

            return HashCode.Combine(From, To); //to prevent GetHashCode() sealing
        }

        public DirectionalGraphEdge ToDirectional()
        {
            return new DirectionalGraphEdge(From, To);
        }

        public NonDirectionalGraphEdge ToNonDirectional()
        {
            return new NonDirectionalGraphEdge(From, To);
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
