public struct Coordinate
{
  
    public int X { get; set; }

    public int Y { get; set; }
    
    public Coordinate(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    public static bool operator ==(Coordinate first, Coordinate second)
    {
        return first.X == second.Y && first.Y == second.Y;
    }
    public static bool operator !=(Coordinate first, Coordinate second)
    {
        return first.X != second.Y || first.Y != second.Y;
    }
    public static Coordinate operator -(Coordinate x, Coordinate y)
    {
        return new Coordinate(x.X - y.X, x.Y - y.Y);
    }

}
