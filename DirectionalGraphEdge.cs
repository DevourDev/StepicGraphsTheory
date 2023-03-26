namespace GraphsTheory
{
    public readonly struct DirectionalGraphEdge : IEquatable<DirectionalGraphEdge>, IComparable<DirectionalGraphEdge>
    {
        public readonly int From;
        public readonly int To;


        public DirectionalGraphEdge(int from, int to)
        {
            From = from;
            To = to;
        }

        public override bool Equals(object? obj)
        {
            return obj is DirectionalGraphEdge other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(From, To);
        }

        public bool Equals(DirectionalGraphEdge other)
        {
            return other.From == From && other.To == To;
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
    }
}
