internal class Direction
{
    public static readonly Direction Up = new Direction(0, +1);
    public static readonly Direction Down = new Direction(0, -1);
    public static readonly Direction Right = new Direction(+1, 0);
    public static readonly Direction Left = new Direction(-1, 0);

    static Direction()
    {
        Up.Perpendicular = Left;
        Down.Perpendicular = Right;
        Right.Perpendicular = Up;
        Left.Perpendicular = Down;

        Up.Opposite = Down;
        Down.Opposite = Up;
        Right.Opposite = Left;
        Left.Opposite = Right;
    }

    public readonly int X;
    public readonly int Y;
    public Direction Perpendicular { get; private set; }
    public Direction Opposite { get; private set; }
    private Direction(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    public void Move(ref int x, ref int y, int count)
    {
        x += this.X * count;
        y += this.Y * count;
    }

    public void MoveOne(ref int x, ref int y) => Move(ref x, ref y, 1);
}