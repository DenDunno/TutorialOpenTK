using OpenTK.Graphics.OpenGL;

public class RenderingObject
{
    public readonly int ShaderProgramId;
    private int _vertexArrayId;
    private int _vertexBufferId;
    private int _indexBufferId;
    private readonly Mesh _mesh;

    public RenderingObject(Mesh mesh, string vertexShader, string fragmentShader)
    {
        _mesh = mesh;
        ShaderProgramId = ShaderProgram.Create(vertexShader, fragmentShader);
        BufferData();
    }
    
    private void BufferData()
    {
        _vertexArrayId = GL.GenVertexArray();
        GL.BindVertexArray(_vertexArrayId);

        _vertexBufferId = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferId);
        GL.BufferData(BufferTarget.ArrayBuffer, _mesh.Vertices.Count * sizeof(float), _mesh.Vertices.ToArray(), BufferUsageHint.StaticDraw);

        _indexBufferId = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ElementArrayBuffer, _indexBufferId);
        GL.BufferData(BufferTarget.ElementArrayBuffer, _mesh.Indices.Count * sizeof(uint), _mesh.Indices.ToArray(), BufferUsageHint.StaticDraw);

        foreach (VertexAttribute attribute in _mesh.Attributes)
        {
            GL.VertexAttribPointer(attribute.Index, attribute.Size, VertexAttribPointerType.Float, false, attribute.Stride, attribute.Offset);
            GL.EnableVertexAttribArray(attribute.Index);
        }
    }
    
    public void Draw()
    {
        GL.BindVertexArray(_vertexArrayId);
        GL.UseProgram(ShaderProgramId);
        GL.DrawElements(PrimitiveType.Triangles, _mesh.Indices.Count, DrawElementsType.UnsignedInt, 0);
    }
}