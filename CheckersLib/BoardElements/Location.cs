namespace CheckersLib.BoardElements
{
    public struct Location
    {
        public int X { get; internal set; }
        public int Y { get; internal set; }
        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static bool operator ==(Location first, Location second)
        {
            return first.X == second.X && first.Y == second.Y;
        }

        public static bool operator !=(Location first, Location second)
        {
            return first.X != second.X || first.Y != second.Y;
        }

        public override bool Equals(object obj)
        {
            return obj is Location location &&
                   X == location.X &&
                   Y == location.Y;
        }

        public override int GetHashCode()
        {
            int hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }
    }
}
