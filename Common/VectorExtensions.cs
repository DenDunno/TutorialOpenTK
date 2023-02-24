using OpenTK.Mathematics;

public static class VectorExtensions
{
    public static bool InRange2D(this Vector2 target, Vector3 min, Vector3 max)
    {
        return target.X >= min.X && target.X <= max.X &&
               target.Y >= min.Y && target.Y <= max.Y;
    }
}