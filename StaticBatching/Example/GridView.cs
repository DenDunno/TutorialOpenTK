using OpenTK.Graphics.OpenGL;

public class GridView
{
    private readonly GridMeshGeneration _meshGeneration;

    public GridView(int elementsCount, float offset)
    {
        _meshGeneration = new GridMeshGeneration(elementsCount, offset);
    }

    public RenderingObject Build()
    {
        Mesh mesh = _meshGeneration.Build();
        RenderingObject renderingObject = new(mesh, "StaticBatching/vert", "StaticBatching/frag");

        int countIndex = GL.GetUniformLocation(renderingObject.ShaderProgramId, "colorsCount");
        int colorsIndex = GL.GetUniformLocation(renderingObject.ShaderProgramId, "colors");

        GL.UseProgram(renderingObject.ShaderProgramId);
        GL.Uniform1(countIndex, 6);
        GL.Uniform4(colorsIndex, 6, new float[]
        {
            255, 255, 0, 255, // yellow
            0, 255, 255, 255, // cyan
            255, 0, 255, 255, // purple
            255, 0, 0, 255,   // red
            0, 255, 0, 255,   // green
            0, 0, 255, 255,   // blue
        });

        return renderingObject;
    }
}