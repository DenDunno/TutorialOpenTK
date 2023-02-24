using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

public static class WindowSettings
{
    private static Window _window = null!;

    public static KeyboardState Keyboard => _window.KeyboardState;
    public static MouseState Mouse => _window.MouseState;
    public static Vector2 Size => _window.Size;
    
    public static void Setup(Window window)
    {
        _window = window;
    }
}