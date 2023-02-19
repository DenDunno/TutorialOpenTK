
public static class Paths
{
    private static readonly string _resourcesPath = Path.GetFullPath(@"..\..\..\..\Resources\");

    public static string GetShader(string shaderName)
    {
        return $"{_resourcesPath}/{shaderName}.glsl";
    }
}