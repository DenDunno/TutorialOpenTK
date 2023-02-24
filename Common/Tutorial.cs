
public static class Tutorial
{
    public static void RunExample(IExample example)
    {
        Window window = new();
        WindowSettings.Setup(window);
        
        window.Load += example.Initialize;
        window.UpdateFrame += example.Update;
        window.RenderFrame += example.Render;
        
        window.Run();
    }
}