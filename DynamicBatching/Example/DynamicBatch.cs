using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class DynamicBatch
{
    private readonly Mesh _overallMesh = new();
    private readonly RenderingObject _overallView;
    
    public DynamicBatch(string vertShaderPath, string fragShaderPath)
    {
        _overallView = new RenderingObject(vertShaderPath, fragShaderPath);
    }

    public void Clear()
    {
        _overallMesh.Indices.Clear();
        _overallMesh.Vertices.Clear();
        _overallMesh.Attributes.Clear();
    }

    public void Add(Mesh mesh, Transform transform)
    {
        int stride = mesh.Attributes[0].Stride / sizeof(float);
        
        TryAddAttributes(mesh.Attributes);
        AddIndices(mesh.Indices, stride);
        AddVertices(mesh.Vertices, transform, stride);
    }

    private void TryAddAttributes(List<VertexAttribute> attributes)
    {
        if (_overallMesh.Attributes.Count == 0)
        {
            _overallMesh.Attributes.AddRange(attributes);
        }
    }

    private void AddIndices(ResizableArray<uint> indices, int stride)
    {
        uint verticesCount = (uint)(_overallMesh.Vertices.Count / stride);

        for (int i = 0; i < indices.Count; ++i)
        {
            _overallMesh.Indices.Add(verticesCount + indices[i]);
        }
    }

    private void AddVertices(ResizableArray<float> vertices, Transform transform, int stride)
    {
        int verticesOverall = _overallMesh.Vertices.Count;
        Matrix4 modelMatrix = transform.ModelMatrix;

        for (int i = 0; i < vertices.Count; ++i)
        {
            _overallMesh.Vertices.Add(vertices[i]);
        }

        for (int i = 0; i < vertices.Count; i += stride)
        {
            Vector4 position = new(vertices[i], vertices[i + 1], 0, 1);
            Vector2 worldPosition = (position * modelMatrix).Xy;

            _overallMesh.Vertices[verticesOverall + i + 0] = worldPosition.X;
            _overallMesh.Vertices[verticesOverall + i + 1] = worldPosition.Y;
        }
    }

    public void Draw()
    {
        _overallView.BufferData(_overallMesh, BufferUsageHint.DynamicDraw);
        _overallView.Draw();
    }
}