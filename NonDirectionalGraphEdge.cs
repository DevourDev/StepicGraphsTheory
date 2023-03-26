namespace GraphsTheory
{
    public readonly struct NonDirectionalGraphEdge : IEquatable<NonDirectionalGraphEdge>, IComparable<NonDirectionalGraphEdge>
    {
        public readonly int From;
        public readonly int To;


        public NonDirectionalGraphEdge(int from, int to)
        {
            From = from;
            To = to;
        }

        public override bool Equals(object? obj)
        {
            return obj is NonDirectionalGraphEdge other && Equals(other);
        }

        public bool Equals(NonDirectionalGraphEdge other)
            => (other.From == From && other.To == To)
            || (other.From == To && other.To == From);


        public static bool operator ==(NonDirectionalGraphEdge left, NonDirectionalGraphEdge right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(NonDirectionalGraphEdge left, NonDirectionalGraphEdge right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            if (From > To)
                return HashCode.Combine(To, From);

            return HashCode.Combine(From, To);
        }

        public int CompareTo(NonDirectionalGraphEdge other)
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


        public static explicit operator DirectionalGraphEdge(NonDirectionalGraphEdge nonDir)
        {
            return new DirectionalGraphEdge(nonDir.From, nonDir.To);
        }

        public static explicit operator NonDirectionalGraphEdge(DirectionalGraphEdge dir)
        {
            return new NonDirectionalGraphEdge(dir.From, dir.To);
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

        public static bool operator <(NonDirectionalGraphEdge left, NonDirectionalGraphEdge right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(NonDirectionalGraphEdge left, NonDirectionalGraphEdge right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(NonDirectionalGraphEdge left, NonDirectionalGraphEdge right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(NonDirectionalGraphEdge left, NonDirectionalGraphEdge right)
        {
            return left.CompareTo(right) >= 0;
        }
    }
}
