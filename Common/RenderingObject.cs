using OpenTK.Graphics.OpenGL;

public class RenderingObject
{
    public readonly int ShaderProgramId;
    private readonly int _vertexArrayId;
    private readonly int _vertexBufferId;
    private readonly int _indexBufferId;
    private int _indicesCount;
    
    public RenderingObject(string vertexShader, string fragmentShader) : this(ShaderProgram.Create(vertexShader, fragmentShader))
    {
    }

    private RenderingObject(int shaderProgramId)
    {
        ShaderProgramId = shaderProgramId;
        _vertexArrayId = GL.GenVertexArray();
        _vertexBufferId = GL.GenBuffer();
        _indexBufferId = GL.GenBuffer();
    }

    public void BufferData(Mesh mesh, BufferUsageHint usageHint = BufferUsageHint.StaticDraw)
    {
        _indicesCount = mesh.Indices.Count;
        
        GL.BindVertexArray(_vertexArrayId);
        
        GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferId);
        GL.BufferData(BufferTarget.ArrayBuffer, mesh.Vertices.Count * sizeof(float), mesh.Vertices.Items, usageHint);

        GL.BindBuffer(BufferTarget.ElementArrayBuffer, _indexBufferId);
        GL.BufferData(BufferTarget.ElementArrayBuffer, mesh.Indices.Count * sizeof(uint), mesh.Indices.Items, usageHint);

        foreach (VertexAttribute attribute in mesh.Attributes)
        {
            GL.VertexAttribPointer(attribute.Index, attribute.Size, VertexAttribPointerType.Float, false, attribute.Stride, attribute.Offset);
            GL.EnableVertexAttribArray(attribute.Index);
        }
    }

    public void Draw()
    {
        GL.BindVertexArray(_vertexArrayId);
        GL.UseProgram(ShaderProgramId);
        GL.DrawElements(PrimitiveType.Triangles, _indicesCount, DrawElementsType.UnsignedInt, 0);
    }
}