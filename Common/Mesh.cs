
public class Mesh
{
    public ResizableArray<float> Vertices { get; init; } = new();
    public ResizableArray<uint> Indices { get; init; } = new();
    public List<VertexAttribute> Attributes { get; init; } = new();
}