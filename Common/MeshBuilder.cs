
public static class MeshBuilder
{
    public static Mesh Quad(float size)
    {
        return new Mesh()
        {
            Vertices =
            {
                size, size, 0,
                size, -size, 0,
                -size, -size, 0,
                -size, size, 0,
            },
            
            Indices =
            {
                0, 1, 2,
                2, 3, 0,
            }
        };
    }
}