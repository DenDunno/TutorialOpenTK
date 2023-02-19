
public class VertexAttribute
{
    public readonly int Index;
    public readonly int Size;
    public readonly int Stride;
    public readonly int Offset;

    public VertexAttribute(int index, int size, int stride, int offset)
    {
        Index = index;
        Size = size;
        Stride = stride;
        Offset = offset;
    }
}