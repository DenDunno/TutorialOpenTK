
public static class Tutorial
{
    public static void RunExample(IExample example)
    {
        Window window = new();
        
        window.Load += example.Initialize;
        window.UpdateFrame += example.Update;
        window.RenderFrame += example.Render;
        
        window.Run();
    }
}