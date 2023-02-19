using OpenTK.Graphics.OpenGL;

public static class ShaderProgram
{
    public static int Create(string vertexShader, string fragmentShader)
    {
        int id = GL.CreateProgram();
    
        int[] shaders = 
        {
            AttachShader(id, Paths.GetShader(fragmentShader), ShaderType.FragmentShader),
            AttachShader(id, Paths.GetShader(vertexShader), ShaderType.VertexShader),
        };
    
        GL.LinkProgram(id);
    
        foreach (int shaderId in shaders)
        {
            GL.DetachShader(id, shaderId);
            GL.DeleteShader(shaderId);
        }

        return id;
    }

    private static int AttachShader(int shaderProgram, string filename, ShaderType type)
    {
        int shaderId = GL.CreateShader(type);
        using StreamReader streamReader = new(filename);
    
        GL.ShaderSource(shaderId, streamReader.ReadToEnd());
        GL.CompileShader(shaderId);
        GL.GetShader(shaderId, ShaderParameter.CompileStatus, out int status);

        if (status == 0)
        {
            throw new Exception($"Error compiling shader: {GL.GetShaderInfoLog(shaderId)}");
        }
    
        GL.AttachShader(shaderProgram, shaderId);

        return shaderId;
    }
}